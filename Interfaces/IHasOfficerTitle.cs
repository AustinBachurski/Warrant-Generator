namespace WarrantGenerator.Interfaces;

public interface IHasOfficerTitle
{
    public string CustomOfficerTitleText { get; }
    public string OfficerTitleSelection { get; }
    public bool CustomOfficerTitleVisibility { get; }
}
