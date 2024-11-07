using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Media;
using WarrantGenerator.DocumentGeneration;
using System.IO;
using System;
using WarrantGenerator.Constants;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.ViewModels;

public partial class ReturnInventoryContentViewModel : ObservableObject, IHasOfficerTitle
{
    public string[] CourtDistrictTypes { get; } = ConstantData.CourtDistricts;
    public string[] OfficerTitles { get; } = ConstantData.OfficerTitles;

    [ObservableProperty]
    private IBrush _officerTitleBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _officerTitleSelection = string.Empty;

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

    [ObservableProperty]
    private IBrush _customOfficerTitleBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _customOfficerTitleText = ConstantData.DefaultOfficerTitle;

    [ObservableProperty]
    private bool _customOfficerTitleVisibility = false;

    [ObservableProperty]
    private IBrush _officerNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _officerNameText = string.Empty;

    partial void OnOfficerNameTextChanged(string value)
    {
        OfficerNameBorder = Brushes.Transparent;
    }

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
    private IBrush _searchablePropertyBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _searchablePropertyText = string.Empty;

    partial void OnSearchablePropertyTextChanged(string value)
    {
        SearchablePropertyBorder = Brushes.Transparent;
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

        if (WarrantSignedByText == string.Empty)
        {
            result = false;
            WarrantSignedByBorder = Brushes.Red;
        }

        if (SearchablePropertyText == string.Empty)
        {
            result = false;
            SearchablePropertyBorder = Brushes.Red;
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
