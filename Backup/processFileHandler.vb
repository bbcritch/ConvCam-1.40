Public Class processFileHandler

    Public processDef As String
    Private currentState As String

    Dim metaGcode As String
    Dim finalGcode As String

    Dim stateStack As Stack
    Public Sub setStartState()

        Dim x As New myXmlUtils
        Dim s As String = x.extract(processDef, "STATELIST")

        Dim sAry() = s.Split(DL)

        currentState = sAry(0)

    End Sub
    Public Function readProcessDefinitionFile(ByVal processFile As String) As String

        Dim fname As String, f As New fileManager

        fname = gPath.addSlash(gPath.templateProcessPath) & processFile
        processDef = ""

        If f.filePresent(fname) Then

            processDef = f.fileRead(fname)

        End If

        readProcessDefinitionFile = processDef
        '      stateStack.Clear()

    End Function
    Public Function stateInfoDetail(ByVal tag As String, Optional ByVal stateName As String = "") As String

        Dim s As String, x As New myXmlUtils
        If stateName = "" Then stateName = currentState

        s = x.extract(processDef, stateName.Replace(" ", ""))
        stateInfoDetail = x.extract(s, tag)

    End Function
    Public Function stateInfoDetailCheck(ByVal stateName As String, ByVal tag As String) As String

        Dim s As String, x As New myXmlUtils

        s = x.extract(processDef, stateName.Replace(" ", ""))
        stateInfoDetailCheck = x.extract(s, tag)

    End Function
    Public Function getCurrentState() As String

        getCurrentState = currentState

    End Function
    Public Function getMetagCodeFileName() As String
        Dim x As New myXmlUtils
        getMetagCodeFileName = x.extract(processDef, "METAGCODE")
    End Function
    Public Sub setCurrentState(ByVal stateName As String)

        If stateName = "" Then Exit Sub
        currentState = stateName.Replace(" ", "")
        '       stateStack.Push(stateName.Replace(" ", ""))

    End Sub
    Public Function nextState() As String

        Dim t As String

        t = getNextState(currentState)
        If t <> "-1" Then currentState = t
        nextState = t

    End Function
    Public Function getNextState(ByVal presentState As String) As String

        Dim s As String, x As New myXmlUtils, i As Integer
        Dim tList As New myList

        getNextState = "-1"

        s = x.extract(processDef, presentState)
        If s = "" Then Exit Function

        tList.setList(x.extract(s, "NEXT"))

        For i = 0 To tList.length(DL) - 1
            getNextState = parseNext(tList.getItem(i, DL))
            If getNextState <> "-1" Then Exit Function
        Next

    End Function
    Private Function parseNext(ByVal s As String) As String

        Dim x As New myXmlUtils, nextState As String
        Dim nextList As New myList

        nextList.setList(s.Trim)
        nextState = nextList.getItem(1)

        If nextList.length = 2 Then

            parseNext = nextState
            Exit Function

        End If

        parseNext = "-1"

        '              p1                   oper                 p2                   nextType
        If parseLogic(nextList.getItem(3), nextList.getItem(4), nextList.getItem(5), nextList.getItem(6)) Then
            parseNext = nextState
        End If

    End Function
    Public Function previousState() As String

        previousState = GetPreviousState(currentState)
        currentState = previousState

    End Function
    Public Function GetPreviousState(ByVal presentState As String)

        Dim s As String, x As New myXmlUtils

        s = x.extract(processDef, presentState)
        GetPreviousState = x.extract(s, "PREV")

        If GetPreviousState = "" Then
            GetPreviousState = presentState
        End If

    End Function

    Public Function getStartState() As String

        Dim grpList As New myList, x As New myXmlUtils

        grpList.setList(x.extract(processDef, "STATELIST"))
        getStartState = grpList.getItem(0, DL)

    End Function
    Public Function resolveVariable(ByVal p As String) As String

        If p = "" Then
            resolveVariable = ""
            Exit Function
        End If

        If p.Substring(0, 1) = "|" Then
            resolveVariable = stateVars.getVar(p)
        Else
            resolveVariable = p
        End If

    End Function
    Public Sub getProcessVars()

        Dim t As New myList, x As New myXmlUtils

        ' This method creates all state variables from template and sets them to nothing.
        t.setList(x.extract(processDef, "VARIABLES"))

        For i = 0 To t.length(DL) - 1
            stateVars.setVar(t.getItem(i, DL), "")
        Next

    End Sub
    Public Function getStateList() As String

        ' Returns state list as if full sequence were run
        Dim s As String, x As New myXmlUtils, nxtSta As String

        getStateList = ""

        currentState = getStartState()
        nxtSta = currentState

        While nxtSta <> "-1"
            s = stateInfoDetail("STNAME")
            getStateList = appendString(getStateList, s, DL)
            nxtSta = nextState()
        End While


    End Function
    Public Function getProcessInfo(ByVal tagPath As String)

        Dim x As New myXmlUtils

        getProcessInfo = x.extract(processDef, tagPath)

    End Function
    Public Function checkStateIntegrity(ByVal presentState As String) As String
        Dim stateVal As String, report As String

        stateVal = stateVars.getVar(presentState)

        report = fitString(presentState, 30, "left")
        report = report & fitString(stateVal, 15, "left")
        report = report & ValidateState(presentState, stateVal)

        checkStateIntegrity = report

    End Function
    Public Function ValidateState(ByVal stateName, ByVal stateVal) As String

        Dim stateType As String, calcString As String, numeric As String
        Dim rangeList As String, upperLimit As String, lowerLimit As String
        Dim report As String = "", ary() As String, eq() As String
        Dim cc As New calc, testSingle As Single

        Dim fm As New fileManager

        stateVal = stateVal.trim

        If stateVal = "" Then
            ValidateState = "FAIL" & vbLf & stateName & "  has no value."
            Exit Function
        End If

        stateType = stateInfoDetailCheck(stateName, "STTYPE")
        calcString = stateInfoDetailCheck(stateName, "CALC")
        rangeList = stateInfoDetailCheck(stateName, "BUTTONLIST")
        upperLimit = stateInfoDetailCheck(stateName, "ULIM")
        lowerLimit = stateInfoDetailCheck(stateName, "LLIM")
        numeric = stateInfoDetailCheck(stateName, "UNITS")

        upperLimit = resolveVariable(upperLimit)
        lowerLimit = resolveVariable(lowerLimit)


        Select Case stateType
            Case "radio"
                report = listCheck(stateVal, rangeList)
            Case "text"

                Dim stVal As String = stateVal

                If numeric = "true" Then
                    If Single.TryParse(stateVal, testSingle) Then

                        If stateName.substring(0, 1) = "u" Then
                            'CONV                    stVal = SRound(ToEnglish(stVal))
                            stVal = SRound(stVal)
                        End If
                        report = RangeCheck(stVal, lowerLimit, upperLimit, numeric)
                    Else
                        report = "FAIL: " & vbLf & " (Invalid numeric entry)"
                    End If
                Else
                    report = "OK"
                End If

            Case "combo"
                report = listCheck(stateVal, rangeList)
            Case "tool"
                report = ToolIdCheck(stateVal)
            Case "file"
                If fm.filePresent(stateVal) Then
                    report = "OK"
                Else
                    report = "FAIL: File note present"
                End If
            Case Else
                report = "OK"

        End Select

        ' Perform calculations in case variables are used in future NEXT logic
        If calcString <> "" Then

            ary = calcString.Trim.Split("$")

            For i = 0 To ary.Length - 1
                If ary(i).IndexOf("=") > 0 Then
                    eq = ary(i).Split("=")
                    stateVars.setVar(eq(0), cc.calcEngine(eq(1)))
                End If
            Next

        End If

        ValidateState = report

    End Function
    Public Function ToolIdCheck(ByVal toolID As String) As String

        Dim t As String
        Dim x As New myXmlUtils

        ToolIdCheck = "Tool Check: OK"
        t = x.extract(toolAll, toolID)

        If t = "" Then
            ToolIdCheck = "Tool '" & toolID & "' not found in library"
            processFailCount = processFailCount + 1
            Exit Function
        End If

    End Function
    Public Function ToolCheck(ByVal toolID As String) As String

        Dim x As New myXmlUtils
        Dim tlist As New myList
        Dim t As String
        Dim ToolLibraryVals As String
        Dim parmName As String
        Dim firstFlag As Boolean = False

        ToolCheck = "Tool Check: OK"
        t = x.extract(toolAll, toolID)

        If t = "" Then
            ToolCheck = "Tool '" & toolID & "' not found in library"
            processFailCount = processFailCount + 1
            Exit Function
        End If

        tlist.setList(GetParmVariableList("Tools", "Tool"))
        ToolLibraryVals = x.extract(toolAll, stateVars.getVar("Tool"))

        t = ""

        For i = 0 To tlist.length(DL) - 1

            parmName = tlist.getItem(i, DL).Replace(" ", "")

            If stateVars.getVar(parmName) <> x.extract(ToolLibraryVals, parmName) Then
                If Not firstFlag Then
                    t = appendString(t, "  Tool Paramater Value Mis-match", vbLf)
                    t = appendString(t, "  Parameter            Process Value        Tool Libr Value", vbLf)
                    t = appendString(t, "  -------------------- -------------------- --------------------", vbLf)
                    firstFlag = True
                End If

                t = appendString(t, "  " & FormatToolParms(tlist.getItem(i, DL), _
                                                     stateVars.getVar(parmName), _
                                                     x.extract(ToolLibraryVals, parmName)), vbLf)
                processWarnCount = processWarnCount + 1
            End If

        Next

        If t = "" Then
            ToolCheck = "OK"
        Else
            ToolCheck = "WARNING" & vbLf & t
        End If


    End Function
    Private Function FormatToolParms(ByVal p1 As String, ByVal p2 As String, ByVal p3 As String)
        Dim spacing As Integer = 21

        p1 = fitString(p1, spacing, "left")
        p2 = fitString(p2, spacing, "left")
        p3 = fitString(p3, spacing, "left")

        FormatToolParms = clipstring(p1, spacing) & clipstring(p2, spacing) & clipstring(p3, spacing)

    End Function
    Public Function listCheck(ByVal valu As String, ByVal rangeList As String) As String

        Dim tList As New myList

        tList.setList(rangeList)

        If tList.indexOf(valu, DL) >= 0 Then
            listCheck = "OK"
        Else
            listCheck = "FAIL" & vbLf & "  (Invalid selection)"
            processFailCount = processFailCount + 1
        End If

    End Function
    Public Function RangeCheck(ByVal valu As String, ByVal lowerLimit As String, ByVal upperLimit As String, ByVal numeric As String) As String

        If numeric = "true" Then
            Dim llim As Double, ulim As Double, sValu As Double

            If valu = "BAD INPUT" Then
                RangeCheck = "Please enter a valid input for this parameter."
                Exit Function
            End If

            sValu = Double.Parse(valu)

            If DISPUNITS = METRIC Then
                lowerLimit = ToMetric(lowerLimit)
                upperLimit = ToMetric(upperLimit)
            End If

            If lowerLimit <> "" Then
                llim = Double.Parse(lowerLimit)
                If sValu < llim Then
                    'CONV                    RangeCheck = "'" & SRound(ToMetric(valu)) & "' is under the limit of " & SRound(ToMetric(lowerLimit))
                    RangeCheck = "'" & SRound(valu) & "' is under the limit of " & SRound(lowerLimit)
                    processFailCount = processFailCount + 1
                    Exit Function
                End If
            End If

            If upperLimit <> "" Then
                ulim = Double.Parse(upperLimit)
                If sValu > ulim Then
                    '                    RangeCheck = "'" & SRound(ToMetric(valu)) & "' is over the limit of " & SRound(ToMetric(upperLimit))
                    RangeCheck = "'" & SRound(valu) & "' is over the limit of " & SRound(upperLimit)
                    processFailCount = processFailCount + 1
                    Exit Function
                End If
            End If

        Else
            If valu = "" Then
                RangeCheck = "Please enter a value for this parameter"
                Exit Function
            End If
            If lowerLimit <> "" Then
                If valu <> lowerLimit Then
                    RangeCheck = "'" & valu & "' does not equal '" & lowerLimit & "'"
                    processFailCount = processFailCount + 1
                    Exit Function
                End If
            End If

            If upperLimit <> "" Then
                If valu > upperLimit Then
                    RangeCheck = "'" & valu & "' does not equal '" & upperLimit & "'"
                    processFailCount = processFailCount + 1
                    Exit Function
                End If
            End If

        End If

        RangeCheck = "OK"

    End Function

End Class
