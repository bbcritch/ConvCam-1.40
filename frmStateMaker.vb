Imports System

Public Class frmStateMaker

    Private processTypeList As New myList
    Private processList As New myList
    Private stateList As New myList

    Private mParentVariables As New myList

    Private suppressLoad As Boolean = False

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        saveProcessFile()
    End Sub
    Private Sub saveProcessFile()

        Dim x As New myXmlUtils, f As New fileManager, t As String

        rebuildProcessTemplate()

        If cmbProcess.Text = "" Then
            MsgBox("No Toolpath Name", MsgBoxStyle.OkOnly)
        Else
            f.fileWrite(makeStateMakerFileName, processFileContent)
            t = cmbProcess.Text
            loadProcessCombo()
            cmbProcess.Text = t
        End If

        saveParentProcessList()

    End Sub
    Private Sub saveParentProcessList()

        Dim pList As New myList
        Dim f As New fileManager
        Dim c As New convCamPaths
        Dim x As New myXmlUtils

        'Read the parent list file
        pList.setList(x.extract(f.fileRead(c.parentPathFile), "PARENTLIST"))

        ' If isParent is not checked, ensure it is removed from the parent list.
        If chkIsParent.Checked = False Then
            pList.removeByName(cmbProcess.Text, DL)
        Else ' otherwise, uniquely add it to the parent list file
            pList.add(cmbProcess.Text, DL, True)
        End If

        ' save the parent list file
        f.fileWrite(c.parentPathFile, x.add(pList.getList, "PARENTLIST"))

    End Sub
    Private Sub btnVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVariable.Click

        If txtVariable.Text <> "" Then
            varList.add(txtVariable.Text.Replace(" ", ""), DL, True)
            loadVarList()
        End If

    End Sub
    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click

        Dim t As String

        If MsgBox("This will clear all states, do you wish to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        t = cmbProcess.Text

        clearProcess()
        clearState()
        InitVarList()
        loadVarList()

        cmbProcess.Text = t

    End Sub
    Private Sub clearAll()

        cmbProcess.Text = ""

        cmbState.Items.Clear()
        cmbPreviousState.Items.Clear()
        cmbNextState.Items.Clear()
        cmbState.Text = ""
        cmbPreviousState.Text = ""
        cmbNextState.Text = ""

        lstVariables.Items.Clear()

        txtProcessDescription.Text = ""
        clearState()

    End Sub
    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        clearAll()
    End Sub
    Private Sub btnClearState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearState.Click
        clearState()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        reOrderStates()
    End Sub
    Private Sub reOrderStates()

        editorDesignator = DL
        editorString = stateList.getList

        frmListEditor.ShowDialog()

        stateList.setList(editorString)

        loadStateCombo()

    End Sub
    Private Sub loadStateCombo()

        cmbState.Items.Clear()
        cmbPreviousState.Items.Clear()
        cmbNextState.Items.Clear()

        For i = 0 To stateList.length(DL) - 1
            If stateList.getItem(i, DL).Trim <> "" Then
                cmbState.Items.Add(stateList.getItem(i, DL).Trim)
                cmbPreviousState.Items.Add(stateList.getItem(i, DL).Trim)
                cmbNextState.Items.Add(stateList.getItem(i, DL).Trim)
            End If
        Next

    End Sub
    Public Sub loadVarList()

        lstVariables.Items.Clear()

        varList.sort(DL)

        For i = 0 To varList.length(DL) - 1
            If varList.getItem(i, DL).Replace(" ", "").Trim <> "" Then
                lstVariables.Items.Add(varList.getItem(i, DL).Replace(" ", "").Trim)
            End If
        Next

    End Sub
    Private Sub btnState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnState.Click

        Dim t As String

        If cmbState.Text <> "" Then

            cmbState.Text = cmbState.Text.Replace(" ", "")
            t = cmbState.Text

            stateList.add(t, DL, True)
            loadStateCombo()

            varList.add(t.Replace(" ", ""), DL, True)
            loadVarList()

            clearState()
            loadState()

        End If

    End Sub
    Private Sub editVariables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editVariables.Click

        editorDesignator = DL
        editorString = varList.getList

        frmListEditor.ShowDialog()
        varList.setList(editorString)

        loadVarList()

    End Sub
    Private Sub btnGcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGcode.Click


        saveProcessFile()

        metaGcodeFileName = txtGcode.Text
        frmMetaCoder.ShowDialog()
        txtGcode.Text = metaGcodeFileName

        loadVarList()

        saveProcessFile()

    End Sub
    Private Sub btnShowXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowXML.Click

        rebuildProcessTemplate()

    End Sub
    Private Sub rebuildProcessTemplate()

        Dim x As New myXmlUtils, f As New fileManager, t1 As String

        processFileContentBAK = processFileContent
        processFileContent = ""

        processFileContent = appendString(processFileContent, x.add(txtProcessDescription.Text, "DESCR"), vbCrLf)
        processFileContent = appendString(processFileContent, vbCrLf & x.add(varList.getList, "VARIABLES"), vbCrLf)

        If chkIsParent.Checked Then
            processFileContent = appendString(processFileContent, vbCrLf & x.add("TRUE", "ISPARENT"), vbCrLf)
        Else
            processFileContent = appendString(processFileContent, vbCrLf & x.add("FALSE", "ISPARENT"), vbCrLf)
        End If

        processFileContent = appendString(processFileContent, vbCrLf & x.add(mParentVariables.getList, "PARENTVARIABLES"), vbCrLf)
        processFileContent = appendString(processFileContent, vbCrLf & x.add(stateList.getList, "STATELIST"), vbCrLf)
        processFileContent = appendString(processFileContent, vbCrLf & x.add(txtGcode.Text, "METAGCODE"), vbCrLf)

        For i = 0 To stateList.length(DL) - 1
            If stateList.getItem(i, DL).Equals(cmbState.Text) Then
                t1 = makeCurrentState()
            Else
                t1 = x.extract(processFileContentBAK, stateList.getItem(i, DL))
            End If

            processFileContent = appendString(processFileContent, vbCrLf & makeGroupInfo(t1), vbCrLf)

        Next

        processFileContentBAK = ""

    End Sub
    Private Function makeGroupInfo(ByVal stateInfo As String) As String

        Dim x As New myXmlUtils, s As String = "", sp As String = "  "

        If stateInfo.Substring(0, 2).Equals(vbCrLf) Then stateInfo = stateInfo.Substring(2)
        If stateInfo.Substring(stateInfo.Length - 2, 2).Equals(vbCrLf) Then stateInfo = stateInfo.Substring(0, stateInfo.Length - 2)

        makeGroupInfo = x.add(vbCrLf & stateInfo & vbCrLf, x.extract(stateInfo, "STNAME"))
        makeGroupInfo = s & vbCrLf & makeGroupInfo

    End Function
    Private Sub rebuildProcessTemplateBAK()

        Dim x As New myXmlUtils, f As New fileManager

        'processFileContent = x.ovwr(processFileContent, "DESCR", txtProcessDescription.Text)
        'processFileContent = x.ovwr(processFileContent, "VARIABLES", varList.getList)
        'processFileContent = x.ovwr(processFileContent, "STATELIST", stateList.getList)
        'processFileContent = x.ovwr(processFileContent, "METAGCODE", txtGcode.Text)
        'processFileContent = x.ovwr(processFileContent, cmbState.Text.Replace(" ", ""), makeCurrentState)

    End Sub
    Private Function makeCurrentState() As String

        Dim s As String = "", x As New myXmlUtils, t As String, sp As String = "  "

        s = appendString(s, sp & x.add(cmbState.Text, "STNAME"), vbCrLf)
        s = appendString(s, sp & x.add(txtStateTitle.Text, "TITLE"), vbCrLf)

        s = appendString(s, sp & x.add(cmbPromptType.Text, "STTYPE"), vbCrLf)

        s = appendString(s, sp & x.add(txtSmPic.Text, "SMPIC"), vbCrLf)
        s = appendString(s, sp & x.add(txtLgPic.Text, "LGPIC"), vbCrLf)
        s = appendString(s, sp & getButtonLabels(), vbCrLf)

        If chkAlpha.Checked Then
            s = appendString(s, sp & x.add("true", "ALPHA"), vbCrLf)
        Else
            s = appendString(s, sp & x.add("false", "ALPHA"), vbCrLf)
        End If

        If chkUnits.Checked = True Then
            t = "true"
        Else
            t = "false"
        End If
        s = appendString(s, sp & x.add(t, "UNITS"), vbCrLf)
        s = appendString(s, sp & x.add(txtUpper.Text, "ULIM"), vbCrLf)
        s = appendString(s, sp & x.add(txtLower.Text, "LLIM"), vbCrLf)
        s = appendString(s, sp & x.add(cmbPreviousState.Text, "PREV"), vbCrLf)
        s = appendString(s, sp & getNextLogic(), vbCrLf)
        s = appendString(s, sp & getCalculations(), vbCrLf)
        s = appendString(s, sp & getPrompt(), vbCrLf)
        s = appendString(s, sp & x.add(txtStateDescription.Text, "DESCR"), vbCrLf)
        s = appendString(s, sp & x.add(txtStateHelp.Text, "HELP"), vbCrLf)
        s = appendString(s, sp & x.add(txtErrorMessage.Text, "ERRORMESSAGE"), vbCrLf)

        makeCurrentState = s

    End Function
    Private Function getNextLogic() As String
        Dim x As New myXmlUtils
        getNextLogic = x.add(MakeList(txtNextLogic.Text), "NEXT")
    End Function
    Private Function getCalculations() As String
        Dim x As New myXmlUtils
        getCalculations = x.add(MakeList(txtCalculations.Text, "$"), "CALC")
    End Function
    Private Function getPrompt() As String
        Dim x As New myXmlUtils
        getPrompt = x.add(MakeList(txtStatePrompt.Text), "PROMPT")
    End Function
    Private Function getGcode() As String
        Dim x As New myXmlUtils
        getGcode = x.add(txtGcode.Text, "METAGCODE")
    End Function
    Private Function getButtonLabels() As String
        Dim x As New myXmlUtils
        getButtonLabels = x.add(MakeList(txtButtonLabels.Text), "BUTTONLIST")
    End Function
    Private Function getPromtInfo() As String
        Dim x As New myXmlUtils
        getPromtInfo = x.add(MakeList(txtStatePrompt.Text), "PROMPT")
    End Function
    Private Function MakeList(ByVal s As String, Optional ByVal delim As String = DL) As String
        Dim ary() As String, t As String = ""

        t = ""
        MakeList = ""
        If s = "" Then Exit Function

        ary = s.Split(vbLf)
        For i = 0 To ary.Length - 1
            If ary(i) <> "" Then
                t = appendString(t, ary(i), delim)
            End If
        Next

        MakeList = t

    End Function
    Private Function extractNextLogic(ByVal s) As String
        extractNextLogic = extractSerializedLines(s, "NEXT")
    End Function
    Private Function extractCalculations(ByVal s) As String
        extractCalculations = extractSerializedLines(s, "CALC", "$")
    End Function
    Private Function extractButtonLabels(ByVal s) As String
        extractButtonLabels = extractSerializedLines(s, "BUTTONLIST")
    End Function
    Private Function extractPrompt(ByVal s) As String
        extractPrompt = extractSerializedLines(s, "PROMPT")
    End Function
    Private Function extractSerializedLines(ByVal s, ByVal tagPath, Optional ByVal Delim = DL) As String

        Dim x As New myXmlUtils, tList As New myList

        extractSerializedLines = ""
        If s = "" Then Exit Function

        tList.setList(x.extract(s, tagPath))
        tList.ReplaceDelim(Delim, vbLf)
        tList.RemoveBlanks(vbLf)

        extractSerializedLines = tList.getList

    End Function
    Private Sub frmStateMaker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        clearAll()
        loadProcessCombo()
        InitVarList()
        loadVarList()
        LoadQuickCombo()

    End Sub
    Private Sub btnUpper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpper.Click
        txtUpper.Text = stateVars.varFormat(txtVariable.Text)
    End Sub
    Private Sub btnLower_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLower.Click
        txtLower.Text = stateVars.varFormat(txtVariable.Text)
    End Sub
    Private Sub btnPromptVar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPromptVar.Click
        If txtButtonLabels.Text = "" Then
            txtButtonLabels.Text = stateVars.varFormat(txtVariable.Text)
        Else
            txtButtonLabels.Text = txtButtonLabels.Text & vbLf & stateVars.varFormat(txtVariable.Text)
        End If
    End Sub
    Private Sub btnCalculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculation.Click

        Dim t As String

        frmCalculator.ShowDialog()

        t = stateVars.varFormat(txtVariable.Text) & "=" & modGlobal.calcCommands

        If txtCalculations.Text = "" Then
            txtCalculations.Text = t
        Else
            txtCalculations.Text = txtCalculations.Text & vbLf & t
        End If

    End Sub
    Private Sub cmbProcess_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcess.SelectedIndexChanged

        readProcessFile()

    End Sub
    Private Sub loadProcessCombo()

        Dim f As New fileManager, s As New myList, t As String

        s.setList(f.getDirectories(gPath.templateProcessPath))

        cmbProcess.Items.Clear()
        cmbProcess.Text = ""

        For i = 0 To s.length(DL) - 1

            t = f.fileNameOnly(s.getItem(i, DL))
            cmbProcess.Items.Add(t.Substring(0, t.Length - 4))

        Next

    End Sub
    Private Sub loadProcessInfo()

        Dim fName As String, f As New fileManager, x As New myXmlUtils

        clearState()

        fName = makeStateMakerFileName()

        If f.filePresent(fName) Then
        End If

    End Sub
    Private Sub loadState()

        Dim s As String, x As New myXmlUtils

        If cmbState.Text <> "" Then

            s = x.extract(processFileContent, cmbState.Text.Replace(" ", ""))

            If s <> "" Then

                clearState()
                LoadGui(s)

            End If

        End If

    End Sub
    Private Sub cmbState_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbState.SelectedIndexChanged

        Dim t As String

        t = cmbState.Text

        If Not suppressLoad Then loadState()

    End Sub
    Private Function makeStateMakerFileName() As String
        makeStateMakerFileName = gPath.addSlash(gPath.templateProcessPath) & cmbProcess.Text & ".txt"
    End Function
    Private Sub saveToArchive(ByVal s As String)
        Dim f As New fileManager
        Dim ccp As New convCamPaths
        f.makeDirectory(ccp.AppPath.Substring(0, 3) & "CCAM-Archive\")

        Dim t As String = Now.ToString
        t = t.Replace("/", "-")
        t = t.Replace("#", "")
        t = t.Replace(":", "-")
        f.fileWrite(ccp.AppPath.Substring(0, 3) & "CCAM-Archive\" & cmbProcess.Text & "_" & t & ".txt", s)
    End Sub
    Private Sub clearProcess()

        Dim t As New myList

        txtProcessDescription.Text = ""
        processFileContent = ""

        stateList.setList("")

        cmbState.Text = ""
        cmbPreviousState.Text = ""
        cmbNextState.Text = ""

        cmbState.Items.Clear()
        cmbPreviousState.Items.Clear()
        cmbNextState.Items.Clear()

        varList.setList("")
        t.setList(dh.getToolParameterList)
        For i = 0 To t.length(DL) - 1
            varList.add("tool" & t.getItem(i, DL), DL, True)
        Next
        lstVariables.Text = ""
        lstVariables.Items.Clear()
        'loadAllSettings()
        getAllVariables()

        loadVarList()

    End Sub
    Private Sub clearState()

        cmbIfConditions.Text = ""

        txtButtonLabels.Text = ""
        txtCalculations.Text = ""
        txtNextLogic.Text = ""
        cmbNextState.Text = ""
        cmbPreviousState.Text = ""
        txtStatePrompt.Text = ""
        txtStateTitle.Text = ""
        txtVar1.Text = ""
        txtVar2.Text = ""
        txtVariable.Text = ""

        txtUpper.Text = ""
        txtLower.Text = ""
        chkUnits.Checked = False
        chkAlpha.Checked = True

        txtStateHelp.Text = ""
        txtErrorMessage.Text = ""
        txtStateDescription.Text = ""

        txtLgPic.Text = ""
        txtSmPic.Text = ""

    End Sub
    Private Sub readProcessFile()

        Dim f As New fileManager, x As New myXmlUtils

        clearProcess()
        clearState()

        If f.filePresent(makeStateMakerFileName) Then

            processFileContent = f.fileRead(makeStateMakerFileName)

            ' Load process variables into varList
            varList.setList(x.extract(processFileContent, "VARIABLES"))
            '   loadAllSettings()
            getAllVariables()

            stateList.setList(x.extract(processFileContent, "STATELIST"))
            txtGcode.Text = x.extract(processFileContent, "METAGCODE")

            txtProcessDescription.Text = x.extract(processFileContent, "DESCR")

            loadStateCombo()

            loadVarList()

            cmbState.Text = stateList.getItem(0, DL)
            txtVariable.Text = varList.getItem(0, DL)

            mParentVariables.setList(x.extract(processFileContent, "PARENTVARIABLES"))

            If x.extract(processFileContent, "ISPARENT") = "TRUE" Then
                chkIsParent.Checked = True
            Else
                chkIsParent.Checked = False
            End If

            loadParentVariableList()

        End If

    End Sub
    Private Sub loadParentVariableList()

        Dim i As Long

        txtParentVariables.Text = ""

        For i = 0 To mParentVariables.length(DL) - 1
            txtParentVariables.Text = txtParentVariables.Text & mParentVariables.getItem(i, DL) & vbCrLf
        Next

    End Sub
    Private Sub lstVariables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVariables.SelectedIndexChanged
        If lstVariables.SelectedItem.ToString <> "" Then txtVariable.Text = lstVariables.SelectedItem.ToString
    End Sub
    Private Sub btnSmPic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSmPic.Click

        Dim f As New fileManager, od As New OpenFileDialog, fname As String

        od.Reset()
        od.Filter = "Picture Files (*.bmp)|*.bmp|JPEG (jpg.*)|jpg.*"
        od.FileName = ""
        od.InitialDirectory = gPath.addSlash(gPath.picturesPath)
        od.ShowDialog()

        If DialogResult <> Windows.Forms.DialogResult.Cancel Then
            fname = f.fileNameOnly(od.FileName)
            txtSmPic.Text = fname
        End If

    End Sub
    Private Sub btnLgPic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLgPic.Click

        glbImageList = txtLgPic.Text
        frmImageListMaker.ShowDialog()
        txtLgPic.Text = glbImageList

        ''Dim f As New fileManager, od As New OpenFileDialog, fname As String

        ''od.Reset()
        ''od.Filter = "Picture Files (*.bmp)|*.bmp|JPEG (jpg.*)|jpg.*"
        ''od.FileName = ""
        ''od.InitialDirectory = gPath.addSlash(gPath.picturesPath)
        ''od.ShowDialog()

        ''If DialogResult <> Windows.Forms.DialogResult.Cancel Then
        ''    fname = f.fileNameOnly(od.FileName)
        ''    txtLgPic.Text = fname
        ''End If

    End Sub
    Private Sub btnPreviousState_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviousState.Click
        setPreviousState()
    End Sub
    Private Sub setPreviousState()
        cmbPreviousState.Text = txtVariable.Text
    End Sub
    Private Sub btnNextState_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextState.Click

        Dim logicString As String

        logicString = "NEXT " & cmbNextState.Text

        Select Case cmbIfConditions.Text
            Case "goto", ""
            Case Else
                logicString = logicString & " IF " & txtVar1.Text & " " & cmbIfConditions.Text & " " & txtVar2.Text
                If chkAlpha.Checked = True Then
                    logicString = logicString & " alpha"
                Else
                    logicString = logicString & " num"
                End If
        End Select

        If txtNextLogic.Text = "" Then
            txtNextLogic.Text = logicString
        Else
            txtNextLogic.Text = txtNextLogic.Text & vbLf & logicString
        End If

    End Sub
    Private Sub btnAddNextStateVal_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNextStateVal.Click
        cmbNextState.Text = txtVariable.Text
    End Sub
    Private Sub btnV1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnV1.Click
        txtVar1.Text = stateVars.varFormat(txtVariable.Text)
    End Sub
    Private Sub btnV2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnV2.Click
        txtVar2.Text = stateVars.varFormat(txtVariable.Text)
    End Sub
    Private Sub btnClearNext_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearNext.Click

        txtNextLogic.Text = ""
        cmbNextState.Text = ""
        txtVar1.Text = ""
        txtVar2.Text = ""
        cmbIfConditions.Text = "goto"

    End Sub
    Private Sub LoadQuickCombo()
        Dim f As New fileManager
        Dim tList As New myList
        Dim x As New myXmlUtils
        Dim s As String

        s = f.fileRead(gPath.Path(gPath.resourcesPath, "QuickStates.txt"))
        '' ''tList.setList(x.extract(s, "STATELIST"))
        tList.setList(x.getChildren(x.add(s, "TEMP"), "TEMP"))

        cmbQuickState.Items.Clear()

        For i = 0 To tList.length(DL) - 1
            cmbQuickState.Items.Add(tList.getItem(i, DL))
        Next

    End Sub
    Private Sub btnQuickState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuickState.Click
        LoadQuickState(cmbQuickState.Text)
    End Sub
    Private Sub LoadQuickState(ByVal stateName As String)

        Dim s As String, x As New myXmlUtils
        Dim f As New fileManager

        If cmbQuickState.Text <> "" Then

            s = f.fileRead(gPath.Path(gPath.resourcesPath, "QuickStates.txt"))

            If s <> "" Then

                clearState()
                s = x.extract(s, stateName.Replace(" ", ""))
                LoadGui(s)

            End If

        End If


    End Sub
    Private Sub LoadGui(ByVal s As String)

        Dim stateName As String
        Dim x As New myXmlUtils

        If s <> "" Then

            stateName = x.extract(s, "STNAME")

            stateList.add(stateName, DL, True)
            loadStateCombo()

            varList.add(stateName.Replace(" ", ""), DL, True)
            loadVarList()

            clearState()

            suppressLoad = True
            cmbState.Text = stateName
            suppressLoad = False

            txtStateTitle.Text = x.extract(s, "TITLE")

            cmbPromptType.Text = "None"
            cmbPromptType.Text = x.extract(s, "STTYPE")

            txtSmPic.Text = x.extract(s, "SMPIC")
            txtLgPic.Text = x.extract(s, "LGPIC")

            txtButtonLabels.Text = x.extract(s, "BUTTONLIST")

            If x.extract(s, "ALPHA") = "true" Then
                chkAlpha.Checked = True
            Else
                chkAlpha.Checked = False
            End If

            If x.extract(s, "UNITS") = "true" Then
                chkUnits.Checked = True
            Else
                chkUnits.Checked = False
            End If

            txtUpper.Text = x.extract(s, "ULIM")
            txtLower.Text = x.extract(s, "LLIM")
            cmbPreviousState.Text = x.extract(s, "PREV")

            txtNextLogic.Text = extractNextLogic(s)
            txtCalculations.Text = extractCalculations(s)
            txtButtonLabels.Text = extractButtonLabels(s)
            txtStatePrompt.Text = extractPrompt(s)

            txtStateDescription.Text = x.extract(s, "DESCR")
            txtStateHelp.Text = x.extract(s, "HELP")
            txtErrorMessage.Text = x.extract(s, "ERRORMESSAGE")

        End If

    End Sub
    Private Sub InitVarList()

        stateVars.clearAllVars()
        getAllVariables()

    End Sub


    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub btnShowQuickStates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowQuickStates.Click

        quickStateHolder = makeGroupInfo(makeCurrentState())
        frmQuickStateViewer.ShowDialog()
        LoadQuickCombo()

    End Sub

    Private Sub btnVariableReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVariableReport.Click
        showVariableReport()
    End Sub
    Private Sub showVariableReport()

    End Sub

    Private Sub btnAddRemoveParentVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRemoveParentVariable.Click

        Dim idx As Long
        idx = mParentVariables.indexOf(txtVariable.Text, DL)

        Select Case idx
            Case -1
                mParentVariables.add(txtVariable.Text, DL, True)
            Case Else
                mParentVariables.removeByName(txtVariable.Text, DL)
        End Select

        loadParentVariableList()

    End Sub

    Private Sub btnDeleteProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteProcess.Click
        Dim f As New fileManager

        If cmbProcess.Text = "" Then
            MsgBox("There is no Toolpath selected.")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete this Toolpath?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Dim s As String = f.fileRead(makeStateMakerFileName)
        saveToArchive(s)

        f.fileDelete(makeStateMakerFileName)

        loadProcessCombo()

    End Sub

    Private Sub btnAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto.Click

        If cmbState.Text = "" Then Exit Sub

        Dim idx As Integer = stateList.indexOf(cmbState.Text, DL)
        cmbPreviousState.Text = stateList.getAtIndex(idx - 1, DL)

        If stateList.getAtIndex(idx + 1, DL) <> "" Then
            txtNextLogic.Text = "NEXT " & stateList.getAtIndex(idx + 1, DL)
        Else
            txtNextLogic.Text = ""
        End If

    End Sub

    Private Sub btnSave1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave1.Click
        saveProcessFile()
    End Sub
End Class
