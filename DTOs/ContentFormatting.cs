﻿using WarrantGenerator.Constants;
using WarrantGenerator.Interfaces;

using System;
using System.IO;
using System.Linq;


namespace WarrantGenerator.DTOs;

public static class FormattedContent
{
    public static string FormattedDateString()
    {
        DateTime now = DateTime.Now;
        return $"{now.Day}{GetDayOrdinal(now)} day of {now:MMMM, yyyy}";
    }

    public static string FormattedDateString(DateTime date)
    {
        return $"{date.Day}{GetDayOrdinal(date)} day of {date:MMMM, yyyy}";
    }

    private static string GetDayOrdinal(DateTime date)
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

    public static string GetOfficerRank(IHasOfficerRank model)
    {
        if (model.CustomOfficerRankVisibility)
        {
            return model.CustomOfficerRankText;
        }

        return model.OfficerRankSelection;
    }

    public static string IndefiniteArticle(char c)
    {
        return char.ToUpper(c) switch
        {
            'A' or 'E' or 'I' or 'O' or 'U' => "an",
            _ => "a",
        };
    }

    public static string LowercaseStartAndRemoveTrailingPunctuation(string text)
    {

        var chars = text.ToCharArray();

        chars[0] = char.ToLower(chars[0]);

        while (chars.Length > 0 && !char.IsLetterOrDigit(chars.Last()))
        {
            Array.Resize(ref chars, chars.Length - 1);
        }

        return new string(chars);
    }

    public static string PosessivePronoun(string gender)
    {
        if (gender == "Female")
        {
            return "her";
        }

        return "his";
    }

    public static string RemoveTrailingPunctuation(string text)
    {
        var chars = text.ToCharArray();

        while (chars.Length > 0 && !char.IsLetterOrDigit(chars.Last()))
        {
            Array.Resize(ref chars, chars.Length - 1);
        }

        return new string(chars);
    }

    public static string SubjectivePronoun(string gender)
    {
        if (gender == "Female")
        {
            return "she";
        }

        return "he";
    }

    public static string ValidFileName(string fileName)
    {
        if (fileName.Contains('.'))
        {
            return Path.Combine(DefaultPath(), fileName.Remove(fileName.LastIndexOf('.')));
        }

        return Path.Combine(DefaultPath(), fileName);
    }

    public static string CrimeCodesAsString(MCACrime[] crimesList)
    {
        if (crimesList.Length == 2)
        {
            return string.Join(" and ", crimesList.Select(crime => crime.Code));
        }

        string combined = string.Join(", ", crimesList.Select(crime => crime.Code));

        if (crimesList.Length > 1)
        {
            return InsertCoordinatingConjunction(combined);
        }

        return combined;
    }

    public static string CrimeDescriptionsAsString(MCACrime[] crimesList)
    {
        if (crimesList.Length == 2)
        {
            return string.Join(" and ", crimesList.Select(crime => crime.Description));
        }

        string combined = string.Join(", ", crimesList.Select(crime => crime.Description));

        if (crimesList.Length > 1)
        {
            return InsertCoordinatingConjunction(combined);
        }

        return combined;
    }

    public static string CrimesCombinedAsString(MCACrime[] crimesList)
    {
        if (crimesList.Length == 2)
        {
            return string.Join(" and ", crimesList.Select(crime => $"M.C.A. § {crime.Code} ({crime.Description})"));
        }

        string combined = string.Join(", ", crimesList.Select(crime => $"M.C.A. § {crime.Code} ({crime.Description})"));

        if (crimesList.Length > 1)
        {
            return InsertCoordinatingConjunction(combined);
        }

        return combined;
    }

    public static string ShortDateString(DateTime date)
    {
        return $"{date:M/d/yyyy}";
    }

    public static string TimeString(TimeSpan time)
    {
        var dateTime = DateTime.Today.Add(time);
        return $"{dateTime:h:mm tt}";
    }

    private static string DefaultPath()
    {
        string? path = Environment.GetEnvironmentVariable(EnVars.DocumentOutPath);

        if (path == null)
        {
            return "./";
        }

        return path.TrimEnd('.', '/', '\\');
    }

    private static string InsertCoordinatingConjunction(string text)
    {
        return text.Insert(text.LastIndexOf(',') + 1, " and");
    }

}

