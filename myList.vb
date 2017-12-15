Public Class myList

    Dim s As String
    Dim tIndex As Long

    Public Sub setList(ByVal listInput As String)
        s = listInput
    End Sub
    Public Sub setListFromXML(ByVal xmlBlock As String)
        Dim x As New myXmlUtils
        setList(x.getChildren(x.add(xmlBlock, "ZZTEMPZZ"), "ZZTEMPZZ"))
    End Sub
    Public Sub setListAppend(ByVal listinput As String)
        s = s & listinput
    End Sub
    Public Function getList() As String
        getList = s
    End Function
    Public Sub add(ByVal t As String, Optional ByVal delim As String = " ", Optional ByVal unique As Boolean = False)

        If unique Then
            If indexOf(t, delim) = -1 Then s = appendString(s, t, delim)
        Else
            s = appendString(s, t, delim)
        End If

    End Sub
    Public Sub removeByName(ByVal itemName As String, ByVal delim As String)

        Dim ary() As String
        Dim forceFlag As Integer = 0

        If s <> "" Then

            ary = s.Split(delim)
            s = ""

            For i = 0 To ary.Length - 1

                If ary(i) <> itemName Or forceFlag = 1 Then
                    add(ary(i), delim)
                Else
                    forceFlag = 1
                End If

            Next

        End If

    End Sub
    Public Sub remove(ByVal idx As Long, Optional ByVal delim As String = " ")

        Dim ary() As String

        If s <> "" Then
            ary = s.Split(delim)
            s = ary(0)


            For i = 1 To ary.Length - 1
                add(ary(i), delim)
            Next

        End If

    End Sub
    Public Function getItem(ByVal idx As Long, Optional ByVal delim As String = " ") As String

        Dim ary() As String

        If s <> "" Then
            ary = s.Split(delim)
            If idx < ary.Length Then
                getItem = ary(idx)
            Else
                getItem = ""
            End If
            tIndex = idx + 1
        Else
            getItem = s
            tIndex = 0
        End If

    End Function
    Public Function indexOf(ByVal t As String, Optional ByVal delim As String = " ") As Long

        Dim ary() As String

        indexOf = -1

        If s <> "" Then
            ary = s.Split(delim)
            For i = 0 To ary.Length - 1
                If ary(i) = t Then
                    indexOf = i
                    i = ary.Length
                End If
            Next
        End If

    End Function
    Public Function length(Optional ByVal delim As String = " ") As Long

        Dim ary() As String

        length = 0

        If s <> "" Then
            ary = s.Split(delim)
            length = ary.Length
        End If

    End Function
    Public Function getNext(Optional ByVal delim As String = " ") As String

        Dim ary() As String

        getNext = ""
        If s = "" Then Exit Function

        ary = s.Split(delim)
        If tIndex >= ary.Length Then Exit Function

        getNext = ary(tIndex)
        tIndex = tIndex + 1

    End Function
    Public Sub getNextInit()
        tIndex = 0
    End Sub
    Public Sub sort(ByVal delim As String)

        Dim ary() As String

        If s <> "" Then
            ary = s.Split(delim)
            Array.Sort(ary)
            s = String.Join(delim, ary)
        End If

    End Sub
    Public Function getUnique(Optional ByVal delim = " ") As String

        Dim t() As String, t1() As String, foundFlag As Boolean

        getUnique = ""
        If s = "" Then Exit Function

        t = s.Split(delim)

        For i = 0 To t.Length - 1

            If getUnique = "" Then
                getUnique = t(i)
            Else
                t1 = getUnique.Split(DL)
                foundflag = False
                For j = 0 To t1.Length - 1
                    If t(i) = t1(j) Then
                        foundFlag = True
                        Exit For
                    End If
                Next

                If foundFlag = False Then getUnique = getUnique & delim & t(i)

            End If

        Next

    End Function
    Public Function getLast(Optional ByVal delim As String = " ")

        Dim ary() As String

        getLast = ""

        If s <> "" Then
            ary = s.Split(delim)
            getLast = ary(ary.Length - 1)
        End If

    End Function
    Public Function ReplaceDelim(ByVal oldDelim As String, ByVal newDelim As String)
        s = s.Replace(oldDelim, newDelim)
        ReplaceDelim = s
    End Function
    Public Function RemoveBlanks(Optional ByVal delim As String = " ")
        Dim ary() As String

        ary = s.Split(delim)
        s = ""

        For i = 0 To ary.Length - 1
            If ary(i) <> "" Then
                s = appendString(s, ary(i), delim)
            End If
        Next

        RemoveBlanks = s

    End Function
    Public Function getAtIndex(ByVal idx As Integer, Optional ByVal delim As String = " ")

        Dim ary() As String = s.Split(delim)

        If idx < 0 Then Return ""
        If idx >= ary.Length Then Return ""

        Return ary(idx)

    End Function

End Class


