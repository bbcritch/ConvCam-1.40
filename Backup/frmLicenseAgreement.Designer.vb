<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicenseAgreement
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
        Me.btnDisagree = New System.Windows.Forms.Button
        Me.btnAgree = New System.Windows.Forms.Button
        Me.rtbAgreement = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'btnDisagree
        '
        Me.btnDisagree.Location = New System.Drawing.Point(361, 502)
        Me.btnDisagree.Name = "btnDisagree"
        Me.btnDisagree.Size = New System.Drawing.Size(287, 23)
        Me.btnDisagree.TabIndex = 0
        Me.btnDisagree.Text = "I do not agree to the terms of this License Agreement"
        Me.btnDisagree.UseVisualStyleBackColor = True
        '
        'btnAgree
        '
        Me.btnAgree.Location = New System.Drawing.Point(7, 502)
        Me.btnAgree.Name = "btnAgree"
        Me.btnAgree.Size = New System.Drawing.Size(339, 23)
        Me.btnAgree.TabIndex = 1
        Me.btnAgree.Text = "I have read and agree to the terms of this License Agreement"
        Me.btnAgree.UseVisualStyleBackColor = True
        '
        'rtbAgreement
        '
        Me.rtbAgreement.Location = New System.Drawing.Point(7, 8)
        Me.rtbAgreement.Name = "rtbAgreement"
        Me.rtbAgreement.Size = New System.Drawing.Size(641, 484)
        Me.rtbAgreement.TabIndex = 2
        Me.rtbAgreement.Text = ""
        '
        'frmLicenseAgreement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 530)
        Me.Controls.Add(Me.rtbAgreement)
        Me.Controls.Add(Me.btnAgree)
        Me.Controls.Add(Me.btnDisagree)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLicenseAgreement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conversational CAM License Agreement"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDisagree As System.Windows.Forms.Button
    Friend WithEvents btnAgree As System.Windows.Forms.Button
    Friend WithEvents rtbAgreement As System.Windows.Forms.RichTextBox
End Class
