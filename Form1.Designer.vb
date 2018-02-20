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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblImageName = New System.Windows.Forms.Label()
        Me.btnGetImage = New System.Windows.Forms.Button()
        Me.txtTabName = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstImageList
        '
        Me.lstImageList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstImageList.FormattingEnabled = True
        Me.lstImageList.ItemHeight = 20
        Me.lstImageList.Location = New System.Drawing.Point(12, 12)
        Me.lstImageList.Name = "lstImageList"
        Me.lstImageList.Size = New System.Drawing.Size(670, 184)
        Me.lstImageList.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblImageName)
        Me.GroupBox1.Controls.Add(Me.btnGetImage)
        Me.GroupBox1.Controls.Add(Me.txtTabName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 241)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(570, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Image"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(443, 19)
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
        Me.lblImageName.Size = New System.Drawing.Size(321, 28)
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
        Me.txtTabName.Location = New System.Drawing.Point(446, 39)
        Me.txtTabName.Name = "txtTabName"
        Me.txtTabName.Size = New System.Drawing.Size(112, 26)
        Me.txtTabName.TabIndex = 3
        '
        'frmImageListMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 397)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lstImageList)
        Me.Name = "frmImageListMaker"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstImageList As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblImageName As System.Windows.Forms.Label
    Friend WithEvents btnGetImage As System.Windows.Forms.Button
    Friend WithEvents txtTabName As System.Windows.Forms.TextBox
End Class
