<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuickStateViewer
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
        Me.txtQuickState = New System.Windows.Forms.RichTextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtQuickState
        '
        Me.txtQuickState.Location = New System.Drawing.Point(9, 4)
        Me.txtQuickState.Name = "txtQuickState"
        Me.txtQuickState.Size = New System.Drawing.Size(489, 352)
        Me.txtQuickState.TabIndex = 0
        Me.txtQuickState.Text = ""
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(216, 362)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(82, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmQuickStateViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 389)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtQuickState)
        Me.Name = "frmQuickStateViewer"
        Me.Text = "frmQuickStateViewer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtQuickState As System.Windows.Forms.RichTextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
