Public Class frmSplash

    Private Sub frmSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblCopyright.Text = GetProgramInfo("COPYRIGHT")
        lblVersion.Text = GetProgramInfo("VERSION")
        Me.Refresh()
    End Sub
End Class