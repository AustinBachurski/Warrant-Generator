using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private static LineNumberType LineNumbers()
    {
        var lineNumberType = new LineNumberType
        {
            CountBy = 1,
            Start = 0,
            Distance = "720",  // Distance from text in twips
            Restart = LineNumberRestartValues.NewPage, // Restart numbering on each new page
        };

        return lineNumberType;
    }

    private static ParagraphProperties SetParagraphProperties()
    {
        var paragraphProperties = new ParagraphProperties();
        paragraphProperties.Append(new Justification() { Val = JustificationValues.Both });
        paragraphProperties.SpacingBetweenLines = new SpacingBetweenLines
        {
            Before = "0",
            After = "0",
            Line = "455",  // With "Exact" LineRule, Line is set in "twips", 1 "twip" == 1/20th of a point.
            LineRule = LineSpacingRuleValues.Exact,
        };

        return paragraphProperties;
    }

    private static StyleRunProperties SetRunProperties()
    {
        var runProperties = new RunProperties();
        runProperties.Append(new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" });
        runProperties.Append(new FontSize() { Val = "24" });  // Val / 2 == font size.

        return new StyleRunProperties(runProperties);
    }

    private static Footer SetFooterProperties()
    {
        var footer = new Footer();
        var paragraph = new Paragraph(new Run(new FieldChar() { FieldCharType = FieldCharValues.Begin }));

        var alignment = new ParagraphProperties
        {
            Justification = new Justification() { Val = JustificationValues.Center }
        };

        paragraph.ParagraphProperties = alignment;

        var pageNumberRun = new Run(new FieldCode(" PAGE "));
        paragraph.Append(pageNumberRun);

        paragraph.Append(new Run(new FieldChar() { FieldCharType = FieldCharValues.Separate }));
        paragraph.Append(new Run(new FieldChar() { FieldCharType = FieldCharValues.End }));
        footer.Append(paragraph);

        return footer;
    }

    private void SetDocumentFormatting(MainDocumentPart document)
    {

        var documentStyle = document.AddNewPart<StyleDefinitionsPart>();
        documentStyle.Styles = new Styles();

        var defaultStyle = new Style()
        {
            Type = StyleValues.Paragraph,
            StyleId = "Normal",
            Default = true,
            StyleName = new StyleName() { Val = "Normal" },
        };

        defaultStyle.Append(SetParagraphProperties());
        defaultStyle.Append(SetRunProperties());
        documentStyle.Styles.Append(defaultStyle);

        // Create footer content with page numbers
        var footerPart = document.AddNewPart<FooterPart>();

        footerPart.Footer = SetFooterProperties();
        footerPart.Footer.Save();

        var footerReference = new FooterReference
        {
            Type = HeaderFooterValues.Default,
            Id = document.GetIdOfPart(footerPart),
        };

        var sectionProperties = new SectionProperties();
        sectionProperties.Append(footerReference);
        sectionProperties.Append(LineNumbers());

        _body.Append(sectionProperties);
    }
}

