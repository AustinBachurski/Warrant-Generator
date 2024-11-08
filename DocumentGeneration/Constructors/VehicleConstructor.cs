using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(VehicleContentViewModel model)
    {
        GenerateDocument = VehicleDocument;
    }
}

