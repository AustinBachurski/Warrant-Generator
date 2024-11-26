using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using System;


namespace WarrantGenerator.WarrantDocument;

public class DocxDocument : IDisposable
{
    public DocxDocument(string filePath)
    {
        _file = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
        _document = _file.AddMainDocumentPart();
        _document.Document = new Document();
        _body = new();
        InitializeDocument();
    }

    public void Dispose()
    {
        _file?.Dispose();
        GC.SuppressFinalize(this);
    }

    public void AppendContent(Paragraph[] paragraphs)
    {
        foreach (var paragraph in paragraphs)
        {
            _body.Append(paragraph);
        }
    }

    public void AppendMultilineText(string text)
    {
        foreach (var content in text.Split(Environment.NewLine))
        {
            _body.Append(
                new Paragraph(
                    new Run(
                        new Text(content) { Space = SpaceProcessingModeValues.Preserve}
                    )
                )
            );
        }
    }

    public void AppendText()
    {
        _body.Append(new Paragraph());
    }

    public void AppendText(string text, params IDocxFormatOptions[] options)
    {
        var paragraph = new Paragraph(new ParagraphProperties());
        var run = new Run(new RunProperties());

        foreach (var option in options)
        {
            option.Apply(paragraph, run);
        }

        paragraph.Append(run);
        _body.Append(paragraph);
    }

    public void AppendIndentedUrl(string url)
    {
        _body.Append(
            new Paragraph(
                new Hyperlink(
                    new Run(
                        new RunProperties(
                            new RunStyle() { Val = DocxStyle.Hyperlink }
                        ),
                        new TabChar(),
                        new Text(url)
                    )
                )
                { Id = _document.AddHyperlinkRelationship(new Uri(url), true).Id }
            )
        );
    }

    public void AppendInlineUrl(string preText, string url, string postText)
    {
        var paragraph = new Paragraph();

        if (!string.IsNullOrEmpty(preText))
        {
            paragraph.Append(
                new Run(
                    new Text(preText)
                    { Space = SpaceProcessingModeValues.Preserve }
                )
            );
        }

        paragraph.Append(
            new Hyperlink(
                new Run(
                    new RunProperties(
                        new RunStyle() { Val = DocxStyle.Hyperlink }
                    ),
                    new Text(url)
                )
            )
            { Id = _document.AddHyperlinkRelationship(new Uri(url), true).Id }
        );

        if (!string.IsNullOrEmpty(postText))
        {
            paragraph.Append(
                new Run(
                    new Text(postText)
                )
            );
        }
    }

    public void FinalizeDocument()
    {
        _document.Document.Append(_body);
        _document.Document.Save();
    }

    public void PageBreak()
    {
        _body.Append(
            new Paragraph(
                new Run(
                    new Break() { Type = BreakValues.Page }
                )
            )
        );
    }

    private readonly WordprocessingDocument _file;
    private readonly MainDocumentPart _document;
    private readonly Body _body;

    private static class DocxColor
    {
        public static string Blue { get; } = "0000FF";
    }

    private static class DocxFont
    {
        public static string CourierNew { get; } = "Courier New";
        public static string Symbol { get; } = "Symbol";
    }

    private static class DocxStyle
    {
        public static string Normal { get; } = "Normal";
        public static string Hyperlink { get; } = "HyperLink";
    }

    private void AddHyperlinkStyle()
    {
        _document.StyleDefinitionsPart.Styles.Append(
            new Style(
                new StyleRunProperties(
                    new Color()
                    {
                        Val = DocxColor.Blue,
                        ThemeColor = ThemeColorValues.Hyperlink
                    },
                    new Underline() { Val = UnderlineValues.Single }
                )
            )
            {
                Type = StyleValues.Character,
                StyleId = DocxStyle.Hyperlink,
                CustomStyle = false,
                StyleName = new StyleName() { Val = DocxStyle.Hyperlink },
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
                        Ascii = DocxFont.CourierNew,
                        HighAnsi = DocxFont.CourierNew
                    },
                    new FontSize() { Val = "24" }
                )
            )
            {
                Type = StyleValues.Paragraph,
                StyleId = DocxStyle.Normal,
                Default = true,
                StyleName = new StyleName() { Val = DocxStyle.Normal },
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
                    new ParagraphProperties(new Indentation() { Left = "720", Hanging = "360" }),
                    new RunProperties(new RunFonts() { Ascii = DocxFont.Symbol, HighAnsi = DocxFont.Symbol })
                )
                { LevelIndex = 0 }
            )
            { AbstractNumberId = 1 },
        new NumberingInstance(new AbstractNumId() { Val = 1 }) { NumberID = 1 });

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
