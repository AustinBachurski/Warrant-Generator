using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using WarrantGenerator.DTOs;

namespace WarrantGenerator.DocumentGeneration;

public class DocumentGenerator(string fileName)
{
    private Body _body = new();
    private readonly string _outputFile = $"C:/Temp/{ValidFileName(fileName)}.docx";

    public string GenerateDocument(DataEntryObject data)
    {
        using var newDocument = WordprocessingDocument.Create(
            _outputFile, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);

        var document = newDocument.AddMainDocumentPart();
        document.Document = new Document();
        SetDocumentFormatting(document);

        InsertBoilerplate(data.District);

        // Data insertion.


        document.Document.Append(_body);
        document.Document.Save();
        return _outputFile;
    }

    private static string ValidFileName(string fileName)
    {
        const string docxExtension = ".docx";
        const string docExtension = ".doc";

        if (fileName.EndsWith(docxExtension))
        {
            return fileName.Remove(fileName.Length - docxExtension.Length).Trim();
        }
        else if (fileName.EndsWith(docExtension))
        {
            return fileName.Remove(fileName.Length - docxExtension.Length).Trim();
        }

        return fileName;
    }

    private void AppendFormattedLine(string line)
    {
        var paragraph = new Paragraph();
        var run = new Run();

        foreach (var content in line.Split('\t'))
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                run.Append(new TabChar());
            }
            else
            {
                run.Append(new Text(content));
            }
        }

        paragraph.Append(run);
        _body.Append(paragraph);
    }
    
    private void InsertBoilerplate(string district)
    {
        var boilerplate = new[]
        {
            $"IN THE {district}, COUNTY OF FLATHEAD, STATE OF MONTANA",
            "STATE OF MONTANA\t\t\t\t\t\t)",
            "\t\t\tPlaintiff,\t\t\t\t)",
            "\t\t\t\t-vs-\t\t\t\t\t)\t\tAPPLICATION FOR",
            "\t\t\tDefendant,\t\t\t\t)\t\tSEARCH WARRANT",
            "",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private void SetDocumentFormatting(MainDocumentPart document)
    {
        var paragraphProperties = new ParagraphProperties();
        paragraphProperties.Append(new Justification() { Val = JustificationValues.Both });

        var runProperties = new RunProperties();
        runProperties.Append(new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" });
        runProperties.Append(new FontSize() { Val = "24" });  // Val / 2 == font size.

        var documentStyle = document.AddNewPart<StyleDefinitionsPart>();
        documentStyle.Styles = new Styles();

        var defaultStyle = new Style()
        {
            Type = StyleValues.Paragraph,
            StyleId = "Normal",
            Default = true,
            StyleName = new StyleName() { Val = "Normal" },
        };

        defaultStyle.Append(paragraphProperties);
        defaultStyle.Append(new StyleRunProperties(runProperties));
        documentStyle.Styles.Append(defaultStyle);
    }
}
