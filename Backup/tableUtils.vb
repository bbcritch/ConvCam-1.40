Module tableUtils
    Public Sub setCell(ByVal grdObject As Object, ByVal row As Integer, ByVal col As Integer, ByVal value As String)

        If row >= grdObject.RowCount Then

            grdObject.RowCount = row + 1

        End If


        If row < grdObject.RowCount And col < grdObject.ColumnCount Then
            grdObject.Item(col, row).Value = value
        End If

    End Sub
    Public Function getCell(ByVal grdObject As Object, ByVal row As Integer, ByVal col As Integer) As String

        getCell = ""

        If row >= 0 And col >= 0 Then

            If row < grdObject.RowCount And col < grdObject.ColumnCount Then
                getCell = grdObject.Item(col, row).Value
            End If

        End If

        If getCell = Nothing Then getCell = ""

    End Function
    Public Sub setCellComboCheck(ByVal grdObject As Object, ByVal row As Integer, ByVal col As Integer, ByVal value As String, ByVal flagCol As Integer)

        Dim tList As New myList, t As String

        If row >= grdObject.RowCount Then
            grdObject.RowCount = row + 1
        End If

        If row < grdObject.RowCount And col < grdObject.ColumnCount Then
            t = getCell(grdObject, row, flagCol)
            If t.Length > 0 Then
                tList.setList(t)
                If tList.indexOf(value, DL) >= 0 Then
                    setCell(grdObject, row, col, value)
                Else
                    setCell(grdObject, row, col, tList.getItem(0, DL))
                End If
            Else
                setCell(grdObject, row, col, value)
            End If
        End If

    End Sub
    Public Sub clearCells(ByVal grdObject As Object)

        For i = 0 To grdObject.RowCount - 1
            For j = 0 To grdObject.ColumnCount - 1
                Call setCell(grdObject, i, j, "")
            Next
        Next
    End Sub
    Public Sub getRowCol(ByVal grd As Object, ByRef rw As Integer, ByRef cl As Integer)

        rw = grd.CurrentCellAddress.Y
        cl = grd.CurrentCellAddress.X

    End Sub
    Public Function getCheckValue(ByVal grd As Object, ByVal rw As Integer, ByVal cl As Integer) As Boolean

        Dim dgCB As New DataGridViewCheckBoxCell

        getRowCol(grd, rw, cl)
        dgCB = CType(grd(cl, rw), DataGridViewCheckBoxCell)

        getCheckValue = CBool(dgCB.EditedFormattedValue)

    End Function
    Public Sub setCheckValue(ByVal grd As Object, ByVal rw As Integer, ByVal cl As Integer, ByVal valu As Boolean)

        Dim dgCB As New DataGridViewCheckBoxCell
        dgCB = CType(grd(cl, rw), DataGridViewCheckBoxCell)

        dgCB.Value = valu

    End Sub
    Public Sub setCombo(ByVal grd As Object, ByVal r As Integer, ByVal c As Integer, ByVal lst As String)

        Dim cell As New DataGridViewComboBoxCell, t As New myList

        t.setList(lst)

        For i = 0 To t.length(DL) - 1
            cell.Items.Add(t.getItem(i, DL))
        Next

        grd.Item(c, r) = cell

    End Sub
    Public Sub setButton(ByVal grd As Object, ByVal r As Integer, ByVal c As Integer)

        Dim cell As New DataGridViewButtonCell, t As New myList
        grd.Item(c, r) = cell

    End Sub
    Public Sub SetToTextCell(ByVal grd As Object, ByVal r As Integer, ByVal c As Integer)

        Dim cell As New DataGridViewTextBoxCell, t As New myList
        grd.Item(c, r) = cell

    End Sub
    Public Sub cellReadOnly(ByVal grd As DataGridView, ByVal r As Integer, ByVal c As Integer)

        grd.Item(c, r).ReadOnly = True

    End Sub
    Public Sub cellReadWrite(ByVal grd As DataGridView, ByVal r As Integer, ByVal c As Integer)

        grd.Item(c, r).ReadOnly = False

    End Sub
    Public Sub setSize(ByVal grd As Object, ByVal r As Integer, ByVal c As Integer)

        Dim cell As New DataGridViewComboBoxCell, t As New myList
        Dim grid As DataGridView

        grid = grd

        grid.ColumnCount = c
        grid.RowCount = r

    End Sub
    Public Sub columnHeader(ByVal grd As Object, ByVal col As Integer, ByVal colLabel As String)

        Dim grid As DataGridView

        grid = grd
        grid.Columns.Item(col).HeaderText = colLabel

    End Sub
    Public Sub columnWidth(ByVal grd As Object, ByVal col As Integer, ByVal wid As Integer)

        Dim grid As DataGridView

        grid = grd
        grid.Columns.Item(col).Width = wid

    End Sub
    Public Sub setActiveCell(ByVal grd As Object, ByVal r As Integer, ByVal c As Integer)


        Dim grid As DataGridView = grd

        If grid.RowCount > r And grid.ColumnCount > c Then
            grid.CurrentCell = grid.Item(c, r)
        End If


    End Sub
    Public Sub setBackgroundColor(ByVal grd As Object, ByVal r As Integer, ByVal c As Integer, ByVal color As Color)

        If grd.rowCount > r Then
            Dim grid As DataGridView = grd
            grid.Item(c, r).Style.BackColor = color
            grid.Item(c, r).Style.SelectionBackColor = color
        End If

    End Sub
    Public Function getBackgroundColor(ByVal grd As Object, ByVal r As Integer, ByVal c As Integer) As Color

        Dim grid As DataGridView = grd
        getBackgroundColor = grid.Item(c, r).Style.BackColor

    End Function
    Public Sub setToolTableGrid(ByVal grd As Object)

        Dim grid As DataGridView = grd

        setSize(grd, 1, tsMan.TotalStations)

        For i = 0 To tsMan.TotalStations - 1

            If tsMan.aStations(i).ToolStation > tsMan.MaxStations Then
                setBackgroundColor(grid, 0, tsMan.aStations(i).ColumnNumber, Color.LightGray)
            Else
                setBackgroundColor(grid, 0, tsMan.aStations(i).ColumnNumber, Color.White)
            End If


            If tsMan.aStations(i).DeepStation Then
                columnHeader(grd, tsMan.aStations(i).ColumnNumber, (tsMan.aStations(i).ToolStation).ToString & "*")
                setBackgroundColor(grid, 0, tsMan.aStations(i).ColumnNumber, Color.LightCyan)
            Else
                columnHeader(grd, tsMan.aStations(i).ColumnNumber, tsMan.aStations(i).ToolStation.ToString)
            End If

            columnWidth(grd, i, 60)
            setCell(grd, 0, i, "")
            grid.Columns.Item(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grid.Columns.Item(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            grid.Columns(i).ReadOnly = True

        Next

    End Sub
    Public Sub PlaceCellEntryObject(ByVal g As DataGridView, ByVal t As Object, ByVal rw As Integer, ByVal cl As Integer)

        t.Visible = False

        Dim rect As System.Drawing.Rectangle = g.GetCellDisplayRectangle(cl, rw, False)

        t.width = rect.Width
        t.height = rect.Height
        t.left = rect.X
        t.top = rect.Y

        t.BackColor = Color.PaleGreen

        t.Visible = True
        t.Text = getCell(g, rw, cl)

        t.Focus()
        t.SelectionStart = 0
        t.SelectionLength = t.Text.Length

    End Sub

End Module
