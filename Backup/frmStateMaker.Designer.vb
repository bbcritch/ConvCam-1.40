<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStateMaker
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
        Me.cmbProcess = New System.Windows.Forms.ComboBox
        Me.cmbState = New System.Windows.Forms.ComboBox
        Me.btnProcess = New System.Windows.Forms.Button
        Me.btnState = New System.Windows.Forms.Button
        Me.lstVariables = New System.Windows.Forms.ListBox
        Me.txtVariable = New System.Windows.Forms.TextBox
        Me.btnVariable = New System.Windows.Forms.Button
        Me.txtStateTitle = New System.Windows.Forms.TextBox
        Me.lblStateTitle = New System.Windows.Forms.Label
        Me.txtStatePrompt = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkUnits = New System.Windows.Forms.CheckBox
        Me.cmbPromptType = New System.Windows.Forms.ComboBox
        Me.btnLower = New System.Windows.Forms.Button
        Me.btnUpper = New System.Windows.Forms.Button
        Me.btnPromptVar = New System.Windows.Forms.Button
        Me.txtLower = New System.Windows.Forms.TextBox
        Me.txtUpper = New System.Windows.Forms.TextBox
        Me.txtButtonLabels = New System.Windows.Forms.RichTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCalculations = New System.Windows.Forms.RichTextBox
        Me.btnCalculation = New System.Windows.Forms.Button
        Me.btnGcode = New System.Windows.Forms.Button
        Me.txtGcode = New System.Windows.Forms.RichTextBox
        Me.btnClearAll = New System.Windows.Forms.Button
        Me.btnClearState = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnShowXML = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.editVariables = New System.Windows.Forms.Button
        Me.btnSmPic = New System.Windows.Forms.Button
        Me.txtSmPic = New System.Windows.Forms.TextBox
        Me.btnLgPic = New System.Windows.Forms.Button
        Me.txtLgPic = New System.Windows.Forms.TextBox
        Me.txtProcessDescription = New System.Windows.Forms.RichTextBox
        Me.txtStateDescription = New System.Windows.Forms.RichTextBox
        Me.txtStateHelp = New System.Windows.Forms.RichTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbNextState = New System.Windows.Forms.ComboBox
        Me.cmbPreviousState = New System.Windows.Forms.ComboBox
        Me.btnClearNext = New System.Windows.Forms.Button
        Me.chkAlpha = New System.Windows.Forms.CheckBox
        Me.btnAddNextStateVal = New System.Windows.Forms.Button
        Me.txtNextLogic = New System.Windows.Forms.RichTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVar2 = New System.Windows.Forms.TextBox
        Me.btnV2 = New System.Windows.Forms.Button
        Me.txtVar1 = New System.Windows.Forms.TextBox
        Me.btnV1 = New System.Windows.Forms.Button
        Me.cmbIfConditions = New System.Windows.Forms.ComboBox
        Me.btnNextState = New System.Windows.Forms.Button
        Me.btnPreviousState = New System.Windows.Forms.Button
        Me.btnQuickState = New System.Windows.Forms.Button
        Me.cmbQuickState = New System.Windows.Forms.ComboBox
        Me.txtErrorMessage = New System.Windows.Forms.RichTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnShowQuickStates = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbProcess
        '
        Me.cmbProcess.FormattingEnabled = True
        Me.cmbProcess.Location = New System.Drawing.Point(96, 18)
        Me.cmbProcess.Name = "cmbProcess"
        Me.cmbProcess.Size = New System.Drawing.Size(133, 21)
        Me.cmbProcess.TabIndex = 0
        '
        'cmbState
        '
        Me.cmbState.FormattingEnabled = True
        Me.cmbState.Location = New System.Drawing.Point(334, 7)
        Me.cmbState.Name = "cmbState"
        Me.cmbState.Size = New System.Drawing.Size(147, 21)
        Me.cmbState.TabIndex = 2
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(12, 18)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(78, 21)
        Me.btnProcess.TabIndex = 3
        Me.btnProcess.Text = "New Process"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnState
        '
        Me.btnState.Location = New System.Drawing.Point(250, 8)
        Me.btnState.Name = "btnState"
        Me.btnState.Size = New System.Drawing.Size(78, 21)
        Me.btnState.TabIndex = 5
        Me.btnState.Text = "New State"
        Me.btnState.UseVisualStyleBackColor = True
        '
        'lstVariables
        '
        Me.lstVariables.FormattingEnabled = True
        Me.lstVariables.Location = New System.Drawing.Point(12, 196)
        Me.lstVariables.Name = "lstVariables"
        Me.lstVariables.Size = New System.Drawing.Size(217, 121)
        Me.lstVariables.TabIndex = 6
        '
        'txtVariable
        '
        Me.txtVariable.Location = New System.Drawing.Point(12, 175)
        Me.txtVariable.Name = "txtVariable"
        Me.txtVariable.Size = New System.Drawing.Size(196, 20)
        Me.txtVariable.TabIndex = 7
        '
        'btnVariable
        '
        Me.btnVariable.Location = New System.Drawing.Point(12, 148)
        Me.btnVariable.Name = "btnVariable"
        Me.btnVariable.Size = New System.Drawing.Size(217, 21)
        Me.btnVariable.TabIndex = 8
        Me.btnVariable.Text = "Add Variable (no spaces)"
        Me.btnVariable.UseVisualStyleBackColor = True
        '
        'txtStateTitle
        '
        Me.txtStateTitle.Location = New System.Drawing.Point(250, 162)
        Me.txtStateTitle.Name = "txtStateTitle"
        Me.txtStateTitle.Size = New System.Drawing.Size(250, 20)
        Me.txtStateTitle.TabIndex = 9
        '
        'lblStateTitle
        '
        Me.lblStateTitle.AutoSize = True
        Me.lblStateTitle.Location = New System.Drawing.Point(253, 145)
        Me.lblStateTitle.Name = "lblStateTitle"
        Me.lblStateTitle.Size = New System.Drawing.Size(55, 13)
        Me.lblStateTitle.TabIndex = 10
        Me.lblStateTitle.Text = "State Title"
        '
        'txtStatePrompt
        '
        Me.txtStatePrompt.Location = New System.Drawing.Point(250, 200)
        Me.txtStatePrompt.Name = "txtStatePrompt"
        Me.txtStatePrompt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtStatePrompt.Size = New System.Drawing.Size(250, 61)
        Me.txtStatePrompt.TabIndex = 12
        Me.txtStatePrompt.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkUnits)
        Me.GroupBox1.Controls.Add(Me.cmbPromptType)
        Me.GroupBox1.Controls.Add(Me.btnLower)
        Me.GroupBox1.Controls.Add(Me.btnUpper)
        Me.GroupBox1.Controls.Add(Me.btnPromptVar)
        Me.GroupBox1.Controls.Add(Me.txtLower)
        Me.GroupBox1.Controls.Add(Me.txtUpper)
        Me.GroupBox1.Controls.Add(Me.txtButtonLabels)
        Me.GroupBox1.Location = New System.Drawing.Point(250, 267)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 180)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Prompt Options"
        '
        'chkUnits
        '
        Me.chkUnits.AutoSize = True
        Me.chkUnits.Location = New System.Drawing.Point(185, 21)
        Me.chkUnits.Name = "chkUnits"
        Me.chkUnits.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkUnits.Size = New System.Drawing.Size(53, 17)
        Me.chkUnits.TabIndex = 57
        Me.chkUnits.Text = "Units:"
        Me.chkUnits.UseVisualStyleBackColor = True
        '
        'cmbPromptType
        '
        Me.cmbPromptType.FormattingEnabled = True
        Me.cmbPromptType.Items.AddRange(New Object() {"text", "combo", "radio", "tool", "finish", "file", "none"})
        Me.cmbPromptType.Location = New System.Drawing.Point(6, 19)
        Me.cmbPromptType.Name = "cmbPromptType"
        Me.cmbPromptType.Size = New System.Drawing.Size(121, 21)
        Me.cmbPromptType.TabIndex = 56
        '
        'btnLower
        '
        Me.btnLower.Location = New System.Drawing.Point(6, 152)
        Me.btnLower.Name = "btnLower"
        Me.btnLower.Size = New System.Drawing.Size(78, 21)
        Me.btnLower.TabIndex = 55
        Me.btnLower.Text = "Lower Limit"
        Me.btnLower.UseVisualStyleBackColor = True
        '
        'btnUpper
        '
        Me.btnUpper.Location = New System.Drawing.Point(6, 128)
        Me.btnUpper.Name = "btnUpper"
        Me.btnUpper.Size = New System.Drawing.Size(78, 21)
        Me.btnUpper.TabIndex = 54
        Me.btnUpper.Text = "Upper Limit"
        Me.btnUpper.UseVisualStyleBackColor = True
        '
        'btnPromptVar
        '
        Me.btnPromptVar.Location = New System.Drawing.Point(224, 43)
        Me.btnPromptVar.Name = "btnPromptVar"
        Me.btnPromptVar.Size = New System.Drawing.Size(20, 79)
        Me.btnPromptVar.TabIndex = 13
        Me.btnPromptVar.UseVisualStyleBackColor = True
        '
        'txtLower
        '
        Me.txtLower.Location = New System.Drawing.Point(98, 153)
        Me.txtLower.Name = "txtLower"
        Me.txtLower.Size = New System.Drawing.Size(140, 20)
        Me.txtLower.TabIndex = 12
        '
        'txtUpper
        '
        Me.txtUpper.Location = New System.Drawing.Point(98, 128)
        Me.txtUpper.Name = "txtUpper"
        Me.txtUpper.Size = New System.Drawing.Size(140, 20)
        Me.txtUpper.TabIndex = 11
        '
        'txtButtonLabels
        '
        Me.txtButtonLabels.Location = New System.Drawing.Point(6, 43)
        Me.txtButtonLabels.Name = "txtButtonLabels"
        Me.txtButtonLabels.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtButtonLabels.Size = New System.Drawing.Size(212, 79)
        Me.txtButtonLabels.TabIndex = 3
        Me.txtButtonLabels.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Prompt Text"
        '
        'txtCalculations
        '
        Me.txtCalculations.Location = New System.Drawing.Point(317, 503)
        Me.txtCalculations.Name = "txtCalculations"
        Me.txtCalculations.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtCalculations.Size = New System.Drawing.Size(432, 57)
        Me.txtCalculations.TabIndex = 27
        Me.txtCalculations.Text = ""
        '
        'btnCalculation
        '
        Me.btnCalculation.Location = New System.Drawing.Point(253, 502)
        Me.btnCalculation.Name = "btnCalculation"
        Me.btnCalculation.Size = New System.Drawing.Size(61, 58)
        Me.btnCalculation.TabIndex = 28
        Me.btnCalculation.Text = "Calculate"
        Me.btnCalculation.UseVisualStyleBackColor = True
        '
        'btnGcode
        '
        Me.btnGcode.Location = New System.Drawing.Point(12, 334)
        Me.btnGcode.Name = "btnGcode"
        Me.btnGcode.Size = New System.Drawing.Size(217, 20)
        Me.btnGcode.TabIndex = 30
        Me.btnGcode.Text = "Create Meta GCODE"
        Me.btnGcode.UseVisualStyleBackColor = True
        '
        'txtGcode
        '
        Me.txtGcode.Location = New System.Drawing.Point(12, 360)
        Me.txtGcode.Name = "txtGcode"
        Me.txtGcode.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtGcode.Size = New System.Drawing.Size(217, 56)
        Me.txtGcode.TabIndex = 29
        Me.txtGcode.Text = ""
        '
        'btnClearAll
        '
        Me.btnClearAll.Location = New System.Drawing.Point(29, 460)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(84, 25)
        Me.btnClearAll.TabIndex = 31
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'btnClearState
        '
        Me.btnClearState.Location = New System.Drawing.Point(29, 491)
        Me.btnClearState.Name = "btnClearState"
        Me.btnClearState.Size = New System.Drawing.Size(84, 25)
        Me.btnClearState.TabIndex = 32
        Me.btnClearState.Text = "Clear State"
        Me.btnClearState.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(124, 460)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 25)
        Me.btnSave.TabIndex = 33
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnShowXML
        '
        Me.btnShowXML.Location = New System.Drawing.Point(124, 491)
        Me.btnShowXML.Name = "btnShowXML"
        Me.btnShowXML.Size = New System.Drawing.Size(84, 25)
        Me.btnShowXML.TabIndex = 34
        Me.btnShowXML.Text = "Show XML"
        Me.btnShowXML.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(484, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(16, 19)
        Me.Button1.TabIndex = 38
        Me.Button1.UseVisualStyleBackColor = True
        '
        'editVariables
        '
        Me.editVariables.Location = New System.Drawing.Point(213, 175)
        Me.editVariables.Name = "editVariables"
        Me.editVariables.Size = New System.Drawing.Size(16, 19)
        Me.editVariables.TabIndex = 39
        Me.editVariables.UseVisualStyleBackColor = True
        '
        'btnSmPic
        '
        Me.btnSmPic.Location = New System.Drawing.Point(253, 455)
        Me.btnSmPic.Name = "btnSmPic"
        Me.btnSmPic.Size = New System.Drawing.Size(61, 20)
        Me.btnSmPic.TabIndex = 44
        Me.btnSmPic.Text = "sm Pic"
        Me.btnSmPic.UseVisualStyleBackColor = True
        '
        'txtSmPic
        '
        Me.txtSmPic.Location = New System.Drawing.Point(317, 455)
        Me.txtSmPic.Name = "txtSmPic"
        Me.txtSmPic.Size = New System.Drawing.Size(183, 20)
        Me.txtSmPic.TabIndex = 43
        '
        'btnLgPic
        '
        Me.btnLgPic.Location = New System.Drawing.Point(253, 476)
        Me.btnLgPic.Name = "btnLgPic"
        Me.btnLgPic.Size = New System.Drawing.Size(61, 21)
        Me.btnLgPic.TabIndex = 46
        Me.btnLgPic.Text = "lg Pic"
        Me.btnLgPic.UseVisualStyleBackColor = True
        '
        'txtLgPic
        '
        Me.txtLgPic.Location = New System.Drawing.Point(317, 476)
        Me.txtLgPic.Name = "txtLgPic"
        Me.txtLgPic.Size = New System.Drawing.Size(183, 20)
        Me.txtLgPic.TabIndex = 45
        '
        'txtProcessDescription
        '
        Me.txtProcessDescription.Location = New System.Drawing.Point(12, 79)
        Me.txtProcessDescription.Name = "txtProcessDescription"
        Me.txtProcessDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtProcessDescription.Size = New System.Drawing.Size(217, 51)
        Me.txtProcessDescription.TabIndex = 47
        Me.txtProcessDescription.Text = ""
        '
        'txtStateDescription
        '
        Me.txtStateDescription.Location = New System.Drawing.Point(250, 76)
        Me.txtStateDescription.Name = "txtStateDescription"
        Me.txtStateDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtStateDescription.Size = New System.Drawing.Size(250, 57)
        Me.txtStateDescription.TabIndex = 49
        Me.txtStateDescription.Text = ""
        '
        'txtStateHelp
        '
        Me.txtStateHelp.Location = New System.Drawing.Point(506, 23)
        Me.txtStateHelp.Name = "txtStateHelp"
        Me.txtStateHelp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtStateHelp.Size = New System.Drawing.Size(230, 75)
        Me.txtStateHelp.TabIndex = 50
        Me.txtStateHelp.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Process Description"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(247, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "State Description"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(504, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "State Help"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(93, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Format: Type Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbNextState)
        Me.GroupBox2.Controls.Add(Me.cmbPreviousState)
        Me.GroupBox2.Controls.Add(Me.btnClearNext)
        Me.GroupBox2.Controls.Add(Me.chkAlpha)
        Me.GroupBox2.Controls.Add(Me.btnAddNextStateVal)
        Me.GroupBox2.Controls.Add(Me.txtNextLogic)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtVar2)
        Me.GroupBox2.Controls.Add(Me.btnV2)
        Me.GroupBox2.Controls.Add(Me.txtVar1)
        Me.GroupBox2.Controls.Add(Me.btnV1)
        Me.GroupBox2.Controls.Add(Me.cmbIfConditions)
        Me.GroupBox2.Controls.Add(Me.btnNextState)
        Me.GroupBox2.Controls.Add(Me.btnPreviousState)
        Me.GroupBox2.Location = New System.Drawing.Point(507, 206)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(229, 290)
        Me.GroupBox2.TabIndex = 57
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Next State Logic"
        '
        'cmbNextState
        '
        Me.cmbNextState.FormattingEnabled = True
        Me.cmbNextState.Location = New System.Drawing.Point(27, 191)
        Me.cmbNextState.Name = "cmbNextState"
        Me.cmbNextState.Size = New System.Drawing.Size(166, 21)
        Me.cmbNextState.TabIndex = 72
        '
        'cmbPreviousState
        '
        Me.cmbPreviousState.FormattingEnabled = True
        Me.cmbPreviousState.Location = New System.Drawing.Point(10, 43)
        Me.cmbPreviousState.Name = "cmbPreviousState"
        Me.cmbPreviousState.Size = New System.Drawing.Size(195, 21)
        Me.cmbPreviousState.TabIndex = 71
        '
        'btnClearNext
        '
        Me.btnClearNext.Location = New System.Drawing.Point(185, 219)
        Me.btnClearNext.Name = "btnClearNext"
        Me.btnClearNext.Size = New System.Drawing.Size(16, 60)
        Me.btnClearNext.TabIndex = 70
        Me.btnClearNext.Text = "Cl r"
        Me.btnClearNext.UseVisualStyleBackColor = True
        '
        'chkAlpha
        '
        Me.chkAlpha.AutoSize = True
        Me.chkAlpha.Checked = True
        Me.chkAlpha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAlpha.Location = New System.Drawing.Point(157, 75)
        Me.chkAlpha.Name = "chkAlpha"
        Me.chkAlpha.Size = New System.Drawing.Size(53, 17)
        Me.chkAlpha.TabIndex = 58
        Me.chkAlpha.Text = "Alpha"
        Me.chkAlpha.UseVisualStyleBackColor = True
        '
        'btnAddNextStateVal
        '
        Me.btnAddNextStateVal.Location = New System.Drawing.Point(10, 192)
        Me.btnAddNextStateVal.Name = "btnAddNextStateVal"
        Me.btnAddNextStateVal.Size = New System.Drawing.Size(16, 21)
        Me.btnAddNextStateVal.TabIndex = 69
        Me.btnAddNextStateVal.UseVisualStyleBackColor = True
        '
        'txtNextLogic
        '
        Me.txtNextLogic.Location = New System.Drawing.Point(10, 99)
        Me.txtNextLogic.Name = "txtNextLogic"
        Me.txtNextLogic.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtNextLogic.Size = New System.Drawing.Size(199, 87)
        Me.txtNextLogic.TabIndex = 57
        Me.txtNextLogic.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(190, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "IF"
        '
        'txtVar2
        '
        Me.txtVar2.Location = New System.Drawing.Point(27, 260)
        Me.txtVar2.Name = "txtVar2"
        Me.txtVar2.Size = New System.Drawing.Size(157, 20)
        Me.txtVar2.TabIndex = 67
        '
        'btnV2
        '
        Me.btnV2.Location = New System.Drawing.Point(10, 259)
        Me.btnV2.Name = "btnV2"
        Me.btnV2.Size = New System.Drawing.Size(16, 21)
        Me.btnV2.TabIndex = 66
        Me.btnV2.UseVisualStyleBackColor = True
        '
        'txtVar1
        '
        Me.txtVar1.Location = New System.Drawing.Point(27, 218)
        Me.txtVar1.Name = "txtVar1"
        Me.txtVar1.Size = New System.Drawing.Size(157, 20)
        Me.txtVar1.TabIndex = 65
        '
        'btnV1
        '
        Me.btnV1.Location = New System.Drawing.Point(10, 219)
        Me.btnV1.Name = "btnV1"
        Me.btnV1.Size = New System.Drawing.Size(16, 21)
        Me.btnV1.TabIndex = 64
        Me.btnV1.UseVisualStyleBackColor = True
        '
        'cmbIfConditions
        '
        Me.cmbIfConditions.FormattingEnabled = True
        Me.cmbIfConditions.Items.AddRange(New Object() {"goto", "equalTo", "notEqualTo", "greaterThan", "lessThan"})
        Me.cmbIfConditions.Location = New System.Drawing.Point(27, 239)
        Me.cmbIfConditions.Name = "cmbIfConditions"
        Me.cmbIfConditions.Size = New System.Drawing.Size(157, 21)
        Me.cmbIfConditions.TabIndex = 63
        '
        'btnNextState
        '
        Me.btnNextState.Location = New System.Drawing.Point(10, 72)
        Me.btnNextState.Name = "btnNextState"
        Me.btnNextState.Size = New System.Drawing.Size(110, 23)
        Me.btnNextState.TabIndex = 61
        Me.btnNextState.Text = "Make Next State Logic"
        Me.btnNextState.UseVisualStyleBackColor = True
        '
        'btnPreviousState
        '
        Me.btnPreviousState.Location = New System.Drawing.Point(10, 18)
        Me.btnPreviousState.Name = "btnPreviousState"
        Me.btnPreviousState.Size = New System.Drawing.Size(199, 23)
        Me.btnPreviousState.TabIndex = 59
        Me.btnPreviousState.Text = "Add Previous State"
        Me.btnPreviousState.UseVisualStyleBackColor = True
        '
        'btnQuickState
        '
        Me.btnQuickState.Location = New System.Drawing.Point(250, 34)
        Me.btnQuickState.Name = "btnQuickState"
        Me.btnQuickState.Size = New System.Drawing.Size(78, 20)
        Me.btnQuickState.TabIndex = 58
        Me.btnQuickState.Text = "Quick State"
        Me.btnQuickState.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnQuickState.UseVisualStyleBackColor = True
        '
        'cmbQuickState
        '
        Me.cmbQuickState.FormattingEnabled = True
        Me.cmbQuickState.Location = New System.Drawing.Point(334, 33)
        Me.cmbQuickState.Name = "cmbQuickState"
        Me.cmbQuickState.Size = New System.Drawing.Size(147, 21)
        Me.cmbQuickState.TabIndex = 59
        '
        'txtErrorMessage
        '
        Me.txtErrorMessage.Location = New System.Drawing.Point(506, 125)
        Me.txtErrorMessage.Name = "txtErrorMessage"
        Me.txtErrorMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtErrorMessage.Size = New System.Drawing.Size(230, 75)
        Me.txtErrorMessage.TabIndex = 60
        Me.txtErrorMessage.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(506, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Error Message"
        '
        'btnShowQuickStates
        '
        Me.btnShowQuickStates.Location = New System.Drawing.Point(484, 33)
        Me.btnShowQuickStates.Name = "btnShowQuickStates"
        Me.btnShowQuickStates.Size = New System.Drawing.Size(17, 19)
        Me.btnShowQuickStates.TabIndex = 62
        Me.btnShowQuickStates.UseVisualStyleBackColor = True
        '
        'frmStateMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 596)
        Me.Controls.Add(Me.btnShowQuickStates)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtErrorMessage)
        Me.Controls.Add(Me.cmbQuickState)
        Me.Controls.Add(Me.btnQuickState)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStateHelp)
        Me.Controls.Add(Me.txtStateDescription)
        Me.Controls.Add(Me.txtProcessDescription)
        Me.Controls.Add(Me.btnLgPic)
        Me.Controls.Add(Me.txtLgPic)
        Me.Controls.Add(Me.btnSmPic)
        Me.Controls.Add(Me.txtSmPic)
        Me.Controls.Add(Me.editVariables)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnShowXML)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClearState)
        Me.Controls.Add(Me.btnClearAll)
        Me.Controls.Add(Me.btnGcode)
        Me.Controls.Add(Me.txtGcode)
        Me.Controls.Add(Me.btnCalculation)
        Me.Controls.Add(Me.txtCalculations)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtStatePrompt)
        Me.Controls.Add(Me.lblStateTitle)
        Me.Controls.Add(Me.txtStateTitle)
        Me.Controls.Add(Me.btnVariable)
        Me.Controls.Add(Me.txtVariable)
        Me.Controls.Add(Me.lstVariables)
        Me.Controls.Add(Me.btnState)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.cmbState)
        Me.Controls.Add(Me.cmbProcess)
        Me.Name = "frmStateMaker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "State Maker"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbProcess As System.Windows.Forms.ComboBox
    Friend WithEvents cmbState As System.Windows.Forms.ComboBox
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents btnState As System.Windows.Forms.Button
    Friend WithEvents btnVariable As System.Windows.Forms.Button
    Friend WithEvents txtVariable As System.Windows.Forms.TextBox
    Friend WithEvents lstVariables As System.Windows.Forms.ListBox
    Friend WithEvents lblStateTitle As System.Windows.Forms.Label
    Friend WithEvents txtStateTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtStatePrompt As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtButtonLabels As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCalculations As System.Windows.Forms.RichTextBox
    Friend WithEvents btnCalculation As System.Windows.Forms.Button
    Friend WithEvents btnGcode As System.Windows.Forms.Button
    Friend WithEvents txtGcode As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnClearState As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnShowXML As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents editVariables As System.Windows.Forms.Button
    Friend WithEvents txtLower As System.Windows.Forms.TextBox
    Friend WithEvents txtUpper As System.Windows.Forms.TextBox
    Friend WithEvents btnSmPic As System.Windows.Forms.Button
    Friend WithEvents txtSmPic As System.Windows.Forms.TextBox
    Friend WithEvents btnLgPic As System.Windows.Forms.Button
    Friend WithEvents txtLgPic As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents txtStateDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents txtStateHelp As System.Windows.Forms.RichTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnPromptVar As System.Windows.Forms.Button
    Friend WithEvents btnLower As System.Windows.Forms.Button
    Friend WithEvents btnUpper As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbPromptType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClearNext As System.Windows.Forms.Button
    Friend WithEvents chkAlpha As System.Windows.Forms.CheckBox
    Friend WithEvents btnAddNextStateVal As System.Windows.Forms.Button
    Friend WithEvents txtNextLogic As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVar2 As System.Windows.Forms.TextBox
    Friend WithEvents btnV2 As System.Windows.Forms.Button
    Friend WithEvents txtVar1 As System.Windows.Forms.TextBox
    Friend WithEvents btnV1 As System.Windows.Forms.Button
    Friend WithEvents cmbIfConditions As System.Windows.Forms.ComboBox
    Friend WithEvents btnNextState As System.Windows.Forms.Button
    Friend WithEvents btnPreviousState As System.Windows.Forms.Button
    Friend WithEvents chkUnits As System.Windows.Forms.CheckBox
    Friend WithEvents btnQuickState As System.Windows.Forms.Button
    Friend WithEvents cmbQuickState As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNextState As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPreviousState As System.Windows.Forms.ComboBox
    Friend WithEvents txtErrorMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnShowQuickStates As System.Windows.Forms.Button
End Class
