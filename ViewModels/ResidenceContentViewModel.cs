using WarrantGenerator.Constants;
using WarrantGenerator.DocumentGeneration;
using WarrantGenerator.DTOs;
using WarrantGenerator.Interfaces;

using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace WarrantGenerator.ViewModels;

public partial class ResidenceContentViewModel : ObservableObject, IHasOfficerRank
{
    public string[] CourtDistrictTypes { get; } = ConstantData.CourtDistricts;
    public string[] DurationTypes { get; } = ConstantData.DurationTypes;
    public string DurationTypeSelection { get; set; } = ConstantData.DefaultDurationTypeSelection;
    public string[] OfficerRanks { get; } = ConstantData.OfficerRanks;
    public string[] OfficerGender { get; } = ConstantData.Genders;


    [ObservableProperty]
    private IBrush _officerNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _officerNameText = Environment.GetEnvironmentVariable(EnVars.OfficerName) ?? string.Empty;

    partial void OnOfficerNameTextChanged(string value)
    {
        OfficerNameBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _officerGenderBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _officerGenderSelection = Environment.GetEnvironmentVariable(EnVars.OfficerGender) ?? string.Empty;

    partial void OnOfficerGenderSelectionChanged(string value)
    {
        OfficerGenderBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _officerRankBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _officerRankSelection = Environment.GetEnvironmentVariable(EnVars.OfficerRank) ?? string.Empty;

    partial void OnOfficerRankSelectionChanged(string value)
    {
        if (value == ConstantData.OfficerRanksOther)
        {
            CustomOfficerRankVisibility = true;
        }
        else
        {
            CustomOfficerRankVisibility = false;
        }

        OfficerRankBorder = Brushes.Transparent;
        CustomOfficerRankBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _customOfficerRankBorder = Brushes.Transparent;

    [ObservableProperty]
    private bool _customOfficerRankVisibility = false;

    [ObservableProperty]
    private string _customOfficerRankText = ConstantData.DefaultOfficerRank;

    partial void OnCustomOfficerRankTextChanged(string value)
    {
        CustomOfficerRankBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _employmentDurationBorder = Brushes.Transparent;

    [ObservableProperty]
    private decimal? _employmentDurationValue = EnVars.DateToDecimal();

    partial void OnEmploymentDurationValueChanged(decimal? value)
    {
        EmploymentDurationBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private string _courtDistrictSelection = ConstantData.DefaultCourtSelection;

    [ObservableProperty]
    private bool _SWATChecked = false;

    [ObservableProperty]
    private bool _crimeUnitChecked = false;

    [ObservableProperty]
    private bool _DelayChecked = false;

    [ObservableProperty]
    private bool _SealChecked = false;

    [ObservableProperty]
    private bool _TelephonicChecked = false;

    [ObservableProperty]
    private IBrush _residenceAddressBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _residenceAddressText = string.Empty;

    partial void OnResidenceAddressTextChanged(string value)
    {
        ResidenceAddressBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _residenceDescriptionBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _residenceDescriptionText = string.Empty;

    partial void OnResidenceDescriptionTextChanged(string value)
    {
        ResidenceDescriptionBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _crimesBorder = Brushes.Transparent;

    [ObservableProperty]
    private ObservableCollection<MCACrime> _crimes = [];

    [ObservableProperty]
    private MCACrime _selectedItem;

    [ObservableProperty]
    private IBrush _mcaCodeBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _mcaCodeText = string.Empty;

    partial void OnMcaCodeTextChanged(string value)
    {
        McaCodeBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _mcaDescriptionBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _mcaDescriptionText = string.Empty;

    partial void OnMcaDescriptionTextChanged(string value)
    {
        McaDescriptionBorder = Brushes.Transparent;
    }

    [RelayCommand]
    public void AddCrimeToCrimesList()
    {
        if (!ValidateMcaCrimeInput())
        {
            return;
        }

        Crimes.Add(new(McaCodeText.Trim(), CorrectCaseAndPunctuation(McaDescriptionText)));
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

    private static string CorrectCaseAndPunctuation(string text)
    {
        var chars = text.ToCharArray();

        chars[0] = char.ToUpper(chars[0]);

        while (chars.Length > 0 && !char.IsLetterOrDigit(chars.Last()))
        {
            Array.Resize(ref chars, chars.Length - 1);
        }

        return new string(chars);
    }

    [RelayCommand]
    public void RemoveCrime()
    {
        Crimes.Remove(SelectedItem);
    }

    [ObservableProperty]
    private IBrush _documentTypeCheckboxesBorder = Brushes.Transparent;

    [ObservableProperty]
    private bool _searchWarrantApplicationChecked = true;

    partial void OnSearchWarrantApplicationCheckedChanged(bool value)
    {
        if (value)
        {
            DocumentTypeCheckboxesBorder = Brushes.Transparent;
        }
    }

    [ObservableProperty]
    private bool _searchWarrantChecked = true;

    partial void OnSearchWarrantCheckedChanged(bool value)
    {
        if (value)
        {
            DocumentTypeCheckboxesBorder = Brushes.Transparent;
        }
    }

    [ObservableProperty]
    private IBrush _probableCauseBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _probableCauseText = string.Empty;

    partial void OnProbableCauseTextChanged(string value)
    {
        ProbableCauseBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _seizablePropertyBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _seizablePropertyText = string.Empty;

    partial void OnSeizablePropertyTextChanged(string value)
    {
        SeizablePropertyBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _outputFileNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _outputFileNameText = string.Empty;

    partial void OnOutputFileNameTextChanged(string value)
    {
        OutputFileNameBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private string? _flyoutMessage = null;

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

    private bool InputsAreValid()
    {
        bool result = true;

        if (OfficerNameText == string.Empty)
        {
            result = false;
            OfficerNameBorder = Brushes.Red;
        }

        if (OfficerGenderSelection == string.Empty)
        {
            result = false;
            OfficerGenderBorder = Brushes.Red;
        }

        if (OfficerRankSelection == string.Empty)
        {
            result = false;
            OfficerRankBorder= Brushes.Red;
        }

        if (CustomOfficerRankVisibility
            && (CustomOfficerRankText == ConstantData.DefaultOfficerRank || CustomOfficerRankText == string.Empty))
        {
            result = false;
            CustomOfficerRankBorder = Brushes.Red;
        }

        if (EmploymentDurationValue == null)
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

        if (!SearchWarrantApplicationChecked && !SearchWarrantChecked)
        {
            result = false;
            DocumentTypeCheckboxesBorder = Brushes.Red;
        }

        if (OutputFileNameText == string.Empty)
        {
            result = false;
            OutputFileNameBorder = Brushes.Red;
        }

        return result;
    }
}

