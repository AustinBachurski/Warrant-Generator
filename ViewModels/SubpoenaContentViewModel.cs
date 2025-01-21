using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.Interfaces;
using WarrantGenerator.WarrantDocument.Documents;

using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System;
using System.IO;


namespace WarrantGenerator.ViewModels;

public partial class SubpoenaContentViewModel : ObservableObject
{
    public string[] AttorneyGender { get; } = ConstantData.Genders;

    [ObservableProperty]
    private IBrush _trappedDateBorder = Brushes.Transparent;

    [ObservableProperty]
    private DateTimeOffset? _trappedDateSelection = null;

    partial void OnTrappedDateSelectionChanged(DateTimeOffset? value)
    {
        TrappedDateBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _startTimeBorder = Brushes.Transparent;

    [ObservableProperty]
    private TimeSpan? _startTimeSelection = null;

    partial void OnStartTimeSelectionChanged(TimeSpan? value)
    {
        StartTimeBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _endTimeBorder = Brushes.Transparent;

    [ObservableProperty]
    private TimeSpan? _endTimeSelection = null;

    partial void OnEndTimeSelectionChanged(TimeSpan? value)
    {
        EndTimeBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _attorneyNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _attorneyNameText = string.Empty;

    partial void OnAttorneyNameTextChanged(string value)
    {
        AttorneyNameBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _attorneyGenderBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _attorneyGenderSelection = string.Empty;

    partial void OnAttorneyGenderSelectionChanged(string value)
    {
        AttorneyGenderBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _phoneNumberBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _phoneNumberText = string.Empty;

    partial void OnPhoneNumberTextChanged(string value)
    {
        PhoneNumberBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _reportNumberBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _reportNumberText = string.Empty;

    partial void OnReportNumberTextChanged(string value)
    {
        ReportNumberBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _companyNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _companyNameText = string.Empty;

    partial void OnCompanyNameTextChanged(string value)
    {
        CompanyNameBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _companyAddressBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _companyAddressText = string.Empty;

    partial void OnCompanyAddressTextChanged(string value)
    {
        CompanyAddressBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _cityStateZipBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _cityStateZipText = string.Empty;

    partial void OnCityStateZipTextChanged(string value)
    {
        CityStateZipBorder = Brushes.Transparent;
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
    private string _flyoutMessage = string.Empty;

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
            var document = new SubpoenaDocument(new SubpoenaData(this));
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

        if (TrappedDateSelection == null)
        {
            result = false;
            TrappedDateBorder = Brushes.Red;
        }

        if (StartTimeSelection == null)
        {
            result = false;
            StartTimeBorder = Brushes.Red;
        }

        if (EndTimeSelection == null)
        {
            result = false;
            EndTimeBorder = Brushes.Red;
        }

        if (AttorneyNameText == string.Empty)
        {
            result = false;
            AttorneyNameBorder = Brushes.Red;
        }

        if (AttorneyGenderSelection == string.Empty)
        {
            result = false;
            AttorneyGenderBorder = Brushes.Red;
        }

        if (PhoneNumberText == string.Empty)
        {
            result = false;
            PhoneNumberBorder = Brushes.Red;
        }

        if (ReportNumberText == string.Empty)
        {
            result = false;
            ReportNumberBorder = Brushes.Red;
        }

        if (CompanyNameText == string.Empty)
        {
            result = false;
            CompanyNameBorder = Brushes.Red;
        }

        if (CompanyAddressText == string.Empty)
        {
            result = false;
            CompanyAddressBorder = Brushes.Red;
        }

        if (CityStateZipText == string.Empty)
        {
            result = false;
            CityStateZipBorder = Brushes.Red;
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
