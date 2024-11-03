using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DTOs;

// TODO: Remove this class, move methods elsewhere.
public class DataEntryObject(StructureContentViewModel model)
{
    // Static Content
    public string ApplicationDate { get; } = FormattedDateString();
    public string Crimes { get; } = CrimesAsString(model.Crimes);
    public string CrimeGrammar { get; } = model.Crimes.Count == 1 ? "crime" : "crimes";
    public string District { get; } = model.CourtDistrictSelection;
    public string DurationType { get; } = model.DurationTypeSelection;
    public string EmploymentDuration { get; } = model.EmploymentDurationText;
    public string OfficerGender { get; } = model.MaleChecked ? "he" : "she";
    public string OfficerGrammar { get; } = CorrectGrammar(model.OfficerTitleSelection.First());
    public string OfficerName { get; } = model.OfficerNameText;
    public string OfficerTitle { get; } = GetOfficerTitle(model);
    public string Organization { get; } = model.OrganizationText;
    public string ProbableCause { get; } = model.ProbableCauseText;
    public string SeizableProperty { get; } = model.SeizablePropertyText;
    public string WarrantType { get; } = model.WarrantTypeSelection;

    // Dynamic Content
    public string DnaSampleDescription { get; } = model.DnaSampleDescriptionText;
    public string SuspectDateOfBirth { get; } = model.SuspectDateOfBirthText;
    public string SuspectDriversLicense { get; } = model.SuspectDriversLicenseText;
    public string SuspectName { get; } = model.SuspectNameText;
    public string ResidenceAddress { get; } = model.ResidenceAddressText;
    public string ResidenceDescription { get; } = model.ResidenceDescriptionText;
    public string VehicleDescription { get; } = model.VehicleDescriptionText;

    private static string GetOfficerTitle(StructureContentViewModel viewModel)
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

