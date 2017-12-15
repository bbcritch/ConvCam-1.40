Public Class frmGenEdit
    Private Sub frmGenEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim f As New fileManager
        rtbEditor.Text = f.fileRead(HELPFILE)
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim f As New fileManager
        f.fileWrite(HELPFILE, rtbEditor.Text)
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class