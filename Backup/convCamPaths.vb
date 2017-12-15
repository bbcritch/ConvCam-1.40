Imports System.IO
Public Class convCamPaths
    Public Function basePath() As String
        basePath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\convCam"
    End Function
    Public Function AppPath() As String
        AppPath = System.AppDomain.CurrentDomain.BaseDirectory()
    End Function
    Public Function VersionPath() As String
        VersionPath = Path(defaultsPath, "VersionInfo.txt")
    End Function
    Public Function LicenseAgreementPath() As String
        LicenseAgreementPath = Path(defaultsPath, "LicenseAgreement.txt")
    End Function
    Public Function InstallHistoryFile() As String
        InstallHistoryFile = Path(basePath, "Configs\InstallationHistory\InstallHistory.txt")
    End Function
    Public Function RunKeyFile() As String
        RunKeyFile = Path(basePath, "Configs\InstallationHistory\RunKey.txt")
    End Function
    Public Function gcodePath() As String

        gcodePath = basePath() & "\My gCode"

    End Function
    Public Function Help() As String

        Help = basePath() & "\Help"

    End Function
    Public Function Configs() As String

        Configs = basePath() & "\Configs"

    End Function
    Public Function partPath() As String

        partPath = basePath() & "\My Parts"

    End Function
    Public Function processPath() As String

        processPath = basePath() & "\My Processes"

    End Function
    Public Function resourcesPath() As String

        resourcesPath = basePath() & "\Resources"

    End Function
    Public Function defaultsPath() As String

        defaultsPath = Path(Configs, "Defaults")

    End Function
    Public Function picturesPath() As String

        picturesPath = resourcesPath() & "\Pictures"

    End Function
    Public Function templatePath() As String

        templatePath = basePath() & "\Templates"

    End Function
    Public Function templateCodePath() As String

        templateCodePath = templatePath() & "\Code"

    End Function
    Public Function templateProcessPath() As String

        templateProcessPath = templatePath() & "\Processes"

    End Function
    Public Function dirList(ByVal path As String) As String

        Dim dDir As New DirectoryInfo(path), fFileSystemInfo As FileSystemInfo

        dirList = ""

        Try
            For Each fFileSystemInfo In dDir.GetFileSystemInfos()
                If dirList = "" Then
                    dirList = fFileSystemInfo.Name
                Else
                    dirList = dirList & DL & fFileSystemInfo.Name
                End If
            Next
        Catch
        End Try

    End Function
    Public Function addSlash(ByVal path As String) As String

        addSlash = path
        If addSlash.Substring(addSlash.Length - 1) <> "\" Then addSlash = addSlash & "\"

    End Function
    Public Function Path(ByVal dirPath As String, ByVal fname As String)

        Path = addSlash(dirPath) & fname

    End Function
    Public Function ConfigFilePath(ByVal fname As String) As String

        ConfigFilePath = Path(Configs, fname)

    End Function
    Public Function ToolSetFilePath(ByVal fname As String) As String

        If fname.Equals("AUTO.txt") Then
            ToolSetFilePath = Path(Configs, fname)
        Else
            ToolSetFilePath = Path(Configs, "Tool Sets\" & fname)
        End If

    End Function

End Class
