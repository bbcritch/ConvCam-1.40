Public Class myXmlUtils
    Dim oldType As String, sType As String, indentNum As Integer

    Public Function extract(ByVal s As String, ByVal tagPath As String) As String

        Dim p1 As Integer, p2 As Integer

        If getTagPos(s, tagPath, p1, p2, "interior") Then
            extract = s.Substring(p1 + 1, p2 - p1 - 1)
        Else
            extract = ""
        End If

    End Function
    Public Function add(ByVal s As String, ByVal tag As String) As String
        add = startTag(tag) & s & endTag(tag)
    End Function
    Private Function startTag(ByVal tag As String) As String

        startTag = "<" & tag & ">"

    End Function
    Private Function endTag(ByVal tag As String) As String

        endTag = "</" & tag & ">"

    End Function
    Public Function formatXML(ByVal s As String) As String

        Dim t As String, p As Integer, oldP As Integer, tagType As String, oldTagType As String
        Dim indentNum As Integer, tag As String, v() As String, u As String, oldType As String

        t = s
        p = 0
        tag = ""

        p = getTag(s, p, tag)

        tagType = getTagType(tag)

        Do While p >= 0

            oldP = p
            oldTagType = tagType
            p = getTag(t, oldP + tag.Length, tag)

            tagType = getTagType(tag)

            If p >= 0 Then

                ' if two start tags in succession, put a crlf and indent between the two.
                If tagType = "start" And oldTagType = "start" Then
                    t = insertCRLF(t, oldP)
                End If

                ' For all end tags, insert a crlf and indent
                If tagType = "end" Then
                    t = insertCRLF(t, p)
                End If

            End If

        Loop

        indentNum = 0
        u = ""
        oldType = ""
        sType = ""


        v = t.Split(vbLf)
        For i = 0 To v.Length - 1

            indentNum = setIndentation(v(i))
            u = u + getIndent(indentNum) + v(i) + vbLf

        Next i

        formatXML = u

    End Function
    Public Function setIndentation(ByVal v As String) As Integer

        If Mid(v, 2, 1) <> "/" And InStr(v, "/") > 0 Then sType = "B"
        If Mid(v, 2, 1) = "/" Then sType = "E"
        If InStr(v, "/") = 0 Then sType = "S"

        Select Case oldType + sType
            Case "B", "E", "S", "ES", "EB", "BS", "BB", "SE"
            Case "EE", "BE"
                indentNum = indentNum - 1
            Case "SS", "SB"
                indentNum = indentNum + 1
        End Select

        oldType = sType

        setIndentation = indentNum

    End Function
    Private Function getTagType(ByVal tag) As String

        If InStr(tag, "/") > 0 Then
            getTagType = "end"
        Else
            getTagType = "start"
        End If

    End Function
    Public Function deFormatXML(ByVal s As String) As String

        Dim t() As String, p As Integer, u As String

        t = s.Split(vbLf)

        For i = 0 To t.Length - 1

            p = InStr(t(i), "<") - 1
            If p >= 0 Then t(i) = t(i).Substring(p)

        Next

        u = String.Join("", t)
        deFormatXML = cleanUp(u)

    End Function
    Private Function getTag(ByVal s As String, ByVal pos As Integer, ByRef tag As String) As Integer

        Dim p As Integer, p1 As Integer

        p = s.IndexOf("<", pos)

        If p >= 0 Then
            p1 = s.IndexOf(">", p)
            tag = s.Substring(p, p1 - p + 1)
        Else
            tag = ""
        End If

        getTag = p

    End Function
    Private Function insertCRLF(ByVal s As String, ByVal pos As Integer) As String

        Dim p As Integer

        p = s.IndexOf(">", pos)

        If p < s.Length - 1 Then
            insertCRLF = s.Substring(0, p + 1) + vbLf + s.Substring(p + 1)
        Else
            insertCRLF = s
        End If

    End Function
    Private Function getIndent(ByVal indentNum As Integer) As String

        Dim indentString As String, totalIndent As String

        indentString = "    "
        totalIndent = ""

        For i = 1 To indentNum
            totalIndent = totalIndent + indentString
        Next i

        getIndent = totalIndent

    End Function
    Public Function getXMLHeader() As String

        getXMLHeader = "<?xml version=" + Chr(34) + "1.0" + Chr(34) + "encoding = " + Chr(34) + "UTF-8" + Chr(34) + "?>"

    End Function
    Public Function remove(ByVal s As String, ByVal tagPath As String) As String

        Dim p1 As Integer, p2 As Integer

        If getTagPos(s, tagPath, p1, p2, "exterior") Then

            If p1 = 0 And p2 = s.Length - 1 Then
                remove = ""
                Exit Function
            End If

            If p1 = 0 Then
                remove = s.Substring(p2 + 1)
                Exit Function
            End If

            If p2 = s.Length - 1 Then
                remove = s.Substring(0, p1)
                Exit Function
            End If

            remove = s.Substring(0, p1) & s.Substring(p2 + 1)
        Else
            remove = s
        End If

    End Function
    Public Function cleanUp(ByVal s As String) As String

        For i = s.Length To 1 Step -1

            If Mid(s, i, 1) = ">" Then
                s = Mid(s, 1, i)
                i = 0
            End If

        Next

        cleanUp = s

    End Function
    Public Function traverse(ByVal s As String, ByVal tagPrefix As String)

        Dim i As Integer, t As String, u As String

        t = ""
        i = 1

        While i > 0

            u = extract(s, tagPrefix & Format(i))

            If u <> "" Then
                t = t & u & DL
                i = i + 1
            Else
                i = -1
            End If

        End While

        If t.Length > 0 Then t = Mid(t, 1, t.Length - 1)

        traverse = t

    End Function
    Public Function getTagPos(ByVal s As String, ByVal tagPath As String, ByRef p1 As Integer, ByRef p2 As Integer, ByVal mode As String) As Boolean

        Dim ary() As String

        ary = tagPath.Split(" ")

        p1 = -1

        If s = "" Then
            getTagPos = False
            Exit Function
        End If

        For i = 0 To ary.Length - 1

            p1 = s.IndexOf(startTag(ary(i)), p1 + 1)

            If p1 = -1 Then
                getTagPos = False
                Exit Function
            End If
        Next

        p2 = s.IndexOf(endTag(ary(ary.Length - 1)), p1 + 1)

        If p2 = -1 Then
            getTagPos = False
            Exit Function
        End If

        Select Case mode
            Case "interior"
                p1 = p1 + startTag(ary(ary.Length - 1)).Length - 1
            Case "exterior"
                p2 = p2 + endTag(ary(ary.Length - 1)).Length - 1
        End Select

        getTagPos = True

    End Function
    Public Function ovwr(ByVal s As String, ByVal tagPath As String, ByVal valu As String) As String

        Dim ary() As String, tags1 As String, tags2 As String
        Dim p1 As Integer, p2 As Integer

        ovwr = s
        ary = tagPath.Split(" ")

        For i = 0 To ary.Length - 1

            If i = 0 Then
                If Not getTagPos(s, ary(0), p1, p2, "interior") Then
                    ovwr = s & addDeep(s, valu, tagPath)
                    Exit Function
                End If
            End If

            If i = ary.Length - 1 Then

                ' if not there, replace siblings with siblings and it
                If Not getTagPos(s, tagPath, p1, p2, "interior") Then
                    tags1 = splitTagPath(tagPath, i, "first")
                    ovwr = replace(s, extract(s, tags1) & add(valu, ary(i)), tags1)
                    Exit Function
                Else ' if last tag is there, just replace it
                    ovwr = replace(s, valu, tagPath)
                    Exit Function
                End If

            End If

            ' if a mid tag is not present, extract its siblings, 
            ' append it to its siblings, then replace 
            tags1 = splitTagPath(tagPath, i, "first")
            If Not getTagPos(s, tags1, p1, p2, "interior") Then
                tags1 = splitTagPath(tagPath, i - 1, "first")
                tags2 = splitTagPath(tagPath, i, "second")
                ovwr = replace(s, extract(s, tags1) & addDeep(s, valu, tags2), tags1)
                Exit Function
            End If

        Next

    End Function
    Public Function addDeep(ByVal s, ByVal valu, ByVal tagpath) As String

        Dim ary() As String

        addDeep = valu
        ary = tagpath.split(" ")

        For i = ary.Length - 1 To 0 Step -1

            addDeep = add(addDeep, ary(i))

        Next

    End Function
    Private Function splitTagPath(ByVal tagpath As String, ByVal idx As Integer, ByVal mode As String) As String

        Dim ary() As String

        splitTagPath = ""

        ary = tagpath.Split(" ")

        If mode = "first" Then

            For i = 0 To idx
                splitTagPath = appendString(splitTagPath, ary(i), " ")
            Next

        Else

            For i = idx + 1 To ary.Length

                splitTagPath = appendString(splitTagPath, ary(i), " ")

            Next

        End If

    End Function
    Private Function firstChild(ByVal s As String, ByVal tagpath As String)

        Dim t As String, p1 As Integer, p2 As Integer

        ' Finds first tag interior to tagpath
        ' If first tag exists and is not an end tag, it is a child
        ' Returns tag if child, "" if not

        t = ""
        getTagPos(s, tagpath, p1, p2, "interior")

        firstChild = ""

        If p1 >= 0 Then

            getTag(s, p1 + 1, t)

            If t <> "" Then
                If getTagType(t) = "start" Then '(if not 'start' xml file is flawed)
                    firstChild = t
                End If
            End If

        End If

    End Function
    Private Function nextSibling(ByVal s As String, ByVal tagpath As String)

        Dim t As String, p1 As Integer, p2 As Integer

        ' Finds first tag exterior to tagpath
        ' If first tag exists and is not an end tag, it is a sibling
        ' Returns tag if child, "" if not

        t = ""
        getTagPos(s, tagpath, p1, p2, "interior")

        nextSibling = ""

        If p2 >= 0 Then

            getTag(s, p2 + 1, t)

            If t <> "" Then
                If getTagType(t) = "start" Then
                    nextSibling = t
                End If
            End If

        End If

    End Function
    Public Function getChildren(ByVal s As String, ByVal tagpath As String)

        Dim t As String, p1 As Integer, p2 As Integer

        getTagPos(s, tagpath, p1, p2, "interior")
        t = firstChild(s, tagpath)

        If t <> "" Then
            t = t.Substring(1, t.Length - 2)
            getChildren = appendString(t, getSiblings(s, (tagpath & " " & t)), DL)
        Else
            getChildren = ""
        End If

    End Function
    Public Function getSiblings(ByVal s As String, ByVal tagpath As String)

        Dim ary() As String, parentPath As String, sibTag As String, searchPath As String
        Dim sTemp As String

        getSiblings = ""
        parentPath = ""

        If tagpath <> "" Then

            ary = tagpath.Split(" ")

            For i = 0 To ary.Length - 2
                parentPath = parentPath & ary(i) & " "
            Next

            parentPath = parentPath.Trim
            sibTag = ary(ary.Length - 1)

            While sibTag <> ""
                searchPath = parentPath & " " & sibTag
                sibTag = nextSibling(s, searchPath.Trim)

                If sibTag <> "" Then

                    sibTag = sibTag.Substring(1, sibTag.Length - 2)

                    If getSiblings = "" Then
                        getSiblings = sibTag
                    Else
                        sTemp = getSiblings
                        getSiblings = appendString(sTemp, sibTag, DL)
                    End If
                End If

            End While

        End If

    End Function
    Public Function replace(ByVal s As String, ByVal newVal As String, ByVal tagPath As String)

        Dim p1 As Long, p2 As Long

        If getTagPos(s, tagPath, p1, p2, "interior") Then

            replace = s.Substring(0, p1 + 1) & newVal & s.Substring(p2)
        Else

            replace = s

        End If

    End Function
    Public Function append(ByVal s As String, ByVal newval As String, ByVal tagpath As String)

        Dim t As String, p1 As Integer, p2 As Integer, ary() As String, newtag As String

        ' If newval exists within tagpath heirarchy, the contents of tagpath are replaced.

        ' if NewVal does not exist in tagpaht heirarchy, newval is appended to end of 
        ' existing heirarchy as a new item.


        ary = tagpath.Split(" ")

        ' Replace contents of tagpath, if tagpath exists
        If getTagPos(s, tagpath, p1, p2, "interior") Then
            append = s.Substring(0, p1 + 1) & newval & s.Substring(p2)
        Else ' Add newval to siblings in tagpath
            newtag = ary(ary.Length - 1) ' get last tag

            ary(ary.Length - 1) = ""  ' remove last tag from tagpath
            tagpath = Trim(Join(ary, " "))

            t = extract(s, tagpath) ' get sibling information
            ' add siblings and newval back into body
            getTagPos(s, tagpath, p1, p2, "interior")
            append = s.Substring(0, p1 + 1) & t & add(newval, newtag) & s.Substring(p2)
        End If

    End Function
End Class
