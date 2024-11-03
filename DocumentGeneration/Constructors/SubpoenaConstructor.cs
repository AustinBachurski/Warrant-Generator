using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(SubpoenaContentViewModel model)
    {
        GenerateDocument = SubpoenaDocument;
    }
}

