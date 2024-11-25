using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.WarrantDocument.Formatters;

public class AlignCenter : IDocxFormatOption
{
    public void Apply(ParagraphProperties paragraphProperties, RunProperties runProperties)
    {
        paragraphProperties.Append(new Justification() { Val = JustificationValues.Center });
    }
}

