namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private void InsertInventoryBoilerplate()
    {
        var boilerplate = new[]
        {
            $"IN THE {_courtDistrict}, COUNTY OF FLATHEAD, STATE OF MONTANA",
            "STATE OF MONTANA\t\t\t\t\t\t)",
            "\t\t\tPlaintiff,\t\t\t\t)",
            "\t\t\t\t-vs-\t\t\t\t\t)\t\tINVENTORY",
            "\t\t\tDefendant,\t\t\t\t)\t\t",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private void InsertOrderBoilerplate()
    {
        var boilerplate = new[]
        {
            $"IN THE {_courtDistrict}, COUNTY OF FLATHEAD, STATE OF MONTANA",
            "STATE OF MONTANA\t\t\t\t\t\t)",
            "\t\t\tPlaintiff,\t\t\t\t)",
            "\t\t\t\t-vs-\t\t\t\t\t)\t\tORDER FOR CUSTODY",
            "\t\t\tDefendant,\t\t\t\t)\t\t",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private void InsertReturnBoilerplate()
    {
        var boilerplate = new[]
        {
            $"IN THE {_courtDistrict}, COUNTY OF FLATHEAD, STATE OF MONTANA",
            "STATE OF MONTANA\t\t\t\t\t\t)",
            "\t\t\tPlaintiff,\t\t\t\t)\t\tRETURN OF WARRANT",
            "\t\t\t\t-vs-\t\t\t\t\t)\t\tAND INVENTORY",
            "\t\t\tDefendant,\t\t\t\t)",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private void InsertWarrantBoilerplate()
    {
        var boilerplate = new[]
        {
            $"IN THE {_courtDistrict}, COUNTY OF FLATHEAD, STATE OF MONTANA",
            "STATE OF MONTANA\t\t\t\t\t\t)",
            "\t\t\tPlaintiff,\t\t\t\t)\t\tAPPLICATION FOR",
            "\t\t\t\t-vs-\t\t\t\t\t)\t\tSEARCH WARRANT",
            "\t\t\tDefendant,\t\t\t\t)",
            "",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private void StateOfMontanaCountyOfFlathead()
    {
        var boilerplate = new[]
        {
            "STATE OF MONTANA\t\t)",
            "\t\t\t\t:ss",
            "COUNTY OF FLATHEAD\t\t)",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }
}

