using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(StructureContentViewModel model)
    {
        GenerateDocument = StructureDocument;
    }
}

