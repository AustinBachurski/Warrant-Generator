using System.Diagnostics;
using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(ReturnInventoryContentViewModel model)
    {
        GenerateDocument = ReturnInventoryDocument;

        _outputPath += (ValidFileName(model.OutputFileNameText));  // Extension applied in the document generation methods.
        _officerName = model.OfficerNameText;
        _officerRank = GetOfficerRank(model);
        _officerSubjectivePronoun = SubjectivePronoun(model.OfficerGenderSelection);
        _officerPosessivePronoun = PosessivePronoun(model.OfficerGenderSelection);
        _courtDistrict = model.CourtDistrictSelection;
        _warrantSignedBy = model.WarrantSignedByText;
        _seizableProperty = LowercaseStartAndRemoveTrailingPunctuation(model.SeizablePropertyText);
        _signedDate = FormattedDateString(model.SignedDateSelection
            ?? throw new UnreachableException("model.SignedDateSelection was null."));
        _servedDate = FormattedDateString(model.ServedDateSelection
            ?? throw new UnreachableException("model.ServedDateSelection was null."));
        _seizedProperty = model.SeizedPropertyText;
        _generateReturnAndRequestDocument = model.ReturnAndRequestChecked;
        _generateInventoryDocument = model.InventoryChecked;
        _generateOrderDocument = model.OrderChecked;
    }
}

