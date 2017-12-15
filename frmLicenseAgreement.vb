Public Class frmLicenseAgreement

    Private Sub frmLicenseAgreement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim f As New fileManager
        Dim cp As New convCamPaths

        LicenseAgreementOK = False
        rtbAgreement.Text = GetProgramInfo("LICENSE")

    End Sub

    Private Sub btnAgree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgree.Click
        LicenseAgreementOK = True
        Me.Close()
    End Sub

    Private Sub btnDisagree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisagree.Click
        Me.Close()
    End Sub
End Class