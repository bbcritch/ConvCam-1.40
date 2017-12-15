<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFixedToolbox
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grdToolLibrary = New System.Windows.Forms.DataGridView
        Me.ToolDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblToolTable = New System.Windows.Forms.Label
        Me.lblToolLibrary = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.grdToolStations = New System.Windows.Forms.DataGridView
        Me.cmbToolSets = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkAuto = New System.Windows.Forms.CheckBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.Station = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Deep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MfgId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Spacer = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.grdToolLibrary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdToolStations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdToolLibrary
        '
        Me.grdToolLibrary.AllowUserToResizeColumns = False
        Me.grdToolLibrary.AllowUserToResizeRows = False
        Me.grdToolLibrary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdToolLibrary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ToolDescription})
        Me.grdToolLibrary.Location = New System.Drawing.Point(239, 26)
        Me.grdToolLibrary.Name = "grdToolLibrary"
        Me.grdToolLibrary.RowHeadersVisible = False
        Me.grdToolLibrary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdToolLibrary.Size = New System.Drawing.Size(214, 404)
        Me.grdToolLibrary.TabIndex = 1
        '
        'ToolDescription
        '
        Me.ToolDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ToolDescription.HeaderText = "Tool Description"
        Me.ToolDescription.Name = "ToolDescription"
        Me.ToolDescription.ReadOnly = True
        Me.ToolDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'lblToolTable
        '
        Me.lblToolTable.AutoSize = True
        Me.lblToolTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToolTable.Location = New System.Drawing.Point(46, 9)
        Me.lblToolTable.Name = "lblToolTable"
        Me.lblToolTable.Size = New System.Drawing.Size(68, 13)
        Me.lblToolTable.TabIndex = 2
        Me.lblToolTable.Text = "Tool Table"
        '
        'lblToolLibrary
        '
        Me.lblToolLibrary.AutoSize = True
        Me.lblToolLibrary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToolLibrary.Location = New System.Drawing.Point(236, 10)
        Me.lblToolLibrary.Name = "lblToolLibrary"
        Me.lblToolLibrary.Size = New System.Drawing.Size(74, 13)
        Me.lblToolLibrary.TabIndex = 3
        Me.lblToolLibrary.Text = "Tool Library"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(10, 384)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(67, 20)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save Set"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(83, 384)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(81, 20)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "Remove Tool"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatus.Location = New System.Drawing.Point(10, 464)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(443, 21)
        Me.lblStatus.TabIndex = 7
        '
        'grdToolStations
        '
        Me.grdToolStations.AllowUserToResizeColumns = False
        Me.grdToolStations.AllowUserToResizeRows = False
        Me.grdToolStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdToolStations.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Station, Me.Deep, Me.MfgId, Me.Sel, Me.Spacer})
        Me.grdToolStations.Location = New System.Drawing.Point(10, 26)
        Me.grdToolStations.Name = "grdToolStations"
        Me.grdToolStations.RowHeadersVisible = False
        Me.grdToolStations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdToolStations.Size = New System.Drawing.Size(223, 350)
        Me.grdToolStations.TabIndex = 8
        '
        'cmbToolSets
        '
        Me.cmbToolSets.FormattingEnabled = True
        Me.cmbToolSets.Location = New System.Drawing.Point(102, 436)
        Me.cmbToolSets.Name = "cmbToolSets"
        Me.cmbToolSets.Size = New System.Drawing.Size(142, 21)
        Me.cmbToolSets.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 441)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Tool Set Files"
        '
        'chkAuto
        '
        Me.chkAuto.AutoSize = True
        Me.chkAuto.Location = New System.Drawing.Point(250, 438)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(48, 17)
        Me.chkAuto.TabIndex = 11
        Me.chkAuto.Text = "Auto"
        Me.chkAuto.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(10, 410)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(78, 20)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Text = "*  Deep"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Silver
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(83, 410)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(81, 20)
        Me.TextBox2.TabIndex = 13
        Me.TextBox2.Text = "Virtual"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(379, 437)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(74, 20)
        Me.btnOK.TabIndex = 14
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Station
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.Station.DefaultCellStyle = DataGridViewCellStyle5
        Me.Station.HeaderText = "Station"
        Me.Station.Name = "Station"
        Me.Station.ReadOnly = True
        Me.Station.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Station.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Station.Width = 65
        '
        'Deep
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.Deep.DefaultCellStyle = DataGridViewCellStyle6
        Me.Deep.HeaderText = "Deep"
        Me.Deep.Name = "Deep"
        Me.Deep.ReadOnly = True
        Me.Deep.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Deep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Deep.Width = 35
        '
        'MfgId
        '
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.MfgId.DefaultCellStyle = DataGridViewCellStyle7
        Me.MfgId.HeaderText = "Mfg ID"
        Me.MfgId.Name = "MfgId"
        Me.MfgId.ReadOnly = True
        Me.MfgId.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MfgId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MfgId.Width = 70
        '
        'Sel
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.Sel.DefaultCellStyle = DataGridViewCellStyle8
        Me.Sel.HeaderText = "Slct"
        Me.Sel.Name = "Sel"
        Me.Sel.Width = 30
        '
        'Spacer
        '
        Me.Spacer.HeaderText = ""
        Me.Spacer.Name = "Spacer"
        Me.Spacer.ReadOnly = True
        Me.Spacer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Spacer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Spacer.Visible = False
        Me.Spacer.Width = 5
        '
        'frmFixedToolbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 489)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.chkAuto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbToolSets)
        Me.Controls.Add(Me.grdToolStations)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblToolLibrary)
        Me.Controls.Add(Me.lblToolTable)
        Me.Controls.Add(Me.grdToolLibrary)
        Me.Name = "frmFixedToolbox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tool Set Manager"
        CType(Me.grdToolLibrary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdToolStations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdToolLibrary As System.Windows.Forms.DataGridView
    Friend WithEvents lblToolTable As System.Windows.Forms.Label
    Friend WithEvents lblToolLibrary As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents grdToolStations As System.Windows.Forms.DataGridView
    Friend WithEvents cmbToolSets As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkAuto As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Station As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MfgId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Spacer As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
