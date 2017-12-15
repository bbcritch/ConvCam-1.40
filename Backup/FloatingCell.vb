Public Class FloatingCell

    Public nCurrentRow As Integer
    Public nCurrentColumn As Integer

    Private m_type As String

    Private m_cmbCell As New ComboBox
    Private m_txtCell As New TextBox
    Private obj As New Object

    Private DGV As New DataGridView

    Public Sub PlaceCell(ByVal newRow As String, ByVal newCol As String)

        Dim type As String = getCell(DGV, newRow, frmConvCAM.COLTYPE)
        Dim valu As String = getCell(DGV, newRow, frmConvCAM.VARCOLUMN)

        hideFloatingCells()

        nCurrentRow = newRow
        nCurrentColumn = newCol

        If type <> "" Then
            setType(type)
        Else
            setType("text")
        End If

        alignToTable()
        setValue(valu)

    End Sub
    Public Sub setObjects(ByVal newDGV As DataGridView, ByVal newText As TextBox, ByVal newCombo As ComboBox)
        DGV = newDGV
        m_cmbCell = newCombo
        m_txtCell = newText
        hideFloatingCells()
    End Sub
    Public Sub alignToTable()

        Try
            Dim rect As System.Drawing.Rectangle = DGV.GetCellDisplayRectangle(nCurrentColumn, nCurrentRow, False)

            If rect.Width <= 0 Or rect.Height <= 0 Or rect.Left < 0 Or rect.Top < 0 Then
                obj.visible = False
                Exit Sub
            End If

            If rect.Top > frmConvCAM.pnlInputs.Height - rect.Height Then
                obj.visible = False
                Exit Sub
            End If

            obj.width = rect.Width
            obj.height = rect.Height
            obj.left = rect.X
            obj.top = rect.Y
            obj.visible = True

            obj.backcolor = Color.PaleGreen

            obj.Focus()
            obj.SelectionStart = 0
            obj.SelectionLength = obj.Text.Length
        Catch
            Dim q As Integer = 2 ' DUMMY STATEMENT
        End Try

    End Sub
    Public Sub setType(ByVal type As String)

        Select Case type
            Case "text"

                obj = m_txtCell
                m_type = "text"


            Case Else

                Dim tList As New myList
                tList.setList(type)
                m_cmbCell.Items.Clear()

                For i = 0 To tList.length(DL) - 1
                    m_cmbCell.Items.Add(tList.getItem(i, DL))
                Next

                obj = m_cmbCell
                m_type = "combo"

        End Select

    End Sub
    Public Sub setValue(ByVal valu As String)

        Select Case m_type
            Case "text"
                m_txtCell.Text = valu.Trim
            Case Else
                m_cmbCell.Text = valu.Trim
        End Select

        obj.Focus()
        obj.SelectionStart = 0
        obj.SelectionLength = obj.Text.Length

    End Sub

    Public Function getValue() As String

        Select Case m_type
            Case "text"
                getValue = m_txtCell.Text.Trim
            Case Else
                getValue = m_cmbCell.Text.Trim
        End Select


    End Function
    Public Sub hideFloatingCells()

        m_cmbCell.Visible = False
        m_txtCell.Visible = False

    End Sub
    Public Sub getValuFromTable()

        obj.text = getCell(DGV, nCurrentRow, nCurrentColumn).Trim

    End Sub
    Public Sub setTableFromValue()

        Dim valu As String, varName As String

        setCell(DGV, nCurrentRow, frmConvCAM.VARCOLUMN, obj.text.trim)

        valu = obj.text.trim
        varName = getCell(DGV, nCurrentRow, frmConvCAM.STATENAMECOL)

        '' ''If varName.Substring(0, 1) = "u" And DISPUNITS = METRIC Then
        '' ''    valu = ToEnglish(valu)
        '' ''End If

        If varName <> "" Then stateVars.setVar(varName, valu, DISPUNITS)

    End Sub
    Public Sub FlagBadInput()

        obj.backcolor = Color.LightPink
        '' ''obj.Text = ""

        obj.Focus()
        obj.SelectionStart = 0
        obj.SelectionLength = obj.Text.Length

    End Sub
    Public Function getCurrentRow() As Integer
        getCurrentRow = nCurrentRow
    End Function
End Class

