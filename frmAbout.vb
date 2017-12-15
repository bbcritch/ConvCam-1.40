Public NotInheritable Class frmAbout

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Set the title of the form.
        Dim ApplicationTitle As String = GetProgramInfo("TITLE")
        Me.Text = String.Format("About {0}", ApplicationTitle)
        Me.LabelProductName.Text = GetProgramInfo("NAME")
        Me.LabelVersion.Text = GetProgramInfo("VERSION")
        Me.LabelCopyright.Text = GetProgramInfo("COPYRIGHT")
        Me.LabelCompanyName.Text = GetProgramInfo("COMPANY")
        Me.TextBoxDescription.Text = GetProgramInfo("DESCRIPTION")
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
