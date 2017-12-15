Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Management

Public Class systemHandler

    Public Function getVolumeNames() As String

        Dim driveInfo() As System.IO.DriveInfo = System.IO.DriveInfo.GetDrives
        Dim s As String = "", nm As String, vl As String
        Dim x As New myXmlUtils

        For i = 0 To driveInfo.Count - 1
            If driveInfo(i).IsReady Then

                nm = driveInfo(i).Name
                vl = driveInfo(i).VolumeLabel.ToString
                s = s & x.add(x.add(nm, "NAME") & x.add(vl, "VLABEL"), i.ToString)

            End If
        Next

        getVolumeNames = x.add(driveInfo.Count.ToString, "QTY") & s

    End Function
    Public Function GetSerialNumberFromDriveLetter(ByVal driveLetter As String) As String
        If Not driveLetter.EndsWith(":") Then
            driveLetter += ":"
        End If

        Return matchDriveLetterWithSerial(driveLetter)
    End Function
    Private Shared Function matchDriveLetterWithSerial(ByVal driveLetter As String) As String

        Dim serialNumber As String = ""
        Dim searcher1 As New ManagementObjectSearcher("SELECT * FROM Win32_LogicalDiskToPartition")

        For Each dm As ManagementObject In searcher1.[Get]()
            Dim diskArray As String() = Nothing
            Dim currentDrive As String = getValueInQuotes(dm("Dependent").ToString())
            diskArray = getValueInQuotes(dm("Antecedent").ToString()).Split(","c)
            Dim driveNumber As String = diskArray(0).Remove(0, 6).Trim()
            If currentDrive.ToLower = driveLetter.ToLower Then
                ' This is where we get the drive serial 

                Dim disks As New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
                For Each disk As ManagementObject In disks.[Get]()

                    If disk("Name").ToString() = ("\\.\PHYSICALDRIVE" & driveNumber) And disk("InterfaceType").ToString() = "USB" Then
                        serialNumber = parseSerialFromDeviceID(disk("PNPDeviceID").ToString())
                    End If
                    Dim sss = disk("Name").ToString
                    sss = disk("InterfaceType").ToString
                Next
            End If
        Next
        Return serialNumber
    End Function
    Private Shared Function parseSerialFromDeviceID(ByVal deviceId As String) As String
        Dim splitDeviceId As String() = deviceId.Split("\"c)
        Dim arrayLen As Integer = splitDeviceId.Length - 1

        Dim serialArray As String() = splitDeviceId(arrayLen).Split("&"c)

        Return serialArray(0)
    End Function
    Private Shared Function getValueInQuotes(ByVal inValue As String) As String
        Dim parsedValue As String = ""

        Dim posFoundStart As Integer = 0
        Dim posFoundEnd As Integer = 0

        posFoundStart = inValue.IndexOf("""")
        posFoundEnd = inValue.IndexOf("""", posFoundStart + 1)

        parsedValue = inValue.Substring(posFoundStart + 1, (posFoundEnd - posFoundStart) - 1)

        Return parsedValue
    End Function
    Public Function getSnFromVolumeName(ByVal vname As String)

        Dim s As String, x As New myXmlUtils, driveLetter As String = ""

        s = getVolumeNames()

        For i = 0 To Integer.Parse(x.extract(s, "QTY")) - 1
            If x.extract(s, i.ToString & " VLABEL").ToUpper = vname.ToUpper Then
                driveLetter = x.extract(s, i.ToString & " NAME")
            End If
        Next

        If driveLetter <> "" Then
            getSnFromVolumeName = GetSerialNumberFromDriveLetter(driveLetter.Substring(0, 1))
        Else
            getSnFromVolumeName = ""
        End If

    End Function
    Public Function GetDriveLetterFromVolumeName(ByVal vName As String) As String

        Dim s As String, x As New myXmlUtils, driveLetter As String = ""

        s = getVolumeNames()

        For i = 0 To Integer.Parse(x.extract(s, "QTY")) - 1
            If x.extract(s, i.ToString & " VLABEL").ToUpper = vname.ToUpper Then
                driveLetter = x.extract(s, i.ToString & " NAME")
            End If
        Next

        If driveLetter.Length > 0 Then
            GetDriveLetterFromVolumeName = driveLetter.Substring(0, 1)
        Else
            GetDriveLetterFromVolumeName = driveLetter
        End If

    End Function
    Public Function getCPUiD() As String
        Dim objMOS As New ManagementObjectSearcher
        Dim objMOC As Management.ManagementObjectCollection
        Dim objMO As New Management.ManagementObject

        Dim cpuID As String = ""

        objMOS = New ManagementObjectSearcher("Select * From Win32_Processor")
        objMOC = objMOS.Get

        For Each objMO In objMOC

            cpuID = objMO("ProcessorID")
            Exit For

        Next

        objMOS.Dispose()
        objMOS = Nothing
        objMO.Dispose()
        objMO = Nothing

        getCPUiD = cpuID

    End Function
    Public Function StartSequence() As Boolean

        StartSequence = False

        Dim f As New fileManager
        Dim c As New convCamPaths

        If f.filePresent(c.Path(c.picturesPath, "developmentmode.bmp")) Then
            DEVELOPMENTMODE = 1
            StartSequence = True
            Exit Function
        Else
            DEVELOPMENTMODE = 0
        End If

        If Not InitInstall() Then Exit Function
        If Not AgreementOK() Then Exit Function

        StartSequence = True

    End Function
    Private Function InitInstall() As Boolean
        ' Check for existance of Install history
        Dim f As New fileManager
        Dim c As New convCamPaths
        Dim z As New Zipper
        Dim cry As New Crypto

        InitInstall = False

        If Not f.filePresent(c.InstallHistoryFile) Then
            Dim drive As String = GetDriveLetterFromVolumeName("CCAM")
            If drive <> "" Then

                Dim sFiles = f.getDirectories(drive & ":/", "F")
                Dim tList As New myList
                Dim sSupportFile As String = ""
                tList.setList(sFiles)

                For i = 0 To tList.length - 1
                    If tList.getItem(i, DL).IndexOf("SUPPORT_") >= 0 Then
                        sSupportFile = tList.getItem(i, DL)
                    End If
                Next

                Dim fileKey As String = z.GetFileKey(c.basePath, c.Path(drive & ":", sSupportFile))

                If fileKey <> "" Then
                    Dim driveKey As String = getSnFromVolumeName("CCAM")
                    fileKey = cry.DecryptFromRead(fileKey)
                    If fileKey = driveKey Then
                        z.UnZipFiles(c.basePath, c.Path(drive & ":", sSupportFile))
                        AddToInstallHistory("First Time Installation")
                        AddToInstallHistory(GetProgramInfo("NAME") & " Version " & GetProgramInfo("VERSION"))
                        CreateRunKey()
                        f.fileDelete(c.Path(c.basePath, "PAKFILE"))
                        InitInstall = True
                    End If
                End If
            Else
                MsgBox("Install the Conversational CAM memory stick then start the program over", MsgBoxStyle.OkOnly, "Installation Aborted")
                InitInstall = False
            End If
        Else
            InitInstall = True
        End If

        If InitInstall = True Then InitInstall = VerifyRunKey()

    End Function
    Public Function AgreementOK(Optional ByVal forceShowing As Boolean = False) As Boolean

        Dim f As New fileManager
        Dim cp As New convCamPaths

        If f.filePresent(cp.Path(cp.Configs, "\Defaults\Utilities.txt")) And forceShowing = False Then
            AgreementOK = True
            Exit Function
        End If

        frmLicenseAgreement.ShowDialog()

        If LicenseAgreementOK Then
            f.fileWrite(cp.Path(cp.Configs, "\Defaults\Utilities.txt"), "Utility CHECK passed")
            AgreementOK = True
            Exit Function
        End If

        f.fileDelete(cp.Path(cp.Configs, "\Defaults\Utilities.txt"))
        AgreementOK = False

    End Function
    Public Sub AddonInstall()

        Dim z As New Zipper
        Dim c As New convCamPaths
        Dim f As New fileManager

        frmConvCAM.dlgOpen.Title = "Find and select your add-on file(s) (<filename>.PKG)"
        frmConvCAM.dlgOpen.Filter = "Package Files (*.pkg)|*.pkg"
        frmConvCAM.dlgOpen.FileName = ""
        frmConvCAM.dlgOpen.ShowDialog()

        Dim addonFileName As String = frmConvCAM.dlgOpen.FileName



        If addonFileName <> "" Then

            Dim fileKey As String = z.GetFileKey(c.basePath, addonFileName)

            If fileKey = "" Then
                SaveLibsAsTemps()
                z.UnZipFiles(c.basePath, addonFileName)
                AddToInstallHistory(f.fileNameOnly(addonFileName))
                RestoreLibs()
                MsgBox("Your files have been updated.", MsgBoxStyle.OkOnly)
            End If

        End If

    End Sub
    Private Sub AddToInstallHistory(ByVal message)

        Dim c As New convCamPaths
        Dim f As New fileManager
        Dim s As String

        f.makeDirectory(c.Path(c.basePath, "Configs\InstallationHistory"))

        s = f.fileRead(c.InstallHistoryFile)
        s = appendString(s, System.DateTime.Today & "  " & message, vbLf)
        f.fileWrite(c.InstallHistoryFile, s)

    End Sub
    Private Sub CreateRunKey()

        Dim s As String = getCPUiD()
        Dim cry As New Crypto
        Dim f As New fileManager
        Dim x As New myXmlUtils
        Dim c As New convCamPaths

        s = x.add(cry.EncryptForSave(s), "RUNKEY")

        f.fileWrite(c.RunKeyFile, s)

    End Sub

    Public Function VerifyRunKey() As Boolean

        Dim CpuID As String = getCPUiD()
        Dim f As New fileManager
        Dim c As New convCamPaths
        Dim x As New myXmlUtils
        Dim cry As New Crypto

        Dim key As String = f.fileRead(c.RunKeyFile)

        If cry.DecryptFromRead(x.extract(key, "RUNKEY")) = CpuID Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub SaveLibsAsTemps()

        Dim f As New fileManager
        Dim c As New convCamPaths

        Dim backUpDir As String = c.Path(c.Configs, "Backup")
        f.makeDirectory(backUpDir)

        Dim toolConfig As String = GetConfigInfo("ToolConfig.txt", "LIBFILE")
        Dim machineConfig As String = GetConfigInfo("MachineConfig.txt", "LIBFILE")
        Dim blankConfig As String = GetConfigInfo("BlankConfig.txt", "LIBFILE")

        f.fileCopy(c.Path(c.Configs, toolConfig), c.Path(backUpDir, toolConfig))
        f.fileCopy(c.Path(c.Configs, machineConfig), c.Path(backUpDir, machineConfig))
        f.fileCopy(c.Path(c.Configs, blankConfig), c.Path(backUpDir, blankConfig))

        f.fileDelete(c.Path(c.Configs, toolConfig))
        f.fileDelete(c.Path(c.Configs, machineConfig))
        f.fileDelete(c.Path(c.Configs, blankConfig))

    End Sub
    Private Sub RestoreLibs()

        AppendLibs("ToolConfig.txt")
        AppendLibs("MachineConfig.txt")
        AppendLibs("BlankConfig.txt")

    End Sub

    Private Sub AppendLibs(ByVal configName As String)

        Dim f As New fileManager
        Dim c As New convCamPaths
        Dim backUpDir As String = c.Path(c.Configs, "Backup")
        Dim oldList As New myList
        Dim newList As New myList

        Dim libName As String = GetConfigInfo(configName, "LIBFILE")

        Dim newTag As String
        Dim newTagIdx As Integer

        Dim x As New myXmlUtils
        Dim s As String = ""

        ' if library is in directory (implies new stuff has been written in..)
        If f.filePresent(c.Path(c.Configs, libName)) Then

            ' Create lists of old and new libraries delimeters
            Dim oLibAll As String = f.fileRead(c.Path(backUpDir, libName))
            Dim oldLib As String = x.getChildren(x.add(oLibAll, "TEMP"), "TEMP")
            oldList.setList(oldLib)

            Dim nLibAll As String = f.fileRead(c.Path(c.Configs, libName))
            Dim newLib As String = x.getChildren(x.add(nLibAll, "TEMP"), "TEMP")
            newList.setList(newLib)

            ' Search for duplicate delimeters
            For i = 0 To newList.length(DL) - 1

                newTag = newList.getItem(i, DL)
                newTagIdx = 1

                ' if there is a duplicate, start incrementing the newtag until
                ' it does not match old delim
                If oldList.indexOf(newTag, DL) >= 0 Then
                    While oldList.indexOf(newTag & "." & newTagIdx.ToString, DL) >= 0
                        newTagIdx = newTagIdx + 1
                    End While
                    newTag = newTag & "." & newTagIdx.ToString
                End If

                ' Extract the new info, and append it to the old library, using newtag as delimeter
                s = x.extract(nLibAll, newList.getItem(i, DL))
                s = x.replace(s, newTag, GetConfigInfo(configName, "DELIMVAR"))
                oLibAll = appendString(oLibAll, x.add(s, newTag), vbLf)
            Next
            ' Write the oldLibAll with new appendages as libray file (overwrites nLibAll)
            f.fileWrite(c.Path(c.Configs, libName), oLibAll)

        Else
            ' If library is not present in configs, then copy backup to configs
            f.fileCopy(c.Path(backUpDir, libName), c.Path(c.Configs, libName))
        End If

    End Sub
End Class

