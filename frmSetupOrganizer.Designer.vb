<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetupOrganizer
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbToolFilter = New System.Windows.Forms.ComboBox()
        Me.picTool = New System.Windows.Forms.PictureBox()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.lblToolType = New System.Windows.Forms.Label()
        Me.chkMyToolsOnly = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblToolDetails = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnRemoveTool = New System.Windows.Forms.Button()
        Me.lblTulType = New System.Windows.Forms.Label()
        Me.cmbToolType = New System.Windows.Forms.ComboBox()
        Me.grdParameters = New System.Windows.Forms.DataGridView()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnglishHeader = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Help = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.spacer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Flags = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlToolType = New System.Windows.Forms.Panel()
        Me.grdItemList = New System.Windows.Forms.DataGridView()
        Me.clmCheck = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFiller = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmGroupBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnUnits = New System.Windows.Forms.Button()
        Me.cmbSort = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSortUp = New System.Windows.Forms.Button()
        CType(Me.picTool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlToolType.SuspendLayout()
        CType(Me.grdItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbToolFilter
        '
        Me.cmbToolFilter.FormattingEnabled = True
        Me.cmbToolFilter.Location = New System.Drawing.Point(46, 4)
        Me.cmbToolFilter.MaxDropDownItems = 15
        Me.cmbToolFilter.Name = "cmbToolFilter"
        Me.cmbToolFilter.Size = New System.Drawing.Size(122, 21)
        Me.cmbToolFilter.TabIndex = 1
        '
        'picTool
        '
        Me.picTool.BackColor = System.Drawing.Color.White
        Me.picTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picTool.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picTool.Location = New System.Drawing.Point(369, 263)
        Me.picTool.Name = "picTool"
        Me.picTool.Size = New System.Drawing.Size(390, 194)
        Me.picTool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picTool.TabIndex = 4
        Me.picTool.TabStop = False
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(369, 463)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(87, 26)
        Me.btnAddNew.TabIndex = 15
        Me.btnAddNew.Text = "New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'lblToolType
        '
        Me.lblToolType.AutoSize = True
        Me.lblToolType.Location = New System.Drawing.Point(3, 8)
        Me.lblToolType.Name = "lblToolType"
        Me.lblToolType.Size = New System.Drawing.Size(29, 13)
        Me.lblToolType.TabIndex = 3
        Me.lblToolType.Text = "Filter"
        '
        'chkMyToolsOnly
        '
        Me.chkMyToolsOnly.AutoSize = True
        Me.chkMyToolsOnly.Location = New System.Drawing.Point(208, 6)
        Me.chkMyToolsOnly.Name = "chkMyToolsOnly"
        Me.chkMyToolsOnly.Size = New System.Drawing.Size(127, 17)
        Me.chkMyToolsOnly.TabIndex = 0
        Me.chkMyToolsOnly.Text = "Show Checked Items"
        Me.chkMyToolsOnly.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnOK.Location = New System.Drawing.Point(670, 463)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(89, 26)
        Me.btnOK.TabIndex = 35
        Me.btnOK.Text = "Select/Exit"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'lblToolDetails
        '
        Me.lblToolDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToolDetails.Location = New System.Drawing.Point(12, 498)
        Me.lblToolDetails.Name = "lblToolDetails"
        Me.lblToolDetails.Size = New System.Drawing.Size(747, 19)
        Me.lblToolDetails.TabIndex = 36
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(569, 463)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(89, 26)
        Me.btnSave.TabIndex = 42
        Me.btnSave.Text = "Save New"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnRemoveTool
        '
        Me.btnRemoveTool.Location = New System.Drawing.Point(469, 463)
        Me.btnRemoveTool.Name = "btnRemoveTool"
        Me.btnRemoveTool.Size = New System.Drawing.Size(87, 26)
        Me.btnRemoveTool.TabIndex = 45
        Me.btnRemoveTool.Text = "Remove"
        Me.btnRemoveTool.UseVisualStyleBackColor = True
        '
        'lblTulType
        '
        Me.lblTulType.AutoSize = True
        Me.lblTulType.Location = New System.Drawing.Point(3, 7)
        Me.lblTulType.Name = "lblTulType"
        Me.lblTulType.Size = New System.Drawing.Size(57, 13)
        Me.lblTulType.TabIndex = 46
        Me.lblTulType.Text = "Item Type:"
        '
        'cmbToolType
        '
        Me.cmbToolType.FormattingEnabled = True
        Me.cmbToolType.Location = New System.Drawing.Point(81, 3)
        Me.cmbToolType.MaxDropDownItems = 15
        Me.cmbToolType.Name = "cmbToolType"
        Me.cmbToolType.Size = New System.Drawing.Size(183, 21)
        Me.cmbToolType.TabIndex = 47
        '
        'grdParameters
        '
        Me.grdParameters.AllowUserToAddRows = False
        Me.grdParameters.AllowUserToResizeColumns = False
        Me.grdParameters.AllowUserToResizeRows = False
        Me.grdParameters.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdParameters.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdParameters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Description, Me.EnglishHeader, Me.Help, Me.spacer, Me.VariableName, Me.Flags})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdParameters.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdParameters.Location = New System.Drawing.Point(369, 43)
        Me.grdParameters.Name = "grdParameters"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdParameters.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdParameters.RowHeadersVisible = False
        Me.grdParameters.RowHeadersWidth = 10
        Me.grdParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdParameters.Size = New System.Drawing.Size(390, 214)
        Me.grdParameters.TabIndex = 48
        '
        'Description
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.Description.DefaultCellStyle = DataGridViewCellStyle2
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Description.Width = 190
        '
        'EnglishHeader
        '
        Me.EnglishHeader.HeaderText = "Value"
        Me.EnglishHeader.Name = "EnglishHeader"
        Me.EnglishHeader.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EnglishHeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EnglishHeader.Width = 130
        '
        'Help
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonFace
        Me.Help.DefaultCellStyle = DataGridViewCellStyle3
        Me.Help.HeaderText = "Help"
        Me.Help.Name = "Help"
        Me.Help.Width = 45
        '
        'spacer
        '
        Me.spacer.HeaderText = ""
        Me.spacer.Name = "spacer"
        Me.spacer.ReadOnly = True
        Me.spacer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.spacer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.spacer.Width = 23
        '
        'VariableName
        '
        Me.VariableName.HeaderText = "VarNames"
        Me.VariableName.Name = "VariableName"
        Me.VariableName.ReadOnly = True
        Me.VariableName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.VariableName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VariableName.Visible = False
        '
        'Flags
        '
        Me.Flags.HeaderText = "Flags"
        Me.Flags.Name = "Flags"
        Me.Flags.ReadOnly = True
        Me.Flags.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Flags.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Flags.Visible = False
        '
        'pnlToolType
        '
        Me.pnlToolType.Controls.Add(Me.cmbToolType)
        Me.pnlToolType.Controls.Add(Me.lblTulType)
        Me.pnlToolType.Location = New System.Drawing.Point(369, 12)
        Me.pnlToolType.Name = "pnlToolType"
        Me.pnlToolType.Size = New System.Drawing.Size(267, 28)
        Me.pnlToolType.TabIndex = 52
        '
        'grdItemList
        '
        Me.grdItemList.AllowUserToResizeColumns = False
        Me.grdItemList.AllowUserToResizeRows = False
        Me.grdItemList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdItemList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmCheck, Me.clmDescription, Me.clmFiller, Me.clmGroupBy, Me.clmType})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdItemList.DefaultCellStyle = DataGridViewCellStyle10
        Me.grdItemList.Location = New System.Drawing.Point(12, 12)
        Me.grdItemList.Name = "grdItemList"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdItemList.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.grdItemList.RowHeadersVisible = False
        Me.grdItemList.Size = New System.Drawing.Size(339, 393)
        Me.grdItemList.TabIndex = 53
        '
        'clmCheck
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.clmCheck.DefaultCellStyle = DataGridViewCellStyle7
        Me.clmCheck.HeaderText = "Chk"
        Me.clmCheck.Name = "clmCheck"
        Me.clmCheck.ReadOnly = True
        Me.clmCheck.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmCheck.Width = 30
        '
        'clmDescription
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.clmDescription.DefaultCellStyle = DataGridViewCellStyle8
        Me.clmDescription.HeaderText = "Description"
        Me.clmDescription.Name = "clmDescription"
        Me.clmDescription.ReadOnly = True
        Me.clmDescription.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmDescription.Width = 265
        '
        'clmFiller
        '
        Me.clmFiller.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        Me.clmFiller.DefaultCellStyle = DataGridViewCellStyle9
        Me.clmFiller.HeaderText = ""
        Me.clmFiller.Name = "clmFiller"
        Me.clmFiller.ReadOnly = True
        Me.clmFiller.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmFiller.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmGroupBy
        '
        Me.clmGroupBy.HeaderText = "GroupBy"
        Me.clmGroupBy.Name = "clmGroupBy"
        Me.clmGroupBy.ReadOnly = True
        Me.clmGroupBy.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmGroupBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmGroupBy.Visible = False
        '
        'clmType
        '
        Me.clmType.HeaderText = "Type"
        Me.clmType.Name = "clmType"
        Me.clmType.ReadOnly = True
        Me.clmType.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmType.Visible = False
        '
        'pnlFilter
        '
        Me.pnlFilter.Controls.Add(Me.lblToolType)
        Me.pnlFilter.Controls.Add(Me.chkMyToolsOnly)
        Me.pnlFilter.Controls.Add(Me.cmbToolFilter)
        Me.pnlFilter.Location = New System.Drawing.Point(13, 411)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(338, 28)
        Me.pnlFilter.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(654, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Units:"
        '
        'btnUnits
        '
        Me.btnUnits.Location = New System.Drawing.Point(695, 13)
        Me.btnUnits.Name = "btnUnits"
        Me.btnUnits.Size = New System.Drawing.Size(64, 22)
        Me.btnUnits.TabIndex = 56
        Me.btnUnits.Text = "English"
        Me.btnUnits.UseVisualStyleBackColor = True
        '
        'cmbSort
        '
        Me.cmbSort.FormattingEnabled = True
        Me.cmbSort.Location = New System.Drawing.Point(59, 442)
        Me.cmbSort.Name = "cmbSort"
        Me.cmbSort.Size = New System.Drawing.Size(122, 21)
        Me.cmbSort.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 446)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sort By"
        '
        'btnSortUp
        '
        Me.btnSortUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSortUp.Location = New System.Drawing.Point(187, 440)
        Me.btnSortUp.Name = "btnSortUp"
        Me.btnSortUp.Size = New System.Drawing.Size(39, 26)
        Me.btnSortUp.TabIndex = 59
        Me.btnSortUp.Text = "Sort"
        Me.btnSortUp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSortUp.UseVisualStyleBackColor = True
        '
        'frmSetupOrganizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 520)
        Me.Controls.Add(Me.btnSortUp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbSort)
        Me.Controls.Add(Me.btnUnits)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlFilter)
        Me.Controls.Add(Me.grdItemList)
        Me.Controls.Add(Me.pnlToolType)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grdParameters)
        Me.Controls.Add(Me.btnRemoveTool)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblToolDetails)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.picTool)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetupOrganizer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.picTool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlToolType.ResumeLayout(False)
        Me.pnlToolType.PerformLayout()
        CType(Me.grdItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbToolFilter As System.Windows.Forms.ComboBox
    Friend WithEvents picTool As System.Windows.Forms.PictureBox
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents lblToolType As System.Windows.Forms.Label
    Friend WithEvents chkMyToolsOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblToolDetails As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnRemoveTool As System.Windows.Forms.Button
    Friend WithEvents lblTulType As System.Windows.Forms.Label
    Friend WithEvents cmbToolType As System.Windows.Forms.ComboBox
    Friend WithEvents grdParameters As System.Windows.Forms.DataGridView
    Friend WithEvents pnlToolType As System.Windows.Forms.Panel
    Friend WithEvents grdItemList As System.Windows.Forms.DataGridView
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUnits As System.Windows.Forms.Button
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnglishHeader As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Help As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents spacer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VariableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Flags As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmCheck As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFiller As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmGroupBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbSort As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSortUp As System.Windows.Forms.Button
End Class
