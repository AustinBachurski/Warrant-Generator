using WarrantGenerator.Constants;

using DocumentFormat.OpenXml.Wordprocessing;
using System;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private void AppendBoldText(string text)
    {
        var paragraph = new Paragraph();
        var run = new Run();

        var format = new RunProperties();
        format.Bold = new Bold();
        run.RunProperties = format;

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

    private void AppendEmptyLine()
    {
        var paragraph = new Paragraph();
        _body.Append(paragraph);
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
        var paragraph = new Paragraph();
        var run = new Run();

        var alignment = new ParagraphProperties();
        alignment.Justification = new Justification() { Val = JustificationValues.Center };
        paragraph.ParagraphProperties = alignment;

        var format = new RunProperties();
        format.Bold = new Bold();
        format.Underline = new Underline() { Val = UnderlineValues.Single };
        run.RunProperties = format;

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

    private void AppendUrl(string url)
    {
        var linkRelationship = _document.AddHyperlinkRelationship(new Uri(url), true);

        var paragraph = new Paragraph();

        var run = new Run(new Text(url));
        run.PrependChild(new RunProperties(new RunStyle() { Val = StyleText.Hyperlink }));

        Hyperlink link = new(run) { Id = linkRelationship.Id, };

        paragraph.Append(link);
        _body.Append(paragraph);
    }

    private void AppendIndentedUrl(string url)
    {
        var linkRelationship = _document.AddHyperlinkRelationship(new Uri(url), true);

        var paragraph = new Paragraph();
        paragraph.Append(new Run(new TabChar()));

        var run = new Run(new Text(url));
        run.PrependChild(new RunProperties(new RunStyle() { Val = StyleText.Hyperlink }));

        Hyperlink link = new(run) { Id = linkRelationship.Id, };

        paragraph.Append(link);
        _body.Append(paragraph);
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

    private void AppendSocialMediaAddresses()
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
        var paragraph = new Paragraph();
        var run = new Run();
        run.Append(new Text(text));

        paragraph.Append(run);
        _body.Append(paragraph);
    }

}

