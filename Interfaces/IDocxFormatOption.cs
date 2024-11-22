using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.Interfaces;

public interface IDocxFormatOption
{
    void Apply(ParagraphProperties paragraphProperties, RunProperties runProperties);
}

