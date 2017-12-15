Public Class frmCalculator


    Private mem(0 To 4) As Single
    Private varName As String, varValue As String
    Private Const precision = 4
    Private stackAry(0 To 10) As Single
    Private v As New vars

    Private engineMode
    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click

        txtCommandString.Text = txtStack.Text.Replace(vbLf, DL)  'UNITS
        Call calcEngine(txtCommandString.Text)

    End Sub
    Private Sub num0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num0.Click
        cmbEntry.Text = cmbEntry.Text
    End Sub
    Private Sub num1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num1.Click
        cmbEntry.Text = cmbEntry.Text
    End Sub
    Private Sub num2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num2.Click
        cmbEntry.Text = cmbEntry.Text & "2"
    End Sub
    Private Sub num3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num3.Click
        cmbEntry.Text = cmbEntry.Text & "3"
    End Sub
    Private Sub num4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num4.Click
        cmbEntry.Text = cmbEntry.Text & "4"
    End Sub
    Private Sub num5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num5.Click
        cmbEntry.Text = cmbEntry.Text & "5"
    End Sub
    Private Sub num6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num6.Click
        cmbEntry.Text = cmbEntry.Text & "6"
    End Sub
    Private Sub num7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num7.Click
        cmbEntry.Text = cmbEntry.Text & "7"
    End Sub
    Private Sub num8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num8.Click
        cmbEntry.Text = cmbEntry.Text & "8"
    End Sub
    Private Sub num9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num9.Click
        cmbEntry.Text = cmbEntry.Text & "9"
    End Sub
    Private Sub dot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dot.Click

        If cmbEntry.Text.Length = 0 Then
            cmbEntry.Text = "."
            Exit Sub
        End If

        Select Case cmbEntry.Text.Substring(0, 1)
            Case "0" To "9", "-"
                If cmbEntry.Text <> "" Then
                    If InStr(cmbEntry.Text, ".") = 0 Then cmbEntry.Text = cmbEntry.Text & "."
                End If
        End Select

    End Sub
    Private Sub numSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numSign.Click

        If cmbEntry.Text.Length = 0 Then
            Call unaryOp("+/-")
        Else
            Select Case cmbEntry.Text.Substring(0, 1)
                Case "0" To "9", "-", ".", "+"
                    cmbEntry.Text = Format(Val(cmbEntry.Text) * -1)
            End Select
        End If

    End Sub
    Private Sub plus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plus.Click
        Call dualOp("+", cmbEntry.Text)
    End Sub
    Private Sub minus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles minus.Click
        Call dualOp("-", cmbEntry.Text)
    End Sub
    Private Sub multiply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles multiply.Click
        Call dualOp("*", cmbEntry.Text)
    End Sub
    Private Sub divide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles divide.Click
        Call dualOp("/", cmbEntry.Text)
    End Sub
    Private Sub btnSqu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSqu.Click
        Call unaryOp("x^2")
    End Sub
    Private Sub btnSqRt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSqRt.Click
        Call unaryOp("sqrt")
    End Sub
    Private Sub btnSin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSin.Click
        Call unaryOp("sin")
    End Sub
    Private Sub btnaSin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaSin.Click
        Call unaryOp("asin")
    End Sub
    Private Sub btnCos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCos.Click
        Call unaryOp("cos")
    End Sub
    Private Sub btnAcos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcos.Click
        Call unaryOp("acos")
    End Sub
    Private Sub btnTan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTan.Click
        Call unaryOp("tan")
    End Sub
    Private Sub btnAtan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtan.Click
        Call unaryOp("atan")
    End Sub
    Private Sub btnPi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPi.Click
        cmbEntry.Text = Format(Math.PI)
    End Sub
    Private Sub btnxSwapY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnxSwapY.Click
        Call dualOp("swap", cmbEntry.Text)
    End Sub
    Private Sub btnxtoy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnxtoy.Click
        Call dualOp("x^y", cmbEntry.Text)
    End Sub
    Private Sub btnCLr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLr.Click
        If cmbEntry.Text = "" Then
            answer.Text = 0
            stackAry(0) = Format(0)
        Else
            cmbEntry.Text = ""
        End If
        Call showStack()
    End Sub
    Private Sub Enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enter.Click

        If cmbEntry.Text.Length = 0 Then
            Call push(stackAry(0))
        Else
            Call push(cmbEntry.Text)
            cmbEntry.Text = ""
        End If

    End Sub
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

        If engineMode <> 1 Then Call addToStack(op)
        If popflag = 1 Then Call pop()
        stackAry(0) = Format(s2)

        answer.Text = stackAry(0)
        Call showStack()

    End Sub
    Private Sub unaryOp(ByVal op As String)

        Dim s1 As Single
        Dim deg2Rad As Single
        Dim roundInt As String = "1"

        deg2Rad = 0.017453292519943295
        s1 = Val(stackAry(0))

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

        If engineMode <> 1 Then
            Call addToStack(op)
        End If

        stackAry(0) = Format(s1)

        answer.Text = stackAry(0)
        Call showStack()

    End Sub
    Private Sub btnSetVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetVariable.Click
        Dim s() As String

        If Trim(vName.Text).Length <> 0 Then

            Call v.setVar(vName.Text, vVal.Text)
        Else
            v.clearVar("")

        End If

        s = v.getVarNames.Split(DL)

        cmbEntry.Items.Clear()

        For i = 0 To s.Length - 1
            cmbEntry.Items.Add(s(i))
        Next

    End Sub
    Private Sub btnClrStack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClrStack.Click
        ClearCalculator()
    End Sub
    Public Sub ClearCalculator()
        Dim i As Integer

        answer.Text = "0"
        txtStack.Text = ""
        cmbEntry.Text = ""

        For i = 0 To 10
            stackAry(i) = "0"
        Next

        For i = 0 To 3
            mem(i) = 0
        Next i

        Call showStack()

    End Sub
    Private Sub addToStack(ByVal s As String)
        txtStack.Text = txtStack.Text + s + vbCrLf
    End Sub
    Private Function resolveVariable(ByVal s As String) As Single

        If s.Length > 0 Then
            Select Case s.Substring(0, 1)
                Case "0" To "9", "-", ".", "+"
                    resolveVariable = Val(s)
                Case ""
                    resolveVariable = 0
                Case Else
                    resolveVariable = Val(v.getVar(s))
            End Select
        Else
            resolveVariable = 0
        End If

    End Function
    Private Sub calcEngine(ByVal cmdString As String)
        Dim s() As String, n As String, i As Integer

        engineMode = 1

        s = cmdString.Split(DL)
        n = ""

        For i = 0 To 10
            stackAry(i) = "0"
        Next

        For i = 0 To s.Length - 1
            Select Case s(i)

                Case "+", "-", "*", "/", "x^y", ">", "<", "EQU"
                    Call dualOp(s(i), "")
                Case "(-)", "cos", "acos", "sin", "asin", "tan", "atan", "sqrt", "x^2", "int", "rup", "abs", "rou"
                    Call unaryOp(s(i))
                Case "enter"
                    Call push(n)
                Case "break"
                    i = s.Length
                Case ""

                Case Else

                    If InStr(s(i), "|") = 1 Then
                        n = v.getVar(s(i).Substring(1, s(i).Length - 2))
                    Else
                        n = s(i)
                    End If

            End Select
        Next

        engineMode = 0

        answer.Text = stackAry(0)
        Call showStack()

    End Sub
    Private Sub btnGetCommandString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCommandString.Click

        txtCommandString.Text = txtStack.Text.Replace(vbLf, DL)
        modGlobal.calcCommands = txtCommandString.Text
        Me.Close()

    End Sub
    Private Sub btnPut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPut.Click

        txtStack.Text = txtCommandString.Text.Replace(DL, vbLf)

    End Sub
    Private Sub push(ByVal s As String)

        If s.Length = 0 Then Exit Sub

        For i = 10 To 1 Step -1
            stackAry(i) = stackAry(i - 1)
        Next i

        stackAry(0) = Format(resolveVariable(s))

        If engineMode <> 1 Then
            Call addToStack(addBracks(s))
            Call addToStack("enter")
            cmbEntry.Text = ""
        End If

        answer.Text = stackAry(0)
        Call showStack()

    End Sub
    Private Sub pop()

        For i = 0 To 9
            stackAry(i) = stackAry(i + 1)
        Next i
        Call showStack()

    End Sub
    Private Function addBracks(ByVal s As String)

        Select Case s.Substring(0, 1)
            Case "0" To "9", "-"
                addBracks = s
            Case ""
                addBracks = s
            Case Else
                addBracks = s
        End Select

    End Function
    Private Sub btnLess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call dualOp("<", cmbEntry.Text)

    End Sub
    Private Sub btnGreater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call dualOp(">", cmbEntry.Text)
    End Sub
    Private Sub btnEqual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call dualOp("EQU", cmbEntry.Text)
    End Sub
    Private Sub showStack()

        txtStackBox.Text = ""

        For i = 0 To 10
            txtStackBox.Text = txtStackBox.Text + Format(stackAry(i)) + vbLf
        Next

    End Sub
    Private Sub frmRpnCalculator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call loadStateNames()
        Call ClearCalculator()

    End Sub
    Private Sub loadStateNames()
        Dim s() As String

        s = varList.getList.Split(DL)
        cmbEntry.Items.Clear()

        For i = 0 To s.Length - 1

            cmbEntry.Items.Add("|" & s(i) & "|")

        Next

    End Sub
    Private Sub btnAbs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbs.Click
        Call unaryOp("abs")
    End Sub
    Private Sub btnInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInt.Click
        Call unaryOp("int")
    End Sub
    Private Sub btnRup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRup.Click
        Call unaryOp("rup")
    End Sub
    Private Sub btnRou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRou.Click
        Call unaryOp("rou" & cmbEntry.Text)
    End Sub
End Class
