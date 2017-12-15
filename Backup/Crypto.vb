Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class Crypto

    Public Function Decrypt(ByVal data As String, ByVal sKey As String, ByVal sVector As String) As String
        Try
            Dim inBytes() As Byte = Convert.FromBase64String(data)
            Dim mStream As New MemoryStream(inBytes, 0, inBytes.Length) ' instead of writing the decrypted text
            Dim utf8 As New UTF8Encoding
            Dim kBytes() As Byte

            Dim aes As New TripleDESCryptoServiceProvider()
            Dim cs As New CryptoStream(mStream, aes.CreateDecryptor(utf8.GetBytes(sKey), utf8.GetBytes(sVector)), CryptoStreamMode.Read)

            Dim sr As New StreamReader(cs)

            kBytes = CreateKeyPool()

            Return sr.ReadToEnd()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Encrypt(ByVal data As String, ByVal sKey As String, ByVal sVector As String) As String
        Try
            Dim utf8 As New UTF8Encoding
            Dim inBytes() As Byte = utf8.GetBytes(data)
            Dim ms As New MemoryStream() 'instead of writing the encrypted
            'string to a filestream, I will use a memorystream

            Dim aes As New TripleDESCryptoServiceProvider()
            Dim cs As New CryptoStream(ms, aes.CreateEncryptor(utf8.GetBytes(sKey), utf8.GetBytes(sVector)), CryptoStreamMode.Write)

            cs.Write(inBytes, 0, inBytes.Length) ' encrypt
            cs.FlushFinalBlock()

            Return Convert.ToBase64String(ms.GetBuffer(), 0, ms.Length)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function CreateKeyPool() As Byte()

        Dim randPoolSource As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+/"
        Dim randObj As New Random
        Dim poolSize As Integer = 64 + Int(randObj.NextDouble * 32)
        Dim randPool As String = ""
        Dim utf8 As New UTF8Encoding

        Dim rBytes(poolSize - 1) As Byte

        Dim idx As Integer

        Dim sourceSize = randPoolSource.Length - 1

        For i = 0 To poolSize - 1
            idx = Int(randObj.NextDouble * (sourceSize - 1))
            randPool = randPool & randPoolSource.Substring(idx, 1)
        Next

        rBytes = utf8.GetBytes(randPool)

        rBytes(0) = poolSize - 2

        CreateKeyPool = rBytes

    End Function
    Public Function GetKey(ByVal keyPool() As Byte) As String

        Dim poolSize As Integer = keyPool(0)
        Dim poolStep As Integer = keyPool(1) And 31
        Dim startInc As Integer = 2
        Dim idx As Integer
        Dim kByte(0 To 15) As Byte
        Dim utf8 As New UTF8Encoding

        idx = startInc


        If poolStep = 0 Then poolStep = 1

        For i = 0 To 15
            kByte(i) = keyPool(idx)
            idx = idx + poolStep
            If idx > poolSize - 1 Then
                startInc = startInc + 1
                idx = startInc
            End If
        Next

        GetKey = utf8.GetString(kByte)

    End Function
    Public Function EncryptForSave(ByVal sString) As String

        Dim keyPool() As Byte
        Dim keyString As String
        Dim utf8 As New UTF8Encoding
        Dim forSave As String = "<CONVCAM>  " & vbLf

        keyPool = CreateKeyPool()
        keyString = GetKey(keyPool)

        EncryptForSave = "<CONVCAM PROPRIETARY>  " & vbLf & utf8.GetString(keyPool) & Encrypt(sString, keyString, keyString)

    End Function
    Public Function DecryptFromRead(ByVal sString As String) As String

        Dim keyString As String
        Dim utf8 As New UTF8Encoding

        sString = sString.Substring(24)
        Dim keyPool() As Byte = utf8.GetBytes(sString)
        keyString = GetKey(keyPool)

        sString = sString.Substring(keyPool(0) + 2)
        DecryptFromRead = Decrypt(sString, keyString, keyString)

    End Function

End Class
