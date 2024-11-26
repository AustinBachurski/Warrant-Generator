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

public partial class ReturnInventoryContentViewModel : ObservableObject, IHasOfficerRank
{
    public string[] CourtDistrictTypes { get; } = ConstantData.CourtDistricts;
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
    private string _customOfficerRankText = ConstantData.DefaultOfficerRank;

    partial void OnCustomOfficerRankTextChanged(string value)
    {
        CustomOfficerRankBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private bool _customOfficerRankVisibility = false;

    [ObservableProperty]
    private string _courtDistrictSelection = ConstantData.DefaultCourtSelection;

    [ObservableProperty]
    private IBrush _warrantSignedByBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _warrantSignedByText = string.Empty;

    partial void OnWarrantSignedByTextChanged(string value)
    {
        WarrantSignedByBorder = Brushes.Transparent;
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
    private IBrush _signedDateBorder = Brushes.Transparent;

    [ObservableProperty]
    private DateTimeOffset? _signedDateSelection = null;

    partial void OnSignedDateSelectionChanged(DateTimeOffset? value)
    {
        SignedDateBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _servedDateBorder = Brushes.Transparent;

    [ObservableProperty]
    private DateTimeOffset? _servedDateSelection = null;

    partial void OnServedDateSelectionChanged(DateTimeOffset? value)
    {
        ServedDateBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _seizedPropertyBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _seizedPropertyText = string.Empty;

    partial void OnSeizedPropertyTextChanged(string value)
    {
        SeizedPropertyBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _documentTypeCheckboxesBorder = Brushes.Transparent;

    [ObservableProperty]
    private bool _returnAndRequestChecked = true;

    partial void OnReturnAndRequestCheckedChanged(bool value)
    {
        if (value)
        {
            DocumentTypeCheckboxesBorder = Brushes.Transparent;
        }
    }

    [ObservableProperty]
    private bool _inventoryChecked = true;

    partial void OnInventoryCheckedChanged(bool value)
    {
        if (value)
        {
            DocumentTypeCheckboxesBorder = Brushes.Transparent;
        }
    }

    [ObservableProperty]
    private bool _orderChecked = true;

    partial void OnOrderCheckedChanged(bool value)
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
            var document = new ReturnInventoryDocument(new ReturnInventoryData(this));
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
            && (CustomOfficerRankText == ConstantData.DefaultOfficerRank
                || CustomOfficerRankText == string.Empty))
        {
            result = false;
            CustomOfficerRankBorder = Brushes.Red;
        }

        if (WarrantSignedByText == string.Empty)
        {
            result = false;
            WarrantSignedByBorder = Brushes.Red;
        }

        if (SeizablePropertyText == string.Empty)
        {
            result = false;
            SeizablePropertyBorder = Brushes.Red;
        }

        if (SignedDateSelection == null)
        {
            result = false;
            SignedDateBorder = Brushes.Red;
        }

        if (ServedDateSelection == null)
        {
            result = false;
            ServedDateBorder = Brushes.Red;
        }

        if (SeizedPropertyText == string.Empty)
        {
            result = false;
            SeizedPropertyBorder = Brushes.Red;
        }

        if (!ReturnAndRequestChecked && !InventoryChecked && !OrderChecked)
        {
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

