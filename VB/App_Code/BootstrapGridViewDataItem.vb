''' <summary>
''' Summary description for BootstrapGridViewDataItem
''' </summary>
Public Class BootstrapGridViewDataItem
    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal type As String)
        Me.ID = id
        Me.Name = name
        Me.Type = type
    End Sub

    Public Property ID() As Integer

    Public Property Name() As String

    Public Property Type() As String
End Class