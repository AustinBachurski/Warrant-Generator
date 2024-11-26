namespace WarrantGenerator.Interfaces;

public interface IReturnInventoryData
{
    public string OutputFile { get; }
    public string OfficerName { get; }
    public string OfficerRank { get; }
    public string OfficerSubjectivePronoun { get; }
    public string OfficerPosessivePronoun { get; }
    public string CourtDistrict { get; }
    public string WarrantSignedBy { get; }
    public string SeizableProperty { get; }
    public string SignedDate { get; }
    public string ServedDate { get; }
    public string SeizedProperty { get; }
    public string TodaysDate { get; }
    public bool GenerateReturnAndRequestDocument { get; }
    public bool GenerateInventoryDocument { get; }
    public bool GenerateOrderDocument { get; }
}
