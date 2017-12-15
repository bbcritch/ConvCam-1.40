<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMetaCoder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnIF = New System.Windows.Forms.Button
        Me.cmbV1 = New System.Windows.Forms.ComboBox
        Me.cmbLogic = New System.Windows.Forms.ComboBox
        Me.cmbV2 = New System.Windows.Forms.ComboBox
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnLoop = New System.Windows.Forms.Button
        Me.btnMath = New System.Windows.Forms.Button
        Me.txtScratch = New System.Windows.Forms.RichTextBox
        Me.txtMetaGCODE = New System.Windows.Forms.RichTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnCopyVar = New System.Windows.Forms.Button
        Me.chkCopyToEditor = New System.Windows.Forms.CheckBox
        Me.btnCopyToEditor = New System.Windows.Forms.Button
        Me.btnSaveToTemp = New System.Windows.Forms.Button
        Me.btnSaveToFile = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.dlgSaveFile = New System.Windows.Forms.SaveFileDialog
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog
        Me.btnOpenFile = New System.Windows.Forms.Button
        Me.btnClearAll = New System.Windows.Forms.Button
        Me.btnClearLogic = New System.Windows.Forms.Button
        Me.btnSet = New System.Windows.Forms.Button
        Me.btnSub = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnVariable = New System.Windows.Forms.Button
        Me.btnCond = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnHelp = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnIF
        '
        Me.btnIF.Location = New System.Drawing.Point(19, 5)
        Me.btnIF.Name = "btnIF"
        Me.btnIF.Size = New System.Drawing.Size(53, 20)
        Me.btnIF.TabIndex = 0
        Me.btnIF.Text = "IF"
        Me.btnIF.UseVisualStyleBackColor = True
        '
        'cmbV1
        '
        Me.cmbV1.FormattingEnabled = True
        Me.cmbV1.Location = New System.Drawing.Point(81, 136)
        Me.cmbV1.Name = "cmbV1"
        Me.cmbV1.Size = New System.Drawing.Size(120, 21)
        Me.cmbV1.Sorted = True
        Me.cmbV1.TabIndex = 1
        '
        'cmbLogic
        '
        Me.cmbLogic.FormattingEnabled = True
        Me.cmbLogic.Items.AddRange(New Object() {"EqualTo eq", "GreaterThan gt", "GreaterThanOrEqual gte", "LessThan lt", "LessThanOrEqual lte", "NotEqualTo ne"})
        Me.cmbLogic.Location = New System.Drawing.Point(207, 136)
        Me.cmbLogic.Name = "cmbLogic"
        Me.cmbLogic.Size = New System.Drawing.Size(133, 21)
        Me.cmbLogic.TabIndex = 2
        '
        'cmbV2
        '
        Me.cmbV2.FormattingEnabled = True
        Me.cmbV2.Location = New System.Drawing.Point(346, 136)
        Me.cmbV2.Name = "cmbV2"
        Me.cmbV2.Size = New System.Drawing.Size(120, 21)
        Me.cmbV2.Sorted = True
        Me.cmbV2.TabIndex = 3
        '
        'cmbType
        '
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Alpha", "Num", "Rel", "Cumu"})
        Me.cmbType.Location = New System.Drawing.Point(472, 136)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(63, 21)
        Me.cmbType.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(131, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "V1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(392, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "V2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Logic"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(473, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Alpha/Num"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(106, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Loop Variable"
        '
        'btnLoop
        '
        Me.btnLoop.Location = New System.Drawing.Point(19, 25)
        Me.btnLoop.Name = "btnLoop"
        Me.btnLoop.Size = New System.Drawing.Size(53, 20)
        Me.btnLoop.TabIndex = 10
        Me.btnLoop.Text = "LOOP"
        Me.btnLoop.UseVisualStyleBackColor = True
        '
        'btnMath
        '
        Me.btnMath.Location = New System.Drawing.Point(19, 46)
        Me.btnMath.Name = "btnMath"
        Me.btnMath.Size = New System.Drawing.Size(53, 21)
        Me.btnMath.TabIndex = 14
        Me.btnMath.Text = "MATH"
        Me.btnMath.UseVisualStyleBackColor = True
        '
        'txtScratch
        '
        Me.txtScratch.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScratch.Location = New System.Drawing.Point(20, 191)
        Me.txtScratch.Name = "txtScratch"
        Me.txtScratch.Size = New System.Drawing.Size(514, 85)
        Me.txtScratch.TabIndex = 15
        Me.txtScratch.Text = ""
        Me.txtScratch.WordWrap = False
        '
        'txtMetaGCODE
        '
        Me.txtMetaGCODE.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMetaGCODE.Location = New System.Drawing.Point(19, 282)
        Me.txtMetaGCODE.Name = "txtMetaGCODE"
        Me.txtMetaGCODE.Size = New System.Drawing.Size(514, 312)
        Me.txtMetaGCODE.TabIndex = 16
        Me.txtMetaGCODE.Text = ""
        Me.txtMetaGCODE.WordWrap = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(89, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Destination Variable"
        '
        'btnCopyVar
        '
        Me.btnCopyVar.Location = New System.Drawing.Point(19, 134)
        Me.btnCopyVar.Name = "btnCopyVar"
        Me.btnCopyVar.Size = New System.Drawing.Size(53, 22)
        Me.btnCopyVar.TabIndex = 18
        Me.btnCopyVar.Text = "CpyVar"
        Me.btnCopyVar.UseVisualStyleBackColor = True
        '
        'chkCopyToEditor
        '
        Me.chkCopyToEditor.AutoSize = True
        Me.chkCopyToEditor.Location = New System.Drawing.Point(19, 163)
        Me.chkCopyToEditor.Name = "chkCopyToEditor"
        Me.chkCopyToEditor.Size = New System.Drawing.Size(75, 17)
        Me.chkCopyToEditor.TabIndex = 19
        Me.chkCopyToEditor.Text = "Auto Copy"
        Me.chkCopyToEditor.UseVisualStyleBackColor = True
        '
        'btnCopyToEditor
        '
        Me.btnCopyToEditor.Location = New System.Drawing.Point(100, 163)
        Me.btnCopyToEditor.Name = "btnCopyToEditor"
        Me.btnCopyToEditor.Size = New System.Drawing.Size(86, 20)
        Me.btnCopyToEditor.TabIndex = 20
        Me.btnCopyToEditor.Text = "Copy to Editor"
        Me.btnCopyToEditor.UseVisualStyleBackColor = True
        '
        'btnSaveToTemp
        '
        Me.btnSaveToTemp.Location = New System.Drawing.Point(155, 600)
        Me.btnSaveToTemp.Name = "btnSaveToTemp"
        Me.btnSaveToTemp.Size = New System.Drawing.Size(86, 23)
        Me.btnSaveToTemp.TabIndex = 21
        Me.btnSaveToTemp.Text = "Save to Temp"
        Me.btnSaveToTemp.UseVisualStyleBackColor = True
        '
        'btnSaveToFile
        '
        Me.btnSaveToFile.Location = New System.Drawing.Point(247, 600)
        Me.btnSaveToFile.Name = "btnSaveToFile"
        Me.btnSaveToFile.Size = New System.Drawing.Size(86, 23)
        Me.btnSaveToFile.TabIndex = 22
        Me.btnSaveToFile.Text = "Save to File"
        Me.btnSaveToFile.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(597, 600)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(109, 23)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(463, 600)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(70, 23)
        Me.btnOK.TabIndex = 23
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.FileName = "OpenFileDialog1"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(19, 600)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(109, 23)
        Me.btnOpenFile.TabIndex = 25
        Me.btnOpenFile.Text = "Open File"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'btnClearAll
        '
        Me.btnClearAll.Location = New System.Drawing.Point(283, 163)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(62, 20)
        Me.btnClearAll.TabIndex = 26
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'btnClearLogic
        '
        Me.btnClearLogic.Location = New System.Drawing.Point(207, 163)
        Me.btnClearLogic.Name = "btnClearLogic"
        Me.btnClearLogic.Size = New System.Drawing.Size(70, 20)
        Me.btnClearLogic.TabIndex = 27
        Me.btnClearLogic.Text = "Clear Logic"
        Me.btnClearLogic.UseVisualStyleBackColor = True
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(19, 68)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(53, 20)
        Me.btnSet.TabIndex = 28
        Me.btnSet.Text = "SET"
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'btnSub
        '
        Me.btnSub.Location = New System.Drawing.Point(19, 89)
        Me.btnSub.Name = "btnSub"
        Me.btnSub.Size = New System.Drawing.Size(53, 20)
        Me.btnSub.TabIndex = 29
        Me.btnSub.Text = "SUBST"
        Me.btnSub.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(89, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(206, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Destination Variable = ScratchBox (literals)"
        '
        'btnVariable
        '
        Me.btnVariable.Location = New System.Drawing.Point(400, 163)
        Me.btnVariable.Name = "btnVariable"
        Me.btnVariable.Size = New System.Drawing.Size(133, 21)
        Me.btnVariable.TabIndex = 31
        Me.btnVariable.Text = "Add Variable (no spaces)"
        Me.btnVariable.UseVisualStyleBackColor = True
        '
        'btnCond
        '
        Me.btnCond.Location = New System.Drawing.Point(19, 108)
        Me.btnCond.Name = "btnCond"
        Me.btnCond.Size = New System.Drawing.Size(53, 20)
        Me.btnCond.TabIndex = 32
        Me.btnCond.Text = "COND"
        Me.btnCond.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(89, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Destination Variable"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(367, 111)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Source Variable"
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(370, 602)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(60, 21)
        Me.btnHelp.TabIndex = 35
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmMetaCoder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 627)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnCond)
        Me.Controls.Add(Me.btnVariable)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnSub)
        Me.Controls.Add(Me.btnSet)
        Me.Controls.Add(Me.btnClearLogic)
        Me.Controls.Add(Me.btnClearAll)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnSaveToFile)
        Me.Controls.Add(Me.btnSaveToTemp)
        Me.Controls.Add(Me.btnCopyToEditor)
        Me.Controls.Add(Me.chkCopyToEditor)
        Me.Controls.Add(Me.btnCopyVar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtMetaGCODE)
        Me.Controls.Add(Me.txtScratch)
        Me.Controls.Add(Me.btnMath)
        Me.Controls.Add(Me.btnLoop)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.cmbV2)
        Me.Controls.Add(Me.cmbLogic)
        Me.Controls.Add(Me.cmbV1)
        Me.Controls.Add(Me.btnIF)
        Me.Name = "frmMetaCoder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmMetaCoder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnIF As System.Windows.Forms.Button
    Friend WithEvents cmbV1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLogic As System.Windows.Forms.ComboBox
    Friend WithEvents cmbV2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnLoop As System.Windows.Forms.Button
    Friend WithEvents btnMath As System.Windows.Forms.Button
    Friend WithEvents txtScratch As System.Windows.Forms.RichTextBox
    Friend WithEvents txtMetaGCODE As System.Windows.Forms.RichTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCopyVar As System.Windows.Forms.Button
    Friend WithEvents chkCopyToEditor As System.Windows.Forms.CheckBox
    Friend WithEvents btnCopyToEditor As System.Windows.Forms.Button
    Friend WithEvents btnSaveToTemp As System.Windows.Forms.Button
    Friend WithEvents btnSaveToFile As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents dlgSaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnOpenFile As System.Windows.Forms.Button
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnClearLogic As System.Windows.Forms.Button
    Friend WithEvents btnSet As System.Windows.Forms.Button
    Friend WithEvents btnSub As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnVariable As System.Windows.Forms.Button
    Friend WithEvents btnCond As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
