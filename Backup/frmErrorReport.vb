Public Class frmErrorReport
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub frmErrorReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rtbReport.Text = sReportFinal
    End Sub
End Class