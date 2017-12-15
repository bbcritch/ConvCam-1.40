Public Class frmProcessPicker

    Private Sub frmProcessPicker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitGui()
    End Sub
    Private Sub InitGui()

        Dim x As New myXmlUtils
        Dim tList As New myList

        tList.setList(x.extract(sTempDesignFile, "PROCESSLIST"))
        lstProcesses.Items.Clear()

        For i = 0 To tList.length(DL) - 1
            lstProcesses.Items.Add(tList.getItem(i, DL))
        Next

        txtProcess.Text = tList.getItem(0, DL) 'Units

        lblPartName.Text = "Part Name: " & x.extract(sTempDesignFile, "PARTNAME")

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        sTempDesignFile = ""
        Me.Close()
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        exitOK()
    End Sub
    Private Sub exitOK()

        Dim x As New myXmlUtils

        If SelectedProcess() Then
            sTempDesignFile = x.extract(sTempDesignFile, txtProcess.Text)
            Me.Close()
        Else
            MsgBox("You must select a valid Tool Path", MsgBoxStyle.OkOnly)
        End If

    End Sub
    Private Function SelectedProcess() As Boolean

        Dim x As New myXmlUtils
        Dim tList As New myList

        SelectedProcess = False

        tList.setList(x.extract(sTempDesignFile, "PROCESSLIST"))

        If txtProcess.Text <> "" Then
            If tList.indexOf(txtProcess.Text, DL) >= 0 Then
                SelectedProcess = True
            End If
        End If

    End Function
    Private Sub lstProcesses_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstProcesses.Click
        txtProcess.Text = lstProcesses.SelectedItem.ToString
    End Sub

    Private Sub lstProcesses_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstProcesses.DoubleClick
        txtProcess.Text = lstProcesses.SelectedItem.ToString
        exitOK()
    End Sub
    Private Sub lstProcesses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProcesses.SelectedIndexChanged
        txtProcess.Text = lstProcesses.SelectedItem.ToString
    End Sub
End Class