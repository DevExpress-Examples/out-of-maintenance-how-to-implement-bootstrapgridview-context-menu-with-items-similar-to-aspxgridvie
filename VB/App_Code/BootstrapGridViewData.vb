Imports System.Collections.Generic
Imports System.Web

''' <summary>
''' Summary description for BootstrapGridViewData
''' </summary>
Public Class BootstrapGridViewData
    Public ReadOnly Property Items() As List(Of BootstrapGridViewDataItem)
        Get
            Dim context As HttpContext = HttpContext.Current

            If context.Session("Items") Is Nothing Then

                Dim items_Renamed As New List(Of BootstrapGridViewDataItem)()

                items_Renamed.Add(New BootstrapGridViewDataItem(1, "First", "FirstType"))
                context.Session("Items") = items_Renamed
            End If

            Return DirectCast(context.Session("Items"), List(Of BootstrapGridViewDataItem))
        End Get
    End Property

    Public Function [Select]() As List(Of BootstrapGridViewDataItem)
        Return Items
    End Function

    Public Sub Insert(ByVal id As Integer, ByVal name As String, ByVal type As String)
        If Items.FindIndex(Function(item) item.ID = id) = -1 Then
            Items.Add(New BootstrapGridViewDataItem(id, name, type))
        End If
    End Sub

    Public Sub Update(ByVal id As Integer, ByVal name As String, ByVal type As String, ByVal old_id As Integer)
        Dim itemIndex As Integer = Items.FindIndex(Function(item) item.ID = id)

        If itemIndex <> -1 Then
            Items(itemIndex).Name = name
            Items(itemIndex).Type = type
        End If
    End Sub

    Public Sub Delete(ByVal old_id As Integer)
        Dim itemIndex As Integer = Items.FindIndex(Function(item) item.ID = old_id)

        If itemIndex <> -1 Then
            Items.RemoveAt(itemIndex)
        End If
    End Sub
End Class