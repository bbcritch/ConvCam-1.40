Public Class ToolStation

    Public aStations(256) As SingleToolStation

    Private sDeepStations As String
    Private nMaxStations As Integer
    Private nTotalStations As Integer
    Private sToolAssignments As String
    Private sToolSequence As String

    Private initFlag As Boolean = False

    Private sStationFile
    Public Property ToolSequence() As String
        Get
            ToolSequence = sToolSequence
        End Get
        Set(ByVal value As String)
            sToolSequence = value
        End Set
    End Property
    Public Property ToolAssignments() As String
        Get
            ToolAssignments = sToolAssignments
        End Get
        Set(ByVal value As String)
            sToolAssignments = value
        End Set
    End Property
    Public Property TotalStations() As Integer
        Get
            TotalStations = nTotalStations
        End Get
        Set(ByVal value As Integer)
            nTotalStations = value
        End Set
    End Property
    Public Property MaxStations() As Integer
        Get
            MaxStations = nMaxStations
        End Get
        Set(ByVal value As Integer)
            nMaxStations = value
        End Set
    End Property
    Public Property DeepStations() As String
        Get
            DeepStations = sDeepStations
        End Get
        Set(ByVal value As String)
            sDeepStations = value
        End Set
    End Property
    Public Sub initStationVariables()

        Dim x As New myXmlUtils
        Dim tList As New myList

        sDeepStations = stateVars.getVar("DeepStations")
        nMaxStations = Integer.Parse(stateVars.getVar("ATCStations"))
        nTotalStations = Integer.Parse(x.extract(sStationFile, "TotalStations"))

        getToolAssignments()

    End Sub
    Public Sub InitializeStations()

        Dim tList As New myList
        Dim x As New myXmlUtils

        tList.setList(sDeepStations)

        For i = 0 To 255

            If Not initFlag Then
                aStations(i) = New SingleToolStation
            End If

            aStations(i).ToolID = ""
            aStations(i).LongTool = False

        Next

        For i = 0 To nTotalStations - 1
            aStations(i).ToolStation = i + 1
            aStations(i).ColumnNumber = nTotalStations - 1 - i

            ' if ToolStation number is in DeepList, mark station as deep
            If tList.indexOf(aStations(i).ToolStation.ToString, ":") >= 0 Then
                aStations(i).DeepStation = True
            Else
                aStations(i).DeepStation = False
            End If
        Next

        initFlag = True

    End Sub
    Private Function getToolAssignments()

        '// Creats assignment list from STATIONFILE information.
        '// Used for loading up stations from file information
        '// Returns station file assignment list
        '// To be used with LoadTools and loading tool table on main page
        '// List has same format as get station assignments

        Dim x As New myXmlUtils, s As String
        Dim tList As New myList

        sToolAssignments = ""

        tList.setList(x.getChildren(sStationFile, "ToolAssignments"))
        s = x.extract(sStationFile, "ToolAssignments")

        For i = 0 To tList.length(DL) - 1
            sToolAssignments = appendString(sToolAssignments, x.extract(s, (i + 1).ToString), DL)
        Next

        getToolAssignments = sToolAssignments

    End Function
    Public Sub LoadToolAssignmentsFromFile()

        Dim tList As New myList

        tList.setList(sToolAssignments)

        For i = 0 To tList.length(DL) - 1
            aStations(i).ToolID = tList.getItem(i, DL)
        Next

    End Sub
    Private Function leftDeepStation(ByVal aIdx As Integer) As Integer

        Dim ts As New SingleToolStation

        leftDeepStation = -1
        If aIdx = tsMan.TotalStations - 1 Then Exit Function

        For i = aIdx + 1 To tsMan.TotalStations - 1
            ts = aStations(i)
            If ts.DeepStation Or i >= nMaxStations Then
                leftDeepStation = i
                Exit Function
            End If
        Next

    End Function
    Private Function rightDeepStation(ByVal aIdx As Integer) As Integer

        Dim ts As New SingleToolStation

        rightDeepStation = -1
        If aIdx = 0 Then Exit Function

        For i = aIdx - 1 To 0 Step -1
            ts = aStations(i)
            If ts.DeepStation Then
                rightDeepStation = i
                Exit Function
            End If
        Next

    End Function
    Private Function leftShortStation(ByVal aIdx As Integer) As Integer

        Dim ts As New SingleToolStation

        leftShortStation = -1
        If aIdx >= tsMan.TotalStations - 1 Then Exit Function

        For i = aIdx + 1 To tsMan.TotalStations - 1
            ts = aStations(i)
            If Not ts.LongTool Then
                leftShortStation = i
                Exit Function
            End If
        Next

    End Function
    Private Function rightShortStation(ByVal aIdx As Integer) As Integer

        Dim ts As New SingleToolStation

        rightShortStation = -1
        If aIdx = 0 Then Exit Function

        For i = aIdx - 1 To 0 Step -1
            ts = aStations(i)
            If Not ts.LongTool Then
                rightShortStation = i
                Exit Function
            End If
        Next

    End Function
    Public Sub LoadTools(ByVal assignmentList As String)

        '// Loads assignmentList into aStation Structure
        '// List looks like:  1:111~2:321~4:232
        '// where format is ToolStation:ToolID

        '// Structure always begins at zero, however beginning is displayed as 1.
        Dim tList As New myList, x As New myXmlUtils, unassignedLongs As String = ""

        tList.setList(assignmentList)
        InitializeStations()

        For i = 0 To tList.length(DL) - 1
            If tList.getItem(i, DL) = "--" Then
                aStations(i).ToolID = ""
                aStations(i).LongTool = False
            Else
                If x.extract(toolAll, tList.getItem(i, DL) & " " & "ToolLength") = "Long" Then
                    If aStations(i).DeepStation Then
                        aStations(i).ToolID = tList.getItem(i, DL)
                        aStations(i).LongTool = True
                    Else ' if long tool assigned to shallow station, re-assign it later
                        aStations(i).ToolID = ""
                        aStations(i).LongTool = False
                        MsgBox("Cannot load a long tool (" & tList.getItem(i, DL) & ") into a shallow station." & vbLf & "Tool will be re-assigned to a virtual station", MsgBoxStyle.OkOnly)
                        unassignedLongs = appendString(unassignedLongs, tList.getItem(i, DL), DL)
                    End If
                Else
                    aStations(i).ToolID = tList.getItem(i, DL)
                    aStations(i).LongTool = False
                End If
            End If
        Next i

        ' Place unassigned long tools into first available virtual stations
        tList.setList(unassignedLongs)

        For i = 0 To tList.length(DL) - 1
            For j = nMaxStations To 255
                If aStations(i).ToolID = "" Then
                    aStations(j).ToolID = tList.getItem(i, DL)
                    aStations(j).LongTool = True
                    Exit For
                End If
            Next
        Next

    End Sub
    Public Function AssignTools(ByVal ToolIDs As String)

        ' ToolIDs contain unique list of all tools to be assigned (no duplicates).
        ' This list contains no blanks, each item is a unique tool. This is different
        ' from the list of tools returned, which contains their assignment information by
        ' their placement within returned list. Blank stations are returned as '--'.

        Dim x As New myXmlUtils, tList As New myList
        Dim nVirtualStationPointer As Integer = nMaxStations - 1

        tList.setList(ToolIDs)
        InitializeStations()
        AssignTools = ""

        If ToolIDs = "" Then Exit Function

        ' If tool is long, assign it to available deep stations only, 
        '   including 'virtual' stations
        For i = 0 To tList.length(DL) - 1
            If x.extract(toolAll, tList.getItem(i, DL) & " ToolLength") = "Long" Then
                For j = 0 To 255
                    If aStations(j).ToolID = "" Then
                        If aStations(j).DeepStation Or j > nMaxStations Then
                            aStations(j).ToolID = tList.getItem(i, DL)
                            aStations(j).LongTool = True
                            If j >= nMaxStations Then nVirtualStationPointer = j
                            Exit For
                        End If
                    End If
                Next
            End If
        Next i

        ' Next, Assign all non-long tools to first station available.
        For i = 0 To tList.length(DL) - 1
            If tList.getItem(i, DL) <> "--" Then
                If x.extract(toolAll, tList.getItem(i, DL) & " ToolLength") <> "Long" Then
                    For j = 0 To 255
                        If aStations(j).ToolID = "" Then
                            aStations(j).ToolID = tList.getItem(i, DL)
                            aStations(j).LongTool = False
                            If j >= nMaxStations Then nVirtualStationPointer = j
                            Exit For
                        End If
                    Next
                End If
            End If
        Next i

        If nVirtualStationPointer > nMaxStations Then
            nTotalStations = nVirtualStationPointer
        End If

        AssignTools = GetStationAssignments()

    End Function
    Public Function GetStationAssignments()

        ' Returns list of tool assignments. Empty ATC Stations designated by '--'
        ' To be used for filling Tool Table displayed on main page.
        ' The size of this list consists of ATC stations, plus number of virtual stations.
        Dim newToolList As String = ""

        ' Create string of tool station assignments
        For i = 0 To nMaxStations - 1
            If aStations(i).ToolID <> "" Then
                newToolList = appendString(newToolList, aStations(i).ToolID, DL)
            Else
                newToolList = appendString(newToolList, "--", DL)
            End If
        Next

        ' Append virtual assignments
        For i = nMaxStations To 255
            If aStations(i).ToolID = "" Then
                Exit For
            Else
                newToolList = appendString(newToolList, aStations(i).ToolID, DL)
            End If

        Next

        GetStationAssignments = newToolList
        sToolAssignments = newToolList

    End Function
    Public Sub readStationFile()

        Dim f As New fileManager

        sStationFile = f.fileRead(gPath.ToolSetFilePath(STATIONFILE & ".txt"))

        If sStationFile = "" Then
            STATIONFILE = "AUTO"
            sStationFile = f.fileRead(gPath.ToolSetFilePath(STATIONFILE & ".txt"))
            writePreferences()
        End If

        initStationVariables()

    End Sub
    Public Sub makeAutoStationeFile()

        Dim f As New fileManager

        f.fileWrite(gPath.ToolSetFilePath("AUTO.txt"), makeAutoXml)

    End Sub
    Public Function makeAutoXml()

        Dim x As New myXmlUtils, t As String = ""

        t = x.add(stateVars.getVar("ATCStations"), "MaxStation")
        t = appendString(t, x.add(stateVars.getVar("DeepStations"), "DeepStations"), vbCrLf)
        t = appendString(t, x.add(stateVars.getVar("ATCStations"), "TotalStations"), vbCrLf)

        t = appendString(t, "<ToolAssignments>", vbCrLf)

        For i = 0 To Integer.Parse(stateVars.getVar("ATCStations")) - 1
            t = appendString(t, x.add("--", (i + 1).ToString), vbCrLf)
        Next

        t = appendString(t, "</ToolAssignments>", vbCrLf)

        makeAutoXml = t

    End Function
    Public Function GetCurrentStationAssignments()

        ''        Dim sToolList As New myList
        Dim sUniqueTools As String

        ''        sToolList.setList(dh.getToolList)
        ''sUniqueTools = UniqueToolList(dh.getToolList)
        sUniqueTools = UniqueToolList(dh.makeToolList)

        If STATIONFILE = "AUTO" Then
            AssignTools(sUniqueTools)
        End If

        GetCurrentStationAssignments = GetStationAssignments()

    End Function
    Public Function ToolReport(ByVal toolList As String) As String

        Dim sToolList As New myList, sUniqueTools
        Dim t As String = "", tlist As New myList, t1 As String = ""
        Dim x As New myXmlUtils

        sToolList.setList(toolList)
        sUniqueTools = UniqueToolList(toolList)

        t = appendString(t, RLM & RDL, vbLf)
        t = appendString(t, CenterInReport("TOOL REPORT"), vbLf)
        t = appendString(t, RLM & RSL, vbLf)
        t = appendString(t, RLM & " Tool List:", vbLf)
        t = appendString(t, ToolDescriptions(sUniqueTools), vbLf)
        t = appendString(t, RLM & RSL, vbLf)
        t = appendString(t, RLM & " Tool Sequence:", vbLf)
        t = appendString(t, RLM & "  " & UniqueToolSequence(toolList), vbLf)
        t = appendString(t, RLM & RSL, vbLf)
        t = appendString(t, RLM & " Station Assignments", vbLf)
        t = appendString(t, RLM & "  Station   Tool Id", vbLf)
        t = appendString(t, RLM & RSL, vbLf)

        If STATIONFILE = "AUTO" Then
            AssignTools(sUniqueTools)
        End If

        tlist.setList(GetStationAssignments)

        For i = 0 To nMaxStations - 1
            t = appendString(t, RLM & FormatAssignments((i + 1).ToString, tlist.getItem(i, DL)), vbLf)
        Next

        If nTotalStations > nMaxStations Then
            t = appendString(t, "", vbLf)
            t = appendString(t, RLM & RSL, vbLf)
            t = appendString(t, RLM & " Virtual Station Assignments", vbLf)
            t = appendString(t, RLM & "  Station     Tool Id", vbLf)
            t = appendString(t, RLM & RSL, vbLf)
            For i = nMaxStations To tlist.length(DL) - 1
                t = appendString(t, RLM & FormatAssignments((i + 1).ToString, tlist.getItem(i, DL)), vbLf)
            Next
        End If

        sToolList.setList(sUniqueTools)

        For i = 0 To sToolList.length(DL) - 1
            If tlist.indexOf(sToolList.getItem(i, DL), DL) < 0 Then
                t1 = appendString(t1, RLM & FormatAssignments(sToolList.getItem(i, DL), "Unassigned"), vbLf)
            End If
        Next

        For i = 0 To nMaxStations - 1
            If tsMan.aStations(i).LongTool And Not tsMan.aStations(i).DeepStation Then
                t1 = appendString(t1, RLM & FormatAssignments(sToolList.getItem(i, DL), "Long tool in Short station"), vbLf)
            End If
        Next

        If t1 <> "" Then
            t = appendString(t, RLM & RSL, vbLf)
            t = appendString(t, RLM & " Tool Check", vbLf)
            t = appendString(t, RLM & RSL, vbLf)
            t = appendString(t, t1, vbLf)
        End If

        ToolReport = t

    End Function
    Private Function FormatAssignments(ByVal s1 As String, ByVal s2 As String)
        FormatAssignments = "  " & fitString(s1, 4, "right") & "         " & s2
    End Function
    Private Function UniqueToolSequence(ByVal toolList As String) As String

        Dim toolSequenceList As New myList, sToolList As New myList, toolID As String
        Dim lastToolAdded As String

        sToolList.setList(toolList)
        toolSequenceList.setList("")

        For i = 0 To sToolList.length(DL) - 1
            toolID = sToolList.getItem(i, DL)
            lastToolAdded = toolSequenceList.getLast(DL)
            If toolID <> lastToolAdded Then
                If toolID <> "--" And toolID <> "" Then
                    toolSequenceList.add(sToolList.getItem(i, DL), DL)
                End If
            End If
        Next

        UniqueToolSequence = toolSequenceList.getList

    End Function
    Public Function UniqueToolList(ByVal toolList As String) As String

        Dim sUniqueToolList As New myList, sToolList As New myList, toolID As String

        sToolList.setList(toolList)
        sUniqueToolList.setList("")

        For i = 0 To sToolList.length(DL) - 1
            toolID = sToolList.getItem(i, DL)
            If toolID <> "--" And toolID <> "" Then
                sUniqueToolList.add(sToolList.getItem(i, DL), DL, True)
            End If
        Next

        UniqueToolList = sUniqueToolList.getList

    End Function
    Private Function ToolDescriptions(ByVal sUniqueTools As String) As String

        Dim t As String = ""
        Dim tList As New myList

        tList.setList(sUniqueTools)

        For i = 0 To tList.length(DL) - 1
            t = appendString(t, RLM & "  " & MakeToolDescr(tList.getItem(i, DL)), vbLf)
        Next

        tooldescriptions = t

    End Function
    Public Function GetStationNumber(ByVal ToolID As String) As String

        Dim tList As New myList

        tList.setList(getToolAssignments)

        For i = 0 To tList.length(DL) - 1
            If tList.getItem(i, DL) = ToolID Then
                GetStationNumber = (i + 1).ToString
                Exit Function
            End If

        Next

        GetStationNumber = "TOOL '" & ToolID & "' is not in the tool table."

    End Function

End Class

