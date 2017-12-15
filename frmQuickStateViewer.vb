Public Class frmQuickStateViewer

    Private Sub frmQuickStateViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim f As New fileManager

        txtQuickState.Text = f.fileRead(gPath.Path(gPath.resourcesPath, "QuickStates.txt"))

        If MsgBox("Would you like to append this state to Quick States?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            txtQuickState.Text = txtQuickState.Text & vbCrLf & quickStateHolder
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim f As New fileManager

        f.fileWrite(gPath.Path(gPath.resourcesPath, "QuickStates.txt"), txtQuickState.Text)
        Close()

    End Sub
End Class