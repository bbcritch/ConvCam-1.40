<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartResolution
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPartResolution))
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnOverwrite = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNewDelim = New System.Windows.Forms.TextBox
        Me.lblNewBlank = New System.Windows.Forms.Label
        Me.lblLibraryBlank = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 314)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(139, 32)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add as New Blank"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnOverwrite
        '
        Me.btnOverwrite.Location = New System.Drawing.Point(176, 314)
        Me.btnOverwrite.Name = "btnOverwrite"
        Me.btnOverwrite.Size = New System.Drawing.Size(139, 32)
        Me.btnOverwrite.TabIndex = 1
        Me.btnOverwrite.Text = "Overwrite Existing Blank"
        Me.btnOverwrite.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(341, 314)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(139, 32)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(468, 131)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 356)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "New ID:"
        '
        'txtNewDelim
        '
        Me.txtNewDelim.Location = New System.Drawing.Point(69, 352)
        Me.txtNewDelim.Name = "txtNewDelim"
        Me.txtNewDelim.Size = New System.Drawing.Size(82, 20)
        Me.txtNewDelim.TabIndex = 5
        '
        'lblNewBlank
        '
        Me.lblNewBlank.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNewBlank.Location = New System.Drawing.Point(12, 9)
        Me.lblNewBlank.Name = "lblNewBlank"
        Me.lblNewBlank.Size = New System.Drawing.Size(228, 157)
        Me.lblNewBlank.TabIndex = 6
        '
        'lblLibraryBlank
        '
        Me.lblLibraryBlank.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLibraryBlank.Location = New System.Drawing.Point(253, 9)
        Me.lblLibraryBlank.Name = "lblLibraryBlank"
        Me.lblLibraryBlank.Size = New System.Drawing.Size(227, 157)
        Me.lblLibraryBlank.TabIndex = 7
        '
        'frmPartResolution
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 377)
        Me.Controls.Add(Me.lblLibraryBlank)
        Me.Controls.Add(Me.lblNewBlank)
        Me.Controls.Add(Me.txtNewDelim)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOverwrite)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "frmPartResolution"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmPartResolution"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnOverwrite As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewDelim As System.Windows.Forms.TextBox
    Friend WithEvents lblNewBlank As System.Windows.Forms.Label
    Friend WithEvents lblLibraryBlank As System.Windows.Forms.Label
End Class
