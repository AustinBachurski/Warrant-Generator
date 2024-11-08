using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.Interfaces;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
   private static string CorrectGrammar(char c)
    {
        return char.ToUpper(c) switch
        {
            'A' or 'E' or 'I' or 'O' or 'U' => "an",
            _ => "a",
        };
    }

    private static string FormattedDateString()
    {
        DateTimeOffset now = DateTime.Now;
        return $"{now.Day}{GetDayOrdinal(now)} day of {now:MMMM, yyyy}";
    }

    private static string FormattedDateString(DateTimeOffset date)
    {
        return $"{date.Day}{GetDayOrdinal(date)} day of {date:MMMM, yyyy}";
    }

    private static string GetDayOrdinal(DateTimeOffset date)
    {
        return date.Day switch
        {
            11 or 12 or 13 => "th",
            _ => (date.Day % 10) switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th",
            },
        };
    }

    private static string GetOfficerTitle(IHasOfficerTitle model)
    {
        if (model.CustomOfficerTitleVisibility)
        {
            return model.CustomOfficerTitleText;
        }

        return model.OfficerTitleSelection;
    }

    private static string PosessivePronoun(string gender)
    {
        if (gender == "Female")
        {
            return "her";
        }

        return "his";
    }
    
    private static string SubjectivePronoun(string gender)
    {
        if (gender == "Female")
        {
            return "she";
        }

        return "he";
    }
    
    private static string ValidFileName(string fileName)
    {
        if (fileName.EndsWith(Extension.Docx))
        {
            return fileName.Remove(fileName.Length - Extension.Docx.Length).Trim();
        }
        else if (fileName.EndsWith(Extension.Doc))
        {
            return fileName.Remove(fileName.Length - Extension.Doc.Length).Trim();
        }

        return fileName;
    }

    private static string CrimesAsString(ObservableCollection<MCACrime> crimesList)
    {
        StringBuilder builder = new();

        const string prefix = "M.C.A. § ";
        const string space = " (";
        const string suffix = "), ";
        int contentLength = prefix.Length + space.Length + suffix.Length;

        foreach (MCACrime each in crimesList)
        {
            builder.Append(prefix);
            builder.Append(each.Code);
            builder.Append(space);
            builder.Append(each.Description);
            builder.Append(suffix);
        }

        if (crimesList.Count > 1)
        {
            builder.Insert(StartingPositionOfLastEntry(builder, contentLength, crimesList), "and ");
        }

        // Trailing ", " is intentional.
        return builder.ToString();
    }

    private static int StartingPositionOfLastEntry(StringBuilder builder, int contentLength, ObservableCollection<MCACrime> crimesList)
    {
        contentLength += crimesList.Last().Code.Length;
        contentLength += crimesList.Last().Description.Length;

        return builder.Length - contentLength;
    }
}

