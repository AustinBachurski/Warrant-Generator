using WarrantGenerator.Constants;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private void AddHyperlinkStyle()
    {
        var hyperlinkStyle = new Style()
        {
            Type = StyleValues.Character,
            StyleId = StyleText.Hyperlink,
            CustomStyle = false,
            StyleName = new StyleName() { Val = StyleText.Hyperlink },
        };

        var styleRunProperties = new StyleRunProperties();
        styleRunProperties.Append(new Color() { Val = StyleText.Blue, ThemeColor = ThemeColorValues.Hyperlink });
        styleRunProperties.Append(new Underline() { Val = UnderlineValues.Single });

        hyperlinkStyle.Append(styleRunProperties);

        _document.StyleDefinitionsPart.Styles.Append(hyperlinkStyle);
    }

    private void AddNormalStyle()
    {
        var styleDefinitions = _document.AddNewPart<StyleDefinitionsPart>();

        styleDefinitions.Styles = new Styles();

        var defaultStyle = new Style()
        {
            Type = StyleValues.Paragraph,
            StyleId = StyleText.Normal,
            Default = true,
            StyleName = new StyleName() { Val = StyleText.Normal },
        };

        var paragraphProperties = new ParagraphProperties();
        paragraphProperties.Append(new Justification() { Val = JustificationValues.Both });
        paragraphProperties.SpacingBetweenLines = new SpacingBetweenLines
        {
            Before = "0",
            After = "0",
            Line = "455",  // With "Exact" LineRule, Line is set in "twips", 1 "twip" == 1/20th of a point.
            LineRule = LineSpacingRuleValues.Exact,
        };
        defaultStyle.Append(paragraphProperties);

        var runProperties = new RunProperties();
        runProperties.Append(new RunFonts() { Ascii = StyleText.CourierNew, HighAnsi = StyleText.CourierNew });
        runProperties.Append(new FontSize() { Val = "24" });  // Val / 2 == font size.
        defaultStyle.Append(runProperties);

        styleDefinitions.Styles.Append(defaultStyle);
    }

    private void InitializeDocument()
    {
        AddNormalStyle();
        AddHyperlinkStyle();
        SetFooterProperties();
    }

    private void SetFooterProperties()
    {
        var footerPart = _document.AddNewPart<FooterPart>();

        var paragraph = new Paragraph(new Run(new FieldChar() { FieldCharType = FieldCharValues.Begin }));

        var alignment = new ParagraphProperties
        {
            Justification = new Justification() { Val = JustificationValues.Center }
        };

        paragraph.ParagraphProperties = alignment;

        paragraph.Append(new Run(new FieldCode(" PAGE ")));
        paragraph.Append(new Run(new FieldChar() { FieldCharType = FieldCharValues.Separate }));
        paragraph.Append(new Run(new FieldChar() { FieldCharType = FieldCharValues.End }));

        footerPart.Footer = new Footer(paragraph);
        footerPart.Footer.Save();

        var sectionProperties = new SectionProperties();

        var footerReference = new FooterReference
        {
            Type = HeaderFooterValues.Default,
            Id = _document.GetIdOfPart(footerPart),
        };
        sectionProperties.Append(footerReference);

        var lineNumberType = new LineNumberType
        {
            CountBy = 1,
            Start = 0,
            Distance = "720",  // Distance from text in twips
            Restart = LineNumberRestartValues.NewPage, // Restart numbering on each new page
        };
        sectionProperties.Append(lineNumberType);

        _body.Append(sectionProperties);
    }

}

