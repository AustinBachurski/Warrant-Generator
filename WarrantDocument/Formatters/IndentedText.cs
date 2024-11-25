using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml.Wordprocessing;
using System.Linq;


namespace WarrantGenerator.WarrantDocument.Formatters;

public class IndentedText(int tabs = 1) : IDocxFormatOption
{
    public void Apply(ParagraphProperties paragraphProperties, RunProperties runProperties)
    {
        foreach (var _ in Enumerable.Range(0, tabs))
        {
            runProperties.Append(new TabChar());
        }
    }
}

