Public Class frmListEditor

    Private Sub listEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ary() As String

        Select Case editorDesignator

            Case "Help Editor", "State Description", "Group Description", "Toolpath Description"
                Me.Text = editorDesignator
                txtEditor.Text = editorString
            Case Else
                Me.Text = "List Editor"
                If editorString <> "" Then
                    ary = editorString.Split(editorDesignator)
                    For i = 0 To ary.Length - 1
                        If i = 0 Then
                            txtEditor.Text = ary(0)
                        Else
                            txtEditor.Text = txtEditor.Text & vbLf & ary(i)
                        End If
                    Next
                End If
        End Select

    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Dim ary() As String

        editorString = ""

        Select Case editorDesignator

            Case "Help Editor", "State Description", "Group Description", "Toolpath Description"
                editorString = txtEditor.Text
            Case Else
                If txtEditor.Text <> "" Then
                    ary = txtEditor.Text.Split(vbLf)
                    For i = 0 To ary.Length - 1
                        If i = 0 Then
                            editorString = ary(0)
                        Else
                            editorString = editorString & editorDesignator & ary(i)
                        End If
                    Next
                End If
        End Select

        Me.Close()

    End Sub

End Class