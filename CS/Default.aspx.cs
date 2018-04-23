using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void bootstrapGridView_CellEditorInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewEditorEventArgs e)
    {
        if ((bootstrapGridView.IsEditing && !bootstrapGridView.IsNewRowEditing) && e.Column.FieldName.Equals("ID"))
            e.Editor.ReadOnly = true;
    }

    protected void SetColumnVisible(string columnName)
    {
        bootstrapGridView.Columns[columnName].Visible = bootstrapGridView.Columns[columnName].Visible ? false : true;
        bootstrapGridView.JSProperties["cpIs" + columnName + "Visible"] = bootstrapGridView.Columns[columnName].Visible;
    }

    protected void bootstrapGridView_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        bootstrapGridView.JSProperties["cpCallbackAction"] = e.Parameters;

        switch (e.Parameters)
        {
            case "FilterRow":
                {
                    bootstrapGridView.Settings.ShowFilterRow = bootstrapGridView.Settings.ShowFilterRow ? false : true;
                    bootstrapGridView.JSProperties["cpIsFilterRowVisible"] = bootstrapGridView.Settings.ShowFilterRow;
                }
                break;
            case "SearchPanel":
                {
                    bootstrapGridView.SettingsSearchPanel.Visible = bootstrapGridView.SettingsSearchPanel.Visible ? false : true;
                    bootstrapGridView.JSProperties["cpIsSearchPanelVisible"] = bootstrapGridView.SettingsSearchPanel.Visible;
                }
                break;
            case "GroupPanel":
                {
                    bootstrapGridView.Settings.ShowGroupPanel = bootstrapGridView.Settings.ShowGroupPanel ? false : true;
                    bootstrapGridView.JSProperties["cpIsGroupPanelVisible"] = bootstrapGridView.Settings.ShowGroupPanel;
                }
                break;
            case "ID":
                SetColumnVisible("ID");
                break;
            case "Name":
                SetColumnVisible("Name");
                break;
            case "Type":
                SetColumnVisible("Type");
                break;
        }
    }
}