using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Media;
using WarrantGenerator.DocumentGeneration;
using WarrantGenerator.DTOs;
using System.IO;
using System;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace WarrantGenerator.ViewModels;

public partial class StructureContentViewModel : ObservableObject
{
    public string[] CourtDistrictTypes { get; } = [
        "11TH JUDICIAL DISTRICT COURT",
        "FLATHEAD COUNTY JUSTICE COURT",
        "KALISPELL MUNICIPAL COURT",
    ];
    public string[] DurationTypes { get; } = [
        "years", "year", "months", "month", "days", "day",
    ];
    public string DurationTypeSelection { get; set; } = "years";
    public string[] OfficerTitles { get; } = [
        "Captain", "Chief", "Detective", "Detective Sergeant", "Lieutenant",
        "Master Patrol Officer", "Officer", "Sergeant", "Other",
    ];
    public string[] WarrantTypes { get; } = [
        "DNA Warrant", "GSR Warrant", "Social Media Warrant",
        "Residence Warrant", "Vehicle Warrant",
    ];

    [ObservableProperty]
    private IBrush _warrantTypeBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _warrantTypeSelection = string.Empty;

    [ObservableProperty]
    private bool _showVehicleDescription = false;

    [ObservableProperty]
    private bool _showSuspectDateOfBirth = false;

    [ObservableProperty]
    private bool _showSuspectDriversLicense = false;

    [ObservableProperty]
    private bool _showSuspectName = false;

    [ObservableProperty]
    private bool _showResidenceAddress = false;

    [ObservableProperty]
    private bool _showResidenceDescription = false;

    [ObservableProperty]
    private bool _showDnaSampleDescription = false;

    [ObservableProperty]
    private IBrush _mcaCodeBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _mcaCodeText = string.Empty;

    [ObservableProperty]
    private IBrush _mcaDescriptionBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _mcaDescriptionText = string.Empty;

    [ObservableProperty]
    private string? _flyoutMessage = null;

    [ObservableProperty]
    private IBrush _courtDistrictBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _courtDistrictSelection = "11TH JUDICIAL DISTRICT COURT";

    [ObservableProperty]
    private IBrush _organizationBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _organizationText =
        Environment.GetEnvironmentVariable("ORGANIZATION") ?? string.Empty;

    [ObservableProperty]
    private IBrush _officerNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private IBrush _officerGenderBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _officerNameText = string.Empty;

    [ObservableProperty]
    private bool _femaleChecked = false;

    [ObservableProperty]
    private bool _maleChecked = false;

    [ObservableProperty]
    private IBrush _officerTitleBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _officerTitleSelection = string.Empty;

    [ObservableProperty]
    private IBrush _customOfficerTitleBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _customOfficerTitleText = "Enter Title";

    [ObservableProperty]
    private bool _customOfficerTitleVisibility = false;

    [ObservableProperty]
    private IBrush _employmentDurationBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _employmentDurationText = string.Empty;

    [ObservableProperty]
    private IBrush _residenceAddressBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _residenceAddressText = string.Empty;

    [ObservableProperty]
    private IBrush _residenceDescriptionBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _residenceDescriptionText = string.Empty;

    [ObservableProperty]
    private MCACrime _selectedItem;

    [ObservableProperty]
    private IBrush _crimesBorder = Brushes.Transparent;

    [ObservableProperty]
    private ObservableCollection<MCACrime> _crimes = [];

    [ObservableProperty]
    private IBrush _probableCauseBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _probableCauseText = string.Empty;

    [ObservableProperty]
    private IBrush _seizablePropertyBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _seizablePropertyText = string.Empty;

    [ObservableProperty]
    private IBrush _outputFileNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _outputFileNameText = string.Empty;

    [ObservableProperty]
    private IBrush _vehicleDescriptionBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _vehicleDescriptionText = string.Empty;

    [ObservableProperty]
    private IBrush _dnaSampleDescriptionBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _dnaSampleDescriptionText = string.Empty;

    [ObservableProperty]
    private IBrush _suspectDateOfBirthBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _suspectDateOfBirthText = string.Empty;

    [ObservableProperty]
    private IBrush _suspectDriversLicenseBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _suspectDriversLicenseText = string.Empty;

    [ObservableProperty]
    private IBrush _suspectNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _suspectNameText = string.Empty;

    partial void OnWarrantTypeSelectionChanged(string value)
    {
        switch (value)
        {
            case "DNA Warrant":
                ShowDNAWarrantContent();
                break;

            case "GSR Warrant":
                ShowGSRWarrantContent();
                break;

            case "Social Media Warrant":
                ShowSocialMediaWarrantContent();
                break;

            case "Residence Warrant":
                ShowResidenceWarrantContent();
                break;

            case "Vehicle Warrant":
                ShowVehicleWarrantContent();
                break;
        }
    }

    partial void OnSuspectNameTextChanged(string value)
    {
        SuspectNameBorder = Brushes.Transparent;
    }

    partial void OnSuspectDriversLicenseTextChanged(string value)
    {
        SuspectDriversLicenseBorder = Brushes.Transparent;
    }

    partial void OnSuspectDateOfBirthTextChanged(string value)
    {
        SuspectDateOfBirthBorder = Brushes.Transparent;
    }

    partial void OnDnaSampleDescriptionTextChanged(string value)
    {
        DnaSampleDescriptionBorder = Brushes.Transparent;
    }

    partial void OnVehicleDescriptionTextChanged(string value)
    {
        VehicleDescriptionBorder = Brushes.Transparent;
    }

    partial void OnMcaCodeTextChanged(string value)
    {
        McaCodeBorder = Brushes.Transparent;
    }

    partial void OnMcaDescriptionTextChanged(string value)
    {
        McaDescriptionBorder = Brushes.Transparent;
    }

    partial void OnCourtDistrictSelectionChanged(string value)
    {
        CourtDistrictBorder = Brushes.Transparent;
    }

    partial void OnOrganizationTextChanged(string value)
    {
        OrganizationBorder = Brushes.Transparent;
    }

    partial void OnOfficerNameTextChanged(string value)
    {
        OfficerNameBorder = Brushes.Transparent;
    }

    partial void OnFemaleCheckedChanged(bool value)
    {
        if (value)
        {
            MaleChecked = false;
        }
        OfficerGenderBorder = Brushes.Transparent;
    }

    partial void OnMaleCheckedChanged(bool value)
    {
        if (value)
        {
            FemaleChecked = false;
        }
        OfficerGenderBorder = Brushes.Transparent;
    }

    partial void OnOfficerTitleSelectionChanged(string value)
    {
        if (value == "Other")
        {
            CustomOfficerTitleVisibility = true;
        }
        else
        {
            CustomOfficerTitleVisibility = false;
        }

        OfficerTitleBorder = Brushes.Transparent;
        CustomOfficerTitleBorder = Brushes.Transparent;
    }

    partial void OnCustomOfficerTitleTextChanged(string value)
    {
        CustomOfficerTitleBorder = Brushes.Transparent;
    }

    partial void OnEmploymentDurationTextChanged(string value)
    {
        EmploymentDurationBorder = Brushes.Transparent;
    }

    partial void OnResidenceAddressTextChanged(string value)
    {
        ResidenceAddressBorder = Brushes.Transparent;
    }

    partial void OnResidenceDescriptionTextChanged(string value)
    {
        ResidenceDescriptionBorder = Brushes.Transparent;
    }

    partial void OnProbableCauseTextChanged(string value)
    {
        ProbableCauseBorder = Brushes.Transparent;
    }

    partial void OnSeizablePropertyTextChanged(string value)
    {
        SeizablePropertyBorder = Brushes.Transparent;
    }

    partial void OnOutputFileNameTextChanged(string value)
    {
        OutputFileNameBorder = Brushes.Transparent;
    }

    private void ShowVehicleWarrantContent()
    {
        ShowVehicleDescription = true;

        ShowSuspectDateOfBirth = false;
        ShowSuspectDriversLicense = false;
        ShowSuspectName = false;
        ShowResidenceAddress = false;
        ShowResidenceDescription = false;
        ShowDnaSampleDescription = false;
    }

    private void ShowResidenceWarrantContent()
    {
        ShowResidenceAddress = true;
        ShowResidenceDescription = true;

        ShowVehicleDescription = false;
        ShowSuspectDateOfBirth = false;
        ShowSuspectDriversLicense = false;
        ShowSuspectName = false;
        ShowDnaSampleDescription = false;
    }

    private void ShowSocialMediaWarrantContent()
    {
        ShowVehicleDescription = false;
        ShowSuspectDateOfBirth = false;
        ShowSuspectDriversLicense = false;
        ShowSuspectName = false;
        ShowResidenceAddress = false;
        ShowResidenceDescription = false;
        ShowDnaSampleDescription = false;
    }

    private void ShowGSRWarrantContent()
    {
        ShowSuspectDateOfBirth = true;
        ShowSuspectDriversLicense = true;
        ShowSuspectName = true;

        ShowVehicleDescription = false;
        ShowResidenceAddress = false;
        ShowResidenceDescription = false;
        ShowDnaSampleDescription = false;
    }

    private void ShowDNAWarrantContent()
    {
        ShowDnaSampleDescription = true;

        ShowVehicleDescription = false;
        ShowSuspectDateOfBirth = false;
        ShowSuspectDriversLicense = false;
        ShowSuspectName = false;
        ShowResidenceAddress = false;
        ShowResidenceDescription = false;
    }

    [RelayCommand]
    public void GenerateWarrantDocument()
    {
        if (!InputsAreValid())
        {
            FlyoutMessage = "All fields must be filled out first.";
            return;
        }

        try
        {
            var document = new DocumentGenerator(OutputFileNameText.Trim());
            var outfile = document.GenerateDocument(new DataEntryObject(this));
            FlyoutMessage = $"Warrant has been generated as:\n\t{outfile}";
        }
        catch (IOException)
        {
            FlyoutMessage = "Unable to write output file.\nIf the file is open, please close it.";
        }
        catch (Exception ex)
        {
            FlyoutMessage = $"Unexpected Error Encountered, Error Details:\n\n{ex}";
        }
    }

    [RelayCommand]
    public void RemoveCrime()
    {
        Crimes.Remove(SelectedItem);
    }

    [RelayCommand]
    public void AddCrimeToCrimesList()
    {
        if (!ValidateMcaCrimeInput())
        {
            return;
        }

        Crimes.Add(new(McaCodeText, McaDescriptionText));
        CrimesBorder = Brushes.Transparent;

        McaCodeText = string.Empty;
        McaDescriptionText = string.Empty;
    }

    private bool ValidateMcaCrimeInput()
    {
        bool result = true;

        if (McaCodeText == string.Empty)
        {
            result = false;
            McaCodeBorder = Brushes.Red;
        }

        if (McaDescriptionText == string.Empty)
        {
            result = false;
            McaDescriptionBorder = Brushes.Red;
        }

        return result;
    }

    private bool InputsAreValid()
    {
        bool result = true;

        if (CourtDistrictSelection == string.Empty)
        {
            result = false;
            CourtDistrictBorder = Brushes.Red;
        }

        if (OrganizationText == string.Empty)
        {
            result = false;
            OrganizationBorder = Brushes.Red;
        }

        if (OfficerNameText == string.Empty)
        {
            result = false;
            OfficerNameBorder = Brushes.Red;
        }

        if (!MaleChecked && !FemaleChecked)
        {
            result = false;
            OfficerGenderBorder = Brushes.Red;
        }

        if (OfficerTitleSelection == string.Empty)
        {
            result = false;
            OfficerTitleBorder= Brushes.Red;
        }

        if (CustomOfficerTitleVisibility
            && (CustomOfficerTitleText == "Enter Title" || CustomOfficerTitleText == string.Empty))
        {
            result = false;
            CustomOfficerTitleBorder = Brushes.Red;
        }

        if (EmploymentDurationText == string.Empty)
        {
            result = false;
            EmploymentDurationBorder = Brushes.Red;
        }

        if (ResidenceAddressText == string.Empty)
        {
            result = false;
            ResidenceAddressBorder = Brushes.Red;
        }

        if (ResidenceDescriptionText == string.Empty)
        {
            result = false;
            ResidenceDescriptionBorder = Brushes.Red;
        }

        if (Crimes.Count == 0)
        {
            result = false;
            CrimesBorder = Brushes.Red;
        }

        if (ProbableCauseText == string.Empty)
        {
            result = false;
            ProbableCauseBorder = Brushes.Red;
        }

        if (SeizablePropertyText == string.Empty)
        {
            result = false;
            SeizablePropertyBorder = Brushes.Red;
        }

        if (OutputFileNameText == string.Empty)
        {
            result = false;
            OutputFileNameBorder = Brushes.Red;
        }

        return result;
    }
}

