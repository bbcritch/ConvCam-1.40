Public Class frmPartInfo

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        abortSave = True
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If ValidateFileName() = False Then Exit Sub
        
        PartFileName = txtPartName.Text
        DesignerName = txtDesigner.Text
        Descriptions = rtbDescriptions.Text

        Me.Close()

    End Sub
    Private Function ValidateFileName()

        Dim f As New fileManager, fName As String

        fName = f.ForceNameValidation(txtPartName.Text)
        txtPartName.Text = fName

        If fName = "" Then
            MsgBox("You must enter a valid file name", MsgBoxStyle.OkOnly)
            ValidateFileName = False
            Exit Function
        End If

        If f.filePresent(gPath.Path(gPath.userPartPath, fName & ".txt")) Then
            If MsgBox("This part file already exists. Do you wish to overwrite it?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                ValidateFileName = False
                Exit Function
            End If
        End If

        ValidateFileName = True

    End Function
    Private Sub frmPartInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        abortSave = False
        txtDesigner.Text = DesignerName
        txtPartName.Text = PartFileName
        rtbDescriptions.Text = Descriptions

        If txtPartName.Text = "" Then
            txtPartName.Text = "enter_part_name"
            txtPartName.SelectionStart = 0
            txtPartName.SelectionLength = txtPartName.Text.Length
        End If

    End Sub

    Private Sub btnChooseFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseFolder.Click

        Dim x As New myXmlUtils
        Dim f As New fileManager

        dlgFolder.SelectedPath = gPath.userPartPath
        dlgFolder.ShowDialog()

        If dlgFolder.SelectedPath <> "" Then
            gPath.makeUserPartPath(dlgFolder.SelectedPath)
            ''f.fileWrite(gPath.Configs & "\partPath.txt", x.add(dlgFolder.SelectedPath, "PATH"))
        End If

    End Sub
End Class