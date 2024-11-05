using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.ObjectModel;
using System.Text;
using WarrantGenerator.DTOs;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public delegate string DocumentDelegate();
    public DocumentDelegate GenerateDocument;

    private Body _body = new();

    private string _outputPath = Environment.GetEnvironmentVariable("DOCUMENT_OUTPUT_PATH") ?? "./";
    private string _nthDayOfMonth = FormattedDateString();
    private string _officerName = string.Empty;
    private string _reportNumber = string.Empty;
    private string _pawnBrokerName = string.Empty;
    private string _pawnBrokerAddress = string.Empty;
    private string _suspectName = string.Empty;
    private string _itemsPawned = string.Empty;

    
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
    
    private static string GetOfficerTitle(StructureContentViewModel viewModel)
    {
        if (viewModel.CustomOfficerTitleVisibility)
        {
            return viewModel.CustomOfficerTitleText;
        }
        return viewModel.OfficerTitleSelection;
    }

   private static string CorrectGrammar(char c)
    {
        return char.ToUpper(c) switch
        {
            'A' or 'E' or 'I' or 'O' or 'U' => "an",
            _ => "a",
        };
    }

    private static string CrimesAsString(ObservableCollection<MCACrime> crimesList)
    {
        StringBuilder builder = new();

        const string prefix = "M.C.A. § ";
        const string space = " (";
        const string suffix = "), ";
        int contentLength = prefix.Length + space.Length + suffix.Length;

        foreach (MCACrime each in crimesList)
        {
            builder.Append(prefix);
            builder.Append(each.Code);
            builder.Append(space);
            builder.Append(each.Description);
            builder.Append(suffix);
        }

        if (crimesList.Count > 1)
        {
            builder.Insert(StartingPositionOfLastEntry(builder, contentLength, crimesList), "and ");
        }

        // Trailing ", " is intentional.
        return builder.ToString();
    }

    private static int StartingPositionOfLastEntry(StringBuilder builder, int contentLength, ObservableCollection<MCACrime> crimesList)
    {
        contentLength += crimesList.Last().Code.Length;
        contentLength += crimesList.Last().Description.Length;

        return builder.Length - contentLength;
    }
    private void InsertWarrantBoilerplate(string district)
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

    private static string FormattedDateString()
    {
        var now = DateTime.Now;
        return $"{now.Day}{GetDayOrdinal(now)} day of {now:MMMM, yyyy}";
    }

    private static string GetDayOrdinal(DateTime date)
    {
        return date.Day switch
        {
            11 or 12 or 13 => "th",
            _ => (date.Day % 10) switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th",
            },
        };
    }
}
