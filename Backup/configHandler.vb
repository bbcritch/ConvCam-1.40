Module configHandler

    Public blankConfig As String
    Public blanksAll As String
    Public blankMy As String

    Public toolConfig As String
    Public toolAll As String
    Public toolMy As String

    Public machineConfig As String
    Public machineAll As String
    Public machineMy As String

    Public generalAll As String
    Public Sub UpdateMyFile(ByVal myFileName As String, ByVal listfile As String)

        ' called after myfile has been created.
        ' Reads latest myfile into global string,
        ' then loads values into global statevars.
        Select Case myFileName
            Case "BlankMy.txt"
                readBlankMy()
                If blankMy <> "" Then
                    frmConvCAM.grpPartProcesses.Visible = True
                End If
                blanksAll = listfile
                loadBlankVals()
            Case "ToolMy.txt"
                readToolMy()
                toolAll = listfile
                loadToolVals()
            Case "MachineMy.txt"
                readMachineMy()
                machineAll = listfile
                loadMachineVals()
        End Select

    End Sub
    Public Sub readBlankMy()
        blankMy = quickReadConfig(quickPath("BlankMy.txt"))
    End Sub
    Public Sub readToolMy()
        toolMy = quickReadConfig(quickPath("ToolMy.txt"))
    End Sub
    Public Sub readMachineMy()
        machineMy = quickReadConfig(quickPath("MachineMy.txt"))
    End Sub
    Public Sub readAllConfigs()

        toolConfig = quickReadConfig(quickPath("ToolConfig.txt"))
        machineConfig = quickReadConfig(quickPath("MachineConfig.txt"))
        blankConfig = quickReadConfig(quickPath("BlankConfig.txt"))

        machineAll = quickReadConfig(quickPath("MachinesAll.txt"))
        toolAll = quickReadConfig(quickPath("ToolsAll.txt"))
        blanksAll = quickReadConfig(quickPath("BlanksAll.txt"))

        generalAll = quickReadConfig(quickPath("GeneralVariables.txt"))

    End Sub
    Public Sub getAllVariables()
        getToolVariables()
        getMachineVariables()
        getBlankVariables()
        getGeneralVariables()
    End Sub
    Public Function GetParmVariableList(ByVal configFileType As String, ByVal stateVarName As String) As String

        Dim targetFile As String = ""
        Dim x As New myXmlUtils
        Dim parmList As String
        Dim dispInfo As String

        Select Case configFileType
            Case "Tools"
                targetFile = toolConfig
            Case "Machine"
                targetFile = machineConfig
            Case "Blank"
                targetFile = blankConfig
        End Select

        dispInfo = x.extract(targetFile, "DISPLAY")
        parmList = x.extract(dispInfo, stateVars.getVar(stateVarName))

        If parmList = "" Then
            GetParmVariableList = x.extract(dispInfo, "PARMS")
        Else
            GetParmVariableList = x.extract(parmList, "PARMS")
        End If

    End Function
    Public Sub getToolVariables()
        Dim x As New myXmlUtils
        addVarsToState(x.extract(toolConfig, "VARS"))
    End Sub
    Public Sub getMachineVariables()
        Dim x As New myXmlUtils
        addVarsToState(x.extract(machineConfig, "VARS"))
    End Sub
    Public Sub getBlankVariables()
        Dim x As New myXmlUtils
        addVarsToState(x.extract(blankConfig, "VARS"))
    End Sub
    Public Sub getGeneralVariables()
        Dim t As String, x As New myXmlUtils
        t = quickReadConfig(quickPath("GeneralVariables.txt"))
        t = x.extract(t, "VARS")
        addVarsToState(t)
    End Sub
    Public Function quickPath(ByVal fname As String) As String
        quickPath = gPath.addSlash(gPath.Configs) & fname
    End Function
    Public Function quickReadConfig(ByVal fname) As String
        Dim f As New fileManager
        quickReadConfig = f.fileRead(fname)
    End Function
    Public Sub addVarsToState(ByVal vList As String)

        Dim t As New myList, vName As String

        t.setList(vList)

        For i = 0 To t.length(DL) - 1
            vName = variableFormat(t.getItem(i, DL)).Trim
            If vName <> "" Then
                stateVars.setVar(vName, "")
                varList.add(vName, DL, True)
            End If
        Next

    End Sub
    Public Sub loadToolVals()
        Dim t As String, x As New myXmlUtils, delimvar As String
        t = x.extract(toolConfig, "DELIMVAR")
        delimvar = x.extract(toolMy, t)
        addVarValsToState(x.extract(toolAll, delimvar))
    End Sub
    Public Sub saveToolVals()

        Dim t As String
        Dim x As New myXmlUtils
        Dim toolAry() As String
        Dim toolList As String

        ' This sub steps through the TOOLLIST variable, and adds 
        ' the tool(s)' values to the state variable list. The variables are added 'as is'
        ' for the first tool in the list. Subsequent tool variables are added by appending
        ' the index number (e.g. _1, _2, etc) to the variable tag names. 

        toolList = stateVars.getVar("TOOLLIST")
        If toolList.Length = 0 Then Exit Sub

        toolAry = toolList.Split(DL)

        For i = 1 To toolAry.Length
            t = x.extract(toolAll, toolAry(i - 1))
            If i > 1 Then t = t.Replace(">", "_" & (i - 1).ToString & ">")
            addVarValsToState(t)
        Next

    End Sub
    Public Sub loadMachineVals()
        Dim t As String, x As New myXmlUtils, delimVar As String
        t = x.extract(machineConfig, "DELIMVAR")
        delimVar = x.extract(machineMy, t)
        addVarValsToState(x.extract(machineAll, delimVar))
    End Sub
    Public Sub loadBlankVals()
        Dim x As New myXmlUtils
        If blankMy <> "" Then addVarValsToState(blankMy)
    End Sub
    Public Sub addVarValsToState(ByVal t As String)

        Dim x As New myXmlUtils, tlist As New myList, i As Integer, s As String

        tlist.setList(x.getChildren(x.add(t, "TEMP"), "TEMP"))

        For i = 0 To tlist.length(DL) - 1
            s = variableFormat(tlist.getItem(i, DL))
            stateVars.setVar(s, x.extract(t, s))
        Next

    End Sub
    Public Sub addVarValsToStateIdx(ByVal t As String)

        Dim x As New myXmlUtils, tlist As New myList, i As Integer, s As String
        Dim tIdx As String

        tIdx = "_" & toolIdx

        tlist.setList(x.getChildren(x.add(t, "TEMP"), "TEMP"))

        For i = 0 To tlist.length(DL) - 1
            s = variableFormat(tlist.getItem(i, DL))
            stateVars.setVar(s + tIdx, x.extract(t, s))
        Next

    End Sub
    Public Sub configStartUp()

        Dim f As New fileManager

        readAllConfigs()
        readMachineMy()

        ' Force blankMy to be empty. It serves as flag that a 
        ' blank must be selected before adding processes to part design.
        f.fileDelete(quickPath("BlankMy.txt"))
        blankMy = ""

        If machineMy = "" Then

            MsgBox("For this first time setup, you will be prompted to select and set up your Legacy Woodworking machine", MsgBoxStyle.OkOnly)
            organizeMode = MACHINEMODE
            frmSetupOrganizer.ShowDialog()

        End If

        If machineMy = "" Then
            MsgBox("Without the machine selected, the program will now abort.", MsgBoxStyle.OkOnly)
            End
        End If

    End Sub
End Module
