namespace WarrantGenerator.Interfaces;

public interface IHasOfficerRank
{
    public string CustomOfficerRankText { get; }
    public string OfficerRankSelection { get; }
    public bool CustomOfficerRankVisibility { get; }
}

