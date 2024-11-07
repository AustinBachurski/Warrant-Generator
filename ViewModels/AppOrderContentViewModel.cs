using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Media;
using WarrantGenerator.Constants;
using WarrantGenerator.DocumentGeneration;
using WarrantGenerator.DTOs;
using System.IO;
using System;
using System.Collections.ObjectModel;
using WarrantGenerator.Interfaces;


namespace WarrantGenerator.ViewModels;

public partial class AppOrderContentViewModel : ObservableObject, IHasOfficerTitle
{
    public string[] CourtDistrictTypes { get; } = ConstantData.CourtDistricts;
    public string[] DurationTypes { get; } = ConstantData.DurationTypes;
    public string DurationTypeSelection { get; set; } = ConstantData.DefaultDurationTypeSelection;
    public string[] OfficerTitles { get; } = ConstantData.OfficerTitles;

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
    private string _courtDistrictSelection = ConstantData.DefaultCourtSelection;

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
    private string _customOfficerTitleText = ConstantData.DefaultOfficerTitle;

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

    partial void OnMcaCodeTextChanged(string value)
    {
        McaCodeBorder = Brushes.Transparent;
    }

    partial void OnMcaDescriptionTextChanged(string value)
    {
        McaDescriptionBorder = Brushes.Transparent;
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

    [RelayCommand]
    public void GenerateDocument()
    {
        if (!InputsAreValid())
        {
            FlyoutMessage = ConstantData.MissingField;
            return;
        }

        try
        {
            var document = new DocumentGenerator(this);
            var outfile = document.GenerateDocument();
            FlyoutMessage = ConstantData.DocumentGeneratedAs + outfile;
        }
        catch (IOException)
        {
            FlyoutMessage = ConstantData.CloseFile;
        }
        catch (Exception ex)
        {
            FlyoutMessage = ConstantData.UnexpectedError + ex;
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
            && (CustomOfficerTitleText == ConstantData.DefaultOfficerTitle || CustomOfficerTitleText == string.Empty))
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
