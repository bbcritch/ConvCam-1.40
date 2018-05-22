Imports System.Drawing
Imports System.IO
Imports System.IO.StringReader
Imports System.Drawing.Printing

Public Class frmConvCAM

    Dim selectedProcessRow As Integer

    Dim stateNum As Integer
    Dim suppressNext As Integer = 0
    Dim partNameDir As String
    Dim processNumber As Integer

    Dim sPreserveTextBox As String = ""

    Dim newPartFlag As Boolean = False
    Dim newProcessFlag As Boolean = False
    Dim dialogWasOpened As Boolean = False

    Dim sActiveStateList As String

    Dim PartDisp As String = "Part"

    Dim curSumRow As Integer = -1
    Dim curSumCol As Integer = -1

    Dim finalGCode As String
    Dim metaGCode As String

    Dim tableRowCount As Integer

    Dim myTooltip As ToolTip = Nothing
    Dim stateList As New myList

    Dim tabName As String = "Part"
    Dim th As New tabHandler
    Dim sh As New systemHandler

    Dim sTemplateName As String

    Private Const TITLECOLUMN = 0
    Public Const VARCOLUMN = 1
    Private Const HELPCOLUMN = 2
    ''Private Const SPACERCOL = 3
    Public Const COLTYPE = 3
    Public Const STATENAMECOL = 4

    Private bSuppressFlag As Boolean = False
    Private bSuppressDoublePressFlag As Boolean = False
    Private bSuppressDoubleEnterFlag As Integer = 0


    Private bSuppressAdvanceFlag As Boolean = False

    Dim ProcessInEdit As String

    Dim fCell As New FloatingCell

    ''    Dim GCODEDIR As String

    Dim forceClose As Boolean

    Private Sub frmConvCAM_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim result As MsgBoxResult

        If forceClose = False Then
            result = MsgBox("Do you wish to save your part file before exiting?", MsgBoxStyle.YesNoCancel)
            Select Case result
                Case MsgBoxResult.Yes
                    savePartFile1()
                    If abortSave = True Then e.Cancel = True
                Case MsgBoxResult.No
                    forceClose = True
                    Me.Close()
                Case MsgBoxResult.Cancel
                    e.Cancel = True
            End Select
        End If

    End Sub

    Private Sub frmConvCAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim f As New fileManager, x As New myXmlUtils
        Dim s As New systemHandler

        TestFunction()
        forceClose = False

        If Not s.StartSequence Then
            DEMOMODE = True
            MsgBox("You are running in DEMO mode.")
        End If

        frmSplash.Show()
        frmSplash.Refresh()

        System.Threading.Thread.Sleep(2000)

        configStartUp()
        readPreferences()

        SetTouchOffCheckMark()

        Part.Visible = True
        ProcessInEdit = ""

        showPart()
        initGUI()

        getAllVariables()
        loadMachineVals()

        setGuiPreferences()
        UpdateStatusBar()

        InitToolTable()

        frmSplash.Close()

        startUpFlag = 1

        updateDispUnitsMenu()
        fCell.setObjects(grdSummary, txtCellTextBox, cmbCellCombo)

    End Sub
    Private Sub initGUI()

        ' TAB CONTROL -- REMOVE AND REPLACE    
        '       Dim s As New myList
        '
        '        s.setList(th.removeAllTabs(tabMain))
        '        th.restoreTabs(tabMain, s.getList)


        grdSummary.Visible = False
        grpTitle.Visible = False

        hideViews()
        hideSubProcesses()
        createDirectories()

        hideMenus()

        dh.designInit()
        updateDesignSequence()

        ''PROCINPUTMODE = TABLEINPUT

        myTooltip = New ToolTip()
        myTooltip.AutoPopDelay = 5000
        myTooltip.InitialDelay = 1000
        myTooltip.ReshowDelay = 500
        myTooltip.ShowAlways = True

        myTooltip.Active = True

        SaveGCodeToolStripMenuItem.Enabled = True

    End Sub
    Private Sub hideMenus()

        If DEVELOPMENTMODE = 1 Then
            DeveloperToolStripMenuItem.Visible = True
        Else
            DeveloperToolStripMenuItem.Visible = False
            tabMain.TabPages.Remove(tabMain.TabPages("Log"))
        End If

    End Sub
    Private Sub hideViews()

        grpTitle.Visible = False
        grdSummary.Visible = False
        fCell.hideFloatingCells()
    End Sub
    Private Sub hideSubProcesses()

        hideViews()

    End Sub
    Private Sub loadProcessTemplate()

        Dim f As New fileManager, fname As String, x As New myXmlUtils

        hideSubProcesses()

        sTemplateName = stateVars.getVar("TEMPLATE")
        fname = gPath.addSlash(gPath.templateProcessPath) & sTemplateName

        If f.filePresent(fname) Then

            p.readProcessDefinitionFile(sTemplateName)
            dispView()

            LoadPicture(picBigPic, sTemplateName.Replace(".txt", ".bmp"))

        End If
    End Sub
    Private Sub RunProcessWizard()

        Dim grpList As New myList

        p.setStartState()
        dispView()

        LoadProcessToTable()
        AdvanceTo(0)


        ''Select Case PROCINPUTMODE

        ''    ''Case STEPBYSTEP

        ''    ''    p.setStartState()
        ''    ''    dispView()
        ''    ''    runState(p.getCurrentState)

        ''    Case TABLEINPUT

        ''        p.setStartState()
        ''        dispView()
        ''        LoadProcessToTable()

        ''End Select

    End Sub
    Private Sub runState(ByVal stateName As String)

        If stateName = "" Then Exit Sub

        p.setCurrentState(stateName)
        dispState()

    End Sub
    Public Sub dispState()

        Dim x As New myXmlUtils
        Dim uLim As String
        Dim lLim As String
        Dim f As New fileManager

        lblPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12)

        dispPromptText(False, "")
        dispPromptCombo(False, "")
        dispPromptButtons(False, "")
        dispDialog(False, "")
        lblUnits.Text = ""

        lblPrompt.Text = VarsToVals(p.stateInfoDetail("PROMPT").Replace("~", vbLf))
        grpTitle.Text = p.stateInfoDetail("TITLE")   'UNITS

        uLim = p.stateInfoDetail("ULIM")
        lLim = p.stateInfoDetail("LLIM")

        setPrevNextButtons()
        setPictures()

        Select Case p.stateInfoDetail("STTYPE").ToLower
            Case "text"
                If uLim <> "" Then
                    If uLim.Substring(0, 1) = "|" Then uLim = stateVars.getVar(uLim)
                    'CONV                    lblPrompt.Text = lblPrompt.Text & vbLf & vbLf & " Upper Limit: " & SRound(ToMetric(uLim))
                    lblPrompt.Text = lblPrompt.Text & vbLf & vbLf & " Upper Limit: " & uLim
                End If
                If lLim <> "" Then
                    If lLim.Substring(0, 1) = "|" Then lLim = stateVars.getVar(lLim)
                    'CONV                    lblPrompt.Text = lblPrompt.Text & vbLf & " Lower Limit: " & SRound(ToMetric(lLim))
                    lblPrompt.Text = lblPrompt.Text & vbLf & " Lower Limit: " & lLim
                End If
                dispPromptText(True, p.stateInfoDetail("BUTTONLIST"))
            Case "radio"
                dispPromptButtons(True, p.stateInfoDetail("BUTTONLIST"))
            Case "combo"
                dispPromptCombo(True, p.stateInfoDetail("BUTTONLIST"))
            Case "tool"
                ' ''dispCuttingTool(True)
                toolIdx = p.stateInfoDetail("IDX")
                dispDialog(True, p.stateInfoDetail("BUTTONLIST"))
            Case "file"
                stateVars.setVar("FileNameOnly", f.fileNameOnly(stateVars.getVar(p.getCurrentState)))
                lblPrompt.Text = VarsToVals(p.stateInfoDetail("PROMPT").Replace("~", vbLf))
                dispDialog(True, p.stateInfoDetail("BUTTONLIST"))
            Case "none", "finish"
                lblPrompt.Visible = True
        End Select
    End Sub
    Private Sub dispDialog(ByVal vis As Boolean, ByVal t As String)

        btnSelectNew.Visible = vis
        lblPrompt.Visible = vis

        btnSelectNew.Text = t

    End Sub
    Private Sub dispPromptButtons(ByVal vis As Boolean, ByVal t As String)

        Dim i As Integer, x As New myXmlUtils, tlist As New myList

        tlist.setList(t)

        i = tlist.length(DL)
        lblPrompt.Visible = vis

        radPrompt1.Text = "BOGUS"
        radPrompt2.Text = "BOGUS"
        radPrompt3.Text = "BOGUS"

        radPrompt1.Visible = False
        radPrompt2.Visible = False
        radPrompt3.Visible = False

        radPrompt1.Checked = False
        radPrompt2.Checked = False
        radPrompt3.Checked = False

        Select Case i
            Case 1
                radPrompt2.Checked = True
                radPrompt2.Text = VarsToVals(tlist.getItem(0, DL))   'UNITS
                radPrompt2.Visible = True
            Case 2
                radPrompt1.Checked = True
                radPrompt1.Text = VarsToVals(tlist.getItem(0, DL))   'UNITS
                radPrompt1.Visible = True
                radPrompt3.Text = VarsToVals(tlist.getItem(1, DL))   'UNITS
                radPrompt3.Visible = True
                If stateVars.getVar(p.getCurrentState) = radPrompt3.Text Then radPrompt3.Checked = True
            Case 3
                radPrompt1.Checked = True
                radPrompt1.Text = VarsToVals(tlist.getItem(0, DL))   'UNITS
                radPrompt1.Visible = True
                radPrompt2.Text = VarsToVals(tlist.getItem(1, DL))   'UNITS
                radPrompt2.Visible = True
                radPrompt3.Text = VarsToVals(tlist.getItem(2, DL))   'UNITS
                radPrompt3.Visible = True
                If stateVars.getVar(p.getCurrentState) = radPrompt2.Text Then radPrompt2.Checked = True
                If stateVars.getVar(p.getCurrentState) = radPrompt3.Text Then radPrompt3.Checked = True
        End Select

    End Sub
    Private Sub dispPromptText(ByVal vis As Boolean, ByVal defaultText As String)

        Dim x As New myXmlUtils, tList As New myList

        lblPrompt.Visible = vis
        txtPrompt.Visible = vis
        txtPrompt.Focus()
        lblUnits.Visible = vis

        If vis = True Then
            '' ''If p.stateInfoDetail("UNITS") = "true" Then
            If p.getCurrentState.Substring(0, 1) = "u" Then
                If DISPUNITS = ENGLISH Then
                    lblUnits.Text = "in"
                Else
                    lblUnits.Text = "mm"
                End If
            Else
                lblUnits.Text = ""
            End If
        End If

        ' Load txtPrompt with state variable
        SetTextPrompt(VarsToVals(p.getCurrentState))   'UNITS
        If txtPrompt.Text = "BAD INPUT" Then txtPrompt.Text = ""

        ' If state variable is blank, set it to default, and update state variable
        If defaultText <> "" And txtPrompt.Text = "" Then  '
            ' Defaults always in ENGLISH, store in english, retrieve as unit-ed
            tList.setList(defaultText)
            stateVars.setVar(p.getCurrentState, p.resolveVariable(tList.getItem(0, DL)))
            SetTextPrompt(VarsToVals(p.getCurrentState))   'UNITS
        End If

    End Sub
    ''Private Sub dispCuttingTool(ByVal vis As Boolean)

    ''    '' Deprecated, no longer called.


    ''    organizeMode = TOOLMODE
    ''    frmSetupOrganizer.ShowDialog()
    ''    stateVars.setVar("Tool", stateVars.getVar("ToolMfgID"))
    ''    If PROCINPUTMODE = TABLEINPUT Then
    ''        closeConvBox()
    ''        AdvanceDown()
    ''    Else
    ''        gotoNext()
    ''    End If

    ''End Sub
    Private Sub dispPromptCombo(ByVal vis As Boolean, ByVal t As String)

        Dim i As Integer, x As New myXmlUtils, tList As New myList

        suppressNext = 1
        tList.setList(t)

        lblPrompt.Visible = vis
        cmbPrompt.Visible = vis
        cmbPrompt.Items.Clear()

        For i = 0 To tList.length(DL) - 1
            If tList.getItem(i, DL) <> "" Then cmbPrompt.Items.Add(VarsToVals(tList.getItem(i, DL)))
        Next

        If stateVars.getVar(p.getCurrentState) = "" Then
            cmbPrompt.Text = VarsToVals(tList.getItem(0, DL))   'UNITS
        Else
            cmbPrompt.Text = VarsToVals(p.getCurrentState)
        End If

    End Sub
    Private Sub dispView()

        hideViews()
        If p.getCurrentState = "" Then Exit Sub

        grdSummary.Visible = True
        txtCellTextBox.Visible = True
        cmbCellCombo.Visible = False

        ''Select Case PROCINPUTMODE
        ''    ''Case STEPBYSTEP
        ''    ''    grpTitle.Visible = True

        ''    Case TABLEINPUT
        ''        grdSummary.Visible = True
        ''        txtCellTextBox.Visible = True
        ''        cmbCellCombo.Visible = False
        ''End Select

    End Sub
    Private Sub gotoNext()

        If Not saveStateValue() Then Exit Sub

        stateCalcs()
        runState(p.nextState())
        getStateValue()

        grpTitle.Visible = False

        ''Select Case PROCINPUTMODE
        ''    Case TABLEINPUT
        ''        grpTitle.Visible = False
        ''    Case Else

        ''End Select

    End Sub
    Private Sub stateCalcs()

        Dim s As String, x As New myXmlUtils, cLine As String, ary() As String, c As New calc
        Dim tList As New myList, i As Integer

        stateVars.setVar("GCODETOOLPATHDESCRIPTION", txtGCodeToolPathDescription.Text)

        s = p.stateInfoDetail("CALC")
        If s = "" Then Exit Sub

        tList.setList(s)

        For i = 0 To tList.length("$")

            cLine = tList.getItem(i, "$")
            ary = Split(cLine, "=")
            If ary.Length = 2 Then stateVars.setVar(stateVars.varDeFormat(ary(0)), c.calcEngine(ary(1)))

        Next

    End Sub
    Private Function saveStateValue() As Boolean

        Dim promptType As String = "", t As String, varVal As String

        saveStateValue = True

        Select Case p.stateInfoDetail("STTYPE").ToLower
            Case "text"
                If txtPrompt.Text.Trim = "" Then
                    MsgBox("You must enter a value before advancing.", MsgBoxStyle.OkOnly)
                    saveStateValue = False
                    Exit Function
                End If
                varVal = txtPrompt.Text
                t = inputCheck(p.getCurrentState, varVal, p.stateInfoDetail("LLIM"), p.stateInfoDetail("ULIM"))
                If t <> "BAD INPUT" Then
                    stateVars.setVar(p.getCurrentState, t, DISPUNITS)
                Else
                    saveStateValue = False
                End If
            Case "radio"
                    If radPrompt1.Checked Then ValToVar(p.getCurrentState, radPrompt1.Text)
                    If radPrompt2.Checked Then ValToVar(p.getCurrentState, radPrompt2.Text)
                    If radPrompt3.Checked Then ValToVar(p.getCurrentState, radPrompt3.Text)
            Case "combo"
                    ValToVar(p.getCurrentState, cmbPrompt.Text)
            Case "tool"
            Case "file"

            Case "none"
                stateVars.setVar(p.getCurrentState, "ENDOFINPUT")
        End Select

    End Function
    Public Sub getStateValue()

        Dim promptType As String = "", t As String = ""
        Dim tList As New myList

        t = stateVars.getVar(p.getCurrentState, DISPUNITS)
        If t = "" Then
            t = p.stateInfoDetail("BUTTONLIST")
            If t <> "" Then
                tList.setList(t)
                t = tList.getItem(0, DL)
            End If
        End If

        'CONV        If p.getCurrentState.Substring(0, 1) = "u" Then t = ToMetric(t)
        Select Case p.stateInfoDetail("STTYPE").ToLower

            Case "text"
                txtPrompt.Text = ""
                If t <> "BAD INPUT" Then SetTextPrompt(t) 'UNITS
            Case "radio"
                If radPrompt1.Text = t Then radPrompt1.Checked = True
                If radPrompt2.Text = t Then radPrompt2.Checked = True
                If radPrompt3.Text = t Then radPrompt3.Checked = True
            Case "combo"
                suppressNext = 1
                cmbPrompt.Text = t   'UNITS
                suppressNext = 0
            Case "tool"
            Case "file"
            Case "none"
                ' no value to load, always determined from other state variables
        End Select

    End Sub
    Private Sub SetTextPrompt(ByVal t As String)
        txtPrompt.Text = t
        txtPrompt.SelectionStart = 0
        txtPrompt.SelectionLength = txtPrompt.Text.Length
    End Sub
    Public Sub readProcess(ByVal fname As String)

        Dim s As String
        Dim f As New fileManager
        Dim prefs As String
        Dim x As New myXmlUtils

        ' Get current preferences
        prefs = f.fileRead(gPath.Path(gPath.Configs, "Preferences.txt"))

        currentProcess = fname

        s = f.fileRead(fname)
        stateVars.loadVarString(s)



        ' Overwrite State Variable values for blank and machine variables, and touchoff method
        ' These values are selected via the setups
        ' The tool values are determined within the ConvCAM process.
        loadBlankVals()
        loadMachineVals()
        stateVars.setVar("TOUCHOFFMETHOD", x.extract(prefs, "TOUCHOFFMETHOD"))

        lblProcessType.Text = f.fileNameOnly(fname)
        loadProcessTemplate()

        txtGCodeToolPathDescription.Text = stateVars.getVar("GCODETOOLPATHDESCRIPTION")

    End Sub

    Private Sub addSavedProcess()

        Dim f As New fileManager, fname As String
        Dim x As New myXmlUtils
        Dim tList As New myList

        If btnBlankDescription.Text = "Blank Description" Then
            MsgBox("You must first select your blank wood piece.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        dlgOpen.Reset()
        dlgOpen.InitialDirectory = gPath.addSlash(gPath.basePath) & "My Parts"
        ''        dlgOpen.Filter = "Part Files (*.txt)|*.txt"
        dlgOpen.Filter = "Part File (*.txt;*.ccm)|*.txt;*.ccm"

        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then

            fname = dlgOpen.FileName

            If f.filePresent(fname) Then
                sTempDesignFile = f.fileRead(fname)

                tList.setList(x.extract(sTempDesignFile, "PROCESSLIST"))

                If tList.getList.Trim <> "" Then

                    frmProcessPicker.ShowDialog()

                    If sTempDesignFile <> "" Then

                        Dim processName As String = x.extract(sTempDesignFile, "ProcessName")
                        fname = gPath.addSlash(gPath.partPath) & "temp part\" & processName

                        Dim i As Integer = 1
                        Dim newFname As String = fname

                        Do While (f.filePresent(newFname & ".txt"))
                            newFname = fname & "_" & i.ToString
                            i = i + 1
                        Loop

                        sTempDesignFile = x.replace(sTempDesignFile, f.fileNameOnly(newFname), "ProcessName")

                        f.fileWrite(newFname & ".txt", sTempDesignFile)
                        dh.addProcess(newFname)
                        updateDesignSequence()
                        setProcessSelectCursor(grdProcessList.RowCount - 1)

                    End If
                End If
            End If
        End If

    End Sub
    Private Function toggleMe(ByVal currentVal As Boolean) As Boolean

        If currentVal = False Then
            toggleMe = True
            ''INPUTRESPONSE = True
        Else
            toggleMe = False
            ''INPUTRESPONSE = False
        End If

    End Function
    Private Sub setPrevNextButtons()

        Dim x As New myXmlUtils

        btnBack.Enabled = True
        btNext.Enabled = True

        ''If PROCINPUTMODE <> STEPBYSTEP Then
        ''btnBack.Enabled = True
        ''btNext.Enabled = True
        ''Exit Sub

        ''End If

        ''If p.stateInfoDetail("PREV") = "" Then
        ''    btnBack.Enabled = False
        ''Else
        ''    btnBack.Enabled = True
        ''End If

        ''If p.stateInfoDetail("NEXT") = "" Then
        ''    btNext.Enabled = False
        ''Else
        ''    btNext.Enabled = True
        ''End If

    End Sub
    Private Sub setPictures()

        Dim fname As String
        Dim ary() As String
        Dim x As New myXmlUtils
        Dim picAndTabName() As String
        Dim tabLabel As String

        'fname = p.stateInfoDetail("SMPIC")

        'Select Case fname.ToLower
        '    Case "", "none"
        '        picSmallPic.Visible = False
        '        LoadPicture(picSmallPic, "")
        '        lblPrompt.Width = 298
        '    Case "same"
        '    Case Else
        '        LoadPicture(picSmallPic, fname)
        '        picSmallPic.Visible = True
        '        lblPrompt.Width = 200
        'End Select

        fname = p.stateInfoDetail("LGPIC")
        Select Case fname.ToLower
            Case "", "none"
                LoadPicture(picBigPic, "")
                pnlSingleImage.Visible = True
                pnlImages.Visible = False
            Case "same"
            Case Else

                ' multi image format:   filename:tabname#filename:tabname#..
                ary = fname.Split("#")

                If ary.Length = 1 Then
                    pnlSingleImage.Visible = True
                    pnlImages.Visible = False
                    LoadPicture(picBigPic, fname)
                Else

                    ' For multiple images, show the multi image panel with the tabs,
                    ' hide all the tabs, then add those for which there are images.
                    pnlSingleImage.Visible = False
                    pnlImages.Visible = True

                    removeTabPages()

                    For i = 0 To 9

                        ' Parse out the picture name and tab name
                        picAndTabName = ary(i).Split(":")

                        ' Pull the tab name (label) from picAndTabName(1)
                        If picAndTabName.Length = 2 Then
                            tabLabel = picAndTabName(1)
                        Else
                            tabLabel = "Tab " & i.ToString
                        End If

                        ' Only add tab pages, if there is an image for it.
                        If ary(i).Length > 0 Then
                            Select Case i
                                Case 0
                                    LoadPicture(pic0, picAndTabName(0))
                                Case 1
                                    LoadPicture(pic1, picAndTabName(0))
                                Case 2
                                    LoadPicture(pic2, picAndTabName(0))
                                Case 3
                                    LoadPicture(pic3, picAndTabName(0))
                                Case 4
                                    LoadPicture(pic4, picAndTabName(0))
                                Case 5
                                    LoadPicture(Pic5, picAndTabName(0))
                                Case 6
                                    LoadPicture(Pic6, picAndTabName(0))
                                Case 7
                                    LoadPicture(Pic7, picAndTabName(0))
                                Case 8
                                    LoadPicture(Pic8, picAndTabName(0))
                                Case 9
                                    LoadPicture(Pic9, picAndTabName(0))
                            End Select
                            addTabPage(i, tabLabel)
                        End If
                    Next
                End If
        End Select

    End Sub

    Private Sub removeTabPages()
        Try
            For i = 0 To 9
                tabImages.TabPages.Remove(tabImages.TabPages("TabPage" & (i + 1).ToString))
            Next
        Catch
        End Try

    End Sub
    Private Sub addTabPage(ByVal idx As Integer, ByVal tabLabel As String)

        Try
            tabImages.TabPages.Add(tabImages.TabPages("TabPage" & (idx + 1).ToString))
        Catch
            '' Ignore error if already present
        End Try

        ' If there is no tab label, name it "View idx"
        If tabLabel.Length = 0 Then
            tabImages.TabPages.Item(idx).Text = "View " & (idx + 1).ToString
        Else
            tabImages.TabPages.Item(idx).Text = tabLabel
        End If

    End Sub
    Private Function inputCheck(ByVal varName As String, ByVal valu As String, ByVal lLim As String, ByVal uLim As String) As String

        Dim a As Single, b As Single, c As Single
        Dim dispLlim As String, dispHlim As String
        Dim mg As String

        ' Valu, the value being checked for soundness, comes in as a string representation of
        ' a number. It comes in in the units the system is displaying as (metric or english)
        ' If it is valid (parses correctly, within range) it will be returned as is (rounded to 4 digits). 
        ' If not, a message box will display it is invalid and "BAD INPUT" will be returned.

        inputCheck = valu

        If p.stateInfoDetail("UNITS") <> "true" Then Exit Function
        If uLim = "" Or lLim = "" Then Exit Function

        If Single.TryParse(valu, a) Then

            ' If the number parses correctly and has no limits, exit the function
            ' successfully
            inputCheck = SRound(valu)

            dispLlim = SRound(lLim)
            dispHlim = SRound(uLim)

            ' Convert limits to metric, if necessary
            If varName.Substring(0, 1) = "u" Then
                If DISPUNITS = METRIC Then
                    dispLlim = SRound(ToMetric(lLim))
                    dispHlim = SRound(ToMetric(uLim))
                End If
            End If

            ' Parse the valu and string limits into numbers a,b, c
            a = Math.Round(Single.Parse(valu), 4)
            b = Math.Round(Single.Parse(stateVars.resolveVariable(dispLlim)), 4)
            c = Math.Round(Single.Parse(stateVars.resolveVariable(dispHlim)), 4)

            ' if the number is within range, exit the function
            If a >= b And a <= c Then Exit Function

            ' otherwise, pop up a message box showing the invalid input.
            mg = "'" & a & "' is out of range." & vbLf & vbLf
            mg = mg & "  Lower Limit: " & b & vbLf
            mg = mg & "  Upper Limit: " & c


            MsgBox(mg, MsgBoxStyle.OkOnly, "Out of Range")
            inputCheck = "BADINPUT"

        Else
            ' Invalid numeric entry
            MsgBox("'" & valu & "' is an invalid number.", MsgBoxStyle.OkOnly, "Invalid Input")
            inputCheck = "BADINPUT"

        End If

    End Function
    Private Sub KickOffProcessInputTable()

        ''        setInputMode(TABLEINPUT)
        dispView()
        ' Exit if no process is selected
        ' TBD if no processes in list, exit

        LoadProcessToTable()
        LoadProcessToTable()
        UpdateStatusBar()

    End Sub
    Private Function LoadProcessToTable() As String

        sActiveStateList = p.getStateList
        SetTableSize()

        If sActiveStateList.Length = 0 Then Exit Function

        PopulateTable()
        curSumRow = 0
        fCell.PlaceCell(0, VARCOLUMN)

        Return getCell(grdProcessList, 0, STATENAMECOL)

    End Function
    Private Sub populateRow(ByVal stateName As String)

        Dim x As New myXmlUtils, s As String, ary() As String
        Dim varVal As String, defaultVal As String


        If stateName <> "" Then

            setCell(grdSummary, tableRowCount, TITLECOLUMN, p.stateInfoDetail("TITLE"))
            setCell(grdSummary, tableRowCount, STATENAMECOL, stateName)
            SetToTextCell(grdSummary, tableRowCount, VARCOLUMN)

            cellReadWrite(grdSummary, tableRowCount, VARCOLUMN)
            setCell(grdSummary, tableRowCount, COLTYPE, "")

            s = p.stateInfoDetail("STTYPE")
            defaultVal = p.stateInfoDetail("BUTTONLIST")
            varVal = stateVars.getVar(stateName)

            If s = "combo" Or s = "radio" Then

                If defaultVal <> "" Then

                    ary = defaultVal.Split(DL)
                    setCell(grdSummary, tableRowCount, COLTYPE, defaultVal)

                    If varVal = "" Then varVal = ary(0)

                    setCell(grdSummary, tableRowCount, VARCOLUMN, varVal)
                    stateVars.setVar(stateName, varVal)
                    cellReadOnly(grdSummary, tableRowCount, VARCOLUMN)

                End If

            ElseIf s = "file" Then

            Else

                If varVal = "" Or varVal = "BAD INPUT" Then

                    varVal = defaultVal

                    Dim lLim As String = stateVars.resolveVariable(p.stateInfoDetail("LLIM"))
                    Dim uLim As String = stateVars.resolveVariable(p.stateInfoDetail("ULIM"))

                    If varVal = "" Then varVal = lLim
                    If varVal = "" Then varVal = uLim

                End If

                stateVars.setVar(stateName, varVal)

                'CONV '' ''If stateName.Substring(0, 1) = "u" And varVal <> "" Then
                ' '' ''    varVal = SRound(ToMetric(varVal))
                ' '' ''End If

                setCell(grdSummary, tableRowCount, VARCOLUMN, varVal)

            End If

            setButton(grdSummary, tableRowCount, HELPCOLUMN)

        End If

    End Sub
    Private Function getSummaryCount() As Integer

        Dim s As New myList, t As New myList

        s.setList(p.getProcessInfo("STATELIST"))
        getSummaryCount = s.length(DL)

    End Function
    Private Function closeConvBox() As Boolean

        Dim varName As String
        Dim varVal As String

        closeConvBox = False
        If Not saveStateValue() Then Exit Function

        closeConvBox = True

        grpTitle.Visible = False

        Dim rw As Integer
        Dim cl As Integer

        getRowCol(grdSummary, rw, cl)

        varName = getCell(grdSummary, rw, STATENAMECOL)
        varVal = stateVars.getVar(varName)

        'CONV        'If varName.Substring(0, 1) = "u" Then
        '    varVal = SRound(ToMetric(varVal))
        'End If

        '        SetCellText(varVal)
        fCell.PlaceCell(rw, VARCOLUMN)
        fCell.setValue(varVal)
        setCell(grdSummary, fCell.nCurrentRow, VARCOLUMN, varVal)

        CheckForStateChanges()

        grdSummary.Enabled = True
        btnDone.Visible = False

    End Function
    ''Private Sub setInputMode(ByVal inputMode As Integer)

    ''    ''Select Case inputMode
    ''    ''    Case STEPBYSTEP
    ''    ''        ConversationalToolStripMenuItem.Checked = True
    ''    ''        DataSetsToolStripMenuItem.Checked = False
    ''    ''    Case TABLEINPUT
    ''    ''        ConversationalToolStripMenuItem.Checked = False
    ''    ''        DataSetsToolStripMenuItem.Checked = True
    ''    ''End Select

    ''    ''PROCINPUTMODE = inputMode
    ''    dispView()


    ''End Sub
    Private Sub newHandler()

        Dim f As New fileManager
        Dim x As New myXmlUtils

        Select Case tabName

            Case "Part"
                If Part.Visible Then

                    If PartFileName <> "" Then
                        If MsgBox("Do you wish to save your part (" & PartFileName & ") before creating a new one?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                            savePartFile1()
                        End If
                    End If

                    PartFileName = ""
                    Descriptions = ""
                    DesignerName = ""
                    GCodePartComment = ""

                    frmPartInfo.ShowDialog()
                    If PartFileName = "" Then Exit Sub

                    processNumber = 1

                    dh.designInit()
                    updateDesignSequence()

                    organizeMode = BLANKMODE
                    frmSetupOrganizer.ShowDialog()
                    SetBlankButtonLabel()
                    txtReport.Text = dh.makeDesignReport

                End If
            Case "G Code"
                    txtGcodeBox.Text = ""
        End Select

    End Sub
    Private Sub readHandler()
        Select Case tabName
            Case "Part"
                readPartFile()
                ''ValidateAllInputs()
            Case "G Code"
                readGCode()
        End Select
    End Sub
    Private Sub loadProcess(ByVal fname)

        readProcess(fname)
        showProcess()

        p.setStartState()
        KickOffProcessInputTable()
        KickOffProcessInputTable()
        curSumRow = 0

        ResetTable()

        ''Select Case PROCINPUTMODE
        ''    ''Case STEPBYSTEP
        ''    ''    RunProcessWizard()
        ''    Case TABLEINPUT
        ''        p.setStartState()
        ''        KickOffProcessInputTable()
        ''        KickOffProcessInputTable()
        ''        curSumRow = 0

        ''        ResetTable()

        ''End Select

        getStateValue()

    End Sub
    Private Sub ResetTable()
        setActiveCell(grdSummary, 0, VARCOLUMN)
        fCell.PlaceCell(0, VARCOLUMN)

        AdvanceTo(0)
        ''TableHelp(0)
    End Sub

    Private Sub readPartFile()

        Dim f As New fileManager, s As String, tempDir As String, pDir As String
        Dim x As New myXmlUtils, tList As New myList

        dlgOpen.Reset()
        dlgOpen.InitialDirectory = gPath.userPartPath
        dlgOpen.Filter = "Part File (*.txt;*.ccm)|*.txt;*.ccm"

        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then

            tempDir = gPath.addSlash(gPath.partPath) & "temp part"
            pDir = f.directoryOnly(dlgOpen.FileName)

            s = f.fileRead(dlgOpen.FileName)
            Call gPath.makeUserPartPath(System.IO.Path.GetDirectoryName(dlgOpen.FileName))

            If s <> "" Then

                frmPartResolution.CancelFlag = False

                ' Check for blank info discrepancies. Resolve if necessary,
                ' including changing ID in part file to match new blankinfo in lib file
                If frmPartResolution.ExtractBlankInfo(s) = False Then
                    frmPartResolution.ShowDialog()
                    If frmPartResolution.CancelFlag = False Then
                        Dim delimVar As String = x.extract(blankConfig, "DELIMVAR")
                        s = x.replace(s, x.extract(blankMy, delimVar), "BLANKINFO " & delimVar)
                        f.fileWrite(dlgOpen.FileName, s)
                    End If
                End If

                If frmPartResolution.CancelFlag = False Then

                    dh.designInit()

                    tList.setList(x.extract(s, "PROCESSLIST"))

                    For i = 0 To tList.length(DL) - 1
                        f.fileWrite(gPath.Path(tempDir, tList.getItem(i, DL) & ".txt"), x.extract(s, tList.getItem(i, DL)))
                        dh.addProcess(gPath.Path(tempDir, tList.getItem(i, DL)))
                    Next

                    UpdateProgramInfo(s)
                    UpdateBlankInfo()

                    updateDesignSequence()

                    buildGCODE()

                End If

            End If

        End If

    End Sub
    Private Sub UpdateProgramInfo(ByVal s As String)

        Dim x As New myXmlUtils

        PartFileName = x.extract(s, "PARTNAME")
        DesignerName = x.extract(s, "DESIGNERNAME")
        Descriptions = stripBlankLines(x.extract(s, "DESCRIPTION"))
        GCodePartComment = stripBlankLines(x.extract(s, "GCODEPARTCOMMENT"))

    End Sub
    Private Sub UpdateBlankInfo()

        Dim tlist As New myList
        Dim x As New myXmlUtils

        tlist.setListFromXML(blankMy)

        For i = 0 To tlist.length(DL) - 1
            stateVars.setVar(tlist.getItem(i, DL), x.extract(blankMy, tlist.getItem(i, DL)))
        Next

        RefreshDisplay()

    End Sub
    Private Sub readGCode()

        Dim f As New fileManager

        dlgOpen.Reset()
        dlgOpen.InitialDirectory = gPath.userGcodePath

        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            txtGcodeBox.Text = f.fileRead(dlgOpen.FileName)   'UNITS
        End If

        Call gPath.makeUserGcodePath(System.IO.Path.GetDirectoryName(dlgOpen.FileName))

    End Sub
    Private Sub SaveCompositePartFile()

        Dim sFileString = dh.makePartFile()
        Dim sFname As String
        Dim f As New fileManager
        Dim x As New myXmlUtils

        sFname = gPath.Path(gPath.userPartPath, PartFileName & ".ccm")
        f.fileWrite(sFname, sFileString)

    End Sub
    Private Sub savePartFile()

        Dim f As New fileManager, s As String, x As New myXmlUtils, tempList As New myList
        Dim tDir As String, pDir As String, partsSaved As String
        Dim gC As New gCodeBuilder, fname As String

        s = dh.makeDesignXML

        If Integer.Parse(x.extract(s, "QTY")) > 1 Then

            Dim partsDir As String = x.extract(f.fileRead(gPath.Configs & "partPath.txt"), "PATH")
            If partsDir = "" Then partsDir = gPath.addSlash(gPath.basePath) & "My Parts"

            dlgSave.Reset()
            dlgSave.InitialDirectory = partsDir
            dlgSave.ShowDialog()

            If dlgSave.FileName <> "" Then

                fname = f.fileNameOnly(dlgSave.FileName)
                pDir = gPath.addSlash(gPath.basePath) & "My Parts\" & fname
                tDir = gPath.addSlash(gPath.basePath) & "My Parts\temp part"

                If tDir = pDir Then
                    MsgBox("You cannot use 'temp parts' as a part name.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                ''partsSaved = f.getDirectories(gPath.partPath)
                ''tempList.setList(partsSaved)
                partsDir = dlgSave.InitialDirectory
                partsSaved = f.getDirectories(partsDir)
                tempList.setList(partsSaved)

                If tempList.indexOf(fname, DL) >= 0 Then
                    If MsgBox("This design already exists. Do you wish to overwrite it?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                        Exit Sub
                    Else
                        f.directoryDelete(pDir)
                    End If
                End If


                f.makeDirectory(pDir)

                f.fileWrite(tDir & "\Design.prt", s)
                f.copyDirFiles(tDir, pDir)

            End If

        Else
            MsgBox("There is no design to save..", MsgBoxStyle.OkOnly, "No Design")
        End If

    End Sub
    Private Sub saveGCode()

        Dim f As New fileManager
        ''       If GCODEDIR = "" Then GCODEDIR = gPath.addSlash(gPath.basePath) & "My gCode"
        buildGCODE()
        If txtGcodeBox.Text.Trim <> "" Then

            dlgSave.Reset()
            dlgSave.InitialDirectory = gPath.userGcodePath
            dlgSave.Filter = "G CODE FILE (*.txt)|*.txt"

            If dlgSave.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                f.fileWrite(dlgSave.FileName, txtGcodeBox.Text.Replace(vbLf, vbCrLf))
                gPath.makeUserGcodePath(System.IO.Path.GetDirectoryName(dlgSave.FileName))
                ''               GCODEDIR = System.IO.Path.GetDirectoryName(dlgSave.FileName)
            End If
        Else
            MsgBox("There is no G CODE to save..", MsgBoxStyle.OkOnly, "No G CODE")
        End If

    End Sub
    Private Sub buildGCODE()

        Dim gC As New gCodeBuilder

        txtGcodeBox.Text = ""

        ' makeGCodeAll is called twice, to clean-up tool mis-info,
        ' do to chicken and egg sequencing
        gC.makeGCodeAll()
        txtGcodeBox.Text = gC.makeGCodeAll

    End Sub
    Private Sub UpdateStatusBar()

        ''lblStatus.Text = inputModeString() & "  " & displayUnits() & "  " & GcodeVerbosity() & "  " & immResp() & "  " & TouchOffMethod()
        lblStatus.Text = displayUnits() & "  " & GcodeVerbosity() & "  " & TouchOffMethod()
        writePreferences()

    End Sub
    Private Function inputModeString() As String

        inputModeString = "INPUT MODE: Table         "

        ''Select Case PROCINPUTMODE
        ''    ''Case STEPBYSTEP
        ''    ''    inputModeString = "INPUT MODE: Conversational"
        ''    Case TABLEINPUT
        ''        inputModeString = "INPUT MODE: Table         "
        ''    Case Else
        ''        inputModeString = ""
        ''End Select
    End Function
    Private Function displayUnits() As String

        If DISPUNITS = METRIC Then
            displayUnits = "UNITS: Metric "
        Else
            displayUnits = "UNITS: English"
        End If

    End Function
    Private Function GcodeVerbosity() As String

        If TRAINING Then
            GcodeVerbosity = "G CODE TRAINING: On "
        Else
            GcodeVerbosity = "G CODE TRAINING: Off"
        End If

    End Function
    ''Private Function immResp() As String

    ''    If INPUTRESPONSE Then
    ''        immResp = "RESP: Auto  "
    ''    Else
    ''        immResp = "RESP: Manual"
    ''    End If

    ''End Function
    Private Function TouchOffMethod()

        TouchOffMethod = ""

        Select Case stateVars.getVar("TOUCHOFFMETHOD")
            Case "SmartTool"
                TouchOffMethod = "TOUCH OFF: Smart  "
            Case "DynamicToolTable"
                TouchOffMethod = "TOUCH OFF: Dynamic"
            Case "StaticToolTable"
                TouchOffMethod = "TOUCH OFF: Static"
            Case "Part"
                TouchOffMethod = "TOUCH OFF: Part   "
            Case "BullNose"
                TouchOffMethod = "TOUCH OFF: Bull   "
            Case "Preset"
                TouchOffMethod = "TOUCH OFF: Preset "
        End Select

    End Function
    Public Sub refreshGrid()

        Dim s As String, i As Integer

        For i = 0 To grdSummary.RowCount - 1

            s = getCell(grdSummary, i, STATENAMECOL)

            If s <> "" Then
                setCell(grdSummary, i, VARCOLUMN, VarsToVals(s))
            End If

        Next

    End Sub
    Public Sub GridToState()

        Dim stateName As String, varVal As String

        stateName = getCell(grdSummary, curSumRow, STATENAMECOL)
        varVal = getCell(grdSummary, curSumRow, VARCOLUMN)
        ValToVar(stateName, varVal)

    End Sub
    Private Sub showProcess()

        pnlProcess.Visible = True
        pnlPart.Visible = False
        PartDisp = "Toolpath"
        DisplayUnitsToolStripMenuItem.Enabled = False

    End Sub
    Private Sub showPart()
        pnlProcess.Visible = False
        pnlPart.Visible = True
        PartDisp = "Part"
        DisplayUnitsToolStripMenuItem.Enabled = True
    End Sub
    Private Sub setGuiPreferences()

        Dim f As New fileManager
        Dim x As New myXmlUtils

        readPreferences()

        updateDispUnitsMenu()

        '' ''Select Case DISPUNITS
        '' ''    Case ENGLISH
        '' ''        DisplayUnitsToolStripMenuItem.Text = "Display Units: English"
        '' ''    Case METRIC
        '' ''        DisplayUnitsToolStripMenuItem.Text = "Display Units: Metric"
        '' ''End Select

        ''        Call setInputMode(PROCINPUTMODE)
        dispView()

        Select Case TRAINING
            Case True
                ToolStripMenuItem1.Text = "G CODE Training: On"
            Case False
                ToolStripMenuItem1.Text = "G CODE Training: Off"
        End Select

        ''Select Case INPUTRESPONSE
        ''    Case True
        ''        mnuImmediateResponse.Text = "Immediate Response: On"
        ''    Case False
        ''        mnuImmediateResponse.Text = "Immediate Response: Off"
        ''End Select

        grpToolManager.Text = "Tool Set: " & f.fileNameOnly(f.stripExtension(STATIONFILE))

    End Sub
    Private Sub ToolBoxShow()

        frmFixedToolbox.ShowDialog()
        writePreferences()
        setGuiPreferences()
        UpdateStatusBar()
        InitToolTable()

    End Sub
    Private Sub LoadToolTable()

        Dim ToolID As String

        Dim sStations As String = ""
        Dim sIDs As String = ""
        Dim sHeader As String = "| Physical"
        Dim sSpacer = ""

        For i = 0 To tsMan.TotalStations - 1
            If i = tsMan.MaxStations Then
                sStations = "|" & sStations
                sIDs = "|" & sIDs
                sHeader = "Virtual || Physical"
            End If

            If i > tsMan.MaxStations Then
                sSpacer = "       " & sSpacer
            End If

            ToolID = tsMan.aStations(i).ToolID
            sStations = appendString("|" & fitString((i + 1).ToString, 6, "center"), sStations, "")
            sIDs = appendString("|" & fitString(ToolID, 6, "center"), sIDs, "")

        Next

        Dim sTableSpacer = ""

        If tsMan.TotalStations > tsMan.MaxStations Then
            sTableSpacer = " "
        End If

        txtToolStations.Text = sSpacer & sHeader
        txtToolStations.AppendText(vbLf & sTableSpacer & sStations & "|")
        txtToolStations.AppendText(vbLf & sTableSpacer & sIDs & "|")

    End Sub
    Public Sub InitToolTable()
        tsMan.makeAutoStationeFile()
        tsMan.readStationFile()
        tsMan.InitializeStations()
        tsMan.LoadToolAssignmentsFromFile()
        LoadToolTable()
        ScrollToEndOfToolTable()
    End Sub
    Public Sub AddToLog(ByVal s As String)
        txtLog.Text = txtLog.Text & s
    End Sub
    Public Sub ClearLog()
        txtLog.Text = ""
    End Sub
    Private Sub UpdateTouchOffChecksAll()
        UnCheckTouchOffs()
        UpdateStatusBar()
        writePreferences()
        ''        If tabName = "GCode" Then buildGCODE()
    End Sub
    Private Sub UnCheckTouchOffs()
        SmartToolToolStripMenuItem.Checked = False
        DynamicToolTableToolStripMenuItem.Checked = False
        StaticToolTableToolStripMenuItem.Checked = False
        PartToolStripMenuItem.Checked = False
        BullNoseToolStripMenuItem.Checked = False
        PresetToolStripMenuItem.Checked = False
    End Sub
    Private Sub SetTouchOffCheckMark()

        UnCheckTouchOffs()
        Select Case stateVars.getVar("TOUCHOFFMETHOD")
            Case "SmartTool"
                SmartToolToolStripMenuItem.Checked = True
            Case "DynamicToolTable"
                DynamicToolTableToolStripMenuItem.Checked = True
            Case "Part"
                PartToolStripMenuItem.Checked = True
            Case "BullNose"
                BullNoseToolStripMenuItem.Checked = True
            Case "StaticToolTable"
                StaticToolTableToolStripMenuItem.Checked = True
            Case "Preset"
                PresetToolStripMenuItem.Checked = True
        End Select

    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'PrintPage is the foundational printing event. This event gets fired for every
        ' page that will be printed
        Static intCurrentChar As Int32
        ' declaring a static variable to hold the position of the last printed char
        Dim font As New Font("Courier New", 12)
        ' initializing the font to be used for printing
        Dim PrintAreaHeight, PrintAreaWidth, marginLeft, marginTop As Int32
        With PrintDocument1.DefaultPageSettings
            ' initializing local variables that contain the bounds of the printing area rectangle
            PrintAreaHeight = .PaperSize.Height - .Margins.Top - .Margins.Bottom
            PrintAreaWidth = .PaperSize.Width - .Margins.Left - .Margins.Right
            ' initializing local variables to hold margin values that will serve
            ' as the X and Y coordinates for the upper left corner of the printing
            ' area rectangle.
            marginLeft = .Margins.Left
            marginTop = .Margins.Top
            ' X and Y coordinate
        End With

        If PrintDocument1.DefaultPageSettings.Landscape Then
            Dim intTemp As Int32
            intTemp = PrintAreaHeight
            PrintAreaHeight = PrintAreaWidth
            PrintAreaWidth = intTemp
            ' if the user selects landscape mode, swap the printing area height and width
        End If

        Dim intLineCount As Int32 = CInt(PrintAreaHeight / font.Height)
        Dim rectPrintingArea As New RectangleF(marginLeft, marginTop, PrintAreaWidth, PrintAreaHeight)
        Dim fmt As New StringFormat(StringFormatFlags.LineLimit)
        Dim intLinesFilled, intCharsFitted As Int32
        e.Graphics.MeasureString(Mid(txtReport.Text, intCurrentChar + 1), font, New SizeF(PrintAreaWidth, PrintAreaHeight), fmt, intCharsFitted, intLinesFilled)
        e.Graphics.DrawString(Mid(txtReport.Text, intCurrentChar + 1), font, Brushes.Black, rectPrintingArea, fmt)
        intCurrentChar += intCharsFitted
        If intCurrentChar < txtReport.Text.Length Then
            e.HasMorePages = True
            'HasMorePages tells the printing module whether another PrintPage event should be fired
        Else
            e.HasMorePages = False
            intCurrentChar = 0
        End If
    End Sub
    Private Sub RefreshDisplay()

        Select Case tabName

            Case "Part"
                ''If PartDisp = "Part" Then
                ''    txtReport.Text = dh.makeDesignReport()
                ''End If
                ''Case "G Code"
                ''    buildGCODE()
            Case "Report"
                txtReport.Text = dh.makeDesignReport()
            Case "Log"
            Case "Web Site"
        End Select

        SetBlankButtonLabel()

    End Sub
    Private Sub SetBlankButtonLabel()
        btnBlankDescription.Text = "Blank: " & MakeBlankDescr()
    End Sub
    Private Sub CheckForStateChanges()
        If p.getStateList <> sActiveStateList Then KickOffProcessInputTable()
    End Sub
    Public Function cleanUpValue(ByVal s As String) As String
        s = s.Replace(Chr(10), "")
        s = s.Replace(Chr(13), "")
        s = s.Replace(Chr(40), "")
        cleanUpValue = s
    End Function
    Private Function IsCombo() As Boolean
        If getCell(grdSummary, curSumRow, COLTYPE) = "" Then
            IsCombo = False
        Else
            IsCombo = True
        End If
    End Function
    Private Sub SetFileMenu(ByVal tabname As String)

        HideFileMenus()

        Select Case tabname.ToLower
            Case "part"
                NewToolStripMenuItem.Enabled = True
                OpenToolStripMenuItem.Enabled = True
                SaveToolStripMenuItem.Enabled = True
                PrintToolStripMenuItem.Enabled = True
                PrintPreviewToolStripMenuItem.Enabled = True
                SaveGCodeToolStripMenuItem.Enabled = True
                ''StepbyStepToolStripMenuItem.Enabled = True
            Case "process"
            Case "g code"
                SaveGCodeToolStripMenuItem.Enabled = True
            Case "website"
            Case "log"

        End Select

    End Sub
    Private Sub HideFileMenus()

        NewToolStripMenuItem.Enabled = False
        OpenToolStripMenuItem.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        SaveGCodeToolStripMenuItem.Enabled = False
        PrintToolStripMenuItem.Enabled = False
        PrintPreviewToolStripMenuItem.Enabled = False

        ''StepbyStepToolStripMenuItem.Enabled = False

    End Sub
    Private Sub createDirectories()

        Dim f As New fileManager

        f.makeDirectory(gPath.gcodePath)
        f.makeDirectory(gPath.partPath)

    End Sub
    Private Sub SetCellText(ByVal s As String)

        s = s.Trim.Replace(" ", "_")

        If IsCombo() Then
            cmbCellCombo.Text = s
            cmbCellCombo.SelectionStart = 0
            cmbCellCombo.SelectionLength = cmbCellCombo.Text.Length
        Else
            txtCellTextBox.Text = s
            txtCellTextBox.SelectionStart = 0
            txtCellTextBox.SelectionLength = txtCellTextBox.Text.Length
        End If
    End Sub
    Private Function GetCellText() As String

        If IsCombo() Then
            cmbCellCombo.Text = cmbCellCombo.Text.Trim.Replace(" ", "_")
            GetCellText = cmbCellCombo.Text
        Else
            txtCellTextBox.Text = txtCellTextBox.Text.Trim.Replace(" ", "_")
            GetCellText = txtCellTextBox.Text
        End If
    End Function
    Private Sub SetCellBackColor(ByVal colr As Color)
        If IsCombo() Then
            cmbCellCombo.BackColor = colr
        Else
            txtCellTextBox.BackColor = colr
        End If
    End Sub
    Private Sub setGridToText()

        If curSumRow <> -1 Then
            If IsCombo() Then
                setCell(grdSummary, curSumRow, VARCOLUMN, cmbCellCombo.Text)
            Else
                setCell(grdSummary, curSumRow, VARCOLUMN, txtCellTextBox.Text)
            End If
        End If

    End Sub
    Public Sub SetCellFocus(ByVal t As Object)

        t.Focus()
        t.SelectionStart = 0
        t.SelectionLength = t.Text.Length

    End Sub
    Private Sub LoadStatePicture(ByVal stateName As String)
        LoadPicture(picBigPic, p.getProcessInfo(stateName & " LGPIC"))
    End Sub
    Private Sub ScrollToEndOfToolTable()

        txtToolStations.SelectionStart = txtToolStations.TextLength
        txtToolStations.ScrollToCaret()

    End Sub

#Region "Events"
    Private Sub btNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNext.Click
        gotoNext()
    End Sub
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        suppressNext = 1
        runState(p.previousState())
        getStateValue()
        suppressNext = 0
    End Sub
    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click
        MsgBox(p.stateInfoDetail("HELP"), MsgBoxStyle.OkOnly, "Prompt Help")
    End Sub

    Private Sub btnProcAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcAdd.Click
        addSavedProcess()
    End Sub
    Private Sub btnProcRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcRemove.Click
        removeProcess()
    End Sub
    Private Sub removeProcess(Optional ByVal forceRemoval As Boolean = False)
        Dim i As Integer

        i = getSelectedProcessRow()
        If i <> -1 Then   '   TBD if list is not empty
            If MsgBox("Are you sure you want to remove this Toolpath?", MsgBoxStyle.OkCancel, "Remove Toolpath") = MsgBoxResult.Cancel Then Exit Sub
            dh.removeProcess(i + 1)
            updateDesignSequence()
            setProcessSelectCursor(i)
        Else
            If Not forceRemoval Then
                MsgBox("There are no Tool Paths to remove.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub btnAddNewProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewProcess.Click

        Dim f As New fileManager
        Dim prefs As String
        Dim x As New myXmlUtils

        If btnBlankDescription.Text = "Blank Description" Then
            MsgBox("You must first select your blank wood piece.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        ClearSelection()
        prefs = f.fileRead(gPath.Path(gPath.Configs, "Preferences.txt"))

        ProcessInEdit = ""
        stateVars.setVar("ProcessName", "")

        frmSelectProcess.ShowDialog()
        If dialogResponse = "cancel" Then Exit Sub

        showProcess()

        stateVars.setVar("GCODETOOLPATHDESCRIPTION", "")
        Me.txtGCodeToolPathDescription.Text = ""

        loadProcessTemplate()
        p.getProcessVars()

        ' Overwrite State Variable values for blank and machine variables, and touchoff method
        ' These values are selected via the setups
        ' The tool values are determined within the ConvCAM process.
        loadBlankVals()
        loadMachineVals()
        stateVars.setVar("TOUCHOFFMETHOD", x.extract(prefs, "TOUCHOFFMETHOD"))

        newProcessFlag = True
        HideFileMenus()
        RunProcessWizard()

        ResetTable()

        ''        If PROCINPUTMODE = TABLEINPUT Then
        ''ResetTable()
        ''        End If

    End Sub
    Private Sub btnBlankDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBlankDescription.Click

        organizeMode = BLANKMODE
        frmSetupOrganizer.ShowDialog()

        If blankMy <> "" Then
            SetBlankButtonLabel()
            txtReport.Text = dh.makeDesignReport
        End If

    End Sub
    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click

        bSuppressAdvanceFlag = True
        If closeConvBox() Then

            stateCalcs()
            Dim rw As Integer
            Dim cl As Integer

            getRowCol(grdSummary, rw, cl)

            Dim varName As String = getCell(grdSummary, rw, STATENAMECOL)
            Dim varVal As String = stateVars.getVar(varName)

            'CONV            If varName.Substring(0, 1) = "u" Then varVal = SRound(ToMetric(varVal))
            If varName = "ProcessName" Then varVal = varVal.Trim.Replace(" ", "_")
            stateVars.setVar(varName, varVal)

            fCell.PlaceCell(rw, VARCOLUMN)
            fCell.setValue(varVal)
            setCell(grdSummary, rw, cl, varVal)

            '' ''AdvanceDown()

        End If

    End Sub
    Private Sub btnFinishAndSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinishAndSave.Click

        ''        If PROCINPUTMODE = TABLEINPUT Then
        '' ''If fCell.getValue = "" Then
        '' ''    MsgBox("You must complete the table before" & vbLf & "you can Finish and Save this process.", MsgBoxStyle.OkOnly)
        '' ''    Exit Sub
        '' ''End If

        FinishTableInputs()
        refreshData()
        ''        End If

        If ValidateAllInputs() = "PASS" Then
            CloseProcess()
            txtReport.Text = dh.makeDesignReport
            buildGCODE()
        Else
            frmErrorReport.ShowDialog()
        End If

    End Sub

    Private Sub btnCancelProcessEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelProcessEdit.Click

        If MsgBox("If you cancel, this Toolpath will be removed. Are you sure you want to cancel?", MsgBoxStyle.YesNo, "Toolpath Cancel") = MsgBoxResult.Yes Then
            removeProcess(True)
            showPart()
            SetFileMenu("part")
        End If

    End Sub
    Private Sub cmbCellCombo_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCellCombo.KeyDown

        e.Handled = True ' Disables user from editing..

    End Sub
    Private Sub cmbCellCombo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCellCombo.KeyPress

        e.Handled = True ' Disables user from editing..

    End Sub
    Private Sub cmbCellCombo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCellCombo.KeyUp

        e.Handled = True ' Disables user from editing..
        Select Case e.KeyValue
            Case 9
                If e.Modifiers = Keys.Shift Then
                    AdvanceUp()
                Else
                    AdvanceDown()
                End If
            Case 13, 40
                AdvanceDown()
            Case 38
                AdvanceUp()
        End Select

    End Sub

    Private Sub cmbCellCombo_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles cmbCellCombo.PreviewKeyDown
        If e.KeyValue = 9 Then e.IsInputKey = True
    End Sub
    Private Sub cmbCellCombo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCellCombo.TextChanged
        If Not bSuppressFlag Then
            If Not bSuppressAdvanceFlag Then AdvanceDown()
            bSuppressDoublePressFlag = False
        End If
    End Sub

    Private Sub txtCellTextBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCellTextBox.Click
        If checkForDialog() Then Exit Sub
    End Sub

    Private Sub txtCellTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCellTextBox.KeyDown
        If e.KeyValue = 13 Or e.KeyValue = 9 Then
            sPreserveTextBox = txtCellTextBox.Text
        End If
    End Sub

    Private Sub txtCellTextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCellTextBox.KeyUp

        Select Case e.KeyValue

            Case 38  ' up arrow
                AdvanceUp()
                Exit Sub
            Case 9
                txtCellTextBox.Text = sPreserveTextBox
                If e.Modifiers = Keys.Shift Then
                    AdvanceUp()
                Else
                    AdvanceDown()
                End If
                Exit Sub
            Case 13, 40 ' tab, enter, down arrow
                If e.KeyValue = 13 Then txtCellTextBox.Text = sPreserveTextBox
                AdvanceDown()
                Exit Sub
        End Select

        checkForDialog()

    End Sub

    Private Sub grdSummary_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellClick

        Dim rw As Integer
        Dim cl As Integer

        getRowCol(grdSummary, rw, cl)

        Select Case cl
            Case HELPCOLUMN
                Call showHelpMessage(getCell(grdSummary, rw, STATENAMECOL))
            Case TITLECOLUMN, VARCOLUMN
                AdvanceTo(rw)
        End Select

    End Sub
    Private Sub showHelpMessage(ByVal stateName As String)
        Dim x As New myXmlUtils
        Dim s As String

        s = x.extract(p.processDef, stateName + " HELP")
        If s = "" Then Exit Sub

        s = VarsToVals(s)

        MsgBox(s, MsgBoxStyle.OkOnly, "Help Message")

    End Sub
    Private Sub showErrorMessage(ByVal stateName As String)

        Dim x As New myXmlUtils
        Dim s As String

        s = x.extract(p.processDef, stateName + " ERRORMESSAGE")
        If s = "" Then
            Dim t As String = x.extract(p.processDef, stateName + " TITLE")
            MsgBox("The '" + t + "' entry is invalid.")
            Exit Sub
        End If

        s = VarsToVals(s)

        MsgBox(s, MsgBoxStyle.OkOnly, "Data Entry Error Message")

    End Sub

    Private Sub grdSummary_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles grdSummary.Scroll
        fCell.alignToTable()
    End Sub

    Private Sub tabMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMain.Click

        Dim gc As New gCodeBuilder

        tabName = tabMain.SelectedTab.Name.ToString

        If tabName = "Report1" Then
            txtReport.Text = dh.makeDesignReport
        End If

        SetFileMenu(tabName)

    End Sub

    ''Private Sub radPrompt1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    ''    If INPUTRESPONSE And suppressNext = 0 Then gotoNext()
    ''End Sub
    ''Private Sub radPrompt2_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPrompt2.MouseUp
    ''    If INPUTRESPONSE And suppressNext = 0 Then gotoNext()
    ''End Sub
    ''Private Sub radPrompt3_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPrompt3.MouseUp
    ''    If INPUTRESPONSE And suppressNext = 0 Then gotoNext()
    ''End Sub

    ''Private Sub cmbPrompt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrompt.SelectedIndexChanged
    ''    If INPUTRESPONSE And suppressNext = 0 Then gotoNext()
    ''End Sub
    Private Sub txtPrompt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrompt.KeyDown
        If e.KeyValue = 13 Then
            sPreserveTextBox = txtPrompt.Text
        End If
    End Sub

    Private Sub txtPrompt_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrompt.KeyUp
        If e.KeyValue = 13 Then
            SetTextPrompt(sPreserveTextBox)
            ''If INPUTRESPONSE Then gotoNext()
        End If
    End Sub
    Private Sub ToolStationManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStationManagerToolStripMenuItem.Click
        ToolBoxShow()
        ScrollToEndOfToolTable()
    End Sub
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub
    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Try
            PrintPreviewDialog1.ShowDialog()
        Catch es As Exception
            MessageBox.Show(es.Message)
        End Try
    End Sub
    Private Sub StateMakerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateMakerToolStripMenuItem1.Click
        frmStateMaker.ShowDialog()
    End Sub
    Private Sub SstateVariablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim x As New myXmlUtils, t As New myList, vname As String

        t.setList(stateVars.getVarNames)
        t.sort(DL)

        txtLog.Text = ""

        For i = 0 To t.length(DL) - 1
            vname = fitString(t.getItem(i, DL), 30, "left")

            txtLog.Text = txtLog.Text & vname & stateVars.getVar(t.getItem(i, DL)) & vbLf   'UNITS
        Next
    End Sub
    Private Sub GCODEDebugOFFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCODEDebugOFFToolStripMenuItem.Click

        If GCODEDebugOFFToolStripMenuItem.Text = "G CODE Debug: OFF" Then
            GCODEDebugOFFToolStripMenuItem.Text = "G CODE Debug: ON"
            DEBUGFLAG = 1
        Else
            GCODEDebugOFFToolStripMenuItem.Text = "G CODE Debug: OFF"
            DEBUGFLAG = 0
        End If

        RefreshDisplay()

    End Sub
    Private Sub TestFunctionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestFunctionToolStripMenuItem.Click
        TestFunction()
    End Sub
    Private Sub SaveGCodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveGCodeToolStripMenuItem.Click
        saveGCode()
    End Sub
    Private Sub IntegrityCheckToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntegrityCheckToolStripMenuItem.Click

        Dim f As New fileManager

        dlgOpen.Reset()
        dlgOpen.InitialDirectory = gPath.addSlash(gPath.basePath) & "My Parts"
        ''dlgOpen.Filter = "ConvCAM Part File (*.txt)|*.txt"
        dlgOpen.Filter = "Part File (*.txt;*.ccm)|*.txt;*.ccm"

        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            DesignIntegrityCheck(dlgOpen.FileName)
        End If
    End Sub
    Private Sub SmartToolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmartToolToolStripMenuItem.Click
        stateVars.setVar("TOUCHOFFMETHOD", "SmartTool")
        UpdateTouchOffChecksAll()
        SmartToolToolStripMenuItem.Checked = True
    End Sub
    Private Sub DynamicToolTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DynamicToolTableToolStripMenuItem.Click
        stateVars.setVar("TOUCHOFFMETHOD", "DynamicToolTable")
        UpdateTouchOffChecksAll()
        DynamicToolTableToolStripMenuItem.Checked = True
    End Sub
    Private Sub StationToolTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StaticToolTableToolStripMenuItem.Click
        stateVars.setVar("TOUCHOFFMETHOD", "StaticToolTable")
        UpdateTouchOffChecksAll()
        StaticToolTableToolStripMenuItem.Checked = True
    End Sub
    Private Sub PartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartToolStripMenuItem.Click
        stateVars.setVar("TOUCHOFFMETHOD", "Part")
        UpdateTouchOffChecksAll()
        PartToolStripMenuItem.Checked = True
    End Sub
    Private Sub BullNoseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BullNoseToolStripMenuItem.Click
        stateVars.setVar("TOUCHOFFMETHOD", "BullNose")
        UpdateTouchOffChecksAll()
        BullNoseToolStripMenuItem.Checked = True
    End Sub
    Private Sub PresetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PresetToolStripMenuItem.Click
        stateVars.setVar("TOUCHOFFMETHOD", "Preset")
        UpdateTouchOffChecksAll()
        PresetToolStripMenuItem.Checked = True
    End Sub
    Private Sub HighCodeVerbosityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HighCodeVerbosityToolStripMenuItem.Click

        organizeMode = MACHINEMODE
        frmSetupOrganizer.ShowDialog()
        tsMan.initStationVariables()
        tsMan.InitializeStations()
        InitToolTable()
        ScrollToEndOfToolTable()
    End Sub
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        newHandler()
        txtGcodeBox.Text = ""
    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        savePartFile1()
        buildGCODE()
    End Sub
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click

        readHandler()

    End Sub
    Private Sub SaveProcessToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        readHandler()
    End Sub
    Private Sub WoodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WoodToolStripMenuItem.Click
        organizeMode = BLANKMODE
        frmSetupOrganizer.ShowDialog()
        SetBlankButtonLabel()
        ScrollToEndOfToolTable()
    End Sub
    Private Sub ConversationalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''setInputMode(STEPBYSTEP)
        ''grpTitle.Visible = False
        ''UpdateStatusBar()
    End Sub
    Private Sub DataSetsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''setInputMode(TABLEINPUT)
        dispView()
        KickOffProcessInputTable()
        UpdateStatusBar()
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

        If ToolStripMenuItem1.Text = "G CODE Training: On" Then
            ToolStripMenuItem1.Text = "G CODE Training: Off"
            TRAINING = False
        Else
            ToolStripMenuItem1.Text = "G CODE Training: On"
            TRAINING = True
        End If

        writePreferences()

        ''If tabName = "G Code" Then buildGCODE()
        UpdateStatusBar()

    End Sub
    Private Sub DisplayUnitsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayUnitsToolStripMenuItem.Click

        '' ''If DisplayUnitsToolStripMenuItem.Text = "Display Units: English" Then
        '' ''    DisplayUnitsToolStripMenuItem.Text = "Display Units: Metric"
        '' ''    DISPUNITS = METRIC
        '' ''Else
        '' ''    DisplayUnitsToolStripMenuItem.Text = "Display Units: English"
        '' ''    DISPUNITS = ENGLISH
        '' ''End If
        '' ''UpdateStatusBar()
        '' ''RefreshDisplay()
    End Sub
    ''Private Sub mnuImmediateResponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImmediateResponse.Click

    ''    If mnuImmediateResponse.Text = "Immediate Response: Off" Then
    ''        mnuImmediateResponse.Text = "Immediate Response: On"
    ''        INPUTRESPONSE = True
    ''    Else
    ''        mnuImmediateResponse.Text = "Immediate Response: Off"
    ''        INPUTRESPONSE = False
    ''    End If

    ''    UpdateStatusBar()

    ''End Sub
    Private Sub HiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HiToolStripMenuItem.Click

        organizeMode = TOOLMODE
        frmSetupOrganizer.ShowDialog()
        ScrollToEndOfToolTable()

    End Sub



#End Region

    Private Sub ConvCAMHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConvCAMHelpToolStripMenuItem.Click
        frmHelp.Show()
    End Sub
    Private Sub SetTableSize()

        stateList.setList(sActiveStateList)
        fCell.hideFloatingCells()
        If stateList.length = 0 Then
            grdSummary.RowCount = 1
        Else
            grdSummary.RowCount = stateList.length(DL) - 1
        End If

    End Sub
    Private Sub PopulateTable()

        Dim sStateName As String
        Dim tmpStateName As String = p.getCurrentState

        For i = 0 To grdSummary.RowCount - 1

            sStateName = stateList.getItem(i, DL).Replace(" ", "")
            p.setCurrentState(sStateName)

            populateRow(sStateName, i)

        Next

        p.setCurrentState(tmpStateName)

    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub
    Private Sub populateRow(ByVal stateName As String, ByVal row As Integer)

        Dim x As New myXmlUtils, s As String, ary() As String
        Dim varVal As String, defaultVal As String

        setCell(grdSummary, row, TITLECOLUMN, p.stateInfoDetail("TITLE"))
        setCell(grdSummary, row, STATENAMECOL, stateName)

        ' Set variable cell to text, read/writeable
        SetToTextCell(grdSummary, row, VARCOLUMN)
        cellReadWrite(grdSummary, row, VARCOLUMN)

        ' Default data type as nothing (vs combo, etc)
        setCell(grdSummary, row, COLTYPE, "")

        defaultVal = p.stateInfoDetail("BUTTONLIST")
        varVal = stateVars.getVar(stateName)

        s = p.stateInfoDetail("STTYPE")

        ' If data is combo or radio type, load coltype as button list items
        '   which at this point is the default
        ' If the stateVars value is "" or "BAD INPUT", set varval to default value,
        '   then update statevar with new default value. Make cell readonly.

        If s = "combo" Or s = "radio" Then

            If defaultVal <> "" And defaultVal <> "BAD INPUT" Then

                setCell(grdSummary, row, COLTYPE, defaultVal)

                ary = defaultVal.Split(DL)
                If varVal = "" Or varVal = "BAD INPUT" Then varVal = ary(0)

                setCell(grdSummary, row, VARCOLUMN, varVal)
                stateVars.setVar(stateName, varVal)
                cellReadOnly(grdSummary, row, VARCOLUMN)

            End If

        Else

            'if not a combo or radio, if state variable is invalid, then 
            '  set varVal to default value, get upper and lower limits.
            '  If varval is still "", set it to upper or lower limit.

            If varVal = "" Or varVal = "BAD INPUT" Then

                varVal = defaultVal

                Dim lLim As String = stateVars.resolveVariable(p.stateInfoDetail("LLIM"))
                Dim uLim As String = stateVars.resolveVariable(p.stateInfoDetail("ULIM"))

                '' ''If varVal = "" Then varVal = lLim
                '' ''If varVal = "" Then varVal = uLim

            End If

            ' Update stateVar with varval

            If varVal <> "" Then
                stateVars.setVar(stateName, varVal)
                varVal = stateVars.getVar(stateName, DISPUNITS)
            End If

            ' Set the cell with the conditioned varVal.

            setCell(grdSummary, row, VARCOLUMN, varVal)

            End If

            setButton(grdSummary, row, HELPCOLUMN)

    End Sub

    Private Sub AdvanceUp()

        Dim rw As Integer
        Dim cl As Integer

        getRowCol(grdSummary, rw, cl)

        If rw > 0 Then
            rw = rw - 1
            AdvanceTo(rw, True)
        End If

        PopulateTable()

    End Sub
    Private Sub AdvanceDown()

        Dim rw As Integer
        Dim cl As Integer

        getRowCol(grdSummary, rw, cl)
        If rw < grdSummary.RowCount - 1 Then
            rw = rw + 1
        End If

        AdvanceTo(rw)

        PopulateTable()

    End Sub
    Private Function AdvanceTo(ByVal rw As Integer, Optional ByVal goUp As Boolean = False) As Boolean

        Dim lastEntryValid As Boolean = ValidateLatestEntry()

        AdvanceTo = False
        bSuppressAdvanceFlag = True

        If lastEntryValid Then stateCalcs()
        Dim tempStateList As String = p.getStateList
        If tempStateList <> sActiveStateList Then
            LoadProcessToTable()
        End If
        setActiveCell(grdSummary, rw, VARCOLUMN)
        fCell.PlaceCell(rw, VARCOLUMN)
        p.setCurrentState(getCell(grdSummary, rw, STATENAMECOL))
        AdvanceTo = True
        '' ''Else
        '' ''If rw <> fCell.getCurrentRow Then
        '' ''    MsgBox("Please enter a valid value before proceeding.", MsgBoxStyle.OkOnly, "Invalid Input")
        '' ''    rw = fCell.getCurrentRow
        '' ''    setActiveCell(grdSummary, rw, VARCOLUMN)
        '' ''    fCell.alignToTable()
        '' ''End If
        '' ''End If
        AdvanceTo = True
        bSuppressAdvanceFlag = False

 
        '' ''AdvanceTo = False
        '' ''bSuppressAdvanceFlag = True

        ' '' '' It's OK to arrow up, if current cell is empty
        '' ''If fCell.getValue = "" And goUp Then
        '' ''    setActiveCell(grdSummary, rw, VARCOLUMN)
        '' ''    fCell.PlaceCell(rw, VARCOLUMN)
        '' ''    p.setCurrentState(getCell(grdSummary, rw, STATENAMECOL))
        '' ''    AdvanceTo = True
        '' ''    Exit Function
        '' ''End If

        '' ''If lastEntryValid Then
        '' ''    stateCalcs()
        '' ''    Dim tempStateList As String = p.getStateList
        '' ''    If tempStateList <> sActiveStateList Then
        '' ''        LoadProcessToTable()
        '' ''    End If
        '' ''    setActiveCell(grdSummary, rw, VARCOLUMN)
        '' ''    fCell.PlaceCell(rw, VARCOLUMN)
        '' ''    p.setCurrentState(getCell(grdSummary, rw, STATENAMECOL))
        '' ''    AdvanceTo = True
        '' ''End If

        '' ''bSuppressAdvanceFlag = False

    End Function
    Private Sub TableHelp(ByVal rw As Integer)

        '' Deprecated, no longer called.

        ''If AdvanceTo(rw) Or rw = fCell.nCurrentRow Then

        ''    Dim stateName As String = getCell(grdSummary, rw, STATENAMECOL)

        ''    If p.stateInfoDetail("STTYPE", stateName) <> "tool" Then
        ''        grpTitle.Visible = True
        ''        btnDone.Visible = True
        ''    End If

        ''    runState(getCell(grdSummary, rw, STATENAMECOL))

        ''End If

    End Sub
    Private Function ValidateLatestEntry() As Boolean

        Dim inputCheck As String
        Dim x As New myXmlUtils
        Dim f As New fileManager

        If fCell.getValue = "" Then
            ValidateLatestEntry = False
            Exit Function
        End If

        inputCheck = p.ValidateState(getCell(grdSummary, fCell.nCurrentRow, STATENAMECOL), fCell.getValue)

        If inputCheck = "OK" Or inputCheck = "Tool Check: OK" Then
            setBackgroundColor(grdSummary, fCell.nCurrentRow, VARCOLUMN, Color.White)
            If getCell(grdSummary, fCell.nCurrentRow, STATENAMECOL) = "ProcessName" Then
                fCell.setValue(fCell.getValue.Replace(" ", "_"))
            End If
            If inputCheck = "Tool Check: OK" Then
                ' If tool, fully update myfile, and all global tool parameters
                '  for selected tool
                Dim myFileParms As String = x.extract(toolAll, fCell.getValue)
                f.fileWrite(quickPath(x.extract(toolConfig, "MYFILE")), myFileParms)
                readToolMy()
                addVarValsToState(x.extract(toolAll, fCell.getValue))
            End If
            fCell.setTableFromValue()
            ValidateLatestEntry = True
        Else
            ValidateLatestEntry = False
            fCell.FlagBadInput()
            showErrorMessage(p.getCurrentState)
        End If

    End Function
    Private Sub FinishTableInputs()

        If ValidateLatestEntry() Then
            stateCalcs()
        End If
        fCell.setTableFromValue()

    End Sub
    Public Function ValidateAllInputs() As String

        Dim tempStateList As String = p.getStateList
        Dim states As New myList
        Dim inputCheck As String
        Dim result As String = "PASS"
        Dim sStateName As String = ""
        Dim sStateValue As String = ""

        Dim toolList As String = ""

        states.setList(p.getStateList)

        sReportFinal = "Listed below are invalid inputs that must be corrected in order to continue."
        sReportFinal = appendString(sReportFinal, "You may either fix the inputs, or Cancel out." & vbLf, "")

        For i = 0 To states.length(DL) - 1
            ''            If PROCINPUTMODE = TABLEINPUT Then
            sStateName = getCell(grdSummary, i, STATENAMECOL)
            If sStateName <> "" Then
                sStateValue = getCell(grdSummary, i, VARCOLUMN)
                inputCheck = p.ValidateState(sStateName, sStateValue)
                If inputCheck = "OK" Or inputCheck = "Tool Check: OK" Then
                Else
                    setBackgroundColor(grdSummary, i, VARCOLUMN, Color.LightPink)
                    sReportFinal = appendString(sReportFinal, fitString("  " & sStateName & ":", 35, "left") & sStateValue, vbLf)
                    result = "FAIL"
                End If
            End If
            ''Else
            ''sStateName = states.getItem(i, DL)
            ''If p.stateInfoDetail("STTYPE", sStateName) <> "finish" Then
            ''    sStateValue = stateVars.getVar(states.getItem(i, DL))
            ''    inputCheck = p.ValidateState(sStateName, sStateValue)
            ''    If inputCheck = "OK" Or inputCheck = "Tool Check: OK" Then
            ''    Else
            ''        sReportFinal = appendString(sReportFinal, fitString("  " & sStateName & ":", 35, "left") & sStateValue, vbLf)
            ''        result = "FAIL"
            ''    End If
            ''End If
            ''End If

            If p.stateInfoDetail("STTYPE", sStateName).ToLower = "tool" Then
                If sStateValue <> "" Then
                    toolList = appendString(toolList, sStateValue, DL)
                End If
            End If

        Next

        Call stateVars.setVar("TOOLLIST", toolList)

        If result = "PASS" Then
            saveToolVals()
            sReportFinal = "PASS"
        End If

        ValidateAllInputs = sReportFinal

    End Function

    Private Sub CloseProcess()

        Dim fName As String
        Dim f As New fileManager
        Dim x As New myXmlUtils

        showPart()

        ' Make process name if one is not present
        If sTemplateName = "Blank Desc.txt" Then
            stateVars.setVar("ProcessName", "Blank Description")
        Else
            stateVars.setVar("ProcessName", f.ForceNameValidation(stateVars.getVar("ProcessName")))
            If stateVars.getVar("ProcessName") = "" Then
                stateVars.setVar("ProcessName", "process_" & processNumber.ToString)
            End If
        End If

        newPartFlag = False

        ' Write process info to file
        fName = gPath.addSlash(gPath.partPath) & "temp part\" & stateVars.getVar("ProcessName")
        f.fileWrite(fName & ".txt", stateVars.makeXML)

        ' Add process to overall design if not already present
        If ProcessInEdit = "" Then
            dh.addProcess(fName)
            updateDesignSequence()
            processNumber = processNumber + 1
        Else
            ' Rename process (in case process name was edited within the process states)
            If ProcessInEdit <> f.fileNameOnly(fName) Then
                dh.renameProcess(ProcessInEdit, fName)
            End If
            updateDesignSequence()
            End If

            ProcessInEdit = ""
            updateDesignSequence()
            SetFileMenu("part")

    End Sub
    Private Sub editProcess(ByVal idx As Integer)

        Dim fname As String

        ProcessInEdit = getCell(grdProcessList, idx, 1)
        fname = gPath.addSlash(gPath.basePath) & "My Parts\temp part\" & ProcessInEdit & ".txt"
        loadProcess(fname)

    End Sub
    Private Sub WhereAreMyFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhereAreMyFilesToolStripMenuItem.Click
        Dim ccp As New convCamPaths
        MsgBox("Your files are located in: " & vbLf & ccp.basePath)
    End Sub

    Private Sub InstallAddonsUpdatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallAddonsUpdatesToolStripMenuItem.Click

        Dim s As New systemHandler
        s.AddonInstall()

    End Sub

    Private Sub InstallationHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallationHistoryToolStripMenuItem.Click
        Dim f As New fileManager
        Dim c As New convCamPaths

        txtLog.Text = f.fileRead(c.InstallHistoryFile)

    End Sub

    Private Sub LicenseAgreementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LicenseAgreementToolStripMenuItem.Click
        Dim sh As New systemHandler
        If Not sh.AgreementOK(True) Then End
    End Sub

    Private Sub ExitToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem2.Click
        Me.Close()
    End Sub
    Private Sub savePartFile1()
        frmPartInfo.ShowDialog()
        If abortSave = False Then
            SaveCompositePartFile()
            lblStatus.Text = "File Saved."
            System.Threading.Thread.Sleep(1000)
            UpdateStatusBar()
            txtReport.Text = dh.makeDesignReport
        End If
    End Sub
    Private Sub refreshData()

        Dim rw As Integer
        Dim cl As Integer

        getRowCol(grdSummary, rw, cl)

        While rw > 0
            If rw > 0 Then
                rw = rw - 1
                AdvanceTo(rw)
            End If
        End While


        getRowCol(grdSummary, rw, cl)

        While rw < grdSummary.RowCount - 1
            If rw < grdSummary.RowCount - 1 Then
                rw = rw + 1
            End If
            AdvanceTo(rw)
        End While
        FinishTableInputs()
    End Sub

    Private Sub btnSelectNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNew.Click
        checkForDialog()
    End Sub
    Public Function checkForDialog() As Boolean

        checkForDialog = False

        Select Case p.stateInfoDetail("STTYPE").ToLower

            Case "tool"

                Call getNewTool()

                ' Differentiates tool variables for processes with multiple tools,
                ' by appending the toolIdx variable.
                ' If there is no toolIdx, this is not called, since base 
                ' tool parameters are saved when exiting the tool selection box.
                ' It's up to the process template to select the correctly indexed
                ' tool parameters.

                checkForDialog = True

            Case "file"

                Call getNewFile()
                checkForDialog = True

        End Select

    End Function
    Private Sub getNewTool()

        organizeMode = TOOLMODE
        frmSetupOrganizer.ShowDialog()

        stateVars.setVar(p.getCurrentState, stateVars.getVar("ToolMfgID"))
        fCell.setValue(stateVars.getVar("ToolMfgID"))
        AdvanceDown()

        ''Select Case PROCINPUTMODE
        ''    Case TABLEINPUT
        'closeConvBox()
        ''AdvanceDown()
        ''Case STEPBYSTEP
        ''    lblPrompt.Text = VarsToVals(p.stateInfoDetail("PROMPT").Replace("~", vbLf))
        ''End Select

    End Sub
    Private Sub getNewFile()

        Dim f As New fileManager

        dlgOpen.Reset()
        dlgOpen.InitialDirectory = gPath.addSlash(gPath.basePath)
        dlgOpen.Filter = "G-Code Files (*.txt)|*.txt"

        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            stateVars.setVar(p.getCurrentState, dlgOpen.FileName)
            stateVars.setVar("FileNameOnly", f.fileNameOnly(dlgOpen.FileName))
        Else
            stateVars.setVar(p.getCurrentState, "")
        End If

        closeConvBox()
        AdvanceDown()

        ''Select Case PROCINPUTMODE
        ''    Case TABLEINPUT
        ''        closeConvBox()
        ''        AdvanceDown()
        ''        ''Case STEPBYSTEP
        ''        ''    lblPrompt.Text = VarsToVals(p.stateInfoDetail("PROMPT").Replace("~", vbLf))
        ''End Select

    End Sub

    Private Sub ClearSelection()

        For i = 0 To grdProcessList.RowCount - 1
            setCell(grdProcessList, i, 0, "")
        Next

    End Sub
    Private Sub updateDesignSequence()

        Dim s As String, ary() As String

        s = dh.getProcessList
        ary = s.Split(DL)

        grdProcessList.RowCount = ary.Length

        For i = 0 To ary.Length - 1
            setCell(grdProcessList, i, 1, ary(i))
        Next

    End Sub
    Private Sub grdProcessList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProcessList.CellClick
        If grdProcessList.RowCount = 0 Then Exit Sub
        If getCell(grdProcessList, 0, 1) = "" Then Exit Sub
        Select Case grdProcessList.CurrentCellAddress.X
            Case 0, 1
                setProcessSelectCursor(grdProcessList.CurrentCellAddress.Y)
            Case 2
                If getCell(grdProcessList, grdProcessList.CurrentCellAddress.Y, 2) = "" Then
                    setCell(grdProcessList, grdProcessList.CurrentCellAddress.Y, 2, "P")
                Else
                    setCell(grdProcessList, grdProcessList.CurrentCellAddress.Y, 2, "")
                End If
        End Select
    End Sub
    Private Sub setProcessSelectCursor(ByVal rowNum As Integer)
        ClearSelection()
        If rowNum = -1 Then Exit Sub
        If rowNum > grdProcessList.RowCount - 1 Then rowNum = grdProcessList.RowCount - 1
        If getCell(grdProcessList, 0, 1) = "" Then Exit Sub
        If grdProcessList.RowCount = 0 Then Exit Sub
        setCell(grdProcessList, rowNum, 0, ">>")
    End Sub
    Private Function getSelectedProcessRow() As Integer

        getSelectedProcessRow = -1
        If grdProcessList.RowCount = 0 Then Exit Function
        If getCell(grdProcessList, 0, 1) = "" Then Exit Function

        For i = 0 To grdProcessList.RowCount - 1
            If getCell(grdProcessList, i, 0) <> "" Then
                getSelectedProcessRow = i
                Exit Function
            End If
        Next

    End Function
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        beginEditProcess()
    End Sub
    Private Sub beginEditProcess()

        Dim i As Integer

        i = getSelectedProcessRow()
        If i <> -1 Then
            editProcess(i)
            HideFileMenus()
            txtCellTextBox.Enabled = True
            cmbCellCombo.Enabled = True
        Else
            MsgBox("There are no Tool Paths to edit", MsgBoxStyle.OkOnly)
        End If


    End Sub
    Private Sub btnSeqDn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeqDn.Click
        Dim i As Integer, j As Integer

        i = getSelectedProcessRow()
        j = grdProcessList.RowCount - 1

        If i = -1 Then
            MsgBox("There are no Tool Paths to move down.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If i = j Then Exit Sub ' At end of table

        dh.swapProcesses(i + 1, i + 2)
        updateDesignSequence()
        setProcessSelectCursor(i + 1)

    End Sub
    Private Sub btnSeqUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeqUp.Click

        Dim i As Integer

        i = getSelectedProcessRow()

        If i = -1 Then
            MsgBox("There are no Tool Paths to move up.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If i = 0 Then Exit Sub

        dh.swapProcesses(i + 1, i)
        updateDesignSequence()
        setProcessSelectCursor(i - 1)

    End Sub

    Private Sub grdProcessList_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProcessList.CellContentDoubleClick

        If grdProcessList.RowCount = 0 Then Exit Sub
        If getCell(grdProcessList, 0, 1) = "" Then Exit Sub
        setProcessSelectCursor(grdProcessList.CurrentCellAddress.Y)
        beginEditProcess()

    End Sub


    Private Sub EnglishToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishToolStripMenuItem.Click
        '' ''If DisplayUnitsToolStripMenuItem.Text = "Display Units: English" Then
        '' ''    DisplayUnitsToolStripMenuItem.Text = "Display Units: Metric"
        '' ''    DISPUNITS = METRIC
        '' ''Else
        '' ''    DisplayUnitsToolStripMenuItem.Text = "Display Units: English"
        DISPUNITS = ENGLISH
        '' ''End If
        UpdateStatusBar()
        RefreshDisplay()
        updateDispUnitsMenu()

    End Sub

    Private Sub MetricToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetricToolStripMenuItem.Click
        '' ''If DisplayUnitsToolStripMenuItem.Text = "Display Units: English" Then
        '' ''    DisplayUnitsToolStripMenuItem.Text = "Display Units: Metric"
        DISPUNITS = METRIC
        '' ''Else
        '' ''    DisplayUnitsToolStripMenuItem.Text = "Display Units: English"
        '' ''    DISPUNITS = ENGLISH
        '' ''End If
        UpdateStatusBar()
        RefreshDisplay()
        updateDispUnitsMenu()

    End Sub
    Private Sub updateDispUnitsMenu()
        Select Case DISPUNITS
            Case ENGLISH
                EnglishToolStripMenuItem.Checked = True
                MetricToolStripMenuItem.Checked = False
            Case METRIC
                MetricToolStripMenuItem.Checked = True
                EnglishToolStripMenuItem.Checked = False
        End Select
    End Sub

    Private Sub DeveloperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeveloperToolStripMenuItem.Click

    End Sub

    Private Sub radPrompt3_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles radPrompt3.MouseUp

    End Sub
    Private Sub btnMakeGcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakeGcode.Click
        buildGCODE()
    End Sub

    Private Sub btnSaveGCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveGCode.Click
        saveGCode()
    End Sub

    Private Sub btnOpenGCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenGCode.Click
        Process.Start("explorer.exe", gPath.userGcodePath)
    End Sub

    Private Sub btnToNotepad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintReport.Click

        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.Print()
        End If

    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click

        Try
            PrintPreviewDialog1.ShowDialog()
        Catch es As Exception
            MessageBox.Show(es.Message)
        End Try

    End Sub

    Private Sub btnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAll.Click
        For i = 0 To grdProcessList.RowCount - 1
            setCell(grdProcessList, i, 2, "P")
        Next
    End Sub

    Private Sub btnNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNone.Click
        For i = 0 To grdProcessList.RowCount - 1
            setCell(grdProcessList, i, 2, "")
        Next
    End Sub

    Private Sub grdProcessList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProcessList.CellContentClick

    End Sub
End Class
