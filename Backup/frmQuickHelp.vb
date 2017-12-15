Public Class frmQuickHelp

    Public sHelp As String
    Public sTitle As String

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Close()
    End Sub
    Private Sub frmQuickHelp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rtbHelpText.Text = sHelp
        Me.Text = sTitle
    End Sub
End Class