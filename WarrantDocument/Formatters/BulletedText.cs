using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.WarrantDocument.Formatters;

public class BulletedText : IDocxFormatOptions
{
    public void Apply(Paragraph paragraph, Run run)
    {
        paragraph.ParagraphProperties.Append(
            new NumberingProperties(
                new NumberingLevelReference() { Val = 0 },
                new NumberingId() { Val = 1 }
            )
        );
    }

}

