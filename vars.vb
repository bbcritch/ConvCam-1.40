Public Class vars

    Private varString As New Hashtable
    Private Const ENGLISH = 0
    Private Const METRIC = 1

    Public Function getHashTable() As Hashtable
        getHashTable = varString
    End Function
    Public Sub clearVar(ByVal varName As String)

        varName = varDeFormat(varName)
        If varString.ContainsKey(varName) Then varString.Remove(varName)

    End Sub
    Public Sub setVar(ByVal varName As String, ByVal varValue As String, Optional ByVal displayUnits As Integer = ENGLISH)

        ' Remove varName from collection
        varName = varDeFormat(varName)

        ' First, remove varname from list, if present
        If varString.ContainsKey(varName) Then varString.Remove(varName)

        ' If varName is has units, round it, then convert to 
        ' English, if optional displayUnits parameter is set to metric.
        ' This is to ensure ALL parameters with units are stored in ENGLISH units.
        If varName.Substring(0, 1) = "u" Then
            varValue = SRound(varValue)
            If displayUnits = METRIC Then
                varValue = ToEnglish(varValue)
            End If
        End If

        ' Store varValue in collection with varName key.
        varString.Add(varName, varValue)

    End Sub
    Public Function getVar(ByVal varName As String, Optional ByVal displayUnits As Integer = ENGLISH) As String

        varName = varDeFormat(varName)

        If varName = "" Then
            getVar = ""
            Exit Function
        End If

        If varString.ContainsKey(varName) Then

            getVar = varString(varName)

            If getVar <> "" Then
                If getVar.Substring(0, 1) = "|" And getVar.Substring(getVar.Length - 1, 1) = "|" Then
                    Return getVar(getVar)
                End If
            End If

            ' If varName has units, convert value to Metric, if 
            ' the optional displayUnits parameter indicates in metric mode.
            ' Then, round value to 4 digits.
            If varName.Substring(0, 1) = "u" Then
                If displayUnits = METRIC Then
                    getVar = ToMetric(getVar)
                End If
                getVar = SRound(getVar)
            End If
        Else
            getVar = ""
        End If

    End Function
    Public Function unitsTest(ByVal varName As String, ByVal displayUnits As Integer)
        If displayUnits = METRIC And varName.Substring(0, 1) = "u" Then
            unitsTest = METRIC
        Else
            unitsTest = ENGLISH
        End If
    End Function
    Public Function getVarNames() As String

        Dim s As String

        getVarNames = ""

        For Each s In varString.Keys

            getVarNames = appendString(getVarNames, s, DL)

        Next

        If getVarNames.Length > 0 Then getVarNames.Substring(0, getVarNames.Length - 1)

    End Function
    Public Sub clearAllVars()

        varString.Clear()

    End Sub
    Public Function makeXML() As String

        Dim s As String, x As New myXmlUtils
        Dim aList As New ArrayList
        Dim varVal As String

        makeXML = ""

        For Each s In varString.Keys
            If s <> "" Then aList.Add(s)
        Next

        aList.Sort()

        For Each s In aList

            If s <> "" Then
                varVal = varString(s)
                '' '' ''If s.Substring(0, 1) = "u" Then
                '' '' ''    If DISPUNITS = METRIC Then
                '' '' ''        varVal = ToEnglish(varVal)
                '' '' ''    End If

                '' '' ''End If
                ''''                makeXML = appendString(makeXML, x.add(varString(s), s.Replace(" ", "")), vbCrLf)
                makeXML = appendString(makeXML, x.add(varVal, s.Replace(" ", "")), vbCrLf)
            End If
        Next


        ' '' ''varName = nameList.getItem(i, DL)
        ' '' ''varVal = VarsAndVals(varName)
        ' '' ''If varName.Substring(0, 1) = "u" Then
        ' '' ''    If DISPUNITS = METRIC Then
        ' '' ''        varVal = ToMetric(varVal)
        ' '' ''    End If
        ' '' ''    varVal = SRound(varVal)
        ' '' ''End If











    End Function
    Public Sub loadVarString(ByVal s As String)

        Dim x As New myXmlUtils, t As New myList

        varString.Clear()
        t.setList(x.getSiblings(x.add("", "NOTUSED") & s, "NOTUSED"))

        For i = 0 To t.length(DL) - 1
            varString.Add(t.getItem(i, DL), x.extract(s, t.getItem(i, DL)))
        Next

        loadParentVariables(varString("ParentProcess"))

    End Sub
    Private Sub loadParentVariables(ByVal parentProcess As String)

        Dim x As New myXmlUtils

        If parentProcess = "" Then Exit Sub
        If parentProcess.ToLower = "none" Then Exit Sub

        ' Read the parent process file content from the temp part directory
        Dim f As New fileManager
        Dim parentContent = f.fileRead(gPath.addSlash(gPath.partPath) & "temp part\" & parentProcess & ".txt")
        If parentContent = "" Then Exit Sub

        ' Get the current process's template name
        Dim templateName = getVar("TEMPLATE")

        ' Get the child's variables that are to be supplied parent variable values
        Dim templateContent = f.fileRead(gPath.addSlash(gPath.templatePath) & "Processes\" & templateName)
        Dim varList As String = x.extract(templateContent, "PARENTVARIABLES")

        If varList = "" Then Exit Sub
        Dim varNames() As String = varList.Split("~")

        ' Plug in the parent variable values into the child variables.
        For i = 0 To varNames.Length - 1
            setVar(varNames(i), x.extract(parentContent, varNames(i)))
        Next

    End Sub
    Public Sub swapValues(ByVal key1 As String, ByVal key2 As String)

        Dim s1 As String, s2 As String

        s1 = varString(key1)
        s2 = varString(key2)

        varString.Remove(key1)
        varString.Remove(key2)

        varString.Add(key1, s2)
        varString.Add(key2, s1)

    End Sub
    Public Function getXML() As String

        ' Converts hashtable to xml format with following structure:

        '<1>
        '    <VARNAME>variableName</VARNAME>        (hashtable key)
        '    <VARVALUE>variableValue</VARVALUE>     (hashtable value)
        '</1>
        '<2>...</n>

        Dim s As String = "", t As String, x As New myXmlUtils, i As Integer = 1, sp As String = "  "
        Dim u As String, aList As New ArrayList

        ' Put keys in arraylist for sorting purposes
        For Each t In varString.Keys
            aList.Add(t)
        Next

        aList.Sort()

        For Each t In aList

            u = ""
            u = appendString(u, sp & x.add(t, "VARNAME"), vbCrLf)
            u = appendString(u, sp & x.add(varString(t), "VARVALUE"), vbCrLf)
            u = x.add(vbCrLf & u & vbCrLf, i.ToString)

            s = appendString(s, u, vbCrLf)
            i += 1

        Next

        getXML = x.add((i - 1).ToString, "QTY") & vbCrLf & s

    End Function
    Public Sub loadXML(ByVal s As String)

        ' Loads hashtable with xml file 's' having following format:

        '<1>
        '    <VARNAME>variableName</VARNAME>        (hashtable key)
        '    <VARVALUE>variableValue</VARVALUE>     (hashtable value)
        '</1>
        '<2>...</n>

        ' (hash table gets loaded with QTY key and quantity value, too.

        Dim t As String, x As New myXmlUtils

        varString.Clear()

        For i = 1 To Val(x.extract(s, "QTY"))

            t = x.extract(s, i.ToString)
            varString.Add(x.extract(t, "VARNAME"), x.extract(t, "VARVALUE"))

        Next

    End Sub
    Public Sub appendVar(ByVal varName As String, ByVal varValue As String, Optional ByVal delim As String = " ")

        Dim t As String

        t = getVar(varName)

        If t = "" Then
            setVar(varName, varValue)
        Else
            setVar(varName, t & delim & varValue)
        End If

    End Sub
    Public Function varFormat(ByVal v As String) As String

        v = v.Replace(" ", "")
        varFormat = v
        If v.Substring(0, 1) <> "|" Then varFormat = "|" & v & "|"

    End Function
    Public Function varDeFormat(ByVal varName As String) As String

        Select Case varName
            Case "", "|", "||"
                varDeFormat = ""
                Exit Function
        End Select

        If varName.Substring(0, 1) = "|" Then varName = varName.Substring(1)
        If varName.Substring(varName.Length - 1) = "|" Then varName = varName.Substring(0, varName.Length - 1)

        varDeFormat = varName

    End Function
    Public Function resolveVariable(ByVal varName As String) As String

        If varName = "" Then
            resolveVariable = ""
            Exit Function
        End If

        If varName.Substring(0, 1) = "|" Then
            resolveVariable = getVar(varName)
        Else
            resolveVariable = varName
        End If

    End Function
    Public Function getVarToMetric(ByVal varName As String) As String

        Dim t As String

        t = getVar(varName)

        If t <> "" Then

            t = (Double.Parse(t) * 25.4).ToString

        End If

        getVarToMetric = t

    End Function
    Public Function getVarEnglish(ByVal varName As String) As String

        Dim t As String

        t = getVar(varName)

        If t <> "" Then

            t = (Double.Parse(t) / 25.4).ToString

        End If

        getVarEnglish = t

    End Function

End Class

