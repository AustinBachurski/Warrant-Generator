namespace WarrantGenerator.Interfaces;

public interface IReturnInventoryData
{
    public string CourtDistrict { get; }
    public string OutputFile { get; }
    public string OfficerName { get; }
    public string OfficerPosessivePronoun { get; }
    public string OfficerRank { get; }
    public string OfficerSubjectivePronoun { get; }
    public string SeizableProperty { get; }
    public string SeizedProperty { get; }
    public string ServedDate { get; }
    public string SignedDate { get; }
    public string TodaysDate { get; }
    public string WarrantSignedBy { get; }

    public bool GenerateInventoryDocument { get; }
    public bool GenerateOrderDocument { get; }
    public bool GenerateReturnAndRequestDocument { get; }

}

