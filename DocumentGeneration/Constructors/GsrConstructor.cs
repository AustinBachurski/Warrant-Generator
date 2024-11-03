using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(GsrContentViewModel model)
    {
        GenerateDocument = GsrDocument;
    }
}

