using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.WarrantDocument.Formatters;

public class AlignCenter : IDocxFormatOptions
{
    public void Apply(Paragraph paragraph, Run run)
    {
        paragraph.ParagraphProperties.Append(
            new Justification() { Val = JustificationValues.Center });
    }
}

