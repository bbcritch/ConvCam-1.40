Public Class frmSelectProcess

    Dim ProcList As String
    Dim filterList As New myList
    Dim selectedItemRow As Integer

    Private Sub frmSelectProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblProcessSelectStatus.Text = "Select a Toolpath.."
        dialogResponse = "cancel"
        loadProcessList()
        ClearSelection()
    End Sub
    Private Sub loadProcessList()

        Dim tempList As New myList

        ProcList = gPath.dirList(gPath.templateProcessPath)
        loadCatalogTable("All")

        cmbFilterList.Items.Clear()
        For i = 0 To filterList.length(DL) - 1
            cmbFilterList.Items.Add(filterList.getItem(i, DL))
        Next

        cmbFilterList.Text = "All"
        loadCatalogTable("All")

    End Sub
    Private Sub loadCatalogTable(ByVal filter As String)

        Dim i As Integer, tempList As New myList, filteredList As String = "", ptype As String

        filterList.setList("All")
        tempList.setList(ProcList)

        For i = 0 To tempList.length(DL) - 1
            ptype = tempList.getItem(i, DL)
            ptype = ptype.Substring(0, ptype.IndexOf(" "))
            If ptype <> "" Then filterList.add(ptype, DL, True)
            If filter.ToLower = "all" Or filter.ToLower = ptype.ToLower Then
                If tempList.getItem(i, DL) <> "" Then
                    filteredList = appendString(filteredList, tempList.getItem(i, DL), DL)
                End If
            End If
        Next

        tempList.setList(filteredList)

        grdProcessCatalog.RowCount = tempList.length(DL)

        For i = 0 To tempList.length(DL) - 1

            setCell(grdProcessCatalog, i, 1, tempList.getItem(i, DL))

        Next

        selectedItemRow = -1
        lblProcessSelectStatus.Text = "Select a Toolpath.."


    End Sub
    Private Sub ClearSelection()

        For i = 0 To grdProcessCatalog.RowCount - 1
            setCell(grdProcessCatalog, i, 0, "")
        Next
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        exitOK()
    End Sub
    Private Sub exitOK()
        Dim t As String, f As New fileManager

        If selectedItemRow = -1 Then
            lblProcessSelectStatus.Text = "No Toolpath is selected. OK ignored"
            Exit Sub
        End If

        t = getCell(grdProcessCatalog, selectedItemRow, 1)
        If f.filePresent(gPath.addSlash(gPath.templateProcessPath) & t) Then
            stateVars.clearAllVars()
            stateVars.setVar("TEMPLATE", t)
        End If

        dialogResponse = "ok"
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub cmbFilterList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilterList.SelectedIndexChanged
        loadCatalogTable(cmbFilterList.Text)
        ClearSelection()
    End Sub
    Private Sub grdProcessCatalog_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProcessCatalog.CellClick
        newSelection()
    End Sub
    Private Sub grdProcessCatalog_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProcessCatalog.CellDoubleClick
        newSelection()
        exitOK()
    End Sub
    Private Sub newSelection()
        selectedItemRow = grdProcessCatalog.CurrentCellAddress.Y
        ClearSelection()
        setCell(grdProcessCatalog, selectedItemRow, 0, ">>")
        lblProcessSelectStatus.Text = "Selected Toolpath: " & getCell(grdProcessCatalog, selectedItemRow, 1)
    End Sub
End Class