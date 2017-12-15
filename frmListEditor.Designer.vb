<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListEditor
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
        Me.txtEditor = New System.Windows.Forms.RichTextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtEditor
        '
        Me.txtEditor.Location = New System.Drawing.Point(21, 13)
        Me.txtEditor.Name = "txtEditor"
        Me.txtEditor.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtEditor.Size = New System.Drawing.Size(269, 224)
        Me.txtEditor.TabIndex = 0
        Me.txtEditor.Text = ""
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(120, 243)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(81, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmListEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 273)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtEditor)
        Me.Name = "frmListEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "listEditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtEditor As System.Windows.Forms.RichTextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
