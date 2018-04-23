using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for BootstrapGridViewData
/// </summary>
public class BootstrapGridViewData
{
    public List<BootstrapGridViewDataItem> Items
    {
        get
        {
            HttpContext context = HttpContext.Current;

            if (context.Session["Items"] == null)
            {
                List<BootstrapGridViewDataItem> items = new List<BootstrapGridViewDataItem>();

                items.Add(new BootstrapGridViewDataItem(1, "First", "FirstType"));
                context.Session["Items"] = items;
            }

            return (List<BootstrapGridViewDataItem>)context.Session["Items"];
        }
    }

    public List<BootstrapGridViewDataItem> Select()
    {
        return Items;
    }

    public void Insert(int id, string name, string type)
    {
        if (Items.FindIndex(item => item.ID == id) == -1)
            Items.Add(new BootstrapGridViewDataItem(id, name, type));
    }

    public void Update(int id, string name, string type, int old_id)
    {
        int itemIndex = Items.FindIndex(item => item.ID == id);

        if (itemIndex != -1)
        {
            Items[itemIndex].Name = name;
            Items[itemIndex].Type = type;
        }
    }

    public void Delete(int old_id)
    {
        int itemIndex = Items.FindIndex(item => item.ID == old_id);

        if (itemIndex != -1)
            Items.RemoveAt(itemIndex);
    }
}