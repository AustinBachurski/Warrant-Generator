using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.WarrantDocument.Formatters;

public class BoldText : IDocxFormatOptions
{
    public void Apply(Paragraph paragraph, Run run)
    {
        run.RunProperties.Append(new Bold());
    }
}

