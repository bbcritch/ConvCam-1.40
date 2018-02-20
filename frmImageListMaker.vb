Public Class frmImageListMaker

    Private Sub frmImageListMaker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadList()
    End Sub
    Private Sub loadList()

        Me.lstImageList.Items.Clear()
        If glbImageList = "" Then Exit Sub

        Dim s() As String = glbImageList.Split(":")

        For i = 0 To s.Length - 1
            lstImageList.Items.Add(s(i))
        Next

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        glbImageList = ""
        If lstImageList.Items.Count = 0 Then Exit Sub

        For i = 0 To lstImageList.Items.Count - 1
            glbImageList += lstImageList.Items(i) & "#"
        Next

        If glbImageList.Substring(glbImageList.Length - 1, 1) = "#" Then
            glbImageList = glbImageList.Substring(0, glbImageList.Length - 2)
        End If

        Me.Close()

    End Sub

    Private Sub btnAddToList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToList.Click

        If lblImageName.Text = " then" Then
            MsgBox("Select an image")
            Exit Sub
        End If

        If txtTabName.Text = "" Then
            MsgBox("Enter a tab name")
            Exit Sub
        End If

        lstImageList.Items.Add(lblImageName.Text & "%" & txtTabName.Text)

    End Sub

    Private Sub btnGetImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetImage.Click
        Dim f As New fileManager, od As New OpenFileDialog, fname As String

        od.Reset()
        od.Filter = "Picture Files (*.bmp)|*.bmp|JPEG (jpg.*)|jpg.*"
        od.FileName = ""
        od.InitialDirectory = gPath.addSlash(gPath.picturesPath)
        od.ShowDialog()

        If DialogResult <> Windows.Forms.DialogResult.Cancel Then
            fname = f.fileNameOnly(od.FileName)
            lblImageName.Text = fname
        End If
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        lstImageList.Items.Clear()
    End Sub

    Private Sub btnDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteSelected.Click
        lstImageList.Items.Remove(lstImageList.SelectedItem)
    End Sub

    Private Sub btnSame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSame.Click
        glbImageList = "same"
        Me.Close()
    End Sub
End Class