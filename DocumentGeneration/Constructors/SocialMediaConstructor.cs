using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(SocialMediaContentViewModel model)
    {
        GenerateDocument = SocialMediaDocument;
    }
}

