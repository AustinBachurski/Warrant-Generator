using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private string SubpoenaDocument()
    {
        using var newDocument = WordprocessingDocument.Create(_outputPath, WordprocessingDocumentType.Document);

        var document = newDocument.AddMainDocumentPart();
        document.Document = new Document();
        SetDocumentFormatting(document);


        // Data insertion.


        document.Document.Append(_body);
        document.Document.Save();
        return _outputPath;
    }
}

