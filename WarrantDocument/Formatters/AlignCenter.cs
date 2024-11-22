using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.DocumentGeneration.Formatters;

public class AlignCenter : IDocxFormatOption
{
    public void Apply(ParagraphProperties paragraphProperties, RunProperties runProperties)
    {
        paragraphProperties.Append(new Justification() { Val = JustificationValues.Center });
    }
}

