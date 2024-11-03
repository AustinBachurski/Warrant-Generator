using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(AdministrativeContentViewModel model)
    {
        GenerateDocument = AdministrativeDocument;

        _outputPath += model.OutputFileNameText;
    }
}

