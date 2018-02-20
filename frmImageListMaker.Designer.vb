<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageListMaker
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
        Me.lstImageList = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAddToList = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblImageName = New System.Windows.Forms.Label()
        Me.btnGetImage = New System.Windows.Forms.Button()
        Me.txtTabName = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDeleteSelected = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnMoveUp = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnSame = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstImageList
        '
        Me.lstImageList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstImageList.FormattingEnabled = True
        Me.lstImageList.ItemHeight = 20
        Me.lstImageList.Location = New System.Drawing.Point(12, 12)
        Me.lstImageList.Name = "lstImageList"
        Me.lstImageList.Size = New System.Drawing.Size(670, 264)
        Me.lstImageList.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSame)
        Me.GroupBox1.Controls.Add(Me.btnAddToList)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblImageName)
        Me.GroupBox1.Controls.Add(Me.btnGetImage)
        Me.GroupBox1.Controls.Add(Me.txtTabName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 282)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(418, 110)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Image"
        '
        'btnAddToList
        '
        Me.btnAddToList.Location = New System.Drawing.Point(335, 72)
        Me.btnAddToList.Name = "btnAddToList"
        Me.btnAddToList.Size = New System.Drawing.Size(72, 31)
        Me.btnAddToList.TabIndex = 8
        Me.btnAddToList.Text = "Add to List"
        Me.btnAddToList.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(332, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Tab Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(118, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Image Name"
        '
        'lblImageName
        '
        Me.lblImageName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImageName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageName.Location = New System.Drawing.Point(119, 39)
        Me.lblImageName.Name = "lblImageName"
        Me.lblImageName.Size = New System.Drawing.Size(210, 28)
        Me.lblImageName.TabIndex = 5
        '
        'btnGetImage
        '
        Me.btnGetImage.Location = New System.Drawing.Point(9, 36)
        Me.btnGetImage.Name = "btnGetImage"
        Me.btnGetImage.Size = New System.Drawing.Size(100, 31)
        Me.btnGetImage.TabIndex = 4
        Me.btnGetImage.Text = "Get Image"
        Me.btnGetImage.UseVisualStyleBackColor = True
        '
        'txtTabName
        '
        Me.txtTabName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTabName.Location = New System.Drawing.Point(335, 41)
        Me.txtTabName.Name = "txtTabName"
        Me.txtTabName.Size = New System.Drawing.Size(72, 26)
        Me.txtTabName.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDeleteSelected)
        Me.GroupBox2.Controls.Add(Me.btnDown)
        Me.GroupBox2.Controls.Add(Me.btnMoveUp)
        Me.GroupBox2.Controls.Add(Me.btnOK)
        Me.GroupBox2.Controls.Add(Me.btnClearAll)
        Me.GroupBox2.Location = New System.Drawing.Point(436, 282)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(246, 111)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'btnDeleteSelected
        '
        Me.btnDeleteSelected.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDeleteSelected.Location = New System.Drawing.Point(126, 37)
        Me.btnDeleteSelected.Name = "btnDeleteSelected"
        Me.btnDeleteSelected.Size = New System.Drawing.Size(98, 31)
        Me.btnDeleteSelected.TabIndex = 13
        Me.btnDeleteSelected.Text = "Delete Selected"
        Me.btnDeleteSelected.UseVisualStyleBackColor = False
        '
        'btnDown
        '
        Me.btnDown.Location = New System.Drawing.Point(66, 37)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(54, 31)
        Me.btnDown.TabIndex = 12
        Me.btnDown.Text = "Down"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Location = New System.Drawing.Point(6, 36)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(54, 31)
        Me.btnMoveUp.TabIndex = 11
        Me.btnMoveUp.Text = "Up"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(126, 72)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(98, 31)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnClearAll
        '
        Me.btnClearAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnClearAll.Location = New System.Drawing.Point(6, 74)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(114, 31)
        Me.btnClearAll.TabIndex = 9
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = False
        '
        'btnSame
        '
        Me.btnSame.Location = New System.Drawing.Point(9, 73)
        Me.btnSame.Name = "btnSame"
        Me.btnSame.Size = New System.Drawing.Size(100, 31)
        Me.btnSame.TabIndex = 9
        Me.btnSame.Text = "No Change"
        Me.btnSame.UseVisualStyleBackColor = True
        '
        'frmImageListMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 397)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lstImageList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "frmImageListMaker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image List Maker"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstImageList As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblImageName As System.Windows.Forms.Label
    Friend WithEvents btnGetImage As System.Windows.Forms.Button
    Friend WithEvents txtTabName As System.Windows.Forms.TextBox
    Friend WithEvents btnAddToList As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnSame As System.Windows.Forms.Button
End Class
