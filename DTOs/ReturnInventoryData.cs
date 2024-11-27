using WarrantGenerator.Constants;
using WarrantGenerator.Interfaces;
using WarrantGenerator.ViewModels;

using System.Diagnostics;


namespace WarrantGenerator.DTOs;

public class ReturnInventoryData(ReturnInventoryContentViewModel model) : IReturnInventoryData
{
    public string OutputFile => _outputFile;
    public string OfficerName => _officerName;
    public string OfficerRank => _officerRank;
    public string OfficerSubjectivePronoun => _officerSubjectivePronoun;
    public string OfficerPosessivePronoun => _officerPosessivePronoun;
    public string CourtDistrict => _courtDistrict;
    public string WarrantSignedBy => _warrantSignedBy;
    public string SeizableProperty => _seizableProperty;
    public string SignedDate => _signedDate;
    public string ServedDate => _servedDate;
    public string SeizedProperty => _seizedProperty;
    public string TodaysDate => _todaysDate;
    public bool GenerateReturnAndRequestDocument => _generateReturnAndRequestDocument;
    public bool GenerateInventoryDocument => _generateInventoryDocument;
    public bool GenerateOrderDocument => _generateOrderDocument;

    private readonly string _outputFile = FormattedContent.ValidFileName(model.OutputFileNameText);
    private readonly string _officerName = model.OfficerNameText;
    private readonly string _officerRank = FormattedContent.GetOfficerRank(model);
    private readonly string _officerSubjectivePronoun = FormattedContent.SubjectivePronoun(model.OfficerGenderSelection);
    private readonly string _officerPosessivePronoun = FormattedContent.PosessivePronoun(model.OfficerGenderSelection);
    private readonly string _courtDistrict = model.CourtDistrictSelection;
    private readonly string _warrantSignedBy = model.WarrantSignedByText;
    private readonly string _seizableProperty = model.SeizablePropertyText;
    private readonly string _signedDate = FormattedContent.FormattedDateString(model.SignedDateSelection
        ?? throw new UnreachableException("model.SignedDateSelection was null."));
    private readonly string _servedDate = FormattedContent.FormattedDateString(model.ServedDateSelection
        ?? throw new UnreachableException("model.ServedDateSelection was null."));
    private readonly string _seizedProperty = model.SeizedPropertyText;
    private readonly string _todaysDate = FormattedContent.FormattedDateString();
    private readonly bool _generateReturnAndRequestDocument = model.ReturnAndRequestChecked;
    private readonly bool _generateInventoryDocument = model.InventoryChecked;
    private readonly bool _generateOrderDocument = model.OrderChecked;

}
