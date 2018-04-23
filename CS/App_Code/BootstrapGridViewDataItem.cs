/// <summary>
/// Summary description for BootstrapGridViewDataItem
/// </summary>
public class BootstrapGridViewDataItem
{
    public BootstrapGridViewDataItem(int id, string name, string type)
    {
        ID = id;
        Name = name;
        Type = type;
    }

    public int ID { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }
}