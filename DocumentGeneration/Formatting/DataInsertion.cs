using DocumentFormat.OpenXml.Wordprocessing;
using System;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
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
        format.Underline = new Underline();
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

    private void AppendText(string text)
    {
        var paragraph = new Paragraph();
        var run = new Run();
        run.Append(new Text(text));

        paragraph.Append(run);
        _body.Append(paragraph);
    }
}

