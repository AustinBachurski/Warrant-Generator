using WarrantGenerator.Constants;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private void AddHyperlinkStyle()
    {
        _document.StyleDefinitionsPart.Styles.Append(
            new Style(
                new StyleRunProperties(
                    new Color()
                    {
                        Val = Doc.Colors.Blue,
                        ThemeColor = ThemeColorValues.Hyperlink
                    },
                    new Underline() { Val = UnderlineValues.Single }
                )
            )
            {
                Type = StyleValues.Character,
                StyleId = Doc.Styles.Hyperlink,
                CustomStyle = false,
                StyleName = new StyleName() { Val = Doc.Styles.Hyperlink },
            }
        );

        _document.StyleDefinitionsPart.Styles.Save();
    }

    private void AddNormalStyle()
    {
        var stylePart = _document.AddNewPart<StyleDefinitionsPart>();

        stylePart.Styles = new Styles(
            new Style(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Both }
                )
                {
                    SpacingBetweenLines = new SpacingBetweenLines()
                    {
                        Before = "0",
                        After = "0",
                        Line = "455",  // With "Exact" LineRule, Line is set in "twips", 1 "twip" == 1/20th of a point.
                        LineRule = LineSpacingRuleValues.Exact,
                    }
                },
                new RunProperties(
                    new RunFonts()
                    {
                        Ascii = Doc.Fonts.CourierNew,
                        HighAnsi = Doc.Fonts.CourierNew
                    },
                    new FontSize() { Val = "24" }
                )
            )
            {
                Type = StyleValues.Paragraph,
                StyleId = Doc.Styles.Normal,
                Default = true,
                StyleName = new StyleName() { Val = Doc.Styles.Normal },
            }
        );

        stylePart.Styles.Save();
    }

    private void AddNumbering()
    {
        var numberingPart = _document.AddNewPart<NumberingDefinitionsPart>();

        numberingPart.Numbering = new Numbering(
            new AbstractNum(
                new Level(
                    new NumberingFormat() { Val = NumberFormatValues.Bullet },
                    new LevelText() { Val = "" },
                    new ParagraphProperties( new Indentation() { Left = "720", Hanging = "360" }),
                    new RunProperties(new RunFonts() { Ascii=Doc.Fonts.Symbol, HighAnsi=Doc.Fonts.Symbol })
                ) { LevelIndex = 0 }
            ) { AbstractNumberId = 1 },
        new NumberingInstance( new AbstractNumId() { Val = 1 } ) { NumberID = 1 });

        numberingPart.Numbering.Save();
    }

    private void AddFooter()
    {
        var footerPart = _document.AddNewPart<FooterPart>();

        footerPart.Footer = new Footer(
            new Paragraph(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Center }
                ),
                new Run(
                    new FieldCode(" PAGE ")
                ),
                new Run(
                    new FieldChar() { FieldCharType = FieldCharValues.Begin }
                ),
                new Run(
                    new FieldChar() { FieldCharType = FieldCharValues.Separate }
                ),
                new Run(
                    new FieldChar() { FieldCharType = FieldCharValues.End }
                )
            )
        );

        footerPart.Footer.Save();

        _body.Append(
            new SectionProperties(
                new FooterReference()
                {
                    Type = HeaderFooterValues.Default,
                    Id = _document.GetIdOfPart(footerPart),
                },
                new LineNumberType()
                {
                    CountBy = 1,
                    Start = 0,
                    Distance = "720",                           // Distance from text in twips
                    Restart = LineNumberRestartValues.NewPage,  // Restart numbering on each new page
                }
            )
        );
    }

    private void InitializeDocument()
    {
        AddNormalStyle();
        AddHyperlinkStyle();
        AddFooter();
        AddNumbering();
    }

}

