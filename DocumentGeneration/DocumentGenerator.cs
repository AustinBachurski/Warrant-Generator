using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.ObjectModel;
using System.Text;
using WarrantGenerator.DTOs;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public delegate string DocumentDelegate();
    public DocumentDelegate GenerateDocument;

    private Body _body = new();

    private string _outputPath = Environment.GetEnvironmentVariable("DOCUMENT_OUTPUT_PATH") ?? "./";
    private string _nthDayOfMonthYear = FormattedDateString();
    private string _officerName = string.Empty;
    private string _officerTitle = string.Empty;
    private string _organization = string.Empty;
    private string _courtDistrict = string.Empty;
    private string _reportNumber = string.Empty;
    private string _pawnBrokerName = string.Empty;
    private string _pawnBrokerAddress = string.Empty;
    private string _suspectName = string.Empty;
    private string _itemsPawned = string.Empty;
    private string _warrantSignedBy = string.Empty;
    private string _searchableProperty = string.Empty;
    private string _signedDate = string.Empty;
    private string _servedDate = string.Empty;
    private string _seizedProperty = string.Empty;
    private bool _generateReturnAndRequestDocument = false;
    private bool _generateInventoryDocument = false;
    private bool _generateOrderDocument = false;


    
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

    private void AppendMultilineText(string text)
    {
        foreach (var content in text.Split(Environment.NewLine))
        {
            var paragraph = new Paragraph();
            var run = new Run();

            run.Append(new Text(content));
            paragraph.Append(run);
            _body.Append(paragraph);
        }
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

    private void AppendEmptyLine()
    {
        var paragraph = new Paragraph();
        _body.Append(paragraph);
    }

    private void AppendText(string text)
    {
        var paragraph = new Paragraph();
        var run = new Run();
        run.Append(new Text(text));

        paragraph.Append(run);
        _body.Append(paragraph);
    }

    private void AppendIndentedText(string text)
    {
        var paragraph = new Paragraph();
        var run = new Run();
        run.Append(new TabChar());
        run.Append(new Text(text));

        paragraph.Append(run);
        _body.Append(paragraph);
    }

    private void AppendCenteredText(string text)
    {
        var paragraph = new Paragraph();
        var run = new Run();

        var alignment = new ParagraphProperties();
        alignment.Justification = new Justification() { Val = JustificationValues.Center };
        paragraph.ParagraphProperties = alignment;

        run.Append(new Text(text));
        paragraph.Append(run);
        _body.Append(paragraph);
    }

    private void AppendBoldCenteredText(string text)
    {
        var paragraph = new Paragraph();
        var run = new Run();

        var alignment = new ParagraphProperties();
        alignment.Justification = new Justification() { Val = JustificationValues.Center };
        paragraph.ParagraphProperties = alignment;

        var format = new RunProperties();
        format.Bold = new Bold();
        run.RunProperties = format;

        run.Append(new Text(text));
        paragraph.Append(run);
        _body.Append(paragraph);
    }

    private static string GetOfficerTitle(IHasOfficerTitle model)
    {
        if (model.CustomOfficerTitleVisibility)
        {
            return model.CustomOfficerTitleText;
        }

        return model.OfficerTitleSelection;
    }

   private static string CorrectGrammar(char c)
    {
        return char.ToUpper(c) switch
        {
            'A' or 'E' or 'I' or 'O' or 'U' => "an",
            _ => "a",
        };
    }

    /*
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
    */


    private void StateOfMontanaCountyOfFlathead()
    {
        var boilerplate = new[]
        {
            "STATE OF MONTANA\t)",
            "\t\t\t\t:ss",
            "COUNTY OF FLATHEAD\t)",
            "",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private void InsertReturnBoilerplate()
    {
        var boilerplate = new[]
        {
            $"IN THE {_courtDistrict}, COUNTY OF FLATHEAD, STATE OF MONTANA",
            "STATE OF MONTANA\t\t\t\t\t\t)",
            "\t\t\tPlaintiff,\t\t\t\t)",
            "\t\t\t\t-vs-\t\t\t\t\t)\t\tRETURN OF WARRANT",
            "\t\t\tDefendant,\t\t\t\t)\t\tAND INVENTORY",
            "",
            "STATE OF MONTANA\t)",
            "\t\t\t\t:ss",
            "COUNTY OF FLATHEAD\t)",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private void InsertInventoryBoilerplate()
    {
        var boilerplate = new[]
        {
            $"IN THE {_courtDistrict}, COUNTY OF FLATHEAD, STATE OF MONTANA",
            "STATE OF MONTANA\t\t\t\t\t\t)",
            "\t\t\tPlaintiff,\t\t\t\t)",
            "\t\t\t\t-vs-\t\t\t\t\t)\t\tINVENTORY",
            "\t\t\tDefendant,\t\t\t\t)\t\t",
            "",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private void InsertOrderBoilerplate()
    {
        var boilerplate = new[]
        {
            $"IN THE {_courtDistrict}, COUNTY OF FLATHEAD, STATE OF MONTANA",
            "STATE OF MONTANA\t\t\t\t\t\t)",
            "\t\t\tPlaintiff,\t\t\t\t)",
            "\t\t\t\t-vs-\t\t\t\t\t)\t\tORDER FOR CUSTODY",
            "\t\t\tDefendant,\t\t\t\t)\t\t",
            "",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private void InsertWarrantBoilerplate()
    {
        var boilerplate = new[]
        {
            $"IN THE {_courtDistrict}, COUNTY OF FLATHEAD, STATE OF MONTANA",
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

    private static void SetDocumentFormatting(MainDocumentPart document)
    {
        var paragraphProperties = new ParagraphProperties();
        paragraphProperties.Append(new Justification() { Val = JustificationValues.Both });
        paragraphProperties.SpacingBetweenLines = new SpacingBetweenLines
        {
            Line = "360",  // "Auto" line is interpreted as 240th's of a line.  240 * 1.5 spacing == 360
            LineRule = LineSpacingRuleValues.Auto,
        };

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
        DateTimeOffset now = DateTime.Now;
        return $"{now.Day}{GetDayOrdinal(now)} day of {now:MMMM, yyyy}";
    }

    private static string FormattedDateString(DateTimeOffset date)
    {
        return $"{date.Day}{GetDayOrdinal(date)} day of {date:MMMM, yyyy}";
    }

    private static string GetDayOrdinal(DateTimeOffset date)
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
