using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.Interfaces;
using WarrantGenerator.WarrantDocument.Documents;

using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;



namespace WarrantGenerator.ViewModels;

public partial class SocialMediaContentViewModel : ObservableObject, IHasOfficerRank
{
    public string[] CourtDistrictTypes { get; } = ConstantData.CourtDistricts;
    public string[] DurationTypes { get; } = ConstantData.DurationTypes;
    public string DurationTypeSelection { get; set; } = ConstantData.DefaultDurationTypeSelection;
    public string[] OfficerRanks { get; } = ConstantData.OfficerRanks;
    public string[] OfficerGender { get; } = ConstantData.Genders;
    public string[] SocialMediaPlatforms { get; } = ConstantData.Platforms;


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
    private bool _DelayChecked = false;

    [ObservableProperty]
    private bool _SealChecked = false;

    [ObservableProperty]
    private IBrush _platformBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _platformSelection = string.Empty;

    partial void OnPlatformSelectionChanged(string value)
    {
        PlatformBorder= Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _startDateBorder = Brushes.Transparent;

    [ObservableProperty]
    private DateTime? _startDateSelection = null;

    partial void OnStartDateSelectionChanged(DateTime? value)
    {
        StartDateBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _accountsBorder = Brushes.Transparent;

    [ObservableProperty]
    private ObservableCollection<SocialMediaProfile> _accounts = [];

    [ObservableProperty]
    private SocialMediaProfile _selectedAccount;

    [ObservableProperty]
    private IBrush _nameEntryBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _nameEntryText = string.Empty;

    partial void OnNameEntryTextChanged(string value)
    {
        NameEntryBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _urlEntryBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _urlTextTitle = ConstantData.NormalUrlTitleText;

    [ObservableProperty]
    private string _urlEntryText = string.Empty;

    partial void OnUrlEntryTextChanged(string value)
    {
        UrlEntryBorder = Brushes.Transparent;
        UrlTextTitle = ConstantData.NormalUrlTitleText;
    }

    [RelayCommand]
    public void AddAccountToAccountList()
    {
        if (!ValidateAccountEntries())
        {
            return;
        }

        try
        {
            var verify = new Uri(UrlEntryText.Trim(' ', '/'));
        }
        catch(UriFormatException)
        {
            UrlEntryBorder = Brushes.Red;
            UrlTextTitle = ConstantData.ErrorUrlTitleText;
            return;
        }

        Accounts.Add(new(NameEntryText.Trim(), UrlEntryText.Trim(' ', '/')));
        AccountsBorder = Brushes.Transparent;

        NameEntryText = string.Empty;
        UrlEntryText = string.Empty;
    }

    private bool ValidateAccountEntries()
    {
        bool result = true;

        if (NameEntryText == string.Empty)
        {
            result = false;
            NameEntryBorder = Brushes.Red;
        }

        if (UrlEntryText == string.Empty)
        {
            result = false;
            UrlEntryBorder = Brushes.Red;
        }

        return result;
    }

    [RelayCommand]
    public void RemoveAccount()
    {
        Accounts.Remove(SelectedAccount);
    }

    [ObservableProperty]
    private IBrush _crimesBorder = Brushes.Transparent;

    [ObservableProperty]
    private ObservableCollection<MCACrime> _crimes = [];

    [ObservableProperty]
    private MCACrime _selectedCrime;

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
        Crimes.Remove(SelectedCrime);
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
    private IBrush _legalCriteriaBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _legalCriteriaText = string.Empty;

    partial void OnLegalCriteriaTextChanged(string value)
    {
        LegalCriteriaBorder = Brushes.Transparent;
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
            var document = new FacebookDocument(new FacebookData(this));
          var outfile = document.GenerateDocuments();
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

        if (PlatformSelection == string.Empty)
        {
            result = false;
            PlatformBorder = Brushes.Red;
        }

        if (StartDateSelection == null)
        {
            result = false;
            StartDateBorder = Brushes.Red;
        }

        if (Accounts.Count == 0)
        {
            result = false;
            AccountsBorder = Brushes.Red;
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

        if (LegalCriteriaText == string.Empty)
        {
            result = false;
            LegalCriteriaBorder = Brushes.Red;
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

