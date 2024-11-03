using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(DnaContentViewModel model)
    {
        GenerateDocument = DnaDocument;
    }
}

