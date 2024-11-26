using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml.Wordprocessing;
using System.Linq;


namespace WarrantGenerator.WarrantDocument.Formatters;

public class IndentedText(int tabs = 1) : IDocxFormatOptions
{
    public void Apply(Paragraph paragraph, Run run)
    {
        foreach (var _ in Enumerable.Range(0, tabs))
        {
            run.Append(new TabChar());
        }
    }
}

