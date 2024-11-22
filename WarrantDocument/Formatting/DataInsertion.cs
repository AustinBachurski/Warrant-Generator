using WarrantGenerator.Constants;

using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Text;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
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
}

