Module OrganizerUtils

    Public Function getParmList(ByVal configfile As String, ByVal delim As String) As String

        Dim t As String, x As New myXmlUtils

        t = x.extract(configFile, "DISPLAY " & variableFormat(delim) & " PARMS")
        If t = "" Then t = x.extract(configFile, "DISPLAY PARMS")
        getParmList = t

    End Function
    Public Function getOptionalList(ByVal configfile As String, ByVal delim As String) As String

        Dim t As String, x As New myXmlUtils
        Dim tList As New myList

        t = x.extract(configfile, "DISPLAY " & variableFormat(delim) & " OPTIONAL")
        If t = "" Then t = x.extract(configfile, "DISPLAY OPTIONAL")

        getOptionalList = t.Replace(" ", "")

    End Function
    Public Function GetDescrTemplate(ByVal configfile As String, ByVal delim As String) As String

        Dim t As String, x As New myXmlUtils

        t = x.extract(configfile, "DISPLAY " & variableFormat(delim) & " DISPVARTEMPLATE")
        If t = "" Then t = x.extract(configfile, "DISPLAY DISPVARTEMPLATE")

        GetDescrTemplate = t

    End Function
    Public Function MakeDescription(ByVal template As String, ByVal VarsAndVals As Hashtable) As String

        Dim nameList As New myList
        Dim t As String
        Dim varName As String
        Dim varVal As String

        ' This function, similar to valstovals, scans the template
        ' string and replaces all variable name occurrances with
        ' their respective values.

        t = FindVars(template)

        If t.Length > 0 Then
            nameList.setList(t)
            For i = 0 To nameList.length(DL) - 1
                varName = nameList.getItem(i, DL)
                varVal = VarsAndVals(varName)
                If varName.Substring(0, 1) = "u" Then
                    If DISPUNITS = METRIC Then
                        varVal = ToMetric(varVal)
                    End If
                    varVal = SRound(varVal)
                End If
                template = template.Replace("|" & varName & "|", varVal)
            Next
        End If

        MakeDescription = template

    End Function
    Public Function MakeBlankDescr() As String

        Dim x As New myXmlUtils

        Dim sTemplate As String = GetDescrTemplate(blankConfig, stateVars.getVar(x.extract(blankConfig, "TYPEVAR")))
        MakeBlankDescr = MakeDescription(sTemplate, stateVars.getHashTable)

    End Function
    Public Function MakeToolDescr(ByVal toolID As String) As String

        Dim x As New myXmlUtils
        Dim ht As New Hashtable
        Dim tList As New myList
        Dim s As String
        Dim t As String

        s = x.extract(toolAll, toolID)
        t = x.getChildren(x.add(s, "TEMP"), "TEMP")
        tList.setList(t)

        For i = 0 To tList.length(DL) - 1
            ht(tList.getItem(i, DL)) = x.extract(s, tList.getItem(i, DL))
        Next

        Dim sTemplate As String = x.extract(toolConfig, "DISPLAY DISPVARTEMPLATEONLY")
        MakeToolDescr = MakeDescription(sTemplate, ht)

    End Function

End Module
