Public Class frmPartResolution

    Public PartFileName As String
    Public CancelFlag As Boolean
    Public BlankDelimiterValue As String
    Private PartFileData As String
    Private BlankPartData As String
    Private BlankLibData As String
    Private BlankDelim As String

    Private Sub frmPartResolution_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadBlankInfo("New Blank Parameters", lblNewBlank, BlankPartData)
        LoadBlankInfo("Library Blank Parameters", lblLibraryBlank, BlankLibData)
        CancelFlag = True

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim x As New myXmlUtils
        Dim newDelim As String = x.extract(blankConfig, "DELIMVAR")

        If ValidateDelim() Then

            BlankPartData = x.replace(BlankPartData, txtNewDelim.Text, newDelim)

            AddBlankInfoToBlankLib(BlankPartData, txtNewDelim.Text)
            UpdateBlankMy(BlankPartData)
            CancelFlag = False
            Me.Close()

        End If
    End Sub
    Private Function ValidateDelim() As Boolean

        Dim NewDelim As String = txtNewDelim.Text.Replace(" ", "")
        Dim tList As New myList
        Dim x As New myXmlUtils

        NewDelim = NewDelim.Replace(">", "")
        NewDelim = NewDelim.Replace("<", "")
        txtNewDelim.Text = NewDelim

        If NewDelim = "" Then
            MsgBox("Please enter a valid ID below the 'Add' button", MsgBoxStyle.OkOnly)
            ValidateDelim = False
            Exit Function
        End If

        tList.setList(x.getChildren(x.add(blanksAll, "TEMP"), "TEMP"))
        If tList.indexOf(NewDelim) >= 0 Then
            MsgBox("This ID already exists. Please enter a valid ID below the 'Add' button", MsgBoxStyle.OkOnly)
            ValidateDelim = False
            Exit Function
        End If

        ValidateDelim = True

    End Function
    Private Sub btnOverwrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverwrite.Click

        ' Adds new blank info to blankAll global and associated file
        Dim x As New myXmlUtils
        Dim f As New fileManager

        blanksAll = x.append(blanksAll, vbCrLf & BlankPartData & vbLf, BlankDelimiterValue)
        f.fileWrite(quickPath("BlanksAll.txt"), blanksAll)
        UpdateBlankMy(BlankPartData)

        CancelFlag = False
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub LoadBlankInfo(ByVal title As String, ByVal lbl As Label, ByVal partInfo As String)

        Dim x As New myXmlUtils
        Dim tList As New myList
        lbl.Text = title & vbLf

        tList.setList(x.getChildren(x.add(partInfo, "TEMP"), "TEMP"))

        For i = 0 To tList.length(DL) - 1

            If tList.getItem(i, DL) <> "CHECKED" Then
                lbl.Text = appendString(lbl.Text, tList.getItem(i, DL) & "   " & x.extract(partInfo, tList.getItem(i, DL)), vbLf)
            End If
        Next

    End Sub

    Public Function ExtractBlankInfo(ByVal partFile As String) As Boolean
        ' Used to populate blankMy variable using values from 
        ' newly loaded existing design

        Dim t As String = ""
        Dim x As New myXmlUtils
        Dim f As New fileManager
        Dim tList As New myList
        Dim delimvar As String

        ExtractBlankInfo = True

        ' Get blank info from part file
        PartFileData = partFile
        BlankPartData = x.extract(PartFileData, "BLANKINFO").Trim(TRIMS)

        ' get Delimiter value from blank inof
        delimvar = x.extract(blankConfig, "DELIMVAR")
        BlankDelimiterValue = x.extract(BlankPartData, delimvar)

        ' Use delimiter value to extract blank info from library
        BlankLibData = x.extract(blanksAll, BlankDelimiterValue)

        Dim BlankCompareResult As Integer = CompareBlankPartToLib(BlankPartData, BlankLibData)

        Select Case BlankCompareResult
            Case -1
                ExtractBlankInfo = False
                Exit Function
            Case 0
                ' No blank info in library, add it.
                AddBlankInfoToBlankLib(BlankPartData, BlankDelimiterValue)
            Case 1
                ' Do nothing, all is OK.
        End Select

        UpdateBlankMy(BlankPartData)

    End Function
    Private Sub UpdateBlankMy(ByVal BlankData As String)

        ' Updates the current blankMy global, and associated file
        Dim f As New fileManager

        blankMy = BlankData
        f.fileWrite(quickPath("BlankMy.txt"), blankMy)

    End Sub
    Private Sub OverwriteBlankInfoToBlankLib(ByVal BlankData As String, ByVal BlankDelim As String)

        ' Adds new blank info to blankAll global and associated file
        Dim x As New myXmlUtils
        Dim f As New fileManager
        Dim s As String = x.add(vbCrLf & BlankData & vbLf, BlankDelim)

        blanksAll = appendString(blanksAll, s, vbCrLf)
        f.fileWrite(quickPath("BlanksAll.txt"), blanksAll)

    End Sub
    Private Sub AddBlankInfoToBlankLib(ByVal BlankData As String, ByVal BlankDelim As String)

        ' Adds new blank info to blankAll global and associated file
        Dim x As New myXmlUtils
        Dim f As New fileManager
        Dim s As String = x.add(vbCrLf & BlankData & vbLf, BlankDelim)

        blanksAll = appendString(blanksAll, s, vbCrLf)
        f.fileWrite(quickPath("BlanksAll.txt"), blanksAll)

    End Sub
    Private Function CompareBlankPartToLib(ByVal BlankPart As String, ByVal BlankLib As String) As Integer

        ' This function compares the parameters from the Blank in the part file
        ' to the blank in the lib file and returns integers as follows:
        '
        ' -1: lists are not equal
        '  0: Blank library does not have blank info from part
        '  1: Blank in part has matching blank in library

        Dim x As New myXmlUtils
        Dim BlankList As New myList
        Dim LibList As New myList
        Dim matchFlag = True
        Dim t1 As String, t2 As String

        ' Blank is not in blank library
        If BlankLib = "" Then
            CompareBlankPartToLib = 0
            Exit Function
        End If

        BlankList.setList(x.getChildren(x.add(BlankPart, "TEMP"), "TEMP"))
        LibList.setList(x.getChildren(x.add(BlankLib, "TEMP"), "TEMP"))

        ' Parameter list is of different length, a non-match
        If BlankList.length(DL) <> LibList.length(DL) Then
            CompareBlankPartToLib = -1
            Exit Function
        End If

        ' Found parameter values that differ, a non-match
        For i = 0 To BlankList.length(DL) - 1
            If BlankList.getItem(i, DL) <> "CHECKED" Then
                t1 = x.extract(BlankPart, BlankList.getItem(i, DL))
                t2 = x.extract(BlankLib, BlankList.getItem(i, DL))
                If t1 <> t2 Then
                    CompareBlankPartToLib = -1
                    Exit Function
                End If
            End If
        Next

        ' All comparisons passed, blanks are equal.
        CompareBlankPartToLib = 1

    End Function

End Class