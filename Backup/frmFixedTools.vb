Public Class frmFixedToolbox

    Dim StationRow As Integer = 0
    Dim suppressLoad As Boolean = False
    Dim ToolsAll As String
    Dim nLastStation As Integer
    Dim tempToolFile As String

    Private Const STATIONCOL = 0
    Private Const DEEPCOL = 1
    Private Const TOOLIDCOL = 2

    Private Sub frmFixedToolbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ClearToolStations()
        loadToolSetCombo()
        LoadToolLibrary()

        If STATIONFILE = "AUTO" Then
            chkAuto.Checked = True
            tempToolFile = ""
        Else
            chkAuto.Checked = False
            tempToolFile = STATIONFILE
        End If

        setToolSelections()

        lblStatus.Text = "Select a tool station, the double click in library"

    End Sub
    Private Sub ClearToolStations()

        Dim tList As New myList, t As String

        grdToolStations.RowCount = 1
        setCell(grdToolStations, 0, STATIONCOL, "")
        setCell(grdToolStations, 0, DEEPCOL, "")
        setCell(grdToolStations, 0, TOOLIDCOL, "")

        grdToolStations.RowCount = 256
        nLastStation = -1

        For i = 0 To 255
            setCell(grdToolStations, i, 0, (i + 1).ToString)
            If i < Integer.Parse(stateVars.getVar("ATCStations")) Then
                setBackgroundColor(grdToolStations, i, STATIONCOL, Color.White)
                setBackgroundColor(grdToolStations, i, DEEPCOL, Color.White)
                setBackgroundColor(grdToolStations, i, TOOLIDCOL, Color.White)
            Else
                setBackgroundColor(grdToolStations, i, STATIONCOL, Color.LightGray)
                setBackgroundColor(grdToolStations, i, DEEPCOL, Color.LightGray)
                setBackgroundColor(grdToolStations, i, TOOLIDCOL, Color.LightGray)
            End If

            If getCell(grdToolStations, i, 1) <> "" Then nLastStation = i

        Next

        setActiveCell(grdToolStations, 0, 1)

        If stateVars.getVar("DeepStations") <> "0" And stateVars.getVar("DeepStations") <> "" Then
            tList.setList(stateVars.getVar("DeepStations"))

            For i = 0 To tList.length(":") - 1
                t = tList.getItem(i, ":")
                setBackgroundColor(grdToolStations, Integer.Parse(t) - 1, STATIONCOL, Color.LightCyan)
                setBackgroundColor(grdToolStations, Integer.Parse(t) - 1, DEEPCOL, Color.LightCyan)
                setBackgroundColor(grdToolStations, Integer.Parse(t) - 1, TOOLIDCOL, Color.LightCyan)
                setCell(grdToolStations, Integer.Parse(t) - 1, DEEPCOL, "X")
            Next

        End If

    End Sub
    Private Sub LoadToolLibrary()

        Dim x As New myXmlUtils
        Dim f As New fileManager
        Dim tList As New myList

        ToolsAll = f.fileRead(gPath.addSlash(gPath.Configs) & "ToolsAll.txt")

        tList.setList(x.getChildren(x.add(ToolsAll, "TEMP"), "TEMP"))

        grdToolLibrary.RowCount = 1
        setCell(grdToolLibrary, 0, 0, "")

        grdToolLibrary.RowCount = tList.length(DL)

        For i = 0 To tList.length(DL) - 1

            setCell(grdToolLibrary, i, 0, MakeToolDescr(tList.getItem(i, DL)))
            If x.extract(ToolsAll, tList.getItem(i, DL) & " ToolLength") = "Long" Then
                setBackgroundColor(grdToolLibrary, i, 0, Color.LightCyan)
            End If

        Next

    End Sub
    Private Sub loadToolSet()

        Dim f As New fileManager, s As String, x As New myXmlUtils
        Dim tlist As New myList, staNum As Integer

        ClearToolStations()

        If f.filePresent(quickToolPath() & "\" & cmbToolSets.Text & ".txt") Then
            s = f.fileRead(quickToolPath() & "\" & cmbToolSets.Text & ".txt")
            tlist.setList(x.getChildren(s, "ToolAssignments"))
            For i = 0 To tlist.length(DL) - 1
                staNum = Integer.Parse(tlist.getItem(i, DL))
                If x.extract(s, staNum.ToString) <> "" Then
                    If x.extract(s, staNum.ToString) = "--" Then
                        setCell(grdToolStations, staNum - 1, TOOLIDCOL, "")
                    Else
                        setCell(grdToolStations, staNum - 1, TOOLIDCOL, x.extract(s, staNum.ToString))
                    End If
                End If
            Next
        End If

    End Sub
    Private Sub loadToolSetCombo()

        Dim f As New fileManager, x As New myXmlUtils, tlist As New myList

        tlist.setList(f.getDirectories(quickToolPath))

        cmbToolSets.Items.Clear()

        For i = 0 To tlist.length(DL)
            If tlist.getItem(i, DL) <> "" Then
                cmbToolSets.Items.Add(f.stripExtension(tlist.getItem(i, DL)))
            End if
        Next

    End Sub
    Public Function quickToolPath() As String
        quickToolPath = gPath.addSlash(gPath.Configs) & "\Tool Sets"
    End Function
    Private Sub grdToolLibrary_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdToolLibrary.CellDoubleClick
        Dim rw As Integer, cl As Integer
        Dim descript As String

        getRowCol(grdToolLibrary, rw, cl)
        descript = extractDescription(getCell(grdToolLibrary, rw, 0))
        addToolToStation(descript)
        
    End Sub
    Private Sub grdToolStations_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdToolStations.CellClick

        Dim cl As Integer
        Dim x As New myXmlUtils
        Dim toolLength As String = "Short"
        Dim msgResult As New MsgBoxResult

        getRowCol(grdToolStations, StationRow, cl)
        setCursor(StationRow)

    End Sub
    Private Sub SetCursor(ByVal nRow As Integer)
        For i = 0 To grdToolStations.RowCount - 1
            setCell(grdToolStations, i, 3, "")
        Next
        setCell(grdToolStations, nRow, 3, "<<")
    End Sub
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Call setCell(grdToolStations, StationRow, TOOLIDCOL, "")
    End Sub
    Private Function extractDescription(ByVal descript As String) As String
        extractDescription = descript.Substring(0, descript.IndexOf(" "))
    End Function
    Private Sub addToolToStation(ByVal descript)

        Dim t As String, t1 As String, msg As String = "", removeAt As Integer, x As New myXmlUtils

        removeAt = -1

        If x.extract(ToolsAll, descript & " ToolLength") = "Long" And _
           getCell(grdToolStations, StationRow, DEEPCOL) <> "X" And _
           getBackgroundColor(grdToolStations, StationRow, STATIONCOL) = Color.White Then
            MsgBox(descript & " is a long tool and will not fit in this station.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        t1 = getCell(grdToolStations, StationRow, TOOLIDCOL)
        If t1 = descript Then Exit Sub
        If t1 <> "" Then
            msg = "This will overwrite " & t1 & "."
        End If

        For i = 0 To 255
            If i <> StationRow Then
                t = getCell(grdToolStations, i, TOOLIDCOL)
                If t = descript Then
                    msg = appendString(msg, "This will move " & descript & " from station " & (i + 1).ToString & ".", vbLf)
                    removeAt = i
                End If
            End If
        Next

        If msg <> "" Then
            msg = appendString(msg, "Do you wish to continue?", vbLf)
            If MsgBox(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If

        If removeAt <> -1 Then
            setCell(grdToolStations, removeAt, TOOLIDCOL, "")
        End If

        setCell(grdToolStations, StationRow, TOOLIDCOL, descript)

    End Sub
    Private Function makeXml()

        Dim x As New myXmlUtils, t As String = "", toolID As String, totalStations As Integer

        getLastStation()
        totalStations = nLastStation + 1

        Dim mxSta As Integer = Integer.Parse(stateVars.getVar("ATCStations"))

        If totalStations < mxSta Then totalStations = mxSta

        t = x.add(stateVars.getVar("ATCStations"), "MaxStation")
        t = appendString(t, x.add(stateVars.getVar("DeepStations"), "DeepStations"), vbCrLf)
        t = appendString(t, x.add((totalStations).ToString, "TotalStations"), vbCrLf)

        t = appendString(t, "<ToolAssignments>", vbCrLf)

        For i = 0 To nLastStation
            toolID = getCell(grdToolStations, i, TOOLIDCOL)
            If toolID <> "" Then
                t = appendString(t, x.add(toolID, (i + 1).ToString), vbCrLf)
            Else
                t = appendString(t, x.add("--", (i + 1).ToString), vbCrLf)
            End If
        Next
        t = appendString(t, "</ToolAssignments>", vbCrLf)

        makeXml = t

    End Function
    Private Sub cmbToolSets_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbToolSets.SelectedIndexChanged

        If suppressLoad = False Then loadToolSet()
        If cmbToolSets.Text <> "" Then tempToolFile = cmbToolSets.Text

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        saveToolSet()
    End Sub
    Private Sub saveToolSet()

        Dim f As New fileManager

        If cmbToolSets.Text.Trim <> "" Then
            STATIONFILE = cmbToolSets.Text
            f.fileWrite(gPath.ToolSetFilePath(cmbToolSets.Text & ".txt"), makeXml)
            suppressLoad = True
            loadToolSetCombo()
            suppressLoad = False
        End If

    End Sub
    Private Sub chkAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAuto.CheckedChanged
        setToolSelections()
    End Sub
    Private Sub setToolSelections()
        If chkAuto.Checked Then
            cmbToolSets.Enabled = False
            btnSave.Enabled = False
            cmbToolSets.Text = ""
        Else
            cmbToolSets.Enabled = True
            btnSave.Enabled = True
            cmbToolSets.Text = tempToolFile   'UNITS
        End If
    End Sub
    Private Sub getLastStation()

        nLastStation = -1

        For i = 0 To 255
            If getCell(grdToolStations, i, TOOLIDCOL) <> "" Then nLastStation = i
        Next

    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        STATIONFILE = "AUTO"

        If Not chkAuto.Checked Then
            If cmbToolSets.Text.Trim <> "" Then
                STATIONFILE = cmbToolSets.Text
                saveToolSet()
            End If
        End If

        Me.Close()

    End Sub

End Class