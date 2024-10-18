using System;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WarrantGenerator.Document;
using WarrantGenerator.DTOs;
using WarrantGenerator.Interfaces;
using System.Collections.ObjectModel;

namespace WarrantGenerator.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public string[] DurationTypes { get; set; } = [
        "years", "year", "months", "month", "days", "day",
    ];
    public string DurationTypeSelection { get; set; } = "years";
    public string[] OfficerTitles { get; set; } = [
        "Captain", "Chief", "Detective", "Detective Sergeant", "Lieutenant",
        "Master Patrol Officer", "Officer", "Sergeant", "Other",
    ];
    public ObservableCollection<MCAs> Crimes { get; set; } = new ObservableCollection<MCAs>
    {
        new( "123", "One two three." ),
        new( "456", "Four five six." ),
        new( "789", "Seven eight nine." ),
        new( "789", "Seven eight nine." ),
        new( "789", "Seven eight nine." ),
    };

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
    private IBrush _targetAddressBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _targetAddressText = string.Empty;

    [ObservableProperty]
    private IBrush _targetDescriptionBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _targetDescriptionText = string.Empty;

    [ObservableProperty]
    private IBrush _searchWarrantReasonBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _searchWarrantReasonText = string.Empty;

    [ObservableProperty]
    private IBrush _searchWarrantContentBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _searchWarrantContentText = string.Empty;

    [ObservableProperty]
    private IBrush _outputFileNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _outputFileNameText = string.Empty;

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

    partial void OnTargetAddressTextChanged(string value)
    {
        TargetAddressBorder = Brushes.Transparent;
    }

    partial void OnTargetDescriptionTextChanged(string value)
    {
        TargetDescriptionBorder = Brushes.Transparent;
    }

    partial void OnSearchWarrantReasonTextChanged(string value)
    {
        SearchWarrantReasonBorder = Brushes.Transparent;
    }

    partial void OnSearchWarrantContentTextChanged(string value)
    {
        SearchWarrantContentBorder = Brushes.Transparent;
    }

    partial void OnOutputFileNameTextChanged(string value)
    {
        OutputFileNameBorder = Brushes.Transparent;
    }

    private IReplacementData[] AssembleData()
    {
        IReplacementData[] data =
        {
            new ApplicationDate(),
            new Organization(OrganizationText),
            new OfficerName(OfficerNameText),
            new OfficerGender(MaleChecked),
            new OfficerTitle(OfficerTitleSelection),
            new OfficerGrammar(OfficerTitleSelection),
            new EmploymentDuration(EmploymentDurationText),
            new DurationType(DurationTypeSelection),
            new TargetAddress(TargetAddressText),
            new TargetDescription(TargetDescriptionText),
            new SearchWarrantReason(SearchWarrantReasonText),
            new SearchWarrantContent(SearchWarrantContentText),
        };

        return data;
    }

    [RelayCommand]
    public void GenerateWarrantDocument()
    {
        if (!InputsAreValid())
        {
            return;
        }

        // TODO: Testing only - correct inputs to method call.
        DocumentGenerator.GenerateDocument("C:/Temp/template.docx", OutputFileNameText, AssembleData());
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

        if (TargetAddressText == string.Empty)
        {
            result = false;
            TargetAddressBorder = Brushes.Red;
        }

        if (TargetDescriptionText == string.Empty)
        {
            result = false;
            TargetDescriptionBorder = Brushes.Red;
        }

        if (SearchWarrantReasonText == string.Empty)
        {
            result = false;
            SearchWarrantReasonBorder = Brushes.Red;
        }

        if (SearchWarrantContentText == string.Empty)
        {
            result = false;
            SearchWarrantContentBorder = Brushes.Red;
        }

        if (OutputFileNameText == string.Empty)
        {
            result = false;
            OutputFileNameBorder = Brushes.Red;
        }

        return result;
    }
}

