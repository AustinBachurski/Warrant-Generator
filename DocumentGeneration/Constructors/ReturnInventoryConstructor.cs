using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(ReturnInventoryContentViewModel model)
    {
        GenerateDocument = ReturnInventoryDocument;
    }
}

