Imports System

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub bootstrapGridView_CellEditorInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.Bootstrap.BootstrapGridViewEditorEventArgs)
        If (bootstrapGridView.IsEditing AndAlso Not bootstrapGridView.IsNewRowEditing) AndAlso e.Column.FieldName.Equals("ID") Then
            e.Editor.ReadOnly = True
        End If
    End Sub

    Protected Sub SetColumnVisible(ByVal columnName As String)
        bootstrapGridView.Columns(columnName).Visible = If(bootstrapGridView.Columns(columnName).Visible, False, True)
        bootstrapGridView.JSProperties("cpIs" & columnName & "Visible") = bootstrapGridView.Columns(columnName).Visible
    End Sub

    Protected Sub bootstrapGridView_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs)
        bootstrapGridView.JSProperties("cpCallbackAction") = e.Parameters

        Select Case e.Parameters
            Case "FilterRow"
                    bootstrapGridView.Settings.ShowFilterRow = If(bootstrapGridView.Settings.ShowFilterRow, False, True)
                    bootstrapGridView.JSProperties("cpIsFilterRowVisible") = bootstrapGridView.Settings.ShowFilterRow
            Case "SearchPanel"
                    bootstrapGridView.SettingsSearchPanel.Visible = If(bootstrapGridView.SettingsSearchPanel.Visible, False, True)
                    bootstrapGridView.JSProperties("cpIsSearchPanelVisible") = bootstrapGridView.SettingsSearchPanel.Visible
            Case "GroupPanel"
                    bootstrapGridView.Settings.ShowGroupPanel = If(bootstrapGridView.Settings.ShowGroupPanel, False, True)
                    bootstrapGridView.JSProperties("cpIsGroupPanelVisible") = bootstrapGridView.Settings.ShowGroupPanel
            Case "ID"
                SetColumnVisible("ID")
            Case "Name"
                SetColumnVisible("Name")
            Case "Type"
                SetColumnVisible("Type")
        End Select
    End Sub
End Class