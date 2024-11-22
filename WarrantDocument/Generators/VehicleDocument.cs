using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private string VehicleDocument()
    {
        using var newDocument = WordprocessingDocument.Create(_outputPath, WordprocessingDocumentType.Document);

        _document = newDocument.AddMainDocumentPart();
        _document.Document = new Document();
        InitializeDocument();


        // Data insertion.


        _document.Document.Append(_body);
        _document.Document.Save();
        return _outputPath;
    }

}

