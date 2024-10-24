using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DTOs;

public class DataEntryObject(MainWindowViewModel viewModel)
{
    // Static Content
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
    public string WarrantType { get; } = viewModel.WarrantTypeSelection;

    // Dynamic Content
    public string DnaSampleDescription { get; } = viewModel.DnaSampleDescriptionText;
    public string SuspectDateOfBirth { get; } = viewModel.SuspectDateOfBirthText;
    public string SuspectDriversLicense { get; } = viewModel.SuspectDriversLicenseText;
    public string SuspectName { get; } = viewModel.SuspectNameText;
    public string ResidenceAddress { get; } = viewModel.ResidenceAddressText;
    public string ResidenceDescription { get; } = viewModel.ResidenceDescriptionText;
    public string VehicleDescription { get; } = viewModel.VehicleDescriptionText;

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

