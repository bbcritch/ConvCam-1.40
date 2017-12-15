Public Class frmMetaCoder

    Dim localStateList As New myList
    Dim codeDirectory

    Private Sub btnIF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIF.Click

        Dim a() As String

        a = cmbLogic.Text.Split(" ")

        txtScratch.Text = "#IF" & vF(cmbV1.Text) & a(1) & vF(cmbV2.Text)
        txtScratch.Text = txtScratch.Text & cmbType.Text & vbLf & "#ENDIF"
        updateCombos()
        copyToEditorCheck()

    End Sub
    Private Sub btnLoop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoop.Click

        txtScratch.Text = "#SET" & vF(cmbV1.Text) & "= ?" & vbLf
        txtScratch.Text = txtScratch.Text & "#LOOP" & vF(cmbV1.Text)
        txtScratch.Text = txtScratch.Text & cmbType.Text & vbLf & "#ENDLOOP"
        updateCombos()
        copyToEditorCheck()

    End Sub
    Private Sub btnMath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMath.Click

        frmCalculator.ShowDialog()
        txtScratch.Text = "#MATH " & vF(cmbV1.Text).Trim & "=" & modGlobal.calcCommands
        copyToEditorCheck()

    End Sub
    Private Function vF(ByVal s As String) As String

        vF = " |" & s & "| "

    End Function
    Private Sub frmMetaCoder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim x As New myXmlUtils, f As New fileManager, fname As String

        localStateList.setList(x.extract(processFileContent, "VARIABLES"))
        localStateList.setListAppend(DL & dh.getToolParameterList)

        If metaGcodeFileName <> "" Then

            fname = gPath.addSlash(gPath.templateCodePath) & metaGcodeFileName
            If f.filePresent(fname) Then

                txtMetaGCODE.Text = f.fileRead(fname)
                pullVariables()

            End If

        End If

        loadVarCombos()

    End Sub
    Private Sub loadVarCombos()

        cmbV1.Items.Clear()
        cmbV2.Items.Clear()

        For i = 0 To localStateList.length(DL) - 1

            If localStateList.getItem(i, DL) <> "" Then
                cmbV1.Items.Add(localStateList.getItem(i, DL))
                cmbV2.Items.Add(localStateList.getItem(i, DL))
            End If

        Next

    End Sub
    Private Sub updateCombos()

        If cmbV1.Text <> "" Then localStateList.add(cmbV1.Text, DL, True)
        If cmbV2.Text <> "" Then localStateList.add(cmbV2.Text, DL, True)

        loadVarCombos()

    End Sub
    Private Sub btnCopyVar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyVar.Click
        txtScratch.Text = vF(cmbV1.Text)
        copyToEditorCheck()
    End Sub
    Private Sub copyToEditorCheck()

        If chkCopyToEditor.Checked Then copyToEditor()

    End Sub
    Private Sub copyToEditor()

        txtMetaGCODE.Text = txtMetaGCODE.Text & vbLf & txtScratch.Text

    End Sub
    Private Sub btnCopyToEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyToEditor.Click
        copyToEditor()
    End Sub
    Private Sub btnSaveToTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveToTemp.Click

        Dim f As New fileManager

        f.fileWrite(gPath.addSlash(gPath.templateCodePath) & "temp.txt", txtMetaGCODE.Text)

    End Sub
    Private Sub btnSaveToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveToFile.Click

        saveMetaGcode()

    End Sub
    Private Sub btnOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFile.Click

        Dim f As New fileManager

        If codeDirectory = "" Then codeDirectory = gPath.templateCodePath

        dlgOpenFile.Reset()
        dlgOpenFile.InitialDirectory = codeDirectory
        If dlgOpenFile.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then

            If f.filePresent(dlgOpenFile.FileName) Then
                txtMetaGCODE.Text = f.fileRead(dlgOpenFile.FileName)
                localStateList.setList("")
                pullVariables()
            End If

        End If

        loadVarCombos()

    End Sub
    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click


        If MsgBox("Are you sure you want to clear everything?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            txtMetaGCODE.Text = ""
            txtScratch.Text = ""
            clearLogic()

        End If

    End Sub
    Private Sub btnClearLogic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLogic.Click
        clearLogic()
    End Sub
    Private Sub clearLogic()

        cmbLogic.Text = ""
        cmbType.Text = ""
        cmbV1.Text = ""
        cmbV2.Text = ""

    End Sub
    Private Sub pullVariables()

        Dim p1 As Integer = 0, p2 As Integer = 0, s As String = ""

        While p1 >= 0 And p2 >= 0

            p1 = txtMetaGCODE.Text.IndexOf("|", p2)
            If p1 >= 0 Then p2 = txtMetaGCODE.Text.IndexOf("|", p1 + 1)

            If p1 >= 0 And p2 > p1 Then

                localStateList.add(txtMetaGCODE.Text.Substring(p1 + 1, p2 - p1 - 1), DL, True)
                p2 += 1

            End If

        End While

    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        metaGcodeFileName = saveMetaGcode()
        Me.Close()
    End Sub
    Private Function saveMetaGcode() As String

        Dim f As New fileManager

        saveMetaGcode = ""

        If codeDirectory = "" Then codeDirectory = gPath.templateCodePath

        dlgSaveFile.Reset()
        dlgSaveFile.InitialDirectory = codeDirectory
        If dlgSaveFile.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then

            f.fileWrite(dlgSaveFile.FileName, txtMetaGCODE.Text)
            saveMetaGcode = f.fileNameOnly(dlgSaveFile.FileName)

        End If

    End Function
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click

        txtScratch.Text = "#SET " & vF(cmbV1.Text).Trim & " = " & txtScratch.Text.Trim
        updateCombos()
        copyToEditorCheck()

    End Sub
    Private Sub btnSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSub.Click
        Dim f As New fileManager

        txtScratch.Text = f.fileRead(gPath.addSlash(gPath.resourcesPath) & "Substititution Syntax.txt")
    End Sub
    Private Sub btnVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVariable.Click

        If cmbV1.Text <> "" Then
            varList.add(cmbV1.Text.Replace(" ", ""), DL, True)
            localStateList.setListAppend(DL & cmbV1.Text.Replace(" ", ""))
            loadVarCombos()
        End If

    End Sub
    Private Sub btnCond_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCond.Click
        txtScratch.Text = "#COND " & vF(cmbV1.Text).Trim & " = " & vF(cmbV2.Text).Trim
        copyToEditorCheck()
    End Sub
    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click
        HELPFILE = gPath.ConfigFilePath("\HelpFiles\MetaGcodeHelp.txt")
        frmGenEdit.ShowDialog()
    End Sub
End Class