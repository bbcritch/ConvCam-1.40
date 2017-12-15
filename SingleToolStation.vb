Public Class SingleToolStation

    Private strToolID As String
    Private bDeepStation As Boolean
    Private bLongTool As Boolean
    Private nColumnNumber As Integer
    Private nToolStation As Integer

    Public Property ToolStation() As Integer
        Get
            ToolStation = nToolStation
        End Get
        Set(ByVal value As Integer)
            nToolStation = value
        End Set
    End Property
    Public Property ColumnNumber() As Integer
        Get
            ColumnNumber = nColumnNumber
        End Get
        Set(ByVal value As Integer)
            nColumnNumber = value
        End Set
    End Property
    Public Property LongTool() As Boolean

        Get
            LongTool = bLongTool
        End Get
        Set(ByVal value As Boolean)
            bLongTool = value
        End Set
    End Property
    Public Property DeepStation() As Boolean
        Get
            Return bDeepStation
        End Get
        Set(ByVal value As Boolean)
            bDeepStation = value
        End Set
    End Property ' Depth
    Public Property ToolID() As String
        Get
            Return strToolID
        End Get
        Set(ByVal value As String)
            strToolID = value
        End Set
    End Property
    Public Sub copy(ByVal s As SingleToolStation)

        Me.ToolID = s.ToolID
        Me.LongTool = s.LongTool

    End Sub

End Class
