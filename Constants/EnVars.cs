using System;
using System.Dynamic;

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
        try
        {
            DateTime startDate = DateTime.Parse(Environment.GetEnvironmentVariable(HireDate));
            return (int)(((DateTime.Now - startDate).TotalDays) / 365);
        }
        catch(Exception)
        {
            return null;
        }
    }
}

