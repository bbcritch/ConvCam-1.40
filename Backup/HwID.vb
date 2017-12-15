Imports System.Management
Module HwID
    Public Function getID() As String
        Dim objMOS As ManagementObjectSearcher
        Dim objMOC As Management.ManagementObjectCollection
        Dim objMO As Management.ManagementObject

        objMOS = New ManagementObjectSearcher("Select * From Win32_Processor")
        objMOC = objMOS.Get

        For Each objMO In objMOC

            MessageBox.Show("CPU ID = " & objMO("ProcessorID"))

        Next

        getID = ""

        objMOS.Dispose()
        objMOS = Nothing
        objMO.Dispose()
        objMO = Nothing

    End Function
End Module
