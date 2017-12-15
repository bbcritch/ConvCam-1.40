Public Class gCodeBuilder

    Dim metaGcode As String
    Dim finalGcode As String
    Dim templateFName

    Dim gToolList As New myList
    Dim gToolStation As New myList
    Dim gBedAngle As New myList
    Dim gProcessName As New myList
    Public Function makeGCodeAll() As String

        Dim f As New fileManager
        Dim pQty As Integer, allGcode As String = ""
        Dim t As String = "", tAry() As String, doFlag As Boolean = False
        Dim sAry() As String, tp As String

        Dim PrevBedAngle As String = "0"

        ' Gets variabls, including process names from design in progress
        getProgramVarialbesLists()

        ' Sets number of process
        pQty = gProcessName.length(DL)
        makeGCodeAll = ""

        If pQty = 0 Then Exit Function

        ' Step through each process
        For i = 0 To pQty - 1

            ' Read process file in gProcessName list, load in their program variables
            readProcessFile(gProcessName.getItem(i, DL))
            updateProgramVariables(i)

            ' Set first and last processes
            stateVars.setVar("FirstProcess", gProcessName.getItem(0, DL))
            stateVars.setVar("LastProcess", gProcessName.getItem(pQty - 1, DL))

            stateVars.setVar("PreviousBedAngle", PrevBedAngle)


            ' Build GCODE for each process and append them
            t = t & vbLf & makeGcode(gProcessName.getItem(i, DL))
            PrevBedAngle = stateVars.getVar("VBedAngle")

        Next

        ' If low verbosity, remove all comments

        If DEBUGFLAG = 0 Then

            If Not TRAINING Then

                tAry = t.Split(vbLf)
                t = ""

                For i = 0 To tAry.Length - 1

                    tp = tAry(i).Trim

                    If tp <> "" Then
                        sAry = tp.Split("(")
                        If sAry.Length > 1 Then
                            If sAry(1).Substring(0, 1) = "*" Then
                                tp = sAry(0)
                            End If
                        End If
                    End If
                    If tp <> "" Then t = appendString(t, tp, vbLf)
                Next
            End If

        End If

        makeGCodeAll = t

    End Function
    Private Sub getProgramVarialbesLists()
        gToolList.setList(dh.getToolList)
        gToolStation.setList(dh.getToolStationList)
        gBedAngle.setList(dh.getBedAngleList)
        gProcessName.setList(dh.getProcessList)
    End Sub
    Private Sub updateProgramVariables(ByVal i As Integer)

        stateVars.setVar("CurrentProcess", gProcessName.getItem(i, DL))
        stateVars.setVar("CurrentTool", gToolList.getItem(i, DL))
        stateVars.setVar("CurrentStation", gToolStation.getItem(i, DL))
        stateVars.setVar("CurrentBedAngle", gBedAngle.getItem(i, DL))

        If i > 0 Then
            stateVars.setVar("PreviousProcess", gProcessName.getItem(i - 1, DL))
            stateVars.setVar("PreviousTool", gToolList.getItem(i - 1, DL))
            stateVars.setVar("PreviousStation", gToolStation.getItem(i - 1, DL))
            stateVars.setVar("PreviousBedAngle", gBedAngle.getItem(i - 1, DL))
        Else
            stateVars.setVar("PreviousProcess", "")
            stateVars.setVar("PreviousTool", "")
            stateVars.setVar("PreviousStation", "")
            stateVars.setVar("PreviousBedAngle", "")
        End If

        If i < gProcessName.length(DL) - 1 Then
            stateVars.setVar("NextProcess", gProcessName.getItem(i + 1, DL))
            stateVars.setVar("NextTool", gToolList.getItem(i + 1, DL))
            stateVars.setVar("NextStation", gToolStation.getItem(i + 1, DL))
            stateVars.setVar("NextBedAngle", gBedAngle.getItem(i + 1, DL))
        Else
            stateVars.setVar("NextProcess", "")
            stateVars.setVar("NextTool", "")
            stateVars.setVar("NextStation", "")
            stateVars.setVar("NextBedAngle", "")
        End If

    End Sub
    Public Function makeGcode(ByVal processName As String) As String

        Dim f As New fileManager, metaC As String, fname As String

        fname = gPath.addSlash(gPath.templateCodePath)
        metaC = f.fileRead(fname & p.getMetagCodeFileName)

        metaC = readEmbeddedMetaFiles(metaC)
        metaC = metaC.Replace(vbCrLf, vbLf)

        finalGcode = ""
        buildFinalGcode(metaC)

        finalGcode = VarsToVals(finalGcode)

        makeGcode = "(=============================)" & vbLf
        makeGcode = makeGcode & "(" & processName & ")" & vbLf
        makeGcode = makeGcode & "(=============================)" & vbLf
        makeGcode = makeGcode & finalGcode & vbLf

    End Function
    Private Sub buildFinalGcode(ByVal meta As String)

        Dim s() As String

        s = meta.Split(vbLf)

        For i = 0 To s.Length - 1

            addCodeLine(s, i)

        Next

    End Sub
    Private Sub deBugMetaCode(ByVal s() As String, ByVal idx As Integer)

        Dim t As String, tList As New myList, varName As String, varVal As String
        Dim debugLine As String, codeLine As String

        Dim preFix As String = "(// "
        Dim sufFix As String = " //)"
        Dim len As Integer = s(idx).Length
        Dim border As String = "///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////"

        If len = 0 Then Exit Sub

        codeLine = s(idx).Replace("|", "!").Trim
        len = 80
        border = border.Substring(0, len)

        finalGcode = finalGcode & vbLf
        finalGcode = appendString(finalGcode, "(" & border & ")", vbLf)
        finalGcode = appendString(finalGcode, preFix & fitString(codeLine, len - 6, "left") & sufFix, vbLf)

        t = getVariables(s(idx))
        tList.setList(t)

        For i = 0 To tList.length(DL) - 1
            t = tList.getItem(i, DL)
            varName = fitString("!" & t & "!", 25, "left") & "= "
            varVal = fitString(stateVars.getVar(t), 20, "left")
            debugLine = fitString(varName & varVal, len - 6, "left")
            finalGcode = appendString(finalGcode, preFix & debugLine & sufFix, vbLf)
        Next

        finalGcode = appendString(finalGcode, "(" & border & ")", vbLf)
        finalGcode = finalGcode & vbLf

    End Sub
    Private Sub addCodeLine(ByVal s() As String, ByRef idx As Integer)

        Dim writeToDisplay As Boolean = True   ' Flags to add line of code
        Dim subFlag As Boolean = False
        Dim subFormula As String = ""
        Dim s1 As String

        s(idx) = s(idx).Trim

        If s(idx).IndexOf("#PAUSE") >= 0 Then
            Dim dummy = "Place to set debugger to pause"
            writeToDisplay = False
        End If

        If s(idx).IndexOf("#SPACE") >= 0 Then
            writeToDisplay = False
            finalGcode = appendString(finalGcode, "", vbLf)
        End If

        If s(idx).IndexOf("--------") >= 0 Or s(idx) = "" Then
            writeToDisplay = False
        End If

        If s(idx).IndexOf("#IF") >= 0 Then

            If DEBUGFLAG = 1 And DEVELOPMENTMODE = 1 Then deBugMetaCode(s, idx)
            expandIF(s, idx)
            writeToDisplay = False

        End If

        If s(idx).IndexOf("#SET") >= 0 Then

            doSet(s, idx)
            writeToDisplay = False
            If DEBUGFLAG = 1 And DEVELOPMENTMODE = 1 Then deBugMetaCode(s, idx)

        End If


        If s(idx).IndexOf("#COND") >= 0 Then

            doCond(s, idx)
            writeToDisplay = False
            If DEBUGFLAG = 1 And DEVELOPMENTMODE = 1 Then deBugMetaCode(s, idx)

        End If


        If s(idx).IndexOf("#LOOP") >= 0 Then

            If DEBUGFLAG = 1 And DEVELOPMENTMODE = 1 Then deBugMetaCode(s, idx)
            expandloop(s, idx)
            writeToDisplay = False

        End If


        If s(idx).IndexOf("#MATH") >= 0 Then

            doMath(s(idx))
            writeToDisplay = False
            If DEBUGFLAG = 1 And DEVELOPMENTMODE = 1 Then deBugMetaCode(s, idx)

        End If

        If s(idx).IndexOf("#SUBON") > 0 Then

            subFlag = True
            writeToDisplay = False

            If DEBUGFLAG = 1 And DEVELOPMENTMODE = 1 Then deBugMetaCode(s, idx)
            subFormula = getSubFormula(s(idx))

        End If

        If s(idx).IndexOf("#SUBOFF") > 0 Then

            If DEBUGFLAG = 1 And DEVELOPMENTMODE = 1 Then deBugMetaCode(s, idx)
            subFlag = False
            writeToDisplay = False

        End If


        If writeToDisplay = True Then

            ' Replace variables with values in line s(idx)
            s1 = VarsToVals(s(idx).Trim)

            ' Ignore all #ENDIFs
            If s(idx).IndexOf("#ENDIF") < 0 Then

                If DEBUGFLAG = 1 And DEVELOPMENTMODE = 1 Then deBugMetaCode(s, idx)

                If subFlag Then
                    s1 = performSubstitution(s1, subFormula)
                End If

                finalGcode = appendString(finalGcode, s1.Trim, vbLf)

            End If

        End If

    End Sub
    Private Sub doSet(ByVal s() As String, ByRef idx As Integer)
        Dim setLogic() As String

        setLogic = s(idx).Split(" ")

        stateVars.setVar(setLogic(1), setLogic(3))

    End Sub
    Private Sub doCond(ByVal s() As String, ByRef idx As Integer)
        Dim setLogic() As String

        setLogic = s(idx).Split(" ")
        stateVars.setVar(setLogic(1), stateVars.getVar(setLogic(3)).Replace(" ", ""))

    End Sub
    Private Sub expandIF(ByVal s() As String, ByRef idx As Integer)

        Dim ifLogic() As String
        Dim dataType As String = "Alpha"

        ' If #IF statement is true this returns next idx to calling routing
        ' otherwise, it returns idx location of corresponding #ENDIF

        ifLogic = s(idx).Trim.Split(" ")

        If ifLogic.Length > 4 Then
            dataType = ifLogic(4)
        Else
            dataType = "Alpha"
        End If

        If parseLogic(ifLogic(1), ifLogic(2), ifLogic(3), dataType) Then
            '            idx = idx + 1
        Else
            For i = idx + 1 To s.Length - 1
                If s(i).IndexOf("#END" & ifLogic(0).Substring(1)) >= 0 Then
                    idx = i
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub expandloop(ByVal s() As String, ByRef idx As Integer)

        Dim t() As String
        Dim endIDX As Integer
        Dim numSteps As Integer
        Dim temp As String

        t = s(idx).Split(" ")
        numSteps = getLoopVarVal(t(1))

        'Determine last index of code within loop
        Dim startIDX As Integer = idx + 1
        For i = idx + 1 To s.Length - 1

            If s(i).IndexOf("#END" & t(0).Substring(1)) >= 0 Then
                endIDX = i
                Exit For
            End If

        Next

        ' Repeat loop within code for number of loop steps
        For i = 1 To numSteps
            For j = startIDX To endIDX - 1
                ' If looping number is a variable, replace it in code with
                ' current value of loop count (i).
                If t(1).IndexOf("|") >= 0 Then
                    temp = s(j)
                    s(j) = s(j).Replace(t(1), (i).ToString)
                    addCodeLine(s, j)
                    s(j) = temp
                Else
                    addCodeLine(s, j)
                End If
            Next
        Next i

        ' increment idx past #end loop statement
        idx = endIDX + 1

    End Sub
    Private Sub doMath(ByVal s As String)

        Dim ary() As String, eq() As String, cc As New calc

        ary = s.Trim.Split(" ")
        eq = ary(1).Split("=")

        stateVars.setVar(eq(0), cc.calcEngine(eq(1)))

    End Sub
    Private Function getSubFormula(ByVal s As String) As String

        Dim t() As String, u As String = ""

        t = s.Split(" ")

        If t.Length > 1 Then

            For i = 1 To t.Length - 1
                u = appendString(u, t(i), " ")
            Next

        End If

        getSubFormula = u

    End Function
    Private Function performSubstitution(ByVal codeLine As String, ByVal formula As String) As String

        Dim parseCode() As String
        Dim parseFormula() As String
        Dim cc As New calc
        Dim replaceThis As String, withThis As String, formulaThis As String

        performSubstitution = codeLine
        parseFormula = formula.Split(" ")

        ' Parse the line of code into it's individual parts
        parseCode = codeLine.Split(" ")

        For i = 0 To parseFormula.Length - 1 Step 3

            replaceThis = stateVars.resolveVariable(parseFormula(i))
            withThis = stateVars.resolveVariable(parseFormula(i + 1))
            formulaThis = stateVars.getVar(parseFormula(i + 2))

            ' If the replacement variable is in the line of code..
            If codeLine.IndexOf(replaceThis) >= 0 Then

                ' Find the individual part where substitution takes place
                For j = 0 To parseCode.Length - 1

                    If parseCode(j).IndexOf(replaceThis) >= 0 Then
                        parseCode(j) = parseCode(j).Trim

                        ' Create the stateVar for current value to be replaced
                        stateVars.setVar("REPLPARM", parseCode(i).Substring(replaceThis.Length))

                        ' Perform replacement with new parameter name and calculated value
                        parseCode(j) = withThis & cc.calcEngine(formulaThis).ToString
                        Exit For
                    End If

                Next

            End If

        Next

        performSubstitution = String.Join(" ", parseCode)

    End Function
    Private Function getGcodeFile(ByVal fname As String) As String

        Dim a() As String, f As New fileManager, t As String, fString As String

        ' Read code snippet
        fString = ""
        a = fname.Split
        t = f.fileRead(gPath.addSlash(gPath.templateCodePath) & a(1))

        ' Append each code snippet line. If snippet references another snippet
        ' recursively call this sub, to append new file lines. 
        ' BEWARE of stack overflow if snippet calls itself!
        a = t.Split(vbLf)

        For i = 0 To a.Length - 1

            If a(i).IndexOf("#FILE ") >= 0 Then
                fString = appendString(fString, getGcodeFile(a(i)), vbLf)
            Else
                fString = appendString(fString, a(i), vbLf)
            End If

        Next

        getGcodeFile = fString

    End Function
    Private Sub readProcessFile(ByVal fname As String)

        Dim f As New fileManager, s As String

        fname = gPath.addSlash(gPath.partPath) & "Temp Part\" & fname & ".txt"

        If f.filePresent(fname) Then
            s = f.fileRead(fname)
            stateVars.loadVarString(s)
            readPreferences()  ' To ensure preference statevars not overwritten w/ process vars
            p.readProcessDefinitionFile(stateVars.getVar("TEMPLATE"))
        End If

    End Sub
    Private Function readEmbeddedMetaFiles(ByVal baseCode As String) As String

        Dim t() As String, returnCode As String = ""

        t = baseCode.Split(vbLf)

        For i = 0 To t.Length - 1

            If t(i).IndexOf("#FILE ") >= 0 Then
                returnCode = appendString(returnCode, getGcodeFile(t(i)), vbLf)
            Else
                returnCode = appendString(returnCode, t(i), vbLf)
            End If

        Next

        readEmbeddedMetaFiles = returnCode

    End Function
    Private Function getLoopVarVal(ByVal s As String) As Single

        Dim t As String

        t = stateVars.resolveVariable(s)

        If t = "" Then
            t = stateVars.varDeFormat(s)
        End If

        getLoopVarVal = Single.Parse(t)

    End Function
    Private Function getVariables(ByVal s As String) As String

        Dim i As Integer = 0, p1 As Integer, p2 As Integer, t As String = ""

        p1 = s.IndexOf("|")

        Do While p1 >= 0

            p2 = s.IndexOf("|", p1 + 1)
            t = appendString(t, s.Substring(p1 + 1, p2 - p1 - 1), DL)
            p1 = s.IndexOf("|", p2 + 1)

        Loop

        getVariables = t

    End Function
End Class
