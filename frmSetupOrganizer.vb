Public Class frmSetupOrganizer

    Private ignoreFlag As Boolean
    Private eventInhibit As Integer = 1

    Private listFile As String
    Private configFile As String
    Private varList As String

    Dim optList As New myList

    Private Const PARMCOL = 0
    Private Const VARVALCOL = 1
    Private Const HELPCOL = 2
    Private Const VARNAMECOL = 4
    Private Const FLAGCOL = 5

    Private Const CHECKCOL = 0
    Private Const DESCRCOL = 1
    Private Const MARKCOL = 2
    Private Const DELIMCOL = 3
    Private Const TYPECOL = 4

    Private Const checkMark = "   X"
    Private Const noCheck = "   --"

    Private singleItemParmNames As String
    Private singleItemListVals As String
    Private singleItemStorageVals As String
    Private singleItemDisplayVals As String

    Private tempDISPUNITS As Integer

    Private ParmChangeFlag As Boolean = False

    Private sortOrder As String = "up"

    Private Sub frmToolOrganizer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DISPUNITS = tempDISPUNITS
    End Sub
    Private Sub frmToolOrganizer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim f As New fileManager, x As New myXmlUtils

        eventInhibit = 1

        Select Case organizeMode
            Case TOOLMODE
                configFile = f.fileRead(gPath.addSlash(gPath.Configs) & "ToolConfig.txt")
                Label1.Visible = True
                btnUnits.Visible = True
                chkMyToolsOnly.Checked = myCheckedTools
            Case MACHINEMODE
                configFile = f.fileRead(gPath.addSlash(gPath.Configs) & "MachineConfig.txt")
                Label1.Visible = False
                btnUnits.Visible = False
            Case BLANKMODE
                configFile = f.fileRead(gPath.addSlash(gPath.Configs) & "BlankConfig.txt")
                Label1.Visible = False
                btnUnits.Visible = False
                chkMyToolsOnly.Checked = myCheckedBlanks
        End Select

        listFile = f.fileRead(gPath.addSlash(gPath.Configs) & x.extract(configFile, "LIBFILE"))
        listFile = listFile.Replace("<>", "")
        listFile = listFile.Replace("</>", "")
        f.fileWrite(quickPath(x.extract(configFile, "LIBFILE")), listFile)

        loadConfiguration()
        resetParmList()

        SortLib()
        SortLib()
        loadList()
        loadList()

        eventInhibit = 0
        loadSelected("Disable Prompt")

        If DISPUNITS = ENGLISH Then
            btnUnits.Text = "English"
        Else
            btnUnits.Text = "Metric"
        End If

        tempDISPUNITS = DISPUNITS

    End Sub
    Private Sub resetParmList()
        grdParameters.RowCount = 1
        setCell(grdParameters, 0, PARMCOL, "")
        setCell(grdParameters, 0, VARVALCOL, "")
        setCell(grdParameters, 0, VARNAMECOL, "")
        setCell(grdParameters, 0, FLAGCOL, "")
        SetToTextCell(grdParameters, 0, VARVALCOL)
    End Sub
    Private Sub loadConfiguration()

        Dim x As New myXmlUtils, t As String, tlist As New myList

        If x.extract(configFile, "ADD") = "Show" Then
            btnAddNew.Visible = True
        Else
            btnAddNew.Visible = False
        End If

        If x.extract(configFile, "REMOVE") = "Show" Then
            btnRemoveTool.Visible = True
        Else
            btnRemoveTool.Visible = False
        End If

        If x.extract(configFile, "SAVE") = "Show" Then
            btnSave.Visible = True
        Else
            btnSave.Visible = False
        End If

        Me.Text = x.extract(configFile, "TITLE")

        If x.extract(configFile, "FILTER") = "Show" Then

            pnlToolType.Visible = True
            pnlFilter.Visible = True

            t = x.extract(configFile, "TYPES")
            tlist.setList(t)

            cmbToolFilter.Items.Clear()
            cmbToolType.Items.Clear()

            cmbToolFilter.Items.Add("All")

            For i = 0 To tlist.length(DL) - 1
                cmbToolFilter.Items.Add(tlist.getItem(i, DL))
                cmbToolType.Items.Add(tlist.getItem(i, DL))
            Next

            cmbToolFilter.Text = "All"
            cmbToolType.Text = ""

        Else

            pnlToolType.Visible = False
            pnlFilter.Visible = False

        End If

        t = x.extract(configFile, "SORTBY")
        tlist.setList(t)

        cmbSort.Items.Clear()
        cmbSort.Text = tlist.getItem(0, DL)

        For i = 0 To tlist.length(DL) - 1
            cmbSort.Items.Add(tlist.getItem(i, DL))
        Next

    End Sub
    Private Sub loadList()

        Dim x As New myXmlUtils, dispVar As String, tlist As New myList
        Dim delimVar As String, typeVar As String, i As Integer, t As String
        Dim filter As String, delim As String, listTypeVar As String

        t = x.getChildren(x.add(listFile, "ZZTEMPZZ"), "ZZTEMPZZ")

        If t = "" Then
            clearList()
            Exit Sub
        End If

        tlist.setList(t)

        dispVar = x.extract(configFile, "DISPVARNAME")
        typeVar = x.extract(configFile, "TYPEVAR")
        delimVar = x.extract(configFile, "DELIMVAR")


        ' Apply filtering if necessary
        If x.extract(configFile, "FILTER") = "Show" Then

            'Filter on check marks, if necessary
            If chkMyToolsOnly.Checked = True Then
                t = ""

                For i = 0 To tlist.length(DL) - 1
                    delim = tlist.getItem(i, DL)
                    setSingleItem(delim)
                    If x.extract(singleItemListVals, "CHECKED") = "X" Then
                        t = appendString(t, delim, DL)
                    End If
                Next
                tlist.setList(t)
            End If

            filter = cmbToolFilter.Text

            If filter <> "" And filter <> "All" Then

                t = ""

                ' Walk through list of items. If filter matches type variable, then
                ' build a new filtered list string 't'
                For i = 0 To tlist.length(DL) - 1

                    delim = tlist.getItem(i, DL)
                    setSingleItem(delim)
                    listTypeVar = x.extract(singleItemListVals, typeVar)

                    If listTypeVar = filter Then
                        t = appendString(t, delim, DL)
                    End If

                Next

                tlist.setList(t)

            End If

        End If

        If tlist.length(DL) = 0 Then
            clearList()

        Else
            grdItemList.RowCount = tlist.length(DL)

            For i = 0 To tlist.length(DL) - 1

                setSingleItem(tlist.getItem(i, DL))
                setCell(grdItemList, i, DESCRCOL, CreateDescription(dispVar, singleItemListVals))
                setCell(grdItemList, i, DELIMCOL, x.extract(singleItemListVals, delimVar))
                setCell(grdItemList, i, TYPECOL, x.extract(singleItemListVals, typeVar))

                If x.extract(configFile, "FILTER") = "Show" Then
                    If x.extract(singleItemListVals, "CHECKED") <> "" Then
                        setCell(grdItemList, i, CHECKCOL, checkMark)
                    Else
                        setCell(grdItemList, i, CHECKCOL, "")
                    End If
                Else
                    setCell(grdItemList, i, 0, noCheck)
                End If

            Next
        End If

    End Sub
    Private Sub clearList()
        grdItemList.RowCount = 1
        Call setCell(grdItemList, 0, CHECKCOL, "")
        Call setCell(grdItemList, 0, DESCRCOL, "")
        Call setCell(grdItemList, 0, DELIMCOL, "")
        Call setCell(grdItemList, 0, TYPECOL, "")
    End Sub
    Private Sub loadAllParms()

        Dim rw As Integer, cl As Integer

        getRowCol(grdItemList, rw, cl)

        ' Re-initialize display aspects of Parameters
        '      clearToolParms()
        loadParmLabels(getCell(grdItemList, rw, TYPECOL))
        cmbToolType.Text = getCell(grdItemList, rw, TYPECOL)

        ' On Item List, update checkmarks,
        ' get list values from selected item
        ' convert values for display
        ' load values into parameter list
        setCheckMarks()
        setSingleItem(getCell(grdItemList, rw, DELIMCOL))
        getSingleItemStorageValsFromList()
        loadSingleItemDispVals()        ' Parm display and 
        getDisplayParmVals()            ' list of values now in sync
        LoadOrganizerPicture()
    End Sub
    Private Sub LoadOrganizerPicture(Optional ByVal ForceCombo As Boolean = False)

        Dim x As New myXmlUtils
        Dim varNames() As String
        Dim varName As String
        Dim fname As String
        Dim f As New fileManager
        Dim cp As New convCamPaths

        varName = x.extract(configFile, "PICVAR")
        varNames = varName.Split(",")

        Dim picName As String
        If varNames.Length > 1 Then
            picName = varNames(1)
        Else
            picName = varName
        End If

        For i = 0 To varNames.Length - 1
            If picName = "TYPECOMBO" Or ForceCombo Then
                fname = cmbToolType.Text & ".bmp"
            Else
                fname = x.extract(singleItemStorageVals, varNames(i)) & ".bmp"
            End If

            If f.filePresent(cp.Path(cp.picturesPath, fname)) Then
                LoadPicture(picTool, fname)
                Exit Sub
            End If
        Next

        LoadPicture(picTool, "TEMP")

    End Sub
    Private Sub setCheckMarks()
        Dim x As New myXmlUtils, rw As Integer, cl As Integer

        If x.extract(configFile, "FILTER") <> "Show" Then
            getRowCol(grdItemList, rw, cl)

            clearCheckMarks()
            setCell(grdItemList, rw, CHECKCOL, checkMark)
        End If
    End Sub
    Private Sub clearCheckMarks()

        Dim i As Integer

        For i = 0 To grdItemList.RowCount - 1
            setCell(grdItemList, i, CHECKCOL, noCheck)
        Next

    End Sub
    Private Sub clearItemListPointers()

        Dim i As Integer

        For i = 0 To grdItemList.RowCount - 1
            setCell(grdItemList, i, MARKCOL, "")
        Next

    End Sub
    Private Sub loadParmLabels(ByVal delim As String)

        Dim t As String, x As New myXmlUtils, tList As New myList
        Dim i As Integer, variableName As String

        t = getParmList(configFile, delim)
        If t = "" Then Exit Sub

        optList.setList(getOptionalList(configFile, delim))

        tList.setList(t)

        grdParameters.RowCount = tList.length(DL)
        varList = ""

        For i = 0 To tList.length(DL) - 1
            variableName = tList.getItem(i, DL)
            setCell(grdParameters, i, PARMCOL, parameterDisplayFormat(variableName))
            setCell(grdParameters, i, VARNAMECOL, variableFormat(variableName))
            varList = appendString(varList, variableFormat(variableName), DL)
        Next

        loadCombos(delim)

    End Sub
    Private Sub cmbToolFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbToolFilter.SelectedIndexChanged

        If Not ignoreFlag Then
            loadList()
        End If

    End Sub
    Public Sub clearToolParms()

        For i = 0 To grdParameters.RowCount - 1
            setCell(grdParameters, i, PARMCOL, "")
            setCell(grdParameters, i, VARNAMECOL, "")
            setCell(grdParameters, i, VARVALCOL, "")
            setCell(grdParameters, i, FLAGCOL, "")
        Next

        cmbToolFilter.Text = ""
        lblToolDetails.Text = ""
        LoadPicture(picTool, "")

    End Sub
    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click

        clearToolParms()
        loadParmLabels(cmbToolType.Text)

    End Sub
    Private Function addToolCheck() As Boolean

        addToolCheck = True

        If cmbToolType.Text.ToLower = "" Then
            addToolCheck = False
            Exit Function
        End If

    End Function
    Private Sub chkMyToolsOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMyToolsOnly.CheckedChanged
        Select Case organizeMode
            Case TOOLMODE
                myCheckedTools = chkMyToolsOnly.Checked
            Case BLANKMODE
                myCheckedBlanks = chkMyToolsOnly.Checked
        End Select
        loadList()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        saveParms()
    End Sub
    Private Sub btnRemoveTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTool.Click

        Dim x As New myXmlUtils, rw As Integer, cl As Integer, f As New fileManager

        If MsgBox("Are you sure you want to remove this item?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            getRowCol(grdItemList, rw, cl)

            listFile = x.remove(listFile, getCell(grdItemList, rw, DELIMCOL))
            f.fileWrite(quickPath(x.extract(configFile, "LIBFILE")), listFile)
            loadList()

        End If

    End Sub
    Private Sub saveListFile()
        Dim f As New fileManager, x As New myXmlUtils
        f.fileWrite(gPath.addSlash(gPath.Configs) & x.extract(configFile, "LIBFILE"), listFile)
    End Sub
    Private Sub cmbToolType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbToolType.SelectedIndexChanged
        If Not ignoreFlag Then
            loadParmLabels(cmbToolType.Text)
            LoadOrganizerPicture(True)
        End If
    End Sub
    Private Function saveParms() As Boolean

        Dim t As String, x As New myXmlUtils, varName As String, f As New fileManager
        Dim varVal As String
        Dim typeVal As String = "ZDUMMY"
        Dim sDescription As String

        saveParms = True

        ' If the variables are not properly filled in, then exit
        If Not getDisplayParmVals() Then
            MsgBox("Invalid selection or parameters.", MsgBoxStyle.OkOnly, "Save Aborted")
            saveParms = False
            Exit Function
        End If

        ' If there has been a parameter change, check to 
        ' see if there is an item already present in the list with
        ' the same delimvar value.
        ' The user will be prompted whether to overwrite the existing item,
        ' or instructed to change the delimvar value (typically to a different ID)
        If ParmChangeFlag Then
            If Not ListItemPresentCheck() Then Exit Function
        End If

        t = singleItemStorageVals
        t.Replace(vbCrLf, vbLf)
        t.Replace(vbLf, vbCrLf)

        If x.extract(configFile, "FILTER") = "Show" Then
            typeVal = cmbToolType.Text
            t = appendString(t, x.add(cmbToolType.Text, x.extract(configFile, "TYPEVAR")), vbCrLf)
        End If

        ' Load description template (unscanned) into list. Will be updated upon display.
        sDescription = GetDescrTemplate(configFile, typeVal)
        t = appendString(t, x.add(sDescription, x.extract(configFile, "DISPVARNAME")), vbCrLf)


        varName = x.extract(configFile, "DELIMVAR")
        varVal = x.extract(t, varName)

        ' get current checked value in list file for this part.
        ' if part isn't in listfile, it's OK, checked will be "".
        Dim checkVal As String = x.extract(listFile, varVal & " CHECKED")
        t = appendString(t, x.add(checkVal, "CHECKED"), vbCrLf)

        listFile = x.append(listFile, vbCrLf & t & vbCrLf, varVal)

        listFile = listFile.Replace("<>", "")
        listFile = listFile.Replace("</>", "")

        f.fileWrite(quickPath(x.extract(configFile, "LIBFILE")), listFile)

        loadList()
        ParmChangeFlag = False

    End Function
    Private Function ListItemPresentCheck() As Boolean

        Dim x As New myXmlUtils
        ListItemPresentCheck = True

        If Not getDisplayParmVals() Then
            Exit Function
        End If

        Dim dimVar As String = x.extract(configFile, "DELIMVAR")
        Dim dimVal As String = x.extract(singleItemStorageVals, dimVar)

        For i = 0 To grdItemList.RowCount - 1
            If getCell(grdItemList, i, DELIMCOL) = dimVal Then
                If MsgBox("This item is already in the list. Select 'Yes' to overwrite it. " & vbLf & "(Select 'No' and change the " & dimVar & " if you wish to save it as a new item.)", MsgBoxStyle.YesNo, "Item Exists") = MsgBoxResult.No Then
                    ListItemPresentCheck = False
                    Exit Function
                Else
                    Exit For
                End If
            End If
        Next

    End Function
    Private Sub grdItemList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItemList.CellClick
        cellClick()
    End Sub
    Private Sub cellClick()
        Dim cl As Integer, rw As Integer

        getRowCol(grdItemList, rw, cl)
        setActiveCell(grdItemList, rw, 1)

        Select Case cl
            Case DESCRCOL, MARKCOL
                loadAllParms()
                markRow(rw)
            Case CHECKCOL
                handleCheck(rw)
                loadList()
        End Select
    End Sub
    Private Sub markSelected()

        Dim delim As String, x As New myXmlUtils

        delim = x.extract(configFile, "DELIMVAR")
        delim = x.extract(singleItemStorageVals, delim)

        For i = 0 To grdItemList.RowCount - 1

            If getCell(grdItemList, i, DELIMCOL) = delim Then
                markRow(i)
                Exit For
            End If

        Next

    End Sub
    Private Sub markRow(ByVal rw As Integer)

        For i = 0 To grdItemList.RowCount - 1
            setCell(grdItemList, i, MARKCOL, "")
        Next
        setCell(grdItemList, rw, MARKCOL, "<<")
        grdItemList.Refresh()
    End Sub
    Private Sub handleCheck(ByVal rw As Integer)

        Dim x As New myXmlUtils, itemDelim As String
        Dim f As New fileManager

        If x.extract(configFile, "FILTER") = "Show" Then
            itemDelim = getCell(grdItemList, rw, DELIMCOL)
            If x.extract(listFile, itemDelim & " CHECKED") = "X" Then
                listFile = x.append(listFile, "", itemDelim & " CHECKED")
            Else
                listFile = x.append(listFile, "X", itemDelim & " CHECKED")
            End If
            f.fileWrite(quickPath(x.extract(configFile, "LIBFILE")), listFile)
        Else

        End If

    End Sub
    Private Sub setSingleItem(ByVal delim As String)

        Dim x As New myXmlUtils, typeVarName As String

        singleItemListVals = x.extract(listFile, delim)

        typeVarName = x.extract(configFile, "TYPEVAR")

        singleItemParmNames = x.getChildren(listFile, delim)

    End Sub
    Private Sub getSingleItemStorageValsFromList()

        ' This functions converts all values in item list to English, if necessary
        ' This list (singleItemDispVals) is what will always get displayed.

        Dim t As New myList, x As New myXmlUtils, valu As String, variableName

        singleItemStorageVals = ""
        t.setList(singleItemListVals)

        For i = 0 To t.length(DL) - 1

            variableName = t.getItem(i, DL)
            valu = x.extract(singleItemListVals, variableName)

            If variableName.substring(0, 1) = "u" Then
                valu = SRound(ToEnglish(valu))
                valu = SRound(valu)
            End If

            singleItemStorageVals = appendString(singleItemStorageVals, x.add(valu, variableName), vbCrLf)

        Next

    End Sub
    Private Sub loadSingleItemDispVals()

        Dim t As New myList, x As New myXmlUtils, valu As String, variableName

        For i = 0 To grdParameters.RowCount - 1

            variableName = getCell(grdParameters, i, VARNAMECOL)
            valu = x.extract(singleItemStorageVals, variableName)

            If variableName.substring(0, 1) = "u" Then
                If DISPUNITS = METRIC Then valu = ToMetric(valu)
                valu = SRound(valu)
            End If

            setCellComboCheck(grdParameters, i, VARVALCOL, valu, FLAGCOL)

        Next

    End Sub
    Private Function getDisplayParmVals() As Boolean

        ' This function obtains display values from parameters, if necessary
        ' converts them to english and storageList.

        Dim t As New myList, x As New myXmlUtils, valu As String, variableName

        getDisplayParmVals = True

        singleItemStorageVals = ""
        t.setList(singleItemListVals)

        For i = 0 To grdParameters.RowCount - 1

            variableName = getCell(grdParameters, i, VARNAMECOL)
            valu = getCell(grdParameters, i, VARVALCOL)

            ' Ensure delim var value has no spaces, since it will be use as an xml tag
            If variableName = x.extract(configFile, "DELIMVAR").Replace(" ", "") Then
                valu = valu.Replace(" ", "_")
                setCell(grdParameters, i, VARVALCOL, valu)
            End If

            If valu = "" And optList.indexOf(variableName, DL) = -1 Then
                getDisplayParmVals = False
                Exit Function
            End If

            If variableName.substring(0, 1) = "u" Then
                If DISPUNITS = METRIC Then valu = SRound(ToEnglish(valu))
                valu = SRound(valu)
            End If

            singleItemStorageVals = appendString(singleItemStorageVals, x.add(valu, variableName), vbCrLf)

        Next

    End Function
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        exitOK()
    End Sub
    Private Sub exitOK()

        Dim f As New fileManager, x As New myXmlUtils

        ' Only save parms if there has been a parameter change (which is defined
        ' by merely clicking in the parmeter grid's variable value cells.
        Dim rw = GetMarkerRow()

        If rw = -1 Then
            MsgBox("You must first select an item from the list.", MsgBoxStyle.OkOnly, "No Item Selected")
            Exit Sub
        End If

        ' If change in parameters, save them into the list file
        If ParmChangeFlag Then
            If Not saveParms() Then Exit Sub
        End If

        Dim myFileParms As String = x.extract(listFile, getCell(grdItemList, rw, DELIMCOL))

        f.fileWrite(quickPath(x.extract(configFile, "MYFILE")), myFileParms)

        ' Update myfile and global variables associated with myfile
        UpdateMyFile(x.extract(configFile, "MYFILE"), listFile)

        Close()

    End Sub
    Private Function GetMarkerRow()

        GetMarkerRow = -1

        For i = 0 To grdItemList.RowCount - 1
            If getCell(grdItemList, i, MARKCOL) = "<<" Then
                GetMarkerRow = i
                Exit Function
            End If
        Next

    End Function
    Private Sub loadSelected(ByVal prFlag As String)

        Dim f As New fileManager, x As New myXmlUtils, t As String, typeVar As String

        t = f.fileRead(gPath.addSlash(gPath.Configs) & x.extract(configFile, "MYFILE"))

        If t = "" Then
            If prFlag = "Enable Prompt" Then
                MsgBox("No item has been selected yet", MsgBoxStyle.OkOnly)
            End If
            LoadPicture(picTool, "")
            clearItemListPointers()
        Else
            singleItemStorageVals = t
            typeVar = x.extract(configFile, "TYPEVAR")
            cmbToolType.Text = x.extract(singleItemStorageVals, typeVar)
            loadParmLabels(cmbToolType.Text)
            loadSingleItemDispVals()
            markSelected()
            LoadOrganizerPicture()
        End If

    End Sub
    Private Function getCombos(ByVal delim As String) As String

        Dim t As String, x As New myXmlUtils

        t = x.extract(configFile, "DISPLAY " & variableFormat(delim) & " COMBOS")
        If t = "" Then t = x.extract(configFile, "DISPLAY COMBOS")
        getCombos = t

    End Function
    Private Sub loadCombos(ByVal delim As String)

        Dim s As String, x As New myXmlUtils, tlist As New myList
        Dim variableName As String, lst As String, uList As New myList

        s = getCombos(delim)

        If s <> "" Then

            tlist.setList(x.getChildren(x.add(s, "TEMP"), "TEMP"))

            For i = 0 To tlist.length(DL) - 1

                variableName = tlist.getItem(i, DL)

                For j = 0 To grdParameters.RowCount - 1

                    If getCell(grdParameters, j, VARNAMECOL) = variableName Then
                        lst = x.extract(s, variableName)
                        setCell(grdParameters, j, FLAGCOL, lst)

                        ' Convert list values to metric (if conditions warrent)
                        If variableName.Substring(0, 1) = "u" Then
                            uList.setList(lst)
                            lst = ""
                            For k = 0 To uList.length(DL) - 1
                                'CONV                                lst = appendString(lst, ToMetric(uList.getItem(i, DL)), DL)
                                lst = appendString(lst, uList.getItem(i, DL), DL)
                            Next
                        End If

                        setCombo(grdParameters, j, VARVALCOL, x.extract(s, variableName))
                        Exit For

                    End If

                Next

            Next

        End If
    End Sub
    Public Function getNameTemplate(ByVal delim As String)

        Dim t As String, x As New myXmlUtils

        t = x.extract(configFile, "DISPLAY " & variableFormat(delim) & " NAME")
        If t = "" Then t = x.extract(configFile, "DISPLAY NAME")
        getNameTemplate = t

    End Function
    Private Sub btnUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnits.Click

        If btnUnits.Text = "English" Then
            DISPUNITS = METRIC
            btnUnits.Text = "Metric"
        Else
            DISPUNITS = ENGLISH
            btnUnits.Text = "English"
        End If

        loadSingleItemDispVals()
        loadList()

    End Sub
    Private Sub grdParameters_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdParameters.CellClick

        Dim row, col As Integer
        Dim parmName As String
        Dim x As New myXmlUtils

        getRowCol(grdParameters, row, col)

        If col = HELPCOL Then
            parmName = getCell(grdParameters, row, VARNAMECOL)
            frmQuickHelp.sHelp = x.extract(configFile, "HELP " & parmName)
            frmQuickHelp.sTitle = "Help - " & getCell(grdParameters, row, PARMCOL)
            frmQuickHelp.ShowDialog()
        End If

        If col = VARVALCOL Then ParmChangeFlag = True

    End Sub
    Private Function CreateDescription(ByVal dispVarName As String, ByVal varList As String) As String

        Dim ht As New Hashtable
        Dim x As New myXmlUtils
        Dim tList As New myList

        ' Create list that has all xml tag names
        tList.setList(x.getChildren(x.add(varList, "TEMP"), "TEMP"))

        ' Create hash table using tag names as keys, and tag's associated values
        For i = 0 To tList.length(DL) - 1
            ht(tList.getItem(i, DL)) = x.extract(varList, tList.getItem(i, DL))
        Next

        ' The template is the value associated with the dispVarName tag
        Dim template As String = x.extract(varList, dispVarName)

        If dispVarName = "ToolDescription" Then
            template = "|ToolType| |Specifications| |uToolDiameter| Dia - |ToolMfgID|"
        End If

        ' Call function that replaces variables with values, using template and hash table of values
        CreateDescription = MakeDescription(template, ht)

    End Function

    Private Sub btnSortUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSortUp.Click
        SortLib()
    End Sub

    Private Sub SortLib()

        Dim x As New myXmlUtils

        Dim t As String = x.getChildren(x.add(listFile, "TEMP"), "TEMP")

        Dim tAry() As String = t.Split("~")

        Dim sortAry(0 To tAry.Length - 1) As String
        Dim sInfo As String
        Dim sKey As String = cmbSort.Text.Replace(" ", "")

        Dim sSelectedItem As String = FindSelectedItem()

        For i = 0 To tAry.Length - 1

            sInfo = x.extract(listFile, tAry(i).Replace(" ", ""))
            sortAry(i) = x.extract(sInfo, sKey) & DL & tAry(i)

        Next

        Array.Sort(sortAry)
        If sortOrder.Equals("down") Then
            Array.Reverse(sortAry)
            sortOrder = "up"
        Else
            sortOrder = "down"
        End If

        Dim newListFile As String = ""

        For i = 0 To sortAry.Length - 1

            tAry = sortAry(i).Split(DL)
            sKey = tAry(1)
            sInfo = x.extract(listFile, sKey)
            newListFile = appendString(newListFile, x.add(vbCrLf & sInfo.Trim(vbLf, vbCr) & vbCrLf, sKey), vbCrLf)

        Next

        listFile = newListFile
        loadList()

        SetSelected(sSelectedItem)
    End Sub

    Private Function FindSelectedItem() As String

        For i = 0 To grdItemList.RowCount - 1

            If getCell(grdItemList, i, MARKCOL) <> "" Then
                FindSelectedItem = getCell(grdItemList, i, DESCRCOL)
                Exit Function
            End If
        Next

        FindSelectedItem = ""

    End Function

    Private Sub SetSelected(ByVal SelectedInfo As String)

        If SelectedInfo = "" Then Exit Sub

        For i = 0 To grdItemList.RowCount - 1

            If getCell(grdItemList, i, DESCRCOL).Equals(SelectedInfo) Then
                markRow(i)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub grdItemList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItemList.CellDoubleClick
        cellClick()
        exitOK()
    End Sub

 
End Class