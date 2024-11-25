using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.WarrantDocument.Formatters;

public class BulletedText : IDocxFormatOption
{
    public void Apply(ParagraphProperties paragraphProperties, RunProperties runProperties)
    {
        paragraphProperties.Append(
            new NumberingProperties(
                new NumberingLevelReference() { Val = 0 },
                new NumberingId() { Val = 1 }
            )
        );
    }
}

