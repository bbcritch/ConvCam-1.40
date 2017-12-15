<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalculator
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtStackBox = New System.Windows.Forms.RichTextBox
        Me.btnPut = New System.Windows.Forms.Button
        Me.btnGetCommandString = New System.Windows.Forms.Button
        Me.txtCommandString = New System.Windows.Forms.TextBox
        Me.btnxSwapY = New System.Windows.Forms.Button
        Me.vVal = New System.Windows.Forms.TextBox
        Me.vName = New System.Windows.Forms.TextBox
        Me.cmbEntry = New System.Windows.Forms.ComboBox
        Me.btnxtoy = New System.Windows.Forms.Button
        Me.btnClrStack = New System.Windows.Forms.Button
        Me.btnPi = New System.Windows.Forms.Button
        Me.btnSqu = New System.Windows.Forms.Button
        Me.btnSqRt = New System.Windows.Forms.Button
        Me.btnAtan = New System.Windows.Forms.Button
        Me.btnAcos = New System.Windows.Forms.Button
        Me.btnaSin = New System.Windows.Forms.Button
        Me.btnTan = New System.Windows.Forms.Button
        Me.btnCos = New System.Windows.Forms.Button
        Me.btnSin = New System.Windows.Forms.Button
        Me.btnProcess = New System.Windows.Forms.Button
        Me.answer = New System.Windows.Forms.TextBox
        Me.btnCLr = New System.Windows.Forms.Button
        Me.btnSetVariable = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Enter = New System.Windows.Forms.Button
        Me.divide = New System.Windows.Forms.Button
        Me.multiply = New System.Windows.Forms.Button
        Me.minus = New System.Windows.Forms.Button
        Me.plus = New System.Windows.Forms.Button
        Me.txtStack = New System.Windows.Forms.RichTextBox
        Me.numSign = New System.Windows.Forms.Button
        Me.dot = New System.Windows.Forms.Button
        Me.num9 = New System.Windows.Forms.Button
        Me.num8 = New System.Windows.Forms.Button
        Me.num7 = New System.Windows.Forms.Button
        Me.num6 = New System.Windows.Forms.Button
        Me.num5 = New System.Windows.Forms.Button
        Me.num4 = New System.Windows.Forms.Button
        Me.num3 = New System.Windows.Forms.Button
        Me.num2 = New System.Windows.Forms.Button
        Me.num1 = New System.Windows.Forms.Button
        Me.num0 = New System.Windows.Forms.Button
        Me.btnAbs = New System.Windows.Forms.Button
        Me.btnInt = New System.Windows.Forms.Button
        Me.btnRup = New System.Windows.Forms.Button
        Me.btnRou = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(388, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Stack"
        '
        'txtStackBox
        '
        Me.txtStackBox.Location = New System.Drawing.Point(368, 48)
        Me.txtStackBox.Name = "txtStackBox"
        Me.txtStackBox.Size = New System.Drawing.Size(108, 260)
        Me.txtStackBox.TabIndex = 144
        Me.txtStackBox.Text = ""
        '
        'btnPut
        '
        Me.btnPut.Location = New System.Drawing.Point(3, 354)
        Me.btnPut.Name = "btnPut"
        Me.btnPut.Size = New System.Drawing.Size(35, 20)
        Me.btnPut.TabIndex = 143
        Me.btnPut.Text = "Put"
        Me.btnPut.UseVisualStyleBackColor = True
        '
        'btnGetCommandString
        '
        Me.btnGetCommandString.Location = New System.Drawing.Point(406, 335)
        Me.btnGetCommandString.Name = "btnGetCommandString"
        Me.btnGetCommandString.Size = New System.Drawing.Size(70, 38)
        Me.btnGetCommandString.TabIndex = 142
        Me.btnGetCommandString.Text = "OK"
        Me.btnGetCommandString.UseVisualStyleBackColor = True
        '
        'txtCommandString
        '
        Me.txtCommandString.Location = New System.Drawing.Point(44, 354)
        Me.txtCommandString.Name = "txtCommandString"
        Me.txtCommandString.Size = New System.Drawing.Size(264, 20)
        Me.txtCommandString.TabIndex = 141
        '
        'btnxSwapY
        '
        Me.btnxSwapY.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxSwapY.Location = New System.Drawing.Point(84, 89)
        Me.btnxSwapY.Name = "btnxSwapY"
        Me.btnxSwapY.Size = New System.Drawing.Size(33, 15)
        Me.btnxSwapY.TabIndex = 140
        Me.btnxSwapY.Text = "x<>y"
        Me.btnxSwapY.UseVisualStyleBackColor = True
        '
        'vVal
        '
        Me.vVal.Location = New System.Drawing.Point(72, 23)
        Me.vVal.Name = "vVal"
        Me.vVal.Size = New System.Drawing.Size(46, 20)
        Me.vVal.TabIndex = 139
        Me.vVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'vName
        '
        Me.vName.Location = New System.Drawing.Point(6, 23)
        Me.vName.Name = "vName"
        Me.vName.Size = New System.Drawing.Size(68, 20)
        Me.vName.TabIndex = 138
        '
        'cmbEntry
        '
        Me.cmbEntry.FormattingEnabled = True
        Me.cmbEntry.Location = New System.Drawing.Point(7, 147)
        Me.cmbEntry.Name = "cmbEntry"
        Me.cmbEntry.Size = New System.Drawing.Size(153, 21)
        Me.cmbEntry.TabIndex = 137
        '
        'btnxtoy
        '
        Me.btnxtoy.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxtoy.Location = New System.Drawing.Point(124, 89)
        Me.btnxtoy.Name = "btnxtoy"
        Me.btnxtoy.Size = New System.Drawing.Size(33, 15)
        Me.btnxtoy.TabIndex = 136
        Me.btnxtoy.Text = "x^y"
        Me.btnxtoy.UseVisualStyleBackColor = True
        '
        'btnClrStack
        '
        Me.btnClrStack.Location = New System.Drawing.Point(315, 317)
        Me.btnClrStack.Name = "btnClrStack"
        Me.btnClrStack.Size = New System.Drawing.Size(47, 27)
        Me.btnClrStack.TabIndex = 135
        Me.btnClrStack.Text = "Clr All"
        Me.btnClrStack.UseVisualStyleBackColor = True
        '
        'btnPi
        '
        Me.btnPi.Location = New System.Drawing.Point(44, 315)
        Me.btnPi.Name = "btnPi"
        Me.btnPi.Size = New System.Drawing.Size(35, 29)
        Me.btnPi.TabIndex = 134
        Me.btnPi.Text = "PI"
        Me.btnPi.UseVisualStyleBackColor = True
        '
        'btnSqu
        '
        Me.btnSqu.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSqu.Location = New System.Drawing.Point(7, 89)
        Me.btnSqu.Name = "btnSqu"
        Me.btnSqu.Size = New System.Drawing.Size(33, 15)
        Me.btnSqu.TabIndex = 133
        Me.btnSqu.Text = "x^2"
        Me.btnSqu.UseVisualStyleBackColor = True
        '
        'btnSqRt
        '
        Me.btnSqRt.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSqRt.Location = New System.Drawing.Point(46, 89)
        Me.btnSqRt.Name = "btnSqRt"
        Me.btnSqRt.Size = New System.Drawing.Size(33, 15)
        Me.btnSqRt.TabIndex = 132
        Me.btnSqRt.Text = "sqrt"
        Me.btnSqRt.UseVisualStyleBackColor = True
        '
        'btnAtan
        '
        Me.btnAtan.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtan.Location = New System.Drawing.Point(85, 68)
        Me.btnAtan.Name = "btnAtan"
        Me.btnAtan.Size = New System.Drawing.Size(33, 15)
        Me.btnAtan.TabIndex = 131
        Me.btnAtan.Text = "atan"
        Me.btnAtan.UseVisualStyleBackColor = True
        '
        'btnAcos
        '
        Me.btnAcos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAcos.Location = New System.Drawing.Point(46, 68)
        Me.btnAcos.Name = "btnAcos"
        Me.btnAcos.Size = New System.Drawing.Size(33, 15)
        Me.btnAcos.TabIndex = 130
        Me.btnAcos.Text = "acos"
        Me.btnAcos.UseVisualStyleBackColor = True
        '
        'btnaSin
        '
        Me.btnaSin.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaSin.Location = New System.Drawing.Point(7, 68)
        Me.btnaSin.Name = "btnaSin"
        Me.btnaSin.Size = New System.Drawing.Size(33, 15)
        Me.btnaSin.TabIndex = 129
        Me.btnaSin.Text = "asin"
        Me.btnaSin.UseVisualStyleBackColor = True
        '
        'btnTan
        '
        Me.btnTan.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTan.Location = New System.Drawing.Point(85, 52)
        Me.btnTan.Name = "btnTan"
        Me.btnTan.Size = New System.Drawing.Size(33, 15)
        Me.btnTan.TabIndex = 128
        Me.btnTan.Text = "tan"
        Me.btnTan.UseVisualStyleBackColor = True
        '
        'btnCos
        '
        Me.btnCos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCos.Location = New System.Drawing.Point(46, 52)
        Me.btnCos.Name = "btnCos"
        Me.btnCos.Size = New System.Drawing.Size(33, 15)
        Me.btnCos.TabIndex = 127
        Me.btnCos.Text = "cos"
        Me.btnCos.UseVisualStyleBackColor = True
        '
        'btnSin
        '
        Me.btnSin.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSin.Location = New System.Drawing.Point(7, 52)
        Me.btnSin.Name = "btnSin"
        Me.btnSin.Size = New System.Drawing.Size(33, 15)
        Me.btnSin.TabIndex = 126
        Me.btnSin.Text = "sin"
        Me.btnSin.UseVisualStyleBackColor = True
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(167, 317)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(141, 27)
        Me.btnProcess.TabIndex = 125
        Me.btnProcess.Text = "Process"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'answer
        '
        Me.answer.Location = New System.Drawing.Point(167, 22)
        Me.answer.Name = "answer"
        Me.answer.Size = New System.Drawing.Size(196, 20)
        Me.answer.TabIndex = 124
        Me.answer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCLr
        '
        Me.btnCLr.Location = New System.Drawing.Point(3, 314)
        Me.btnCLr.Name = "btnCLr"
        Me.btnCLr.Size = New System.Drawing.Size(35, 29)
        Me.btnCLr.TabIndex = 123
        Me.btnCLr.Text = "Clr"
        Me.btnCLr.UseVisualStyleBackColor = True
        '
        'btnSetVariable
        '
        Me.btnSetVariable.Location = New System.Drawing.Point(124, 23)
        Me.btnSetVariable.Name = "btnSetVariable"
        Me.btnSetVariable.Size = New System.Drawing.Size(32, 19)
        Me.btnSetVariable.TabIndex = 122
        Me.btnSetVariable.Text = "set"
        Me.btnSetVariable.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Set Variable"
        '
        'Enter
        '
        Me.Enter.Location = New System.Drawing.Point(85, 314)
        Me.Enter.Name = "Enter"
        Me.Enter.Size = New System.Drawing.Size(76, 29)
        Me.Enter.TabIndex = 120
        Me.Enter.Text = "Enter"
        Me.Enter.UseVisualStyleBackColor = True
        '
        'divide
        '
        Me.divide.Location = New System.Drawing.Point(126, 279)
        Me.divide.Name = "divide"
        Me.divide.Size = New System.Drawing.Size(35, 29)
        Me.divide.TabIndex = 119
        Me.divide.Text = "/"
        Me.divide.UseVisualStyleBackColor = True
        '
        'multiply
        '
        Me.multiply.Location = New System.Drawing.Point(126, 244)
        Me.multiply.Name = "multiply"
        Me.multiply.Size = New System.Drawing.Size(35, 29)
        Me.multiply.TabIndex = 118
        Me.multiply.Text = "X"
        Me.multiply.UseVisualStyleBackColor = True
        '
        'minus
        '
        Me.minus.Location = New System.Drawing.Point(126, 209)
        Me.minus.Name = "minus"
        Me.minus.Size = New System.Drawing.Size(35, 29)
        Me.minus.TabIndex = 117
        Me.minus.Text = "-"
        Me.minus.UseVisualStyleBackColor = True
        '
        'plus
        '
        Me.plus.Location = New System.Drawing.Point(126, 174)
        Me.plus.Name = "plus"
        Me.plus.Size = New System.Drawing.Size(35, 29)
        Me.plus.TabIndex = 116
        Me.plus.Text = "+"
        Me.plus.UseVisualStyleBackColor = True
        '
        'txtStack
        '
        Me.txtStack.Location = New System.Drawing.Point(167, 48)
        Me.txtStack.Name = "txtStack"
        Me.txtStack.Size = New System.Drawing.Size(195, 260)
        Me.txtStack.TabIndex = 115
        Me.txtStack.Text = ""
        '
        'numSign
        '
        Me.numSign.Location = New System.Drawing.Point(3, 279)
        Me.numSign.Name = "numSign"
        Me.numSign.Size = New System.Drawing.Size(35, 29)
        Me.numSign.TabIndex = 114
        Me.numSign.Text = "+/-"
        Me.numSign.UseVisualStyleBackColor = True
        '
        'dot
        '
        Me.dot.Location = New System.Drawing.Point(85, 279)
        Me.dot.Name = "dot"
        Me.dot.Size = New System.Drawing.Size(35, 29)
        Me.dot.TabIndex = 113
        Me.dot.Text = "."
        Me.dot.UseVisualStyleBackColor = True
        '
        'num9
        '
        Me.num9.Location = New System.Drawing.Point(85, 244)
        Me.num9.Name = "num9"
        Me.num9.Size = New System.Drawing.Size(35, 29)
        Me.num9.TabIndex = 112
        Me.num9.Text = "9"
        Me.num9.UseVisualStyleBackColor = True
        '
        'num8
        '
        Me.num8.Location = New System.Drawing.Point(44, 244)
        Me.num8.Name = "num8"
        Me.num8.Size = New System.Drawing.Size(35, 29)
        Me.num8.TabIndex = 111
        Me.num8.Text = "8"
        Me.num8.UseVisualStyleBackColor = True
        '
        'num7
        '
        Me.num7.Location = New System.Drawing.Point(3, 244)
        Me.num7.Name = "num7"
        Me.num7.Size = New System.Drawing.Size(35, 29)
        Me.num7.TabIndex = 110
        Me.num7.Text = "7"
        Me.num7.UseVisualStyleBackColor = True
        '
        'num6
        '
        Me.num6.Location = New System.Drawing.Point(85, 209)
        Me.num6.Name = "num6"
        Me.num6.Size = New System.Drawing.Size(35, 29)
        Me.num6.TabIndex = 109
        Me.num6.Text = "6"
        Me.num6.UseVisualStyleBackColor = True
        '
        'num5
        '
        Me.num5.Location = New System.Drawing.Point(44, 209)
        Me.num5.Name = "num5"
        Me.num5.Size = New System.Drawing.Size(35, 29)
        Me.num5.TabIndex = 108
        Me.num5.Text = "5"
        Me.num5.UseVisualStyleBackColor = True
        '
        'num4
        '
        Me.num4.Location = New System.Drawing.Point(3, 209)
        Me.num4.Name = "num4"
        Me.num4.Size = New System.Drawing.Size(35, 29)
        Me.num4.TabIndex = 107
        Me.num4.Text = "4"
        Me.num4.UseVisualStyleBackColor = True
        '
        'num3
        '
        Me.num3.Location = New System.Drawing.Point(85, 174)
        Me.num3.Name = "num3"
        Me.num3.Size = New System.Drawing.Size(35, 29)
        Me.num3.TabIndex = 106
        Me.num3.Text = "3"
        Me.num3.UseVisualStyleBackColor = True
        '
        'num2
        '
        Me.num2.Location = New System.Drawing.Point(44, 174)
        Me.num2.Name = "num2"
        Me.num2.Size = New System.Drawing.Size(35, 29)
        Me.num2.TabIndex = 105
        Me.num2.Text = "2"
        Me.num2.UseVisualStyleBackColor = True
        '
        'num1
        '
        Me.num1.Location = New System.Drawing.Point(3, 174)
        Me.num1.Name = "num1"
        Me.num1.Size = New System.Drawing.Size(35, 29)
        Me.num1.TabIndex = 104
        Me.num1.Text = "1"
        Me.num1.UseVisualStyleBackColor = True
        '
        'num0
        '
        Me.num0.Location = New System.Drawing.Point(44, 279)
        Me.num0.Name = "num0"
        Me.num0.Size = New System.Drawing.Size(35, 29)
        Me.num0.TabIndex = 103
        Me.num0.Text = "0"
        Me.num0.UseVisualStyleBackColor = True
        '
        'btnAbs
        '
        Me.btnAbs.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbs.Location = New System.Drawing.Point(7, 110)
        Me.btnAbs.Name = "btnAbs"
        Me.btnAbs.Size = New System.Drawing.Size(33, 15)
        Me.btnAbs.TabIndex = 146
        Me.btnAbs.Text = "abs"
        Me.btnAbs.UseVisualStyleBackColor = True
        '
        'btnInt
        '
        Me.btnInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInt.Location = New System.Drawing.Point(46, 110)
        Me.btnInt.Name = "btnInt"
        Me.btnInt.Size = New System.Drawing.Size(33, 15)
        Me.btnInt.TabIndex = 147
        Me.btnInt.Text = "int"
        Me.btnInt.UseVisualStyleBackColor = True
        '
        'btnRup
        '
        Me.btnRup.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRup.Location = New System.Drawing.Point(84, 110)
        Me.btnRup.Name = "btnRup"
        Me.btnRup.Size = New System.Drawing.Size(33, 15)
        Me.btnRup.TabIndex = 148
        Me.btnRup.Text = "rup"
        Me.btnRup.UseVisualStyleBackColor = True
        '
        'btnRou
        '
        Me.btnRou.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRou.Location = New System.Drawing.Point(124, 110)
        Me.btnRou.Name = "btnRou"
        Me.btnRou.Size = New System.Drawing.Size(33, 15)
        Me.btnRou.TabIndex = 149
        Me.btnRou.Text = "rou"
        Me.btnRou.UseVisualStyleBackColor = True
        '
        'frmCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 388)
        Me.Controls.Add(Me.btnRou)
        Me.Controls.Add(Me.btnRup)
        Me.Controls.Add(Me.btnInt)
        Me.Controls.Add(Me.btnAbs)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStackBox)
        Me.Controls.Add(Me.btnPut)
        Me.Controls.Add(Me.btnGetCommandString)
        Me.Controls.Add(Me.txtCommandString)
        Me.Controls.Add(Me.btnxSwapY)
        Me.Controls.Add(Me.vVal)
        Me.Controls.Add(Me.vName)
        Me.Controls.Add(Me.cmbEntry)
        Me.Controls.Add(Me.btnxtoy)
        Me.Controls.Add(Me.btnClrStack)
        Me.Controls.Add(Me.btnPi)
        Me.Controls.Add(Me.btnSqu)
        Me.Controls.Add(Me.btnSqRt)
        Me.Controls.Add(Me.btnAtan)
        Me.Controls.Add(Me.btnAcos)
        Me.Controls.Add(Me.btnaSin)
        Me.Controls.Add(Me.btnTan)
        Me.Controls.Add(Me.btnCos)
        Me.Controls.Add(Me.btnSin)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.answer)
        Me.Controls.Add(Me.btnCLr)
        Me.Controls.Add(Me.btnSetVariable)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Enter)
        Me.Controls.Add(Me.divide)
        Me.Controls.Add(Me.multiply)
        Me.Controls.Add(Me.minus)
        Me.Controls.Add(Me.plus)
        Me.Controls.Add(Me.txtStack)
        Me.Controls.Add(Me.numSign)
        Me.Controls.Add(Me.dot)
        Me.Controls.Add(Me.num9)
        Me.Controls.Add(Me.num8)
        Me.Controls.Add(Me.num7)
        Me.Controls.Add(Me.num6)
        Me.Controls.Add(Me.num5)
        Me.Controls.Add(Me.num4)
        Me.Controls.Add(Me.num3)
        Me.Controls.Add(Me.num2)
        Me.Controls.Add(Me.num1)
        Me.Controls.Add(Me.num0)
        Me.Name = "frmCalculator"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStackBox As System.Windows.Forms.RichTextBox
    Friend WithEvents btnPut As System.Windows.Forms.Button
    Friend WithEvents btnGetCommandString As System.Windows.Forms.Button
    Friend WithEvents txtCommandString As System.Windows.Forms.TextBox
    Friend WithEvents btnxSwapY As System.Windows.Forms.Button
    Friend WithEvents vVal As System.Windows.Forms.TextBox
    Friend WithEvents vName As System.Windows.Forms.TextBox
    Friend WithEvents cmbEntry As System.Windows.Forms.ComboBox
    Friend WithEvents btnxtoy As System.Windows.Forms.Button
    Friend WithEvents btnClrStack As System.Windows.Forms.Button
    Friend WithEvents btnPi As System.Windows.Forms.Button
    Friend WithEvents btnSqu As System.Windows.Forms.Button
    Friend WithEvents btnSqRt As System.Windows.Forms.Button
    Friend WithEvents btnAtan As System.Windows.Forms.Button
    Friend WithEvents btnAcos As System.Windows.Forms.Button
    Friend WithEvents btnaSin As System.Windows.Forms.Button
    Friend WithEvents btnTan As System.Windows.Forms.Button
    Friend WithEvents btnCos As System.Windows.Forms.Button
    Friend WithEvents btnSin As System.Windows.Forms.Button
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents answer As System.Windows.Forms.TextBox
    Friend WithEvents btnCLr As System.Windows.Forms.Button
    Friend WithEvents btnSetVariable As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Enter As System.Windows.Forms.Button
    Friend WithEvents divide As System.Windows.Forms.Button
    Friend WithEvents multiply As System.Windows.Forms.Button
    Friend WithEvents minus As System.Windows.Forms.Button
    Friend WithEvents plus As System.Windows.Forms.Button
    Friend WithEvents txtStack As System.Windows.Forms.RichTextBox
    Friend WithEvents numSign As System.Windows.Forms.Button
    Friend WithEvents dot As System.Windows.Forms.Button
    Friend WithEvents num9 As System.Windows.Forms.Button
    Friend WithEvents num8 As System.Windows.Forms.Button
    Friend WithEvents num7 As System.Windows.Forms.Button
    Friend WithEvents num6 As System.Windows.Forms.Button
    Friend WithEvents num5 As System.Windows.Forms.Button
    Friend WithEvents num4 As System.Windows.Forms.Button
    Friend WithEvents num3 As System.Windows.Forms.Button
    Friend WithEvents num2 As System.Windows.Forms.Button
    Friend WithEvents num1 As System.Windows.Forms.Button
    Friend WithEvents num0 As System.Windows.Forms.Button
    Friend WithEvents btnAbs As System.Windows.Forms.Button
    Friend WithEvents btnInt As System.Windows.Forms.Button
    Friend WithEvents btnRup As System.Windows.Forms.Button
    Friend WithEvents btnRou As System.Windows.Forms.Button
End Class
