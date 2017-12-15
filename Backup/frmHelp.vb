Public Class frmHelp

    Private Sub dgvTopics_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTopics.CellClick

        Dim rw As Integer
        Dim cl As Integer

        getRowCol(dgvTopics, rw, cl)

        Dim topic As String = getCell(dgvTopics, rw, cl)

        If topic <> "" Then LoadHelpFiles(topic)
    End Sub


    Private Sub frmHelp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadTopics()
        setActiveCell(dgvTopics, 0, 0)
        LoadHelpFiles(getCell(dgvTopics, 0, 0))
    End Sub
    Private Sub LoadHelpFiles(ByVal topic As String)

        Dim cp As New convCamPaths
        Dim f As New fileManager

        brsHelp.Navigate(cp.Path(cp.Help, topic.Trim & ".pdf"))
        rtbHelp.Text = f.fileRead(cp.Path(cp.Help, topic.Trim & ".txt"))

    End Sub
    Private Sub LoadTopics()

        Dim fPath As String
        Dim cp As New convCamPaths
        Dim f As New fileManager


        fPath = cp.Path(cp.Help, "HelpContents.txt")
        Dim topic As String = f.fileRead(fPath)

        topic.Replace(vbCrLf, vbLf)
        Dim topicAry() = topic.Trim.Split(vbLf)

        dgvTopics.RowCount = topicAry.Length

        For i = 0 To topicAry.Length - 1
            If topicAry(i) <> "" Then setCell(dgvTopics, i, 0, topicAry(i).Replace(vbLf, "").Replace(vbCr, ""))
        Next

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim f As New fileManager
        Dim fPath As String
        Dim topic As String
        Dim cp As New convCamPaths

        Dim rw As Integer
        Dim cl As Integer

        getRowCol(dgvTopics, rw, cl)

        topic = getCell(dgvTopics, rw, cl).Trim
        fPath = cp.Path(cp.Help, topic & ".txt")

        f.fileWrite(fPath, rtbHelp.Text.Trim(" ", vbCr, vbLf))

    End Sub

End Class