using System;


namespace WarrantGenerator.Constants;

public static class EnVars
{
    public static string DocumentOutPath { get; } = "DOCUMENT_OUTPUT_PATH";
    public static string OfficerName { get; } = "OFFICER_NAME";
    public static string OfficerGender { get; } = "OFFICER_GENDER";
    public static string OfficerRank { get; } = "OFFICER_RANK";
    public static string HireDate { get; } = "OFFICER_HIRE_DATE";

    public static decimal? DateToDecimal()
    {
        if (!DateTime.TryParse(Environment.GetEnvironmentVariable(HireDate), out DateTime startDate))
        {
            return null;
        }

        return (int)((DateTime.Now - startDate).TotalDays / 365);
    }

}

