<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectProcess
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grdProcessCatalog = New System.Windows.Forms.DataGridView()
        Me.selCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbFilterList = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblProcessSelectStatus = New System.Windows.Forms.Label()
        CType(Me.grdProcessCatalog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(12, 499)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(68, 22)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(111, 499)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 22)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'grdProcessCatalog
        '
        Me.grdProcessCatalog.AllowUserToAddRows = False
        Me.grdProcessCatalog.AllowUserToResizeColumns = False
        Me.grdProcessCatalog.AllowUserToResizeRows = False
        Me.grdProcessCatalog.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.grdProcessCatalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdProcessCatalog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selCol, Me.ProcessName})
        Me.grdProcessCatalog.Location = New System.Drawing.Point(12, 12)
        Me.grdProcessCatalog.Name = "grdProcessCatalog"
        Me.grdProcessCatalog.RowHeadersVisible = False
        Me.grdProcessCatalog.Size = New System.Drawing.Size(546, 481)
        Me.grdProcessCatalog.TabIndex = 6
        '
        'selCol
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.selCol.DefaultCellStyle = DataGridViewCellStyle3
        Me.selCol.HeaderText = ""
        Me.selCol.Name = "selCol"
        Me.selCol.ReadOnly = True
        Me.selCol.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.selCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.selCol.Width = 30
        '
        'ProcessName
        '
        Me.ProcessName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.ProcessName.DefaultCellStyle = DataGridViewCellStyle4
        Me.ProcessName.HeaderText = "Toolpath Template Name"
        Me.ProcessName.Name = "ProcessName"
        Me.ProcessName.ReadOnly = True
        '
        'cmbFilterList
        '
        Me.cmbFilterList.FormattingEnabled = True
        Me.cmbFilterList.Location = New System.Drawing.Point(323, 500)
        Me.cmbFilterList.Name = "cmbFilterList"
        Me.cmbFilterList.Size = New System.Drawing.Size(235, 21)
        Me.cmbFilterList.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(241, 504)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Template Filter"
        '
        'lblProcessSelectStatus
        '
        Me.lblProcessSelectStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProcessSelectStatus.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessSelectStatus.Location = New System.Drawing.Point(12, 524)
        Me.lblProcessSelectStatus.Name = "lblProcessSelectStatus"
        Me.lblProcessSelectStatus.Size = New System.Drawing.Size(546, 19)
        Me.lblProcessSelectStatus.TabIndex = 9
        '
        'frmSelectProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 544)
        Me.Controls.Add(Me.lblProcessSelectStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbFilterList)
        Me.Controls.Add(Me.grdProcessCatalog)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectProcess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Toolpath Template"
        CType(Me.grdProcessCatalog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grdProcessCatalog As System.Windows.Forms.DataGridView
    Friend WithEvents cmbFilterList As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblProcessSelectStatus As System.Windows.Forms.Label
    Friend WithEvents selCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
