
Public Class calc

    Private mem(0 To 4) As Single
    Private varName As String, varValue As String
    Private Const precision = 4
    Private stackAry(0 To 10) As Single

    Public Function calcEngine(ByVal cmdString As String) As Single
        Dim s() As String, n As String, i As Integer

        s = cmdString.Split(DL)
        n = ""

        ' For case where there is a single math parameter, return that parameter as value
        If s.Length = 1 Then
            s(0) = stateVars.resolveVariable(s(0))
            '' ''calcEngine = Math.Round(Val((0)), 4)
            calcEngine = Math.Round(Val(s(0)), 4)
            Exit Function
        End If


        For i = 0 To 10
            stackAry(i) = "0"
        Next

        For i = 0 To s.Length - 1
            Select Case s(i)

                Case "+", "-", "*", "/", "x^y", ">", "<", "EQU"
                    Call dualOp(s(i), "")
                Case "(-)", "cos", "acos", "sin", "asin", "tan", "atan", "sqrt", "x^2", "abs", "int", "rup", "rou"
                    Call unaryOp(s(i))
                Case "enter"
                    Call push(n)
                Case "break"
                    i = s.Length
                Case ""

                Case Else

                    n = stateVars.resolveVariable(s(i))

            End Select
        Next

        calcEngine = Math.Round(Val(stackAry(0)), 4)

    End Function
    Private Sub dualOp(ByVal op As String, ByVal num As String)

        Dim s1 As Single, s2 As Single, popflag As Integer

        If num <> "" Then
            Call push(num)
        End If

        s1 = Val(stackAry(0))
        s2 = Val(stackAry(1))

        popflag = 1

        Select Case op
            Case "+"
                s2 = s1 + s2
            Case "-"
                s2 = s2 - s1
            Case "*"
                s2 = s2 * s1
            Case "/"
                If s1 <> 0 Then s2 = s2 / s1
            Case "swap"
                popflag = 0
                stackAry(0) = Format(s2)
                stackAry(1) = Format(s1)
            Case "x^y"
                s2 = s2 ^ s1
            Case ">"
                Call pop() ' true condition
                Call pop()
                If s1 <= s2 Then Call pop() ' false condition
                popflag = 0
                s2 = stackAry(0)
            Case "<"
                Call pop() ' true condition
                Call pop()
                If s1 >= s2 Then Call pop() ' false condition
                popflag = 0
                s2 = stackAry(0)
            Case "EQU"
                Call pop() ' true condition
                Call pop()
                If s1 <> s2 Then Call pop() ' false condition
                popflag = 0
                s2 = stackAry(0)
        End Select

        If popflag = 1 Then Call pop()
        stackAry(0) = Format(s2)

    End Sub
    Private Sub unaryOp(ByVal op As String)

        Dim s1 As Single
        Dim deg2Rad As Single

        deg2Rad = 0.017453292519943295

        s1 = Val(stackAry(0))

        Dim roundInt As String = "1"

        If op.Substring(0, 3) = "rou" Then
            If op.Length = 3 Then
                roundInt = 1
            Else
                roundInt = op.Substring(3, 1)
                If roundInt < "0" Or roundInt > "9" Then roundInt = "1"
            End If
            op = "rou"
        End If

        Select Case op
            Case "+/-"
                s1 = -s1
            Case "sin"
                s1 = Math.Sin(s1 * deg2Rad)
            Case "asin"
                s1 = Math.Asin(s1) / deg2Rad
            Case "cos"
                s1 = Math.Cos(s1 * deg2Rad)
            Case "acos"
                s1 = Math.Acos(s1) / deg2Rad
            Case "tan"
                s1 = Math.Tan(s1 * deg2Rad)
            Case "atan"
                s1 = Math.Atan(s1) / deg2Rad
            Case "x^2"
                s1 = s1 * s1
            Case "sqrt"
                If s1 > 0 Then s1 = s1 ^ 0.5
            Case "abs"
                s1 = Math.Abs(s1)
            Case "int"
                s1 = Int(s1)
            Case "rup"
                If s1 > Int(s1) Then s1 = Int(s1) + 1
            Case "rou"
                s1 = Math.Round(s1, Convert.ToInt16(roundInt))
        End Select

        stackAry(0) = Format(s1)

    End Sub
    Private Sub push(ByVal s As String)

        If s.Length = 0 Then Exit Sub

        For i = 10 To 1 Step -1
            stackAry(i) = stackAry(i - 1)
        Next i

        stackAry(0) = Format(resolveVariable(s))

    End Sub
    Private Sub pop()

        For i = 0 To 9
            stackAry(i) = stackAry(i + 1)
        Next i

    End Sub
    Private Function resolveVariable(ByVal s As String) As Single

        If s.Length > 0 Then
            Select Case s.Substring(0, 1)
                Case "0" To "9", "-", ".", "+"
                    resolveVariable = Val(s)
                Case ""
                    resolveVariable = 0
                Case Else
                    resolveVariable = Val(stateVars.getVar(s))
            End Select
        Else
            resolveVariable = 0
        End If

    End Function
End Class
