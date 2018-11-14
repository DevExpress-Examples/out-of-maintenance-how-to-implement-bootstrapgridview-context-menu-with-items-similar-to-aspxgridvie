var itemIndex;
var gridViewElementsVisibility = {
    FilterRow: false,
    SearchPanel: false,
    GroupPanel: false,
    ID: true,
    Name: true,
    Type: true
}

function setMenuElementEnabled(menuElementName, isMenuElemenVisibleName) {
    gridViewElementsVisibility[menuElementName] = bootstrapGridView[isMenuElemenVisibleName]
    bootstrapGridView[isMenuElemenVisibleName] = null;
}

function onBootstrapGridViewEndCallback(s, e) {
    setMenuElementEnabled(s["cpCallbackAction"], "cpIs" + s["cpCallbackAction"] + "Visible");
    s["cpCallbackAction"] = null;
}

function setMenuItemText(menuItemName) {
    var menuItem = bootstrapPopupMenu.GetItemByName(menuItemName);

    if (gridViewElementsVisibility[menuItemName])
        menuItem.SetText("Hide " + menuItemName);
    else
        menuItem.SetText("Show " + menuItemName);
}

function onGridInit(s, e) {
    s.GetMainElement().addEventListener("contextmenu", function (evt) {
        var $sourceElement = $(ASPxClientUtils.GetEventSource(evt));

        ASPxClientUtils.PreventEvent(evt);
        updateMenuItem = bootstrapPopupMenu.GetItemByName("Update");
        updateMenuItem.SetText("Edit");
        deleteMenuItem = bootstrapPopupMenu.GetItemByName("Delete");
        deleteMenuItem.SetText("Remove");

        var $gridRow = $sourceElement.parents(".grid-row");

        if ($gridRow.length) {
            itemIndex = s.GetPageIndex() * s.pageRowSize + $gridRow.index();
            var rowKey = s.GetRowKey(itemIndex);
            updateMenuItem.SetText(updateMenuItem.GetText() + " " + rowKey);
            deleteMenuItem.SetText(deleteMenuItem.GetText() + " " + rowKey);
            updateMenuItem.SetEnabled(true);
            deleteMenuItem.SetEnabled(true);
        }
        else {
            updateMenuItem.SetEnabled(false);
            deleteMenuItem.SetEnabled(false);
        }

        for (var i = 3; i < bootstrapPopupMenu.GetItemCount(); i++)
            setMenuItemText(bootstrapPopupMenu.GetItem(i).name);

        bootstrapPopupMenu.ShowAtPos(evt.clientX, evt.clientY);
    });
}

function onBootstrapPopupMenuClick(s, e) {
    var itemName = e.item.name;

    switch (itemName) {
        case "Insert":
            bootstrapGridView.AddNewRow();
            break;
        case "Update":
            bootstrapGridView.StartEditRow(itemIndex);
            break;
        case "Delete":
            bootstrapGridView.DeleteRow(itemIndex);
            break;
        default:
            bootstrapGridView.PerformCallback(itemName);
            break;
    }
}