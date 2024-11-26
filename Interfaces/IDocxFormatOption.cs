using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.Interfaces;

public interface IDocxFormatOptions
{
    void Apply(Paragraph paragraph, Run run);
}

