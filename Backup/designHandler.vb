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
        tlist.setList(getToolList)

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

        t.setList(getProcessFileList)

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
        Dim x As New myXmlUtils, toolID As String

        t.setList(getProcessFileList)

        For i = 0 To t.length(DL) - 1

            s = f.fileRead(t.getItem(i, DL) & ".txt")
            If s <> "" Then
                toolID = x.extract(s, "TOOLLIST")
                If toolID = "" Then toolID = "--"
                toolList.add(toolID, DL, False)
            End If
        Next

        getToolList = toolList.getList

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
    Public Function makeDesignReport() As String

        Dim s As New myList, t As String = ""
        Dim f As New fileManager, toolList As New myList, x As New myXmlUtils, u As String = ""

        makeDesignReport = ""
        If startUpFlag = 0 Then Exit Function

        s.setList(getProcessList)
        toolList.setList(getToolList)

        t = appendString(t, MakeReportHeader(), vbLf)
        t = appendString(t, MakeReportBlankInfo(), vbLf)
        t = appendString(t, tsMan.ToolReport(toolList.getList), vbLf)

        t = appendString(t, RLM & RDL, vbLf)
        t = appendString(t, CenterInReport("PROCESS SEQUENCE"), vbLf)
        t = appendString(t, RLM & RDL, vbLf)
        t = appendString(t, RLM & "  Total Number of Processes: " & s.length(DL).ToString, vbLf)

        For i = 0 To s.length(DL) - 1

            u = f.fileRead(gPath.addSlash(gPath.partPath) & "temp part\" & s.getItem(i, DL) & ".txt")

            t = appendString(t, RLM & RSL, vbLf)
            t = appendString(t, RLM & "  Process Name: " & s.getItem(i, DL), vbLf)
            t = appendString(t, RLM & "  Process Type: " & x.extract(u, "TEMPLATE"), vbLf)
            t = appendString(t, RLM & "  Tool ID:      " & toolList.getItem(i, DL), vbLf)

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
End Class
