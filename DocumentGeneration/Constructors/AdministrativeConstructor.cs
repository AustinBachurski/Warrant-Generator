using WarrantGenerator.Constants;
using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(AdministrativeContentViewModel model)
    {
        GenerateDocument = AdministrativeDocument;

        _outputPath += (ValidFileName(model.OutputFileNameText) + Extension.Docx);
        _officerName = model.OfficerNameText;
        _reportNumber = model.ReportNumberText;
        _pawnBrokerName = model.PawnBrokerNameText;
        _pawnBrokerAddress = model.PawnBrokerAddressText;
        _suspectName = model.SuspectNameText;
        _itemsPawned = model.ItemsPawnedText;
    }
}

