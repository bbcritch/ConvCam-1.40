Public Class designHandler

    Dim designString As New vars
    Dim qty As Integer
    Public Sub designInit()

        Dim tList As New myList
        Dim f As New fileManager
        Dim fname As String

        fname = gPath.addSlash(gPath.partPath) & "temp part"
        tList.setList(f.getDirectories(fname))

        For i = 0 To tList.length(DL) - 1
            f.fileDelete(fname & "\" & tList.getItem(i, DL))
        Next

        designString.clearAllVars()
        designString.setVar("QTY", "0")


    End Sub
    Public Sub addProcess(ByVal fname As String)

        Dim f As New fileManager, q As Integer

        q = incrQuantity(1)

        designString.setVar("NAME" & q.ToString, f.getFileName(fname))
        designString.setVar("PATH" & q.ToString, fname)

    End Sub
    Public Sub renameProcess(ByVal currentProcess As String, ByVal fname As String)

        Dim f As New fileManager

        ' Rename the current file path to the old one.
        Dim newPath() As String = fname.Split("\")
        newPath(newPath.Length - 1) = currentProcess

        ' Delete the old process file (the new one has already been written
        Dim oldPath As String = String.Join("\", newPath) & ".txt"
        f.fileDelete(oldPath)

        Dim numProcesses As Integer = Val(designString.getVar("QTY"))

        ' Find the current process name and change it to the new one (from fname)
        For i = 1 To numProcesses
            If designString.getVar("NAME" & i.ToString) = currentProcess Then
                designString.setVar("NAME" & i.ToString, f.getFileName(fname))
                designString.setVar("PATH" & i.ToString, fname)
            End If
        Next

    End Sub
    Public Sub removeProcess(ByVal idx As Integer)

        Dim q As Integer

        If idx = 0 Then Exit Sub

        q = getQuantity()

        For i = idx + 1 To q

            swapProcesses(i, i - 1)

        Next

        designString.clearVar("NAME" & q.ToString)
        designString.clearVar("PATH" & q.ToString)

        incrQuantity(-1)

    End Sub
    Public Sub swapProcesses(ByVal idx1 As Integer, ByVal idx2 As Integer)

        If idx1 <> 0 And idx2 <> 0 Then
            designString.swapValues("NAME" & idx1.ToString, "NAME" & idx2.ToString)
            designString.swapValues("PATH" & idx1.ToString, "PATH" & idx2.ToString)
        End If

    End Sub
    Public Function getProcessList() As String

        Dim q As Integer

        q = getQuantity()
        getProcessList = ""

        For i = 1 To q
            getProcessList = appendString(getProcessList, designString.getVar("NAME" & i.ToString), DL)
        Next

    End Function
    Public Function getToolStationList() As String

        Dim tlist As New myList, t As String = ""
        Dim ts As New ToolStation
        ''        tlist.setList(getToolList)

        tlist.setList(makeToolList())

        For i = 0 To tlist.length(DL) - 1
            t = appendString(t, GetToolStation(tlist.getItem(i, DL)), DL)
        Next

        getToolStationList = t

    End Function
    Public Function GetToolStation(ByVal ToolID As String) As String

        Dim tList As New myList

        tList.setList(tsMan.GetCurrentStationAssignments)

        GetToolStation = (tList.indexOf(ToolID, DL) + 1).ToString

        If GetToolStation = "0" Then GetToolStation = "Tool '" & ToolID & "' not found in tool table"


    End Function
    Public Function getBedAngleList()

        Dim f As New fileManager, s As String, t As New myList, bedAngleList As New myList
        Dim x As New myXmlUtils, t1 As String

        '       t.setList(getProcessFileList)
        t.setList(getCheckedProcessFileNameList)

        If t.length = 0 Then
            Return ""
        End If

        For i = 0 To t.length(DL) - 1

            s = f.fileRead(t.getItem(i, DL) & ".txt")
            t1 = x.extract(s, "VBedAngle")
            If t1 <> "" Then
                bedAngleList.add(t1, DL, False)
            Else
                bedAngleList.add("--", DL, False)
            End If
        Next

        getBedAngleList = bedAngleList.getList

    End Function
    Public Function getProcessFileList() As String

        Dim q As Integer

        q = getQuantity()
        getProcessFileList = ""

        For i = 1 To q
            getProcessFileList = appendString(getProcessFileList, designString.getVar("PATH" & i.ToString), DL)
        Next

    End Function
    Private Sub setQuantity(ByVal q As Integer)

        designString.clearVar("QTY")
        designString.setVar("QTY", q)

    End Sub
    Private Function getQuantity() As Integer

        getQuantity = Val(designString.getVar("QTY"))

    End Function
    Private Function incrQuantity(ByVal incr As Integer) As Integer

        Dim q As Integer

        q = getQuantity()
        q += incr
        setQuantity(q)
        incrQuantity = q

    End Function
    Public Function makeDesignXML() As String

        Dim q As Integer

        q = getQuantity()

        makeDesignXML = designString.getXML

    End Function
    Public Sub loadDesignXML(ByVal s As String)

        designString.loadXML(s)

    End Sub
    Public Sub makeDesignFolder(ByVal fname As String)

        Dim f As New fileManager

        f.makeDirectory(fname)

    End Sub
    Public Function getToolList() As String

        Dim f As New fileManager, s As String, t As New myList, toolList As New myList
        Dim x As New myXmlUtils

        Dim strToolList
        Dim toolAry() As String

        ''        t.setList(getProcessFileList)
        t.setList(getCheckedProcessFileNameList)

        For i = 0 To t.length(DL) - 1

            s = f.fileRead(t.getItem(i, DL) & ".txt")
            If s <> "" Then

                strToolList = stateVars.getVar("TOOLLIST")

                If strToolList.length = 0 Then
                    toolList.add("--", DL, False)
                Else
                    toolAry = strToolList.Split(DL)

                    For j = 0 To toolAry.Length - 1
                        If j = 0 Then
                            toolList.add(x.extract(s, "ToolMfgID"), DL, False)
                        Else
                            toolList.add(x.extract(s, "ToolMfgID_" & j.ToString), DL, False)
                        End If
                    Next
                End If

                ''               toolID = x.extract(s, "TOOLLIST")
                'toolID = x.extract(s, "ToolMfgID")
                'If toolID = "" Then toolID = "--"
                'toolList.add(toolID, DL, False)
            End If
        Next

        getToolList = toolList.getList

    End Function
    Public Function makeToolList() As String

        Dim processData As String
        Dim templateName As String = ""
        Dim x As New myXmlUtils
        Dim states() As String
        Dim stateValue As String
        Dim toolList As String = ""

        Dim f As New fileManager

        Dim processList As New myList
        processList.setList(getCheckedProcessList)

        For i = 0 To processList.length(DL) - 1

            processData = f.fileRead(gPath.addSlash(gPath.partPath) & "temp part\" & processList.getItem(i, DL) & ".txt")
            templateName = x.extract(processData, "TEMPLATE")
            p.readProcessDefinitionFile(templateName)

            states = p.getStateList.Split(DL)

            For j = 0 To states.Count - 1


                If p.stateInfoDetail("STTYPE", states(j)).ToLower = "tool" Then
                    stateValue = x.extract(processData, states(j))
                    If stateValue <> "" Then
                        toolList = appendString(toolList, stateValue, DL)
                    End If
                End If
            Next
        Next

        Return toolList

    End Function
    Public Sub loadToolVariables()

        Dim toollist As String, f As New fileManager, x As New myXmlUtils, t As New myList, s As String
        Dim t1 As String

        ' This function loads stateVars from tool parameters. 
        ' Sets toolType and toolID variables
        ' Gets parameter list from selected Tool
        ' Sets stateVars using same parameter names (pre-pended with "tool")
        ' and values that are from selected tool.

        If stateVars.getVar("Tool") <> "" Then

            toollist = f.fileRead(gPath.addSlash(gPath.Configs) & "ToolsAll.txt")

            s = x.extract(toollist, stateVars.getVar("Tool"))
            stateVars.setVar("toolType", x.extract(s, "TYPE"))

            t.setList(x.getChildren(s, "PARMS"))

            For i = 1 To t.length(DL) - 1
                t1 = t.getItem(i, DL).Replace(" ", "")
                stateVars.setVar("tool" & t1, x.extract(s, "PARMS " & t1))
            Next

            stateVars.setVar("selectTool", stateVars.getVar("Tool"))

        End If

    End Sub
    Public Function getToolParameterList() As String

        Dim f As New fileManager, s As String, x As New myXmlUtils

        ' Returns list of ALL tool parameters by extracting from 'Other' tool type

        s = f.fileRead(gPath.addSlash(gPath.Configs) & "ToolConfig.txt")
        s = x.extract(s, "Other")
        getToolParameterList = s

    End Function
    Public Function makePartFile() As String

        Dim f As New fileManager
        Dim x As New myXmlUtils
        Dim partString As String = ""
        Dim sList As New myList
        Dim tList As New myList
        Dim s As String = ""
        Dim t As String = ""
        Dim u As String = ""

        partString = appendString(partString, x.add(PartFileName, "PARTNAME"), vbCrLf)
        partString = appendString(partString, x.add(DesignerName, "DESIGNERNAME"), vbCrLf)
        partString = appendString(partString, x.add(Date.Today().ToString, "DATE"), vbCrLf)
        partString = appendString(partString, vbCrLf & x.add(vbCrLf & Descriptions & vbCrLf, "DESCRIPTION"), vbCrLf)
        partString = appendString(partString, vbCrLf & x.add(vbCrLf & GCodePartComment & vbCrLf, "GCODEPARTCOMMENT"), vbCrLf)
        partString = appendString(partString, x.add(stateVars.getVar("TOUCHOFFMETHOD"), "TOUCHOFFMETHOD"), vbCrLf & vbCrLf)
        partString = appendString(partString, x.add(vbCrLf & blankMy & vbCrLf, "BLANKINFO"), vbCrLf & vbCrLf)
        partString = appendString(partString, x.add(getProcessList, "PROCESSLIST"), vbCrLf & vbCrLf)

        tList.setList(getProcessList)

        For i = 0 To tList.length(DL) - 1

            s = f.fileRead(gPath.addSlash(gPath.partPath) & "temp part\" & tList.getItem(i, DL) & ".txt")
            sList.setList(x.getSiblings(x.add("dummy", "TEMPORARY") & s, "TEMPORARY"))
            u = ""

            For j = 0 To sList.length(DL) - 1
                u = appendString(u, "  " & x.add(x.extract(s, sList.getItem(j, DL)), sList.getItem(j, DL)), vbCrLf)
            Next

            partString = appendString(partString, x.add(vbCrLf & u & vbCrLf, tList.getItem(i, DL)), vbCrLf & vbCrLf)

        Next

        makePartFile = partString

    End Function
    Public Function getParentListForCombo() As String

        Dim x As New myXmlUtils

        ' Get the list of processes currently in the part
        Dim processList As New myList
        processList.setList(getProcessList)

        ' Get the list of processes that can be parents
        Dim f As New fileManager
        Dim parentList As New myList
        Dim c As New convCamPaths
        parentList.setList(x.extract(f.fileRead(c.parentPathFile), "PARENTLIST"))

        Dim processName As String = ""
        Dim templateName As String = ""

        Dim processContent As String = ""

        Dim comboList As New myList
        comboList.setList("None")

        ' Step through each process in the part. Using its name, extract its corresponding template
        ' If the template name is in the parent list, add the corresponding processname to the combo list.
        For i = 0 To processList.length(DL) - 1

            processName = processList.getItem(i, DL)
            processContent = f.fileRead(gPath.addSlash(gPath.partPath) & "temp part\" & processList.getItem(i, DL) & ".txt")
            templateName = f.stripExtension(x.extract(processContent, "TEMPLATE"))

            ' Add process name if in parentList and if not the current process.
            If parentList.indexOf(templateName, ",") >= 0 Then
                If processName <> stateVars.getVar("ProcessName") Then
                    comboList.add(processName, DL)
                End If
            End If
        Next

        ' Return the list of parent processes.
        getParentListForCombo = comboList.getList

    End Function
    Public Function makeDesignReport() As String

        Dim s As New myList, t As String = ""
        Dim f As New fileManager, toolList As New myList, x As New myXmlUtils, u As String = ""

        makeDesignReport = ""
        If startUpFlag = 0 Then Exit Function

        Dim processList As String = getCheckedProcessList()

        ''        s.setList(getProcessList)
        ''        toolList.setList(getToolList)
        s.setList(getCheckedProcessList)
        toolList.setList(makeToolList)

        t = appendString(t, MakeReportHeader(), vbLf)
        t = appendString(t, MakeReportBlankInfo(), vbLf)
        t = appendString(t, tsMan.ToolReport(toolList.getList), vbLf)

        t = appendString(t, RLM & RDL, vbLf)
        t = appendString(t, CenterInReport("TOOLPATH SEQUENCE"), vbLf)
        t = appendString(t, RLM & RDL, vbLf)
        t = appendString(t, RLM & "  Total Number of Toolpaths: " & s.length(DL).ToString, vbLf)

        For i = 0 To s.length(DL) - 1

            u = f.fileRead(gPath.addSlash(gPath.partPath) & "temp part\" & s.getItem(i, DL) & ".txt")

            t = appendString(t, RLM & RSL, vbLf)
            t = appendString(t, RLM & "  Toolpath Name: " & s.getItem(i, DL), vbLf)
            t = appendString(t, RLM & "  Toolpath Type: " & x.extract(u, "TEMPLATE"), vbLf)
            t = appendString(t, RLM & "  Tool Description:     " & toolList.getItem(i, DL), vbLf)

        Next

        t = appendString(t, RLM & RDL, vbLf)

        makeDesignReport = t

    End Function
    Private Function MakeReportHeader() As String

        Dim t As String = ""
        t = appendString(t, RLM & RDL, vbLf)
        t = appendString(t, CenterInReport("PART REPORT"), vbLf)
        t = appendString(t, RLM & RSL, vbLf)
        t = appendString(t, RLM & "  Part Name: " & PartFileName, vbLf)

        If DesignerName <> "" Then
            t = appendString(t, RLM & "  Designer:  " & DesignerName, vbLf)
        End If

        t = appendString(t, RLM & "  Date:      " & Date.Today(), vbLf)

        ' The following code takes the part description, removes leading and trailing
        ' blank lines, and re-builds descriptions with proper report indentation.
        Dim sDescriptions = Descriptions
        If sDescriptions <> "" Then

            t = appendString(t, "", vbLf)
            t = appendString(t, RLM & "  DESCRIPTION:", vbLf)

            Dim tAry() As String = sDescriptions.Replace(vbCrLf, vbLf).Split(vbLf)
            sDescriptions = ""

            Dim lastIdx As Integer = tAry.Length - 1

            ' Find last non-blank line
            For i = tAry.Length - 1 To 0 Step -1
                If tAry(i) = "" And lastIdx > 0 Then
                    lastIdx = lastIdx - 1
                Else
                    Exit For
                End If
            Next

            ' Re-build Description with indentations, starting with first non-blank line.
            Dim blankFlag As Boolean = True
            For i = 0 To lastIdx
                If tAry(i) <> "" Then blankFlag = False
                If Not blankFlag Then
                    sDescriptions = appendString(sDescriptions, RLM & "   " & tAry(i), vbLf)
                End If
            Next

            t = appendString(t, sDescriptions, vbLf)

        End If

        MakeReportHeader = t

    End Function
    Private Function MakeReportBlankInfo() As String

        Dim t As String = ""
        Dim x As New myXmlUtils
        Dim tList As New myList
        Dim dispVar = x.extract(blankConfig, "DISPVARNAME")

        tList.setList(x.getChildren(x.add(blankMy, "TEMP"), "TEMP"))

        t = appendString(t, RLM & RDL, vbLf)
        t = appendString(t, CenterInReport("BLANK DESCRIPTION"), vbLf)
        t = appendString(t, RLM & RSL, vbLf)
        t = appendString(t, RLM & " " & MakeBlankDescr(), vbLf)
        MakeReportBlankInfo = t

    End Function
    Public Function getCheckedProcessList(Optional ByVal getAll As Boolean = False, Optional ByVal asIndices As Boolean = False) As String

        ' Returns the list of Toolpath names as listed in the Toolpath grid.
        Dim checkedProcessList As New myList
        Dim checkedQty As Integer = 0

        Dim allProcessList As New myList
        Dim allQty As Integer = 0

        Dim processName As String

        ' Loop through the process list grid in frmConvCam.
        ' Make two lists: All, and those that are checked
        For i = 0 To 100000
            processName = getCell(frmConvCAM.grdProcessList, i, 1)
            Select Case processName
                Case ""
                    Exit For
                Case Else
                    If asIndices Then
                        ' Returns the index of the toolpath name
                        allProcessList.add(i.ToString, DL)
                        If getCell(frmConvCAM.grdProcessList, i, 2) <> "" Then
                            checkedProcessList.add(i.ToString, DL)
                        End If
                    Else
                        ' Returns the actual toolpath name
                        allProcessList.add(processName, DL)
                        If getCell(frmConvCAM.grdProcessList, i, 2) <> "" Then
                            checkedProcessList.add(processName, DL)
                        End If
                    End If

            End Select
        Next

        ' If the checked list is empty or the getAll flag is true, return ALL the processes
        ' Otherwise, return only the checked ones.
        Select Case checkedProcessList.length(DL)
            Case 0
                Return ""
            Case Else
                If getAll Then
                    Return allProcessList.getList
                Else
                    Return checkedProcessList.getList
                End If
        End Select

    End Function
    Public Function getCheckedProcessFileNameList() As String

        Dim processList As New myList
        processList.setList(getCheckedProcessList)

        If processList.length(DL) = 0 Then
            getCheckedProcessFileNameList = ""
            Exit Function
        End If

        getCheckedProcessFileNameList = ""

        Dim indexList As New myList
        indexList.setList(getCheckedProcessIndices)

        For i = 0 To indexList.length(DL) - 1
            getCheckedProcessFileNameList = appendString(getCheckedProcessFileNameList, designString.getVar("PATH" & indexList.getItem(i, DL)), DL)
        Next

    End Function
    Private Function getCheckedProcessIndices() As String
        Return getCheckedProcessList(, True)
    End Function
End Class
