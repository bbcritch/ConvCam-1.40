Public Class tabHandler

    Dim colTabs As New Collection()
    Public Function removeAllTabs(ByRef tabCtl As TabControl) As String

        Dim tabNames As String = ""
        Dim topTab As Integer
        topTab = tabCtl.Controls.Count - 1

        colTabs.Clear()

        For i = 0 To tabCtl.Controls.Count - 1

            tabNames = appendString(tabNames, tabCtl.TabPages(i).Name, DL)
            colTabs.Add(tabCtl.TabPages(i), tabCtl.TabPages(i).Name)

        Next

        For i = tabCtl.Controls.Count - 1 To 0 Step -1
            tabCtl.Controls.Remove(tabCtl.TabPages(i))
        Next

        removeAllTabs = tabNames

    End Function
    Public Sub restoreTabs(ByVal tabCtl As TabControl, ByVal tabNames As String)

        Dim tabNameList As New myList

        tabNameList.setList(tabNames)

        For i = 0 To tabNameList.length(DL) - 1
            tabCtl.Controls.Add(colTabs(tabNameList.getItem(i, DL)))
            colTabs.Remove(tabNameList.getItem(i, DL))
        Next

    End Sub
End Class