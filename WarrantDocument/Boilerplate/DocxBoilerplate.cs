using WarrantGenerator.WarrantDocument;

using DocumentFormat.OpenXml.Wordprocessing;

using System.Linq;


namespace WarrantGenerator.WarrantDocument.Boilerplate;

public static class DocxBoilerplate
{

    public static Paragraph[] DistrictBoilerplate(string district, string option1 = "", string option2 = "")
    {
        return [
            new Paragraph(
                new Run(
                    new Text($"IN THE {district}, COUNTY OF FLATHEAD, STATE OF MONTANA")
                )
            ),
            new Paragraph(
                new Run(
                    new Text("STATE OF MONTANA"),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text(")")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text("Plaintiff,"),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text(")")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text("-vs-"),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text(")"),
                    new TabChar(),
                    new Text(option1)
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text("Defendant,"),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text(")"),
                    new TabChar(),
                    new Text(option2)
                )
            )
        ];
    }

    public static Paragraph[] FiledUnderSeal()
    {
        return [
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text("Filed Under Seal")
                )
            )
        ];
    }

    public static Paragraph[] StateOfMontanaBoilerplate()
    {
        return [
            new Paragraph(
                new Run(
                    new Text("STATE OF MONTANA"),
                    new TabChar(),
                    new Text(")")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text(":ss")
                )
            ),
            new Paragraph(
                new Run(
                    new Text("COUNTY OF FLATHEAD"),
                    new TabChar(),
                    new Text(")")
                )
            )
        ];
    }

}
