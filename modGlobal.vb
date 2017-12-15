Imports System.IO
Module modGlobal

    Public DEVELOPMENTMODE As Integer = 0
    Public DEMOMODE As Boolean = False

    Public sReportFinal As String

    Public abortSave As Boolean

    Public xferBuf As String
    Public p As New processFileHandler

    Public LicenseAgreementOK As Boolean

    Public TRIMS() As Char = {vbLf, vbCr}


    Public tsMan As New ToolStation
    Public HELPFILE As String = ""

    Public masterProcessList As New vars
    Public currentProcess As String

    Public browserURL As String

    Public stateVars As New vars
    Public dh As New designHandler

    Public settingsList As New vars
    Public dialogResponse As String

    Public editorString As String
    Public editorDesignator As String

    Public calcCommands As String

    Public varList As New myList

    Public DEBUGFLAG As Integer = 0

    Public gPath As New convCamPaths
    Public processFileContent As String
    Public processFileContentBAK As String

    Public metaGcodeFileName As String

    Public mDown As Point
    Public mMove As Point
    Public mUp As Point
    Public g As System.Drawing.Graphics

    Public mouseFlag As Integer
    Public Const MOUSEISDOWN = 1
    Public Const MOUSEISUP = 0
    Public Const MOUSEISMOVING = 2

    Public organizeMode As Integer
    Public Const TOOLMODE = 0
    Public Const MACHINEMODE = 1
    Public Const BLANKMODE = 2

    Public PartFileName As String = ""
    Public DesignerName As String = ""
    Public Descriptions As String = ""

    Public Const DL = "~"

    Public startUpFlag As Integer = 0

    Public sTempDesignFile As String = ""

    Public Const RDL = "============================================================"
    Public Const RSL = "------------------------------------------------------------"
    Public Const RLM = "  "

    Public myCheckedTools As Boolean
    Public myCheckedBlanks As Boolean

    Public toolIdx As String

    Public quickStateHolder As String

    Public Function flattenString(ByVal s As String) As String

        If s.Length > 0 Then
            flattenString = s.Replace(vbLf, DL)
        Else
            flattenString = ""
        End If

        If Mid(flattenString, flattenString.Length, 1) = DL Then
            flattenString = Mid(flattenString, 1, flattenString.Length - 1)
        End If

    End Function
    Public Function appendString(ByVal bodyString As String, ByVal appendedString As String, ByVal delim As String) As String

        If bodyString = "" Then
            bodyString = appendedString
        Else
            bodyString = bodyString & delim & appendedString
        End If

        appendString = bodyString

    End Function
    Public Function fitString(ByVal s As String, ByVal len As Integer, ByVal justify As String, Optional ByVal clip As Boolean = False) As String

        Dim spaces As String = "                                                                                                              "
        Dim delta As Integer

        If clip Then
            If s.Length > len Then
                s = s.Substring(0, len)
            End If
        End If

        fitString = s
        If s.Length >= len Or len = 0 Then Exit Function

        delta = len - s.Length

        Select Case justify
            Case "left"
                fitString = s & spaces.Substring(0, delta)
            Case "right"
                fitString = spaces.Substring(0, delta) & s
            Case "center"
                fitString = spaces.Substring(0, Int(delta / 2)) & s & spaces.Substring(0, Int(delta / 2))
                If fitString.Length < len Then fitString = " " & fitString
                '              fitString = fitString(fitString, len, "left")
            Case Else
                fitString = s
        End Select

    End Function
    Public Function clipString(ByVal s As String, ByVal len As Integer)

        If s.Length > len Then s = s.Substring(0, len)
        clipString = s

    End Function
    Public Function parseLogic(ByVal p1 As String, ByVal oper As String, ByVal p2 As String, ByVal varType As String) As Boolean

        Dim x As Single, y As Single

        parseLogic = False

        p1 = stateVars.resolveVariable(p1)
        p2 = stateVars.resolveVariable(p2)

        Select Case varType.Substring(0, 1).ToLower

            Case "a"  ' alpha

                Select Case oper.ToLower
                    Case "equalto", "eq"
                        If p1 = p2 Then parseLogic = True
                    Case "notequalto", "ne"
                        If p1 <> p2 Then parseLogic = True
                    Case "greaterthan", "gt"
                        If p1 > p2 Then parseLogic = True
                    Case "lessthan", "lt"
                        If p1 < p2 Then parseLogic = True
                    Case "greaterthanequalto", "gte"
                        If p1 >= p2 Then parseLogic = True
                    Case "lessthanequalto", "lte"
                        If p1 <= p2 Then parseLogic = True
                End Select

            Case "n" ' numeric

                x = Val(p1)
                y = Val(p2)

                Select Case oper.ToLower
                    Case "equalto", "eq"
                        If x = y Then parseLogic = True
                    Case "nottqualto", "ne"
                        If x <> y Then parseLogic = True
                    Case "greaterthan", "gt"
                        If x > y Then parseLogic = True
                    Case "lessthan", "lt"
                        If x < y Then parseLogic = True
                    Case "greaterthanequalto", "gte"
                        If x >= y Then parseLogic = True
                    Case "lessthanequalto", "lte"
                        If x <= y Then parseLogic = True
                End Select

        End Select

    End Function
    Public Function variableFormat(ByVal v As String) As String

        If v <> "" Then
            variableFormat = v.Replace(" ", "")
        Else
            variableFormat = v
        End If

    End Function
    Public Function parameterDisplayFormat(ByVal v As String) As String

        If v.Substring(0, 1) = "u" Then
            parameterDisplayFormat = v.Substring(1)
        Else
            parameterDisplayFormat = v
        End If

    End Function
    Public Sub writeToLog(ByVal logInfo As String)
        frmConvCAM.txtLog.Text = frmConvCAM.txtLog.Text & logInfo & vbLf
    End Sub
    Public Function VarsToVals(ByVal s As String) As String

        Dim nameList As New myList
        Dim t As String
        Dim varName As String
        Dim varVal As String

        ' This function scans a string that is to be displayed,
        ' finds all state variables within the string, and 
        ' converts the variable names to values, while also
        ' correctly converting to metric, if needed.

        ' Get list of variables within string
        t = FindVars(s)

        ' Iterate through each varname, get its value, substitutue 
        ' the value back in for the name, in the source string.
        ' (The value is converted according to DISPUNITS. This function
        '  should only be called for display variable purposes.)
        If t.Length > 0 Then
            nameList.setList(t)
            For i = 0 To nameList.length(DL) - 1
                varName = nameList.getItem(i, DL)
                varVal = stateVars.getVar(varName, DISPUNITS)
                s = s.Replace("|" & varName & "|", varVal)
            Next
        End If

        VarsToVals = s

    End Function
    Public Sub ValToVar(ByVal varName As String, ByVal varVal As String)

        Dim tResp As String

        If varName.Substring(0, 1) = "u" Then
            'CONV           tResp = ToEnglish(varVal)
            tResp = varVal
            If InvalidNumberMessage(varName, tResp, varVal) Then Exit Sub
            varVal = SRound(tResp)
        End If

        stateVars.setVar(varName, varVal)

    End Sub
    Public Function FindVars(ByVal s As String) As String

        ' s is scanned and 
        ' returns a list of all found variable names.
        ' The list may contain duplicates.

        Dim bFound As Boolean = True
        Dim p1 As Integer = 0
        Dim p2 As Integer = -1
        FindVars = ""

        While bFound = True

            p1 = s.IndexOf("|", p2 + 1)
            p2 = s.IndexOf("|", p1 + 1)

            If p1 < p2 And p1 >= 0 Then
                FindVars = appendString(FindVars, s.Substring(p1 + 1, p2 - p1 - 1), "~")
            Else
                bFound = False
            End If

        End While

    End Function
    Public Function ToEnglish(ByVal s As String) As String
        ' Only convert, if in metric mode
        Dim t As Single

        If Single.TryParse(s, t) Then
            If s <> "" And DISPUNITS = METRIC Then
                ToEnglish = Math.Round((Convert.ToDouble(s) / 25.4), 8).ToString
            Else
                ToEnglish = s
            End If
        Else
            ToEnglish = "BAD INPUT"
        End If

    End Function
    Public Function ToMetric(ByVal s As String) As String

        ' Converts parameter s to metric from english.
        ' Prior testing to ensure variable has units and conversion is 
        ' required is determined from calling context(s), not here.
        Dim t As Single

        If s = "" Then
            Return ""
            Exit Function
        End If

        If Single.TryParse(s, t) Then
            ToMetric = (Convert.ToDouble(s) * 25.4).ToString
        Else
            ToMetric = "BAD INPUT"
        End If

    End Function
    Public Function SRound(ByVal varVal As String) As String

        Dim t As Double

        Try
            If varVal.IndexOf(".") >= 0 Then ' Preserves integers??
                t = Convert.ToDouble(varVal)
                t = Math.Round(t, 4)
                If Math.Abs(t - Math.Round(t, 0)) < 0.0004 Then t = Math.Round(t, 0)
                varVal = t.ToString
            End If
        Catch
        End Try

        SRound = varVal

    End Function
    Public Function InvalidNumberMessage(ByVal varName As String, ByVal varVal As String, ByVal tResp As String) As Boolean
        InvalidNumberMessage = False
        If tResp = "BAD INPUT" Then
            InvalidNumberMessage = True
            MsgBox("'" & varVal & "' is not a valid number for " & varName & ". " & vbLf & "Please correct.")
        End If
    End Function
    Public Sub LoadPicture(ByVal p As PictureBox, ByVal fName As String)

        Dim f As New fileManager
        Dim cp As New convCamPaths
        Dim FilePath As String

        If fName = "" Or fName = "none" Then
            p.Image = Nothing
            Exit Sub
        End If

        FilePath = cp.Path(cp.picturesPath, fName)

        If Not f.filePresent(FilePath) Then
            FilePath = cp.Path(cp.picturesPath, "Temporary.bmp")
        End If

        p.Image = New System.Drawing.Bitmap(FilePath)

    End Sub

    Public Function CenterInReport(ByVal s As String) As String

        CenterInReport = fitString(s, RLM.Length + RDL.Length, "center")

    End Function

    Public Function GetProgramInfo(ByVal key As String) As String

        Dim f As New fileManager
        Dim c As New convCamPaths
        Dim x As New myXmlUtils

        Dim fileContent As String = ""

        If key.ToUpper = "LICENSE" Then
            fileContent = f.fileRead(c.LicenseAgreementPath)
        Else
            fileContent = f.fileRead(c.VersionPath)
            fileContent = x.extract(fileContent, key.ToUpper)
        End If

        GetProgramInfo = fileContent

    End Function
    Public Function GetConfigInfo(ByVal configFile As String, ByVal parameter As String) As String

        Dim f As New fileManager
        Dim c As New convCamPaths
        Dim x As New myXmlUtils

        Dim s As String = f.fileRead(c.Path(c.Configs, configFile))

        GetConfigInfo = x.extract(s, parameter)

    End Function

    Public Sub TestFunction()
        'Dim crypt As New Crypto
        'Dim s As String
        'Dim sh As New systemHandler

        'Dim drives As DriveInfo() = DriveInfo.GetDrives()

        'For Each drive As DriveInfo In drives
        '    If drive.DriveType.ToString.IndexOf("Removable") > -1 Then
        '        drive.VolumeLabel = "CCAM2"
        '    End If
        'Next

        's = crypt.EncryptForSave(sh.getSnFromVolumeName("CCAM"))
        'Dim t As String = crypt.DecryptFromRead(s)



    End Sub
End Module
