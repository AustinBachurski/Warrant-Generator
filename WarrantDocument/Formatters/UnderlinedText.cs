using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.WarrantDocument.Formatters;

public class UnderlinedText : IDocxFormatOptions
{
    public void Apply(Paragraph paragraph, Run run)
    {
        run.RunProperties.Append(new Underline() { Val = UnderlineValues.Single });
    }

}

