using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(AppOrderContentViewModel model)
    {
        GenerateDocument = AppOrderDocument;
    }
}

