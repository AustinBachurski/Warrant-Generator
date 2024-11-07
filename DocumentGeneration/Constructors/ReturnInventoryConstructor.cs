using System.Diagnostics;
using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(ReturnInventoryContentViewModel model)
    {
        GenerateDocument = ReturnInventoryDocument;

        _outputPath += (ValidFileName(model.OutputFileNameText));
        _officerName = model.OfficerNameText;
        _officerTitle = GetOfficerTitle(model);
        _courtDistrict = model.CourtDistrictSelection;
        _warrantSignedBy = model.WarrantSignedByText;
        _searchableProperty = model.SearchablePropertyText;
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

