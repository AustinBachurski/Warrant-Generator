using System.Collections.ObjectModel;

namespace WarrantGenerator.DTOs;

public class MCATreeNode
{
    public string? Prefix { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public bool IsChecked { get; set; } = false;
    public ObservableCollection<MCATreeNode>? Children { get; set; }
    public bool HasChildren => Children != null && Children.Count > 0;

    public MCATreeNode(string code, string description)
    {
        Prefix = null;
        Code = code;
        Description = description;
        Children = null;
    }

    public MCATreeNode(string prefix, string code, string description)
    {
        Prefix = prefix;
        Code = code;
        Description = description;
        Children = new();
    }
}
