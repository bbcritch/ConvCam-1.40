<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHelp
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
        Me.rtbHelp = New System.Windows.Forms.RichTextBox
        Me.dgvTopics = New System.Windows.Forms.DataGridView
        Me.Topics = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblTopics = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.brsHelp = New System.Windows.Forms.WebBrowser
        CType(Me.dgvTopics, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rtbHelp
        '
        Me.rtbHelp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbHelp.Location = New System.Drawing.Point(758, 36)
        Me.rtbHelp.Name = "rtbHelp"
        Me.rtbHelp.Size = New System.Drawing.Size(154, 510)
        Me.rtbHelp.TabIndex = 1
        Me.rtbHelp.Text = ""
        '
        'dgvTopics
        '
        Me.dgvTopics.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvTopics.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTopics.ColumnHeadersVisible = False
        Me.dgvTopics.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Topics})
        Me.dgvTopics.Location = New System.Drawing.Point(12, 36)
        Me.dgvTopics.Name = "dgvTopics"
        Me.dgvTopics.RowHeadersVisible = False
        Me.dgvTopics.Size = New System.Drawing.Size(141, 534)
        Me.dgvTopics.TabIndex = 2
        '
        'Topics
        '
        Me.Topics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Topics.HeaderText = "Topics"
        Me.Topics.Name = "Topics"
        Me.Topics.ReadOnly = True
        '
        'lblTopics
        '
        Me.lblTopics.AutoSize = True
        Me.lblTopics.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTopics.Location = New System.Drawing.Point(28, 16)
        Me.lblTopics.Name = "lblTopics"
        Me.lblTopics.Size = New System.Drawing.Size(93, 16)
        Me.lblTopics.TabIndex = 3
        Me.lblTopics.Text = "Help Topics"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(801, 549)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(78, 21)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save Notes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(816, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Notes"
        '
        'brsHelp
        '
        Me.brsHelp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.brsHelp.Location = New System.Drawing.Point(160, 39)
        Me.brsHelp.MinimumSize = New System.Drawing.Size(20, 20)
        Me.brsHelp.Name = "brsHelp"
        Me.brsHelp.Size = New System.Drawing.Size(588, 531)
        Me.brsHelp.TabIndex = 6
        '
        'frmHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 573)
        Me.Controls.Add(Me.brsHelp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblTopics)
        Me.Controls.Add(Me.dgvTopics)
        Me.Controls.Add(Me.rtbHelp)
        Me.Name = "frmHelp"
        Me.Text = "Help"
        CType(Me.dgvTopics, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbHelp As System.Windows.Forms.RichTextBox
    Friend WithEvents dgvTopics As System.Windows.Forms.DataGridView
    Friend WithEvents lblTopics As System.Windows.Forms.Label
    Friend WithEvents Topics As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents brsHelp As System.Windows.Forms.WebBrowser
End Class
