Imports System.IO
Public Class fileManager
    Public Sub fileWrite(ByVal fname As String, ByVal fileText As String)

        Dim fso, a, b

        fso = CreateObject("Scripting.FileSystemObject")

        If fso.fileexists(fname) = True Then
            b = fso.GetFile(fname)
            b.DELETE()
        End If

        a = fso.CreateTextFile(fname, True)
        a.writeline(fileText.Trim(TRIMS))
        a.Close()

    End Sub
    Public Function fileRead(ByVal fname As String) As String

        If Not filePresent(fname) Then
            fileRead = ""
            Exit Function
        Else
            Dim fs As New FileStream(fname, FileMode.Open, FileAccess.Read)
            Dim s As New StreamReader(fs)
            'creating a new StreamWriter and passing the filestream object fs as argument

            fileRead = s.ReadToEnd().Trim(TRIMS)
            s.Close()
        End If

    End Function
    Public Sub fileDelete(ByVal fname As String)

        If System.IO.File.Exists(fname) = True Then

            System.IO.File.Delete(fname)

        End If

    End Sub
    Public Function filePresent(ByVal fname As String) As Boolean

        filePresent = System.IO.File.Exists(fname)

    End Function
    Public Function dirPresent(ByVal dirPath) As Boolean
        dirPresent = System.IO.Directory.Exists(dirPath)
    End Function
    Public Function getDirectories(ByVal dirPath As String, Optional ByVal filter As String = "BOTH") As String

        Dim s As String = ""
        Dim dDir As New DirectoryInfo(dirPath)
        Dim fFileSystemInfo As FileSystemInfo

        Try
            For Each fFileSystemInfo In dDir.GetFileSystemInfos()

                Select Case filter
                    Case "BOTH", "B"
                        s = appendString(s, fFileSystemInfo.Name, DL)
                    Case "DIRS", "D"
                        If fFileSystemInfo.Attributes = FileAttributes.Directory Then
                            s = appendString(s, fFileSystemInfo.Name, DL)
                        End If
                    Case "FILES", "F"
                        If fFileSystemInfo.Attributes = FileAttributes.Archive Then
                            s = appendString(s, fFileSystemInfo.Name, DL)
                        End If
                End Select

            Next
        Catch
        End Try

        getDirectories = s

    End Function
    Public Sub makeDirectory(ByVal dirName As String)

        Try
            Directory.CreateDirectory(dirName)
        Catch
        End Try

    End Sub
    Public Sub directoryDelete(ByVal dirName As String)

        Try
            Directory.Delete(dirName, True)
        Catch
        End Try

    End Sub
    Public Function getFileName(ByVal fPath As String) As String

        Dim f As New FileInfo(fPath)

        getFileName = f.Name

    End Function
    Public Function fileNameOnly(ByVal dirPath As String) As String

        fileNameOnly = IO.Path.GetFileName(dirPath)

    End Function
    Public Function directoryOnly(ByVal filePath As String) As String

        directoryOnly = IO.Path.GetDirectoryName(filePath)

    End Function
    Public Sub fileCopy(ByVal source As String, ByVal dest As String)

        If source = dest Then Exit Sub
        If source = "" Then Exit Sub
        If Not filePresent(source) Then Exit Sub

        System.IO.File.Copy(source, dest, True)

    End Sub
    Public Function getProcessType(ByVal fname As String) As String

        getProcessType = ""

        If fname <> "" Then

            If fname.IndexOf(" ") > 0 Then

                getProcessType = fname.Substring(0, fname.IndexOf(" "))

            End If
        End If

    End Function
    Public Function getprocessName(ByVal fname As String) As String

        getprocessName = ""

        If fname <> "" Then

            If fname.IndexOf(" ") > 0 Then

                getprocessName = fileNameOnly(fname.Substring(fname.IndexOf(" ") + 1))

            End If
        End If

    End Function
    Public Sub copyDirFiles(ByVal fromDir As String, ByVal toDir As String)

        Dim tempList As New myList, t As String, i As Integer

        tempList.setList(getDirectories(fromDir))

        For i = 0 To tempList.length(DL) - 1
            t = fileRead(gPath.addSlash(fromDir) & tempList.getItem(i, DL))
            fileWrite(gPath.addSlash(toDir) & tempList.getItem(i, DL), t)
        Next

    End Sub
    Public Function stripExtension(ByVal fname As String)

        stripExtension = fname

        If fname.IndexOf(".") > 0 Then
            stripExtension = fname.Substring(0, fname.IndexOf("."))
        End If

    End Function
    Public Function ForceNameValidation(ByVal fName As String)

        Dim newFName As String = ""

        fName = stripExtension(fName)

        For i = 0 To fName.Length - 1

            Select Case fName.Substring(i, 1)
                Case "a" To "z", "0" To "9", "A" To "Z", "_"
                    newFName = appendString(newFName, fName.Substring(i, 1), "")
            End Select
        Next

        ForceNameValidation = newFName

    End Function
    Public Sub DeepCopy(ByVal fromDir As String, ByVal toDir As String)

        Dim dirList As String = getDirectories(fromDir, "D")
        Dim fileList As String = getDirectories(fromDir, "F")
        Dim ccp As New convCamPaths

        Dim tList As New myList
        Dim tPath As String

        tList.setList(dirList)

        makeDirectory(toDir)

        For i = 0 To tList.length(DL) - 1
            tPath = tList.getItem(i, DL)
            makeDirectory(ccp.Path(fromDir, tPath))
            DeepCopy(ccp.Path(fromDir, tPath), ccp.Path(toDir, tPath))
        Next

        tList.setList(fileList)

        For i = 0 To tList.length(DL) - 1
            tPath = tList.getItem(i, DL)
            fileCopy(ccp.Path(fromDir, tPath), ccp.Path(toDir, tPath))
        Next

    End Sub
End Class
