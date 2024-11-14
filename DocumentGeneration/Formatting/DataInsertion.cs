using WarrantGenerator.Constants;

using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Text;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private void AppendBoldText(string text)
    {
        _body.Append(
            new Paragraph(
                new Run(
                    new RunProperties(
                        new Bold()
                    ),
                    new Text(text)
                )
            )
        );
    }

    private void AppendBoldCenteredText(string text)
    {
        _body.Append(
            new Paragraph(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Center } 
                ),
                new Run(
                    new RunProperties(
                        new Bold(),
                        new Text(text)
                    )
                )
            )
        );
    }

    private void AppendBoldUnderlinedText(string text)
    {
        _body.Append(
            new Paragraph(
                new Run(
                    new RunProperties(
                        new Bold(),
                        new Underline() { Val = UnderlineValues.Single }
                    ),
                    new Text(text)
                )
            )
        );
    }

    private void AppendBulletedText(string text)
    {
        _body.Append(
            new Paragraph(
                new ParagraphProperties(
                    new NumberingProperties(
                        new NumberingLevelReference() { Val = 0 },
                        new NumberingId() { Val = 1 }
                    )
                ),
                new Run(
                    new Text(text)
                )
            )
        );
    }

    private void AppendCenteredText(string text)
    {
        _body.Append(
            new Paragraph(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Center }
                ),
                new Run(
                    new Text(text)
                )
            )
        );
    }

    private void AppendDoublyIndentedText(string text)
    {
        _body.Append(
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new Text(text)
                )
            )
        );
    }

    private void AppendEmptyLine()
    {
        _body.Append(new Paragraph());
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

    private void AppendHeading(string text)
    {
        _body.Append(
            new Paragraph(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Center }
                ),
                new Run(
                    new RunProperties(
                        new Bold(),
                        new Underline() { Val = UnderlineValues.Single }
                    ),
                    new Text(text)
                )
            )
        );
    }

    private void AppendIndentedText(string text)
    {
        _body.Append(
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text(text)
                )
            )
        );
    }

    private void AppendIndentedUrl(string url)
    {
        _body.Append(
            new Paragraph(
                new Run(
                    new TabChar()
                ),
                new Hyperlink(
                    new Run(
                        new RunProperties(
                            new RunStyle() { Val = Doc.Styles.Hyperlink }
                        ),
                        new Text(url)
                    )
                )
                { Id = _document.AddHyperlinkRelationship(new Uri(url), true).Id }
            )
        );
    }

    private void AppendMultilineText(string text)
    {
        foreach (var content in text.Split(Environment.NewLine))
        {
            _body.Append(
                new Paragraph(
                    new Run(
                        new Text(content)
                    )
                )
            );
        }
    }

    private void AppendSocialMediaAccounts()
    {
        var accounts = _accountNamesCombined.Split(Environment.NewLine);

        foreach (var account in  accounts)
        {
            var data = account.Split(ConstantData.Separator);

            AppendText(data[0]);         // Name
            AppendIndentedUrl(data[1]);  // URL
            AppendEmptyLine();
        }
    }

    private void AppendSocialMediaUrls()
    {
        var accounts = _accountNamesCombined.Split(Environment.NewLine);

        foreach (var account in  accounts)
        {
            var data = account.Split(ConstantData.Separator);

            AppendIndentedUrl(data[1]);  // URL
            AppendEmptyLine();
        }
    }

    private void AppendText(string text)
    {
        _body.Append(
            new Paragraph(
                new Run(
                    new Text(text)
                )
            )
        );
    }

    private void AppendUrl(string url)
    {
        _body.Append(
            new Paragraph(
                new Hyperlink(
                    new Run(
                        new RunProperties(
                            new RunStyle() { Val = Doc.Styles.Hyperlink }
                        ),
                        new Text(url)
                    )
                )
                { Id = _document.AddHyperlinkRelationship(new Uri(url), true).Id }
            )
        );
    }

    private void PageBreak()
    {
        _body.Append(
            new Paragraph(
                new Run(
                    new Break() { Type = BreakValues.Page }
                )
            )
        );
    }

}

