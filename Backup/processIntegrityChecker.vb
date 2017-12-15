Module processIntegrityChecker


    Public processFailCount As Integer = 0
    Public processWarnCount As Integer = 0

    Public Function DesignIntegrityCheck(ByVal DesignFileName As String) As String

        Dim x As New myXmlUtils
        Dim tList As New myList
        Dim f As New fileManager
        Dim df As String
        Dim integrityReport As String = ""
        Dim totalFails As Integer
        Dim totalWarns As Integer

        df = f.fileRead(DesignFileName)
        DesignIntegrityCheck = ""

        If df = "" Then Exit Function
        tList.setList(x.extract(df, "PROCESSLIST"))

        For i = 0 To tList.length(DL) - 1
            integrityReport = appendString(integrityReport, ProcessIntegrityCheck(x.extract(df, tList.getItem(i, DL))), vbLf & vbLf)
            totalFails = totalFails + processFailCount
            totalWarns = totalWarns + processWarnCount
        Next

        DesignIntegrityCheck = MakeHeader(f.stripExtension(f.fileNameOnly(DesignFileName)) & " Integrity Check", totalFails, totalWarns) & vbLf & integrityReport
        frmConvCAM.ClearLog()
        frmConvCAM.AddToLog(DesignIntegrityCheck)

    End Function
    Public Function ProcessIntegrityCheck(ByVal processInfo As String)

        Dim f As New fileManager, processTemplateFileName As String
        Dim x As New myXmlUtils
        Dim doNextState As String = "IN PROCESS.."
        Dim stateCheck As String = ""
        Dim presentState As String
        Dim processTouchOffMethod As String = ""

        processTemplateFileName = x.extract(processInfo, "TEMPLATE")
        processTouchOffMethod = x.extract(processInfo, "TOUCHOFFMETHOD")

        p.readProcessDefinitionFile(processTemplateFileName)
        stateVars.loadVarString(processInfo)
        readPreferences()

        presentState = p.getStartState
        processFailCount = 0
        processWarnCount = 0

        stateCheck = appendString(stateCheck, TouchOffMethodCheck(processTouchOffMethod), vbLf)

        Do While presentState <> "-1"

            stateCheck = appendString(stateCheck, p.checkStateIntegrity(presentState), vbLf)
            presentState = p.getNextState(presentState)

        Loop

        ProcessIntegrityCheck = MakeHeader("PROCESS NAME: " & x.extract(processInfo, "ProcessName"), processFailCount, processWarnCount) & stateCheck

    End Function
    Private Function MakeHeader(ByVal Title As String, ByVal fails As Integer, ByVal warns As String) As String

        Dim s As String = ""

        MakeHeader = ""

        s = appendString(s, "================================================================", vbLf)
        Title = fitString(Title, 45, "left")
        Title = clipString(Title, 45)

        If fails = 0 And warns = 0 Then
            s = appendString(s, Title & "PASS", vbLf)
            MakeHeader = s & vbLf
            Exit Function
        End If

        If fails = 0 And warns <> 0 Then
            s = appendString(s, Title & "PASS with Warnings", vbLf)
            s = appendString(s, "  WARNINGS: " & warns.ToString, vbLf)
            MakeHeader = s & vbLf
            Exit Function
        End If

        If fails > 0 And warns = 0 Then
            s = appendString(s, Title & "FAIL", vbLf)
            s = appendString(s, "  FAILURES: " & fails.ToString, vbLf)
            MakeHeader = s & vbLf
            Exit Function
        End If

        If fails > 0 And warns > 0 Then
            s = appendString(s, Title & "FAIL", vbLf)
            s = appendString(s, "  FAILURES: " & fails.ToString, vbLf)
            s = appendString(s, "  WARNINGS: " & warns.ToString, vbLf)
            MakeHeader = s & vbLf
            Exit Function
        End If

    End Function
    Private Function TouchOffMethodCheck(ByVal processTouchOffMethod As String) As String

        Dim preferenceTouchOffMethod = stateVars.getVar("TOUCHOFFMETHOD")

        If processTouchOffMethod = preferenceTouchOffMethod Then
            TouchOffMethodCheck = vbLf & "Touch-off Method:                            OK" & vbLf
            Exit Function
        End If

        TouchOffMethodCheck = "FAIL: Touch-off Method mis-match:"
        appendString(TouchOffMethodCheck, "  Preferred TOM: " & preferenceTouchOffMethod, vbLf)
        appendString(TouchOffMethodCheck, "  Process TOM:   " & processTouchOffMethod, vbLf)
        processFailCount = processFailCount + 1

    End Function
End Module
