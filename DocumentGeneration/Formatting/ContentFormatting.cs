﻿using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.Interfaces;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Wordprocessing;


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

    private static string GetOfficerRank(IHasOfficerRank model)
    {
        if (model.CustomOfficerRankVisibility)
        {
            return model.CustomOfficerRankText;
        }

        return model.OfficerRankSelection;
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

    private static string CrimeCodesAsString(ObservableCollection<MCACrime> crimesList)
    {
        if (crimesList.Count == 2)
        {
            return string.Join(" and ", crimesList.Select(crime => crime.Code));
        }

        string combined = string.Join(", ", crimesList.Select(crime => crime.Code));

        if (crimesList.Count > 1)
        {
            return InsertCoordinatingConjunction(combined);
        }

        return combined;
    }

    private static string CrimeDescriptionsAsString(ObservableCollection<MCACrime> crimesList)
    {
        if (crimesList.Count == 2)
        {
            return string.Join(" and ", crimesList.Select(crime => crime.Description));
        }

        string combined = string.Join(", ", crimesList.Select(crime => crime.Description));

        if (crimesList.Count > 1)
        {
            return InsertCoordinatingConjunction(combined);
        }

        return combined;
    }

    private static string CrimesCombinedAsString(ObservableCollection<MCACrime> crimesList)
    {
        if (crimesList.Count == 2)
        {
            return string.Join(" and ", crimesList.Select(crime => $"M.C.A. § {crime.Code} ({crime.Description})"));
        }

        string combined = string.Join(", ", crimesList.Select(crime => $"M.C.A. § {crime.Code} ({crime.Description})"));

        if (crimesList.Count > 1)
        {
            return InsertCoordinatingConjunction(combined);
        }

        return combined;
    }

    private static string InsertCoordinatingConjunction(string text)
    {
        return text.Insert(text.LastIndexOf(',') + 1, " and");
    }

    private static int StartingPositionOfLastEntry(StringBuilder builder, int contentLength, ObservableCollection<MCACrime> crimesList)
    {
        contentLength += crimesList.Last().Code.Length;
        contentLength += crimesList.Last().Description.Length;

        return builder.Length - contentLength;
    }
}

