using System;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct ApplicationDate : IReplacementData
{
    public string target { get; set; } = "{{APPLICATION_DATE}}";
    public string data { get; set; }

    public ApplicationDate()
    {
        var now = DateTime.Now;
        data = $"{now.Day}{GetDayOrdinal(now)} day of {now:MMMM, yyyy}";
    }


    private static string GetDayOrdinal(DateTime date)
    {
        switch (date.Day)
        {
            case 11:
            case 12:
            case 13:
                return "th";
        }

        switch (date.Day % 10)
        {
            case 1:
                return "st";

            case 2:
                return "nd";

            case 3:
                return "rd";

            default:
                return "th";
        }
    }
}

