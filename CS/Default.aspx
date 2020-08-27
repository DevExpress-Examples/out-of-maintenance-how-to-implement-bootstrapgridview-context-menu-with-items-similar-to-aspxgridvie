<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to implement BootstrapGridView context menu with items similar to ASPxGridView</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript" src="Content/Script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:ObjectDataSource ID="objectDataSource" runat="server" OldValuesParameterFormatString="old_{0}" TypeName="BootstrapGridViewData" SelectMethod="Select" InsertMethod="Insert"
                UpdateMethod="Update" DeleteMethod="Delete" />
            <div class="container">
                <dx:BootstrapGridView ID="bootstrapGridView" runat="server" ClientInstanceName="bootstrapGridView" DataSourceID="objectDataSource" KeyFieldName="ID"
                    OnCellEditorInitialize="bootstrapGridView_CellEditorInitialize" OnCustomCallback="bootstrapGridView_CustomCallback">
                    <ClientSideEvents EndCallback="onBootstrapGridViewEndCallback" Init="onGridInit" />
                    <CssClasses Row="grid-row" />
                    <Columns>
                        <dx:BootstrapGridViewTextColumn FieldName="ID">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewDataColumn FieldName="Name" />
                        <dx:BootstrapGridViewDataColumn FieldName="Type" />
                    </Columns>
                    <SettingsDataSecurity AllowInsert="true" AllowEdit="true" AllowDelete="true" />
                </dx:BootstrapGridView>
            </div>
            <dx:BootstrapPopupMenu ID="bootstrapPopupMenu" runat="server" ClientInstanceName="bootstrapPopupMenu">
                <ClientSideEvents ItemClick="onBootstrapPopupMenuClick" />
                <Items>
                    <dx:BootstrapMenuItem Text="Add" IconCssClass="glyphicon glyphicon-plus" Name="Insert" />
                    <dx:BootstrapMenuItem Name="Update" IconCssClass="glyphicon glyphicon-refresh" />
                    <dx:BootstrapMenuItem Name="Delete" IconCssClass="glyphicon glyphicon-remove" />
                    <dx:BootstrapMenuItem Name="FilterRow" IconCssClass="glyphicon glyphicon-filter" />
                    <dx:BootstrapMenuItem Name="SearchPanel" IconCssClass="glyphicon glyphicon-search" />
                    <dx:BootstrapMenuItem Name="GroupPanel" IconCssClass="glyphicon glyphicon-compressed" />
                    <dx:BootstrapMenuItem Name="ID" />
                    <dx:BootstrapMenuItem Name="Name" />
                    <dx:BootstrapMenuItem Name="Type" />
                </Items>
            </dx:BootstrapPopupMenu>
        </div>
    </form>
</body>
</html>
