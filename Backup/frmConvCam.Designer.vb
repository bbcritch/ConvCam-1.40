<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConvCAM
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConvCAM))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
        Me.SaveGCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StepbyStepToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConversationalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DataSetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DisplayUnitsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EnglishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MetricToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuImmediateResponse = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HighCodeVerbosityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WoodToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStationManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TouchOffMethodToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SmartToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DynamicToolTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StaticToolTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BullNoseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PresetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConvCAMHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WhereAreMyFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.InstallAddonsUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InstallationHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.LicenseAgreementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeveloperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StateMakerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.IntegrityCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GCODEDebugOFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TestFunctionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tabMain = New System.Windows.Forms.TabControl
        Me.Part = New System.Windows.Forms.TabPage
        Me.pnlPart = New System.Windows.Forms.Panel
        Me.btnBlankDescription = New System.Windows.Forms.Button
        Me.grpToolManager = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtToolStations = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grdProcessList = New System.Windows.Forms.DataGridView
        Me.selCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnProcAdd = New System.Windows.Forms.Button
        Me.btnAddNewProcess = New System.Windows.Forms.Button
        Me.grpPartProcesses = New System.Windows.Forms.GroupBox
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnSeqDn = New System.Windows.Forms.Button
        Me.btnProcRemove = New System.Windows.Forms.Button
        Me.btnSeqUp = New System.Windows.Forms.Button
        Me.Report = New System.Windows.Forms.GroupBox
        Me.txtReport = New System.Windows.Forms.RichTextBox
        Me.pnlProcess = New System.Windows.Forms.Panel
        Me.picBigPic = New System.Windows.Forms.PictureBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.btnCancelProcessEdit = New System.Windows.Forms.Button
        Me.btnFinishAndSave = New System.Windows.Forms.Button
        Me.lblProcessType = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.pnlInputs = New System.Windows.Forms.Panel
        Me.grpTitle = New System.Windows.Forms.GroupBox
        Me.btnSelectNew = New System.Windows.Forms.Button
        Me.radPrompt3 = New System.Windows.Forms.RadioButton
        Me.radPrompt1 = New System.Windows.Forms.RadioButton
        Me.radPrompt2 = New System.Windows.Forms.RadioButton
        Me.txtPrompt = New System.Windows.Forms.TextBox
        Me.lblUnits = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.lblPrompt = New System.Windows.Forms.Label
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.picSmallPic = New System.Windows.Forms.PictureBox
        Me.cmbPrompt = New System.Windows.Forms.ComboBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnHelp = New System.Windows.Forms.Button
        Me.btnDone = New System.Windows.Forms.Button
        Me.btNext = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.cmbCellCombo = New System.Windows.Forms.ComboBox
        Me.txtCellTextBox = New System.Windows.Forms.TextBox
        Me.grdSummary = New System.Windows.Forms.DataGridView
        Me.Parameter = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdButtons = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtXmlViewer = New System.Windows.Forms.RichTextBox
        Me.GCode = New System.Windows.Forms.TabPage
        Me.txtGcodeBox = New System.Windows.Forms.RichTextBox
        Me.Web = New System.Windows.Forms.TabPage
        Me.brsWeb = New System.Windows.Forms.WebBrowser
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnHome = New System.Windows.Forms.Button
        Me.btnBrsGo = New System.Windows.Forms.Button
        Me.btnBrowseForward = New System.Windows.Forms.Button
        Me.btnBrowseBack = New System.Windows.Forms.Button
        Me.txtURL = New System.Windows.Forms.TextBox
        Me.Log = New System.Windows.Forms.TabPage
        Me.txtLog = New System.Windows.Forms.RichTextBox
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog
        Me.lblStatus = New System.Windows.Forms.Label
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.MenuStrip1.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.Part.SuspendLayout()
        Me.pnlPart.SuspendLayout()
        Me.grpToolManager.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdProcessList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPartProcesses.SuspendLayout()
        Me.Report.SuspendLayout()
        Me.pnlProcess.SuspendLayout()
        CType(Me.picBigPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.pnlInputs.SuspendLayout()
        Me.grpTitle.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.picSmallPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCode.SuspendLayout()
        Me.Web.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Log.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.TouchOffMethodToolStripMenuItem, Me.HelpToolStripMenuItem, Me.DeveloperToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(786, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ExitToolStripMenuItem, Me.SaveGCodeToolStripMenuItem, Me.ToolStripSeparator3, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem2})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.NewToolStripMenuItem.Text = "New Part..."
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.OpenToolStripMenuItem.Text = "Open Part..."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SaveToolStripMenuItem.Text = "Save Part..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(154, 6)
        '
        'SaveGCodeToolStripMenuItem
        '
        Me.SaveGCodeToolStripMenuItem.Name = "SaveGCodeToolStripMenuItem"
        Me.SaveGCodeToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SaveGCodeToolStripMenuItem.Text = "Save GCode"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(154, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.PrintToolStripMenuItem.Text = "Print Report..."
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "PrintPreview..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(154, 6)
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(157, 22)
        Me.ExitToolStripMenuItem2.Text = "Exit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StepbyStepToolStripMenuItem, Me.DisplayUnitsToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.mnuImmediateResponse})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.ViewToolStripMenuItem.Text = "Preferences"
        '
        'StepbyStepToolStripMenuItem
        '
        Me.StepbyStepToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConversationalToolStripMenuItem, Me.DataSetsToolStripMenuItem})
        Me.StepbyStepToolStripMenuItem.Name = "StepbyStepToolStripMenuItem"
        Me.StepbyStepToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.StepbyStepToolStripMenuItem.Text = "Process Input Mode"
        '
        'ConversationalToolStripMenuItem
        '
        Me.ConversationalToolStripMenuItem.Name = "ConversationalToolStripMenuItem"
        Me.ConversationalToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ConversationalToolStripMenuItem.Text = "Conversational"
        '
        'DataSetsToolStripMenuItem
        '
        Me.DataSetsToolStripMenuItem.Name = "DataSetsToolStripMenuItem"
        Me.DataSetsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.DataSetsToolStripMenuItem.Text = "Table"
        '
        'DisplayUnitsToolStripMenuItem
        '
        Me.DisplayUnitsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnglishToolStripMenuItem, Me.MetricToolStripMenuItem})
        Me.DisplayUnitsToolStripMenuItem.Name = "DisplayUnitsToolStripMenuItem"
        Me.DisplayUnitsToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.DisplayUnitsToolStripMenuItem.Text = "Display Units"
        '
        'EnglishToolStripMenuItem
        '
        Me.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem"
        Me.EnglishToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.EnglishToolStripMenuItem.Text = "English"
        '
        'MetricToolStripMenuItem
        '
        Me.MetricToolStripMenuItem.Name = "MetricToolStripMenuItem"
        Me.MetricToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.MetricToolStripMenuItem.Text = "Metric"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(208, 22)
        Me.ToolStripMenuItem1.Text = "GCODE Training: High"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(205, 6)
        '
        'mnuImmediateResponse
        '
        Me.mnuImmediateResponse.Name = "mnuImmediateResponse"
        Me.mnuImmediateResponse.Size = New System.Drawing.Size(208, 22)
        Me.mnuImmediateResponse.Text = "Immediate Response: Off"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HighCodeVerbosityToolStripMenuItem, Me.WoodToolStripMenuItem, Me.HiToolStripMenuItem, Me.ToolStripSeparator1, Me.ToolStationManagerToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.SettingsToolStripMenuItem.Text = "Setups"
        '
        'HighCodeVerbosityToolStripMenuItem
        '
        Me.HighCodeVerbosityToolStripMenuItem.Name = "HighCodeVerbosityToolStripMenuItem"
        Me.HighCodeVerbosityToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.HighCodeVerbosityToolStripMenuItem.Text = "Machine  Settings"
        '
        'WoodToolStripMenuItem
        '
        Me.WoodToolStripMenuItem.Name = "WoodToolStripMenuItem"
        Me.WoodToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.WoodToolStripMenuItem.Text = "Blank Selection"
        '
        'HiToolStripMenuItem
        '
        Me.HiToolStripMenuItem.Name = "HiToolStripMenuItem"
        Me.HiToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.HiToolStripMenuItem.Text = "Tool Box Organizer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
        '
        'ToolStationManagerToolStripMenuItem
        '
        Me.ToolStationManagerToolStripMenuItem.Name = "ToolStationManagerToolStripMenuItem"
        Me.ToolStationManagerToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ToolStationManagerToolStripMenuItem.Text = "Tool Station Manager"
        '
        'TouchOffMethodToolStripMenuItem
        '
        Me.TouchOffMethodToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SmartToolToolStripMenuItem, Me.DynamicToolTableToolStripMenuItem, Me.StaticToolTableToolStripMenuItem, Me.PartToolStripMenuItem, Me.BullNoseToolStripMenuItem, Me.PresetToolStripMenuItem})
        Me.TouchOffMethodToolStripMenuItem.Name = "TouchOffMethodToolStripMenuItem"
        Me.TouchOffMethodToolStripMenuItem.Size = New System.Drawing.Size(106, 20)
        Me.TouchOffMethodToolStripMenuItem.Text = "Touch Off Method"
        '
        'SmartToolToolStripMenuItem
        '
        Me.SmartToolToolStripMenuItem.Name = "SmartToolToolStripMenuItem"
        Me.SmartToolToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SmartToolToolStripMenuItem.Text = "Smart Tool"
        '
        'DynamicToolTableToolStripMenuItem
        '
        Me.DynamicToolTableToolStripMenuItem.Name = "DynamicToolTableToolStripMenuItem"
        Me.DynamicToolTableToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.DynamicToolTableToolStripMenuItem.Text = "Dynamic Tool Table"
        '
        'StaticToolTableToolStripMenuItem
        '
        Me.StaticToolTableToolStripMenuItem.Name = "StaticToolTableToolStripMenuItem"
        Me.StaticToolTableToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.StaticToolTableToolStripMenuItem.Text = "Static Tool Table"
        '
        'PartToolStripMenuItem
        '
        Me.PartToolStripMenuItem.Name = "PartToolStripMenuItem"
        Me.PartToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.PartToolStripMenuItem.Text = "Part"
        '
        'BullNoseToolStripMenuItem
        '
        Me.BullNoseToolStripMenuItem.Name = "BullNoseToolStripMenuItem"
        Me.BullNoseToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.BullNoseToolStripMenuItem.Text = "Bull Nose"
        '
        'PresetToolStripMenuItem
        '
        Me.PresetToolStripMenuItem.Name = "PresetToolStripMenuItem"
        Me.PresetToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.PresetToolStripMenuItem.Text = "Preset"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.ConvCAMHelpToolStripMenuItem, Me.WhereAreMyFilesToolStripMenuItem, Me.ToolStripSeparator4, Me.InstallAddonsUpdatesToolStripMenuItem, Me.InstallationHistoryToolStripMenuItem, Me.ToolStripSeparator5, Me.LicenseAgreementToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ConvCAMHelpToolStripMenuItem
        '
        Me.ConvCAMHelpToolStripMenuItem.Name = "ConvCAMHelpToolStripMenuItem"
        Me.ConvCAMHelpToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ConvCAMHelpToolStripMenuItem.Text = "ConvCAM Help"
        '
        'WhereAreMyFilesToolStripMenuItem
        '
        Me.WhereAreMyFilesToolStripMenuItem.Name = "WhereAreMyFilesToolStripMenuItem"
        Me.WhereAreMyFilesToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.WhereAreMyFilesToolStripMenuItem.Text = "Where are my files?"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(218, 6)
        '
        'InstallAddonsUpdatesToolStripMenuItem
        '
        Me.InstallAddonsUpdatesToolStripMenuItem.Name = "InstallAddonsUpdatesToolStripMenuItem"
        Me.InstallAddonsUpdatesToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.InstallAddonsUpdatesToolStripMenuItem.Text = "Install Add-ons"
        '
        'InstallationHistoryToolStripMenuItem
        '
        Me.InstallationHistoryToolStripMenuItem.Name = "InstallationHistoryToolStripMenuItem"
        Me.InstallationHistoryToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.InstallationHistoryToolStripMenuItem.Text = "Installation History (See log)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(218, 6)
        '
        'LicenseAgreementToolStripMenuItem
        '
        Me.LicenseAgreementToolStripMenuItem.Name = "LicenseAgreementToolStripMenuItem"
        Me.LicenseAgreementToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.LicenseAgreementToolStripMenuItem.Text = "License Agreement"
        '
        'DeveloperToolStripMenuItem
        '
        Me.DeveloperToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StateMakerToolStripMenuItem1, Me.IntegrityCheckToolStripMenuItem, Me.GCODEDebugOFFToolStripMenuItem, Me.TestFunctionToolStripMenuItem})
        Me.DeveloperToolStripMenuItem.Name = "DeveloperToolStripMenuItem"
        Me.DeveloperToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.DeveloperToolStripMenuItem.Text = "Developer"
        '
        'StateMakerToolStripMenuItem1
        '
        Me.StateMakerToolStripMenuItem1.Name = "StateMakerToolStripMenuItem1"
        Me.StateMakerToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.StateMakerToolStripMenuItem1.Text = "State Maker"
        '
        'IntegrityCheckToolStripMenuItem
        '
        Me.IntegrityCheckToolStripMenuItem.Name = "IntegrityCheckToolStripMenuItem"
        Me.IntegrityCheckToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.IntegrityCheckToolStripMenuItem.Text = "Integrity Check"
        '
        'GCODEDebugOFFToolStripMenuItem
        '
        Me.GCODEDebugOFFToolStripMenuItem.Name = "GCODEDebugOFFToolStripMenuItem"
        Me.GCODEDebugOFFToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.GCODEDebugOFFToolStripMenuItem.Text = "GCODE Debug: OFF"
        '
        'TestFunctionToolStripMenuItem
        '
        Me.TestFunctionToolStripMenuItem.Name = "TestFunctionToolStripMenuItem"
        Me.TestFunctionToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.TestFunctionToolStripMenuItem.Text = "Test Function"
        '
        'tabMain
        '
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.Controls.Add(Me.Part)
        Me.tabMain.Controls.Add(Me.GCode)
        Me.tabMain.Controls.Add(Me.Web)
        Me.tabMain.Controls.Add(Me.Log)
        Me.tabMain.Location = New System.Drawing.Point(0, 24)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(786, 578)
        Me.tabMain.TabIndex = 1
        '
        'Part
        '
        Me.Part.Controls.Add(Me.pnlProcess)
        Me.Part.Controls.Add(Me.pnlPart)
        Me.Part.Location = New System.Drawing.Point(4, 22)
        Me.Part.Name = "Part"
        Me.Part.Padding = New System.Windows.Forms.Padding(3)
        Me.Part.Size = New System.Drawing.Size(778, 552)
        Me.Part.TabIndex = 2
        Me.Part.Text = "Part"
        Me.Part.UseVisualStyleBackColor = True
        '
        'pnlPart
        '
        Me.pnlPart.Controls.Add(Me.btnBlankDescription)
        Me.pnlPart.Controls.Add(Me.grpToolManager)
        Me.pnlPart.Controls.Add(Me.GroupBox1)
        Me.pnlPart.Controls.Add(Me.grpPartProcesses)
        Me.pnlPart.Controls.Add(Me.Report)
        Me.pnlPart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPart.Location = New System.Drawing.Point(3, 3)
        Me.pnlPart.Name = "pnlPart"
        Me.pnlPart.Size = New System.Drawing.Size(772, 546)
        Me.pnlPart.TabIndex = 4
        '
        'btnBlankDescription
        '
        Me.btnBlankDescription.Location = New System.Drawing.Point(15, 6)
        Me.btnBlankDescription.Name = "btnBlankDescription"
        Me.btnBlankDescription.Size = New System.Drawing.Size(248, 22)
        Me.btnBlankDescription.TabIndex = 41
        Me.btnBlankDescription.Text = "Blank Description"
        Me.btnBlankDescription.UseVisualStyleBackColor = True
        '
        'grpToolManager
        '
        Me.grpToolManager.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpToolManager.Controls.Add(Me.Label3)
        Me.grpToolManager.Controls.Add(Me.Label2)
        Me.grpToolManager.Controls.Add(Me.txtToolStations)
        Me.grpToolManager.Location = New System.Drawing.Point(281, 459)
        Me.grpToolManager.Name = "grpToolManager"
        Me.grpToolManager.Size = New System.Drawing.Size(485, 84)
        Me.grpToolManager.TabIndex = 40
        Me.grpToolManager.TabStop = False
        Me.grpToolManager.Text = "Tool Station Manager"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tool ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Tool Station:"
        '
        'txtToolStations
        '
        Me.txtToolStations.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToolStations.Location = New System.Drawing.Point(80, 14)
        Me.txtToolStations.Name = "txtToolStations"
        Me.txtToolStations.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal
        Me.txtToolStations.Size = New System.Drawing.Size(397, 65)
        Me.txtToolStations.TabIndex = 4
        Me.txtToolStations.Text = ""
        Me.txtToolStations.WordWrap = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.grdProcessList)
        Me.GroupBox1.Controls.Add(Me.btnProcAdd)
        Me.GroupBox1.Controls.Add(Me.btnAddNewProcess)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 424)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Process List"
        '
        'grdProcessList
        '
        Me.grdProcessList.AllowUserToAddRows = False
        Me.grdProcessList.AllowUserToResizeColumns = False
        Me.grdProcessList.AllowUserToResizeRows = False
        Me.grdProcessList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.grdProcessList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdProcessList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selCol, Me.ProcessName})
        Me.grdProcessList.Location = New System.Drawing.Point(10, 48)
        Me.grdProcessList.Name = "grdProcessList"
        Me.grdProcessList.RowHeadersVisible = False
        Me.grdProcessList.Size = New System.Drawing.Size(244, 371)
        Me.grdProcessList.TabIndex = 43
        '
        'selCol
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.selCol.DefaultCellStyle = DataGridViewCellStyle7
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
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.ProcessName.DefaultCellStyle = DataGridViewCellStyle8
        Me.ProcessName.HeaderText = "Process Template Name"
        Me.ProcessName.Name = "ProcessName"
        Me.ProcessName.ReadOnly = True
        '
        'btnProcAdd
        '
        Me.btnProcAdd.Location = New System.Drawing.Point(168, 19)
        Me.btnProcAdd.Name = "btnProcAdd"
        Me.btnProcAdd.Size = New System.Drawing.Size(75, 22)
        Me.btnProcAdd.TabIndex = 41
        Me.btnProcAdd.Text = "Add Existing"
        Me.btnProcAdd.UseVisualStyleBackColor = True
        '
        'btnAddNewProcess
        '
        Me.btnAddNewProcess.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddNewProcess.Location = New System.Drawing.Point(27, 19)
        Me.btnAddNewProcess.Name = "btnAddNewProcess"
        Me.btnAddNewProcess.Size = New System.Drawing.Size(75, 22)
        Me.btnAddNewProcess.TabIndex = 40
        Me.btnAddNewProcess.Text = "Add New"
        Me.btnAddNewProcess.UseVisualStyleBackColor = False
        '
        'grpPartProcesses
        '
        Me.grpPartProcesses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpPartProcesses.Controls.Add(Me.btnEdit)
        Me.grpPartProcesses.Controls.Add(Me.btnSeqDn)
        Me.grpPartProcesses.Controls.Add(Me.btnProcRemove)
        Me.grpPartProcesses.Controls.Add(Me.btnSeqUp)
        Me.grpPartProcesses.Location = New System.Drawing.Point(9, 459)
        Me.grpPartProcesses.Name = "grpPartProcesses"
        Me.grpPartProcesses.Size = New System.Drawing.Size(263, 82)
        Me.grpPartProcesses.TabIndex = 0
        Me.grpPartProcesses.TabStop = False
        Me.grpPartProcesses.Text = "Part Processes"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(41, 47)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(79, 22)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSeqDn
        '
        Me.btnSeqDn.Font = New System.Drawing.Font("Wingdings 3", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnSeqDn.Location = New System.Drawing.Point(186, 47)
        Me.btnSeqDn.Name = "btnSeqDn"
        Me.btnSeqDn.Size = New System.Drawing.Size(33, 22)
        Me.btnSeqDn.TabIndex = 2
        Me.btnSeqDn.Text = "q"
        Me.btnSeqDn.UseVisualStyleBackColor = True
        '
        'btnProcRemove
        '
        Me.btnProcRemove.Location = New System.Drawing.Point(41, 19)
        Me.btnProcRemove.Name = "btnProcRemove"
        Me.btnProcRemove.Size = New System.Drawing.Size(79, 22)
        Me.btnProcRemove.TabIndex = 1
        Me.btnProcRemove.Text = "Remove"
        Me.btnProcRemove.UseVisualStyleBackColor = True
        '
        'btnSeqUp
        '
        Me.btnSeqUp.Font = New System.Drawing.Font("Wingdings 3", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnSeqUp.Location = New System.Drawing.Point(186, 19)
        Me.btnSeqUp.Name = "btnSeqUp"
        Me.btnSeqUp.Size = New System.Drawing.Size(33, 22)
        Me.btnSeqUp.TabIndex = 0
        Me.btnSeqUp.Text = "p"
        Me.btnSeqUp.UseVisualStyleBackColor = True
        '
        'Report
        '
        Me.Report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Report.Controls.Add(Me.txtReport)
        Me.Report.Location = New System.Drawing.Point(278, 6)
        Me.Report.Name = "Report"
        Me.Report.Size = New System.Drawing.Size(491, 445)
        Me.Report.TabIndex = 3
        Me.Report.TabStop = False
        Me.Report.Text = "Report"
        '
        'txtReport
        '
        Me.txtReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReport.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReport.Location = New System.Drawing.Point(6, 16)
        Me.txtReport.Name = "txtReport"
        Me.txtReport.Size = New System.Drawing.Size(482, 423)
        Me.txtReport.TabIndex = 0
        Me.txtReport.Text = ""
        '
        'pnlProcess
        '
        Me.pnlProcess.Controls.Add(Me.picBigPic)
        Me.pnlProcess.Controls.Add(Me.GroupBox8)
        Me.pnlProcess.Controls.Add(Me.GroupBox6)
        Me.pnlProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProcess.Location = New System.Drawing.Point(3, 3)
        Me.pnlProcess.Name = "pnlProcess"
        Me.pnlProcess.Size = New System.Drawing.Size(772, 546)
        Me.pnlProcess.TabIndex = 5
        '
        'picBigPic
        '
        Me.picBigPic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picBigPic.BackColor = System.Drawing.Color.White
        Me.picBigPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picBigPic.Location = New System.Drawing.Point(3, 332)
        Me.picBigPic.Name = "picBigPic"
        Me.picBigPic.Size = New System.Drawing.Size(760, 208)
        Me.picBigPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picBigPic.TabIndex = 12
        Me.picBigPic.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.Controls.Add(Me.btnCancelProcessEdit)
        Me.GroupBox8.Controls.Add(Me.btnFinishAndSave)
        Me.GroupBox8.Controls.Add(Me.lblProcessType)
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(168, 328)
        Me.GroupBox8.TabIndex = 10
        Me.GroupBox8.TabStop = False
        '
        'btnCancelProcessEdit
        '
        Me.btnCancelProcessEdit.Location = New System.Drawing.Point(16, 95)
        Me.btnCancelProcessEdit.Name = "btnCancelProcessEdit"
        Me.btnCancelProcessEdit.Size = New System.Drawing.Size(128, 23)
        Me.btnCancelProcessEdit.TabIndex = 23
        Me.btnCancelProcessEdit.Text = "Cancel"
        Me.btnCancelProcessEdit.UseVisualStyleBackColor = True
        '
        'btnFinishAndSave
        '
        Me.btnFinishAndSave.Location = New System.Drawing.Point(16, 66)
        Me.btnFinishAndSave.Name = "btnFinishAndSave"
        Me.btnFinishAndSave.Size = New System.Drawing.Size(128, 23)
        Me.btnFinishAndSave.TabIndex = 22
        Me.btnFinishAndSave.Text = "Finish and Save"
        Me.btnFinishAndSave.UseVisualStyleBackColor = True
        '
        'lblProcessType
        '
        Me.lblProcessType.AutoSize = True
        Me.lblProcessType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessType.Location = New System.Drawing.Point(13, 29)
        Me.lblProcessType.Name = "lblProcessType"
        Me.lblProcessType.Size = New System.Drawing.Size(0, 16)
        Me.lblProcessType.TabIndex = 21
        Me.lblProcessType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Process File: "
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.pnlInputs)
        Me.GroupBox6.Location = New System.Drawing.Point(177, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(581, 325)
        Me.GroupBox6.TabIndex = 11
        Me.GroupBox6.TabStop = False
        '
        'pnlInputs
        '
        Me.pnlInputs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlInputs.AutoScroll = True
        Me.pnlInputs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlInputs.Controls.Add(Me.grpTitle)
        Me.pnlInputs.Controls.Add(Me.cmbCellCombo)
        Me.pnlInputs.Controls.Add(Me.txtCellTextBox)
        Me.pnlInputs.Controls.Add(Me.grdSummary)
        Me.pnlInputs.Controls.Add(Me.txtXmlViewer)
        Me.pnlInputs.Location = New System.Drawing.Point(18, 10)
        Me.pnlInputs.Name = "pnlInputs"
        Me.pnlInputs.Size = New System.Drawing.Size(557, 309)
        Me.pnlInputs.TabIndex = 0
        '
        'grpTitle
        '
        Me.grpTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grpTitle.Controls.Add(Me.btnSelectNew)
        Me.grpTitle.Controls.Add(Me.radPrompt3)
        Me.grpTitle.Controls.Add(Me.radPrompt1)
        Me.grpTitle.Controls.Add(Me.radPrompt2)
        Me.grpTitle.Controls.Add(Me.txtPrompt)
        Me.grpTitle.Controls.Add(Me.lblUnits)
        Me.grpTitle.Controls.Add(Me.Panel5)
        Me.grpTitle.Controls.Add(Me.cmbPrompt)
        Me.grpTitle.Controls.Add(Me.Panel4)
        Me.grpTitle.Location = New System.Drawing.Point(125, 31)
        Me.grpTitle.Name = "grpTitle"
        Me.grpTitle.Size = New System.Drawing.Size(326, 261)
        Me.grpTitle.TabIndex = 1
        Me.grpTitle.TabStop = False
        Me.grpTitle.Text = "Title"
        Me.grpTitle.Visible = False
        '
        'btnSelectNew
        '
        Me.btnSelectNew.Location = New System.Drawing.Point(120, 188)
        Me.btnSelectNew.Name = "btnSelectNew"
        Me.btnSelectNew.Size = New System.Drawing.Size(87, 25)
        Me.btnSelectNew.TabIndex = 17
        Me.btnSelectNew.Text = "#"
        Me.btnSelectNew.UseVisualStyleBackColor = True
        '
        'radPrompt3
        '
        Me.radPrompt3.Appearance = System.Windows.Forms.Appearance.Button
        Me.radPrompt3.Location = New System.Drawing.Point(213, 188)
        Me.radPrompt3.Name = "radPrompt3"
        Me.radPrompt3.Size = New System.Drawing.Size(99, 23)
        Me.radPrompt3.TabIndex = 14
        Me.radPrompt3.TabStop = True
        Me.radPrompt3.Text = "#"
        Me.radPrompt3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radPrompt3.UseVisualStyleBackColor = True
        '
        'radPrompt1
        '
        Me.radPrompt1.Appearance = System.Windows.Forms.Appearance.Button
        Me.radPrompt1.Location = New System.Drawing.Point(15, 188)
        Me.radPrompt1.Name = "radPrompt1"
        Me.radPrompt1.Size = New System.Drawing.Size(99, 23)
        Me.radPrompt1.TabIndex = 12
        Me.radPrompt1.TabStop = True
        Me.radPrompt1.Text = "#"
        Me.radPrompt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radPrompt1.UseVisualStyleBackColor = True
        '
        'radPrompt2
        '
        Me.radPrompt2.Appearance = System.Windows.Forms.Appearance.Button
        Me.radPrompt2.Location = New System.Drawing.Point(114, 188)
        Me.radPrompt2.Name = "radPrompt2"
        Me.radPrompt2.Size = New System.Drawing.Size(99, 23)
        Me.radPrompt2.TabIndex = 13
        Me.radPrompt2.TabStop = True
        Me.radPrompt2.Text = "#"
        Me.radPrompt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.radPrompt2.UseVisualStyleBackColor = True
        '
        'txtPrompt
        '
        Me.txtPrompt.Location = New System.Drawing.Point(67, 190)
        Me.txtPrompt.Multiline = True
        Me.txtPrompt.Name = "txtPrompt"
        Me.txtPrompt.Size = New System.Drawing.Size(191, 20)
        Me.txtPrompt.TabIndex = 10
        '
        'lblUnits
        '
        Me.lblUnits.AutoSize = True
        Me.lblUnits.Location = New System.Drawing.Point(264, 194)
        Me.lblUnits.Name = "lblUnits"
        Me.lblUnits.Size = New System.Drawing.Size(29, 13)
        Me.lblUnits.TabIndex = 11
        Me.lblUnits.Text = "units"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblPrompt)
        Me.Panel5.Controls.Add(Me.CheckedListBox1)
        Me.Panel5.Controls.Add(Me.picSmallPic)
        Me.Panel5.Location = New System.Drawing.Point(8, 13)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(309, 173)
        Me.Panel5.TabIndex = 6
        '
        'lblPrompt
        '
        Me.lblPrompt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrompt.Location = New System.Drawing.Point(3, 7)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(200, 145)
        Me.lblPrompt.TabIndex = 6
        Me.lblPrompt.Text = "prompt"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(39, 22)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(120, 94)
        Me.CheckedListBox1.TabIndex = 9
        '
        'picSmallPic
        '
        Me.picSmallPic.Location = New System.Drawing.Point(209, 7)
        Me.picSmallPic.Name = "picSmallPic"
        Me.picSmallPic.Size = New System.Drawing.Size(92, 145)
        Me.picSmallPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picSmallPic.TabIndex = 8
        Me.picSmallPic.TabStop = False
        '
        'cmbPrompt
        '
        Me.cmbPrompt.FormattingEnabled = True
        Me.cmbPrompt.Location = New System.Drawing.Point(67, 189)
        Me.cmbPrompt.Name = "cmbPrompt"
        Me.cmbPrompt.Size = New System.Drawing.Size(217, 21)
        Me.cmbPrompt.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnHelp)
        Me.Panel4.Controls.Add(Me.btnDone)
        Me.Panel4.Controls.Add(Me.btNext)
        Me.Panel4.Controls.Add(Me.btnBack)
        Me.Panel4.Location = New System.Drawing.Point(5, 225)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(315, 28)
        Me.Panel4.TabIndex = 3
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(263, 2)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(47, 21)
        Me.btnHelp.TabIndex = 2
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(113, 0)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(90, 23)
        Me.btnDone.TabIndex = 16
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        Me.btnDone.Visible = False
        '
        'btNext
        '
        Me.btNext.Location = New System.Drawing.Point(158, 2)
        Me.btNext.Name = "btNext"
        Me.btNext.Size = New System.Drawing.Size(45, 23)
        Me.btNext.TabIndex = 1
        Me.btNext.Text = ">>"
        Me.btNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(113, 2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(45, 23)
        Me.btnBack.TabIndex = 0
        Me.btnBack.Text = "<<"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'cmbCellCombo
        '
        Me.cmbCellCombo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbCellCombo.FormattingEnabled = True
        Me.cmbCellCombo.Location = New System.Drawing.Point(0, 25)
        Me.cmbCellCombo.Name = "cmbCellCombo"
        Me.cmbCellCombo.Size = New System.Drawing.Size(69, 21)
        Me.cmbCellCombo.TabIndex = 17
        '
        'txtCellTextBox
        '
        Me.txtCellTextBox.AcceptsTab = True
        Me.txtCellTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCellTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCellTextBox.Location = New System.Drawing.Point(0, 46)
        Me.txtCellTextBox.Multiline = True
        Me.txtCellTextBox.Name = "txtCellTextBox"
        Me.txtCellTextBox.Size = New System.Drawing.Size(69, 20)
        Me.txtCellTextBox.TabIndex = 16
        '
        'grdSummary
        '
        Me.grdSummary.AllowUserToAddRows = False
        Me.grdSummary.AllowUserToDeleteRows = False
        Me.grdSummary.AllowUserToResizeColumns = False
        Me.grdSummary.AllowUserToResizeRows = False
        Me.grdSummary.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.grdSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSummary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Parameter, Me.Value, Me.cmdButtons, Me.Column1, Me.Column2, Me.Column3})
        Me.grdSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSummary.Enabled = False
        Me.grdSummary.Location = New System.Drawing.Point(0, 0)
        Me.grdSummary.Name = "grdSummary"
        Me.grdSummary.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdSummary.Size = New System.Drawing.Size(553, 305)
        Me.grdSummary.TabIndex = 0
        '
        'Parameter
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Parameter.DefaultCellStyle = DataGridViewCellStyle9
        Me.Parameter.FillWeight = 150.0!
        Me.Parameter.HeaderText = "Parameter"
        Me.Parameter.Name = "Parameter"
        Me.Parameter.ReadOnly = True
        Me.Parameter.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Parameter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Parameter.Width = 220
        '
        'Value
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Value.DefaultCellStyle = DataGridViewCellStyle10
        Me.Value.FillWeight = 150.0!
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        Me.Value.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Value.Width = 200
        '
        'cmdButtons
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdButtons.DefaultCellStyle = DataGridViewCellStyle11
        Me.cmdButtons.FillWeight = 120.0!
        Me.cmdButtons.HeaderText = "Help"
        Me.cmdButtons.Name = "cmdButtons"
        Me.cmdButtons.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cmdButtons.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cmdButtons.Width = 50
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle12
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        Me.Column3.Visible = False
        '
        'txtXmlViewer
        '
        Me.txtXmlViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtXmlViewer.Location = New System.Drawing.Point(0, 0)
        Me.txtXmlViewer.Name = "txtXmlViewer"
        Me.txtXmlViewer.Size = New System.Drawing.Size(553, 305)
        Me.txtXmlViewer.TabIndex = 2
        Me.txtXmlViewer.Text = ""
        '
        'GCode
        '
        Me.GCode.Controls.Add(Me.txtGcodeBox)
        Me.GCode.Location = New System.Drawing.Point(4, 22)
        Me.GCode.Name = "GCode"
        Me.GCode.Padding = New System.Windows.Forms.Padding(3)
        Me.GCode.Size = New System.Drawing.Size(778, 552)
        Me.GCode.TabIndex = 3
        Me.GCode.Text = "GCode"
        Me.GCode.UseVisualStyleBackColor = True
        '
        'txtGcodeBox
        '
        Me.txtGcodeBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGcodeBox.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGcodeBox.Location = New System.Drawing.Point(3, 3)
        Me.txtGcodeBox.Name = "txtGcodeBox"
        Me.txtGcodeBox.Size = New System.Drawing.Size(772, 546)
        Me.txtGcodeBox.TabIndex = 0
        Me.txtGcodeBox.Text = ""
        '
        'Web
        '
        Me.Web.Controls.Add(Me.brsWeb)
        Me.Web.Controls.Add(Me.Panel1)
        Me.Web.Location = New System.Drawing.Point(4, 22)
        Me.Web.Name = "Web"
        Me.Web.Padding = New System.Windows.Forms.Padding(3)
        Me.Web.Size = New System.Drawing.Size(778, 552)
        Me.Web.TabIndex = 1
        Me.Web.Text = "Web Site"
        Me.Web.UseVisualStyleBackColor = True
        '
        'brsWeb
        '
        Me.brsWeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.brsWeb.Location = New System.Drawing.Point(3, 54)
        Me.brsWeb.MinimumSize = New System.Drawing.Size(20, 20)
        Me.brsWeb.Name = "brsWeb"
        Me.brsWeb.Size = New System.Drawing.Size(772, 495)
        Me.brsWeb.TabIndex = 2
        Me.brsWeb.Url = New System.Uri("", System.UriKind.Relative)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnHome)
        Me.Panel1.Controls.Add(Me.btnBrsGo)
        Me.Panel1.Controls.Add(Me.btnBrowseForward)
        Me.Panel1.Controls.Add(Me.btnBrowseBack)
        Me.Panel1.Controls.Add(Me.txtURL)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(772, 51)
        Me.Panel1.TabIndex = 0
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(615, 14)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(55, 20)
        Me.btnHome.TabIndex = 4
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'btnBrsGo
        '
        Me.btnBrsGo.Location = New System.Drawing.Point(575, 14)
        Me.btnBrsGo.Name = "btnBrsGo"
        Me.btnBrsGo.Size = New System.Drawing.Size(32, 20)
        Me.btnBrsGo.TabIndex = 3
        Me.btnBrsGo.Text = "Go"
        Me.btnBrsGo.UseVisualStyleBackColor = True
        '
        'btnBrowseForward
        '
        Me.btnBrowseForward.Location = New System.Drawing.Point(70, 16)
        Me.btnBrowseForward.Name = "btnBrowseForward"
        Me.btnBrowseForward.Size = New System.Drawing.Size(56, 19)
        Me.btnBrowseForward.TabIndex = 2
        Me.btnBrowseForward.Text = "Forward"
        Me.btnBrowseForward.UseVisualStyleBackColor = True
        '
        'btnBrowseBack
        '
        Me.btnBrowseBack.Location = New System.Drawing.Point(8, 16)
        Me.btnBrowseBack.Name = "btnBrowseBack"
        Me.btnBrowseBack.Size = New System.Drawing.Size(56, 19)
        Me.btnBrowseBack.TabIndex = 1
        Me.btnBrowseBack.Text = "Back"
        Me.btnBrowseBack.UseVisualStyleBackColor = True
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(141, 15)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(421, 20)
        Me.txtURL.TabIndex = 0
        Me.txtURL.Text = "http://www.legacywoodworking.com/"
        '
        'Log
        '
        Me.Log.Controls.Add(Me.txtLog)
        Me.Log.Location = New System.Drawing.Point(4, 22)
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(778, 552)
        Me.Log.TabIndex = 5
        Me.Log.Text = "Log"
        Me.Log.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.Location = New System.Drawing.Point(0, 0)
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(778, 552)
        Me.txtLog.TabIndex = 0
        Me.txtLog.Text = ""
        '
        'dlgOpen
        '
        Me.dlgOpen.FileName = "OpenFileDialog1"
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblStatus.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(0, 605)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(786, 18)
        Me.lblStatus.TabIndex = 2
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'frmConvCAM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 623)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmConvCAM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conversational CAM"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.Part.ResumeLayout(False)
        Me.pnlPart.ResumeLayout(False)
        Me.grpToolManager.ResumeLayout(False)
        Me.grpToolManager.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdProcessList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPartProcesses.ResumeLayout(False)
        Me.Report.ResumeLayout(False)
        Me.pnlProcess.ResumeLayout(False)
        CType(Me.picBigPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.pnlInputs.ResumeLayout(False)
        Me.pnlInputs.PerformLayout()
        Me.grpTitle.ResumeLayout(False)
        Me.grpTitle.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.picSmallPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCode.ResumeLayout(False)
        Me.Web.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Log.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents Web As System.Windows.Forms.TabPage
    Friend WithEvents brsWeb As System.Windows.Forms.WebBrowser
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnBrowseForward As System.Windows.Forms.Button
    Friend WithEvents btnBrowseBack As System.Windows.Forms.Button
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents btnBrsGo As System.Windows.Forms.Button
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StepbyStepToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuImmediateResponse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Part As System.Windows.Forms.TabPage
    Friend WithEvents Report As System.Windows.Forms.GroupBox
    Friend WithEvents txtReport As System.Windows.Forms.RichTextBox
    Friend WithEvents GCode As System.Windows.Forms.TabPage
    Friend WithEvents txtGcodeBox As System.Windows.Forms.RichTextBox
    Friend WithEvents grpPartProcesses As System.Windows.Forms.GroupBox
    Friend WithEvents btnSeqDn As System.Windows.Forms.Button
    Friend WithEvents btnProcRemove As System.Windows.Forms.Button
    Friend WithEvents btnSeqUp As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents HighCodeVerbosityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pnlPart As System.Windows.Forms.Panel
    Friend WithEvents pnlProcess As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlInputs As System.Windows.Forms.Panel
    Friend WithEvents grpTitle As System.Windows.Forms.GroupBox
    Friend WithEvents radPrompt3 As System.Windows.Forms.RadioButton
    Friend WithEvents radPrompt1 As System.Windows.Forms.RadioButton
    Friend WithEvents radPrompt2 As System.Windows.Forms.RadioButton
    Friend WithEvents txtPrompt As System.Windows.Forms.TextBox
    Friend WithEvents lblUnits As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents picSmallPic As System.Windows.Forms.PictureBox
    Friend WithEvents lblPrompt As System.Windows.Forms.Label
    Friend WithEvents cmbPrompt As System.Windows.Forms.ComboBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents grdSummary As System.Windows.Forms.DataGridView
    Friend WithEvents txtXmlViewer As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFinishAndSave As System.Windows.Forms.Button
    Friend WithEvents lblProcessType As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picBigPic As System.Windows.Forms.PictureBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents WoodToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConversationalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataSetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisplayUnitsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConvCAMHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Log As System.Windows.Forms.TabPage
    Friend WithEvents txtLog As System.Windows.Forms.RichTextBox
    Friend WithEvents grpToolManager As System.Windows.Forms.GroupBox
    Friend WithEvents DeveloperToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StateMakerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IntegrityCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TouchOffMethodToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmartToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DynamicToolTableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StaticToolTableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BullNoseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PresetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStationManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents GCODEDebugOFFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBlankDescription As System.Windows.Forms.Button
    Friend WithEvents TestFunctionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents txtCellTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Parameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdButtons As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbCellCombo As System.Windows.Forms.ComboBox
    Friend WithEvents SaveGCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancelProcessEdit As System.Windows.Forms.Button
    Friend WithEvents WhereAreMyFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InstallAddonsUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstallationHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LicenseAgreementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtToolStations As System.Windows.Forms.RichTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSelectNew As System.Windows.Forms.Button
    Friend WithEvents btnProcAdd As System.Windows.Forms.Button
    Friend WithEvents btnAddNewProcess As System.Windows.Forms.Button
    Friend WithEvents grdProcessList As System.Windows.Forms.DataGridView
    Friend WithEvents selCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnglishToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetricToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class