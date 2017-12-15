<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmErrorReport
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
        Me.rtbReport = New System.Windows.Forms.RichTextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'rtbReport
        '
        Me.rtbReport.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbReport.Location = New System.Drawing.Point(12, 12)
        Me.rtbReport.Name = "rtbReport"
        Me.rtbReport.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbReport.Size = New System.Drawing.Size(307, 276)
        Me.rtbReport.TabIndex = 0
        Me.rtbReport.Text = ""
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(119, 301)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(93, 26)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmErrorReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 333)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.rtbReport)
        Me.Name = "frmErrorReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbReport As System.Windows.Forms.RichTextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
