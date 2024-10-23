using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DTOs;

public class DataEntryObject(MainWindowViewModel viewModel)
{
    public string ApplicationDate { get; } = FormattedDateString();
    public string Crimes { get; } = CrimesAsString(viewModel.Crimes);
    public string CrimeGrammar { get; } = viewModel.Crimes.Count == 1 ? "crime" : "crimes";
    public string District { get; } = viewModel.CourtDistrictSelection;
    public string DurationType { get; } = viewModel.DurationTypeSelection;
    public string EmploymentDuration { get; } = viewModel.EmploymentDurationText;
    public string OfficerGender { get; } = viewModel.MaleChecked ? "he" : "she";
    public string OfficerGrammar { get; } = CorrectGrammar(viewModel.OfficerTitleSelection.First());
    public string OfficerName { get; } = viewModel.OfficerNameText;
    public string OfficerTitle { get; } = GetOfficerTitle(viewModel);
    public string Organization { get; } = viewModel.OrganizationText;
    public string ProbableCause { get; } = viewModel.ProbableCauseText;
    public string SeizableProperty { get; } = viewModel.SeizablePropertyText;
    public string SuspectDateOfBirth { get; } = string.Empty;
    public string SuspectDriversLicense { get; } = string.Empty;
    public string SuspectName { get; } = string.Empty;
    public string TargetAddress { get; } = viewModel.TargetAddressText;
    public string TargetDescription { get; } = viewModel.TargetDescriptionText;

    private static string GetOfficerTitle(MainWindowViewModel viewModel)
    {
        if (viewModel.CustomOfficerTitleVisibility)
        {
            return viewModel.CustomOfficerTitleText;
        }
        return viewModel.OfficerTitleSelection;
    }

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
        var now = DateTime.Now;
        return $"{now.Day}{GetDayOrdinal(now)} day of {now:MMMM, yyyy}";
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
