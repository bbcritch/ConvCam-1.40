Imports System.IO
Imports System.IO.Compression
Imports System.IO.File
Imports System.Text
Public Class Zipper

    Dim Header As String
    Dim idx As Integer = 0
    Dim fileBuffer() As Byte
    Dim tempFile As String

    Public zipFile As String
    Public sParentDir As String
    Public Function ZipFiles(ByVal ParentSource As String, ByVal ZipFilePath As String, Optional ByVal Key As String = "") As Boolean

        Dim f As New fileManager
        Dim c As New convCamPaths

        idx = 0

        sParentDir = ParentSource
        zipFile = ZipFilePath
        tempFile = c.Path(sParentDir, "PAKFILE")

        f.fileDelete(tempFile)

        MakeSingleFile(sParentDir)
        addHeader(Key)
        CompressAndSaveFile()

    End Function
    Private Sub MakeSingleFile(ByVal ParentDir As String)

        Dim f As New fileManager
        Dim dirsNfiles As String
        Dim tList As New myList
        Dim x As New myXmlUtils
        Dim fileBytes() As Byte
        Dim c As New convCamPaths
        Dim filePath As String

        dirsNfiles = f.getDirectories(ParentDir, "F")

        tList.setList(dirsNfiles)

        ' copy each file to fileBytes, add file info to Header
        For i = 0 To tList.length(DL) - 1
            filePath = c.Path(ParentDir, tList.getItem(i, DL))
            fileBytes = System.IO.File.ReadAllBytes(filePath)
            AddToHeader(filePath, fileBytes.Length)
            ConcatFileBytes(fileBytes)
        Next

        ' Recursively drill down inside sub-directories.
        dirsNfiles = f.getDirectories(ParentDir, "D")
        tList.setList(dirsNfiles)

        For i = 0 To tList.length(DL) - 1
            MakeSingleFile(c.Path(ParentDir, tList.getItem(i, DL)))
        Next

    End Sub

    Private Sub AddToHeader(ByVal filePath As String, ByVal fileLength As Integer)
        Dim s As String = ""
        Dim x As New myXmlUtils

        Dim sAry() As String = filePath.Split("\")
        Dim LastDir = sAry(sAry.Length - 2)

        filePath = filePath.Substring(sParentDir.Length + 1)

        s = x.add(filePath, "PATH")
        s = appendString(s, x.add(fileLength.ToString, "SIZE"), vbLf)
        Header = appendString(Header, x.add(vbLf & s & vbLf, "FILE_" & idx.ToString), vbLf)
        idx = idx + 1

    End Sub
    Private Sub addHeader(Optional ByVal Key As String = "")

        Dim f As New fileManager
        Dim bytes() As Byte
        Dim wfile As System.IO.FileStream
        Dim x As New myXmlUtils
        Dim newHeader As String = x.add(vbLf & Header & vbLf, "HEADER")

        Dim tempFile1 As String = tempFile & "1"
        Dim tempFile2 As String = tempFile & "2"

        If Key <> "" Then
            newHeader = Key & vbLf & newHeader
        End If

        ' Convert Header to bytes() via tempFile1
        f.fileWrite(tempFile1, newHeader)
        bytes = System.IO.File.ReadAllBytes(tempFile1)
        f.fileDelete(tempFile1)

        ' Write header bytes to tempFile
        wfile = New FileStream(tempFile, FileMode.Create)
        wfile.Write(bytes, 0, bytes.Length)
        wfile.Close()

        ' Append file bytes to header in tempFile
        bytes = System.IO.File.ReadAllBytes(tempFile2)
        wfile = New FileStream(tempFile, FileMode.Append)
        wfile.Write(bytes, 0, bytes.Length)
        wfile.Close()

        f.fileDelete(tempFile1)
        f.fileDelete(tempFile2)

    End Sub
    Private Sub ConcatFileBytes(ByRef fileBytes() As Byte)

        Dim tempFile2 As String = tempFile & "2"

        Dim wfile As System.IO.FileStream
        wfile = New FileStream(tempFile2, FileMode.Append)
        wfile.Write(fileBytes, 0, fileBytes.Length)
        wfile.Close()

    End Sub
    Private Sub CompressAndSaveFile()

        Dim f As New fileManager
        Dim bytes() As Byte
        Dim wfile As System.IO.FileStream

        If f.filePresent(zipFile) Then f.fileDelete(zipFile)

        Dim memoryStream As New MemoryStream()
        Dim gZipStream As New GZipStream(memoryStream, CompressionMode.Compress, True)

        bytes = System.IO.File.ReadAllBytes(tempFile)
        gZipStream.Write(bytes, 0, bytes.Length)
        gZipStream.Dispose()
        memoryStream.Position = 0

        Dim buffer(memoryStream.Length) As Byte
        memoryStream.Read(buffer, 0, buffer.Length)

        memoryStream.Dispose()

        wfile = New FileStream(zipFile, FileMode.Append)
        wfile.Write(buffer, 0, buffer.Length)
        wfile.Close()

    End Sub
    Public Function UnZipFiles(ByVal ParentDest As String, ByVal ZipFilePath As String) As Boolean

        Dim c As New convCamPaths
        Dim f As New fileManager

        sParentDir = ParentDest
        zipFile = ZipFilePath

        f.makeDirectory(sParentDir)
        tempFile = c.Path(sParentDir, "PAKFILE")

        Try
            'Create a MemoryStream from the file bytes
            Dim stream As New MemoryStream(File.ReadAllBytes(ZipFilePath))

            'Create a new GZipStream from the MemoryStream
            Dim gZip As New GZipStream(stream, CompressionMode.Decompress)

            'Byte array to hold bytes
            Dim buffer(3) As Byte

            'Read the stream
            stream.Position = stream.Length - 5
            stream.Read(buffer, 0, 4)

            'Calculate the size of the decompressed bytes
            Dim size As Integer = BitConverter.ToInt32(buffer, 0)

            'Start at the beginning of the stream
            stream.Position = 0

            Dim decompressed(size - 1) As Byte

            'Read decompressed bytes into byte array
            gZip.Read(decompressed, 0, size)

            'Close & clean up
            gZip.Dispose()
            stream.Dispose()

            'Write the final file
            File.WriteAllBytes(tempFile, decompressed)

            UnPackFiles()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Return False
        End Try
    End Function
    Public Sub UnPackFiles()

        Dim f As New fileManager
        Dim sHeader As String
        Dim filePos As Integer
        Dim x As New myXmlUtils
        Dim idx = 0

        Dim filePath As String
        Dim fileSize As String
        Dim wfile As System.IO.FileStream
        Dim c As New convCamPaths


        sHeader = f.fileRead(tempFile)

        MakeAllDirs(x.extract(sHeader, "DIRS"))

        filePos = sHeader.IndexOf("</HEADER>") + 9

        sHeader = x.extract(sHeader, "HEADER")

        Dim sFileInfo As String = x.extract(sHeader, "FILE_" & idx.ToString)
        Dim bytes() As Byte = System.IO.File.ReadAllBytes(tempFile)
        Dim sPath As String

        While sFileInfo <> ""

            filePath = x.extract(sFileInfo, "PATH")
            fileSize = Convert.ToInt32(x.extract(sFileInfo, "SIZE"))

            sPath = c.Path(sParentDir, filePath)
            MakeDirs(sPath)

            wfile = New FileStream(sPath, FileMode.Create)
            wfile.Write(bytes, filePos + 2, fileSize)
            wfile.Close()

            filePos = filePos + fileSize
            idx = idx + 1
            sFileInfo = x.extract(sHeader, "FILE_" & idx.ToString)

        End While

        wfile.Dispose()

    End Sub

    Private Sub MakeDirs(ByVal sPath As String)

        Dim sAry() As String = sPath.Split("\")
        Dim sFullPath As String = sAry(0)
        Dim c As New convCamPaths
        Dim f As New fileManager

        For i = 1 To sAry.Length - 2
            sFullPath = c.Path(sFullPath, sAry(i))
            f.makeDirectory(sFullPath)
        Next

    End Sub
    Private Sub MakeAllDirs(ByVal dirList)

        Dim dAry() As String = dirList.split(vbLf)
        Dim f As New fileManager
        Dim c As New convCamPaths

        For i = 0 To dAry.Length - 1
            f.makeDirectory(c.Path(c.basePath, dAry(i)))
        Next

    End Sub
    Public Function GetFileKey(ByVal ParentDest As String, ByVal ZipFilePath As String) As String
        Dim c As New convCamPaths
        Dim f As New fileManager

        sParentDir = ParentDest
        zipFile = ZipFilePath

        f.makeDirectory(sParentDir)
        tempFile = c.Path(sParentDir, "PAKFILE")

        Try
            'Create a MemoryStream from the file bytes
            Dim stream As New MemoryStream(File.ReadAllBytes(ZipFilePath))

            'Create a new GZipStream from the MemoryStream
            Dim gZip As New GZipStream(stream, CompressionMode.Decompress)

            'Byte array to hold bytes
            Dim buffer(3) As Byte

            'Read the stream
            stream.Position = stream.Length - 5
            stream.Read(buffer, 0, 4)

            'Calculate the size of the decompressed bytes
            Dim size As Integer = BitConverter.ToInt32(buffer, 0)

            'Start at the beginning of the stream
            stream.Position = 0

            Dim decompressed(size - 1) As Byte

            'Read decompressed bytes into byte array
            gZip.Read(decompressed, 0, size)

            'Close & clean up
            gZip.Dispose()
            stream.Dispose()

            'Write the final file
            File.WriteAllBytes(tempFile, decompressed)

            Dim key As String = f.fileRead(tempFile)
            Dim x As New myXmlUtils

            Return x.extract(key, "KEY")

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Return "NO KEY"
        End Try
    End Function
End Class
