<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuickHelp
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
        Me.rtbHelpText = New System.Windows.Forms.RichTextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'rtbHelpText
        '
        Me.rtbHelpText.Location = New System.Drawing.Point(9, 6)
        Me.rtbHelpText.Name = "rtbHelpText"
        Me.rtbHelpText.Size = New System.Drawing.Size(394, 127)
        Me.rtbHelpText.TabIndex = 0
        Me.rtbHelpText.Text = ""
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(172, 142)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(67, 22)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmQuickHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 169)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.rtbHelpText)
        Me.Name = "frmQuickHelp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Help"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbHelpText As System.Windows.Forms.RichTextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
