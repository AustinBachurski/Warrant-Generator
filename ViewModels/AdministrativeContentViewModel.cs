using WarrantGenerator.Constants;
using WarrantGenerator.DocumentGeneration;

using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.IO;


namespace WarrantGenerator.ViewModels;

public partial class AdministrativeContentViewModel : ObservableObject
{
    [ObservableProperty]
    private IBrush _officerNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _officerNameText = Environment.GetEnvironmentVariable(EnVars.OfficerName) ?? string.Empty;

    partial void OnOfficerNameTextChanged(string value)
    {
        OfficerNameBorder = Brushes.Transparent;
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
    private IBrush _pawnBrokerNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _pawnBrokerNameText = string.Empty;

    partial void OnPawnBrokerNameTextChanged(string value)
    {
        PawnBrokerNameBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _pawnBrokerAddressBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _pawnBrokerAddressText = string.Empty;

    partial void OnPawnBrokerAddressTextChanged(string value)
    {
        PawnBrokerAddressBorder = Brushes.Transparent;
    }

    [ObservableProperty]
    private IBrush _suspectNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _suspectNameText = string.Empty;

    partial void OnSuspectNameTextChanged(string value)
    {
        SuspectNameBorder = Brushes.Transparent;
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
    private IBrush _itemsPawnedBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _itemsPawnedText = string.Empty;

    partial void OnItemsPawnedTextChanged(string value)
    {
        ItemsPawnedBorder = Brushes.Transparent;
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

        if (ReportNumberText == string.Empty)
        {
            result = false;
            ReportNumberBorder = Brushes.Red;
        }

        if (PawnBrokerNameText == string.Empty)
        {
            result = false;
            PawnBrokerNameBorder = Brushes.Red;
        }

        if (PawnBrokerAddressText == string.Empty)
        {
            result = false;
            PawnBrokerAddressBorder = Brushes.Red;
        }

        if (SuspectNameText == string.Empty)
        {
            result = false;
            SuspectNameBorder = Brushes.Red;
        }

        if (ItemsPawnedText == string.Empty)
        {
            result = false;
            ItemsPawnedBorder = Brushes.Red;
        }

        if (OutputFileNameText == string.Empty)
        {
            result = false;
            OutputFileNameBorder = Brushes.Red;
        }

        return result;
    }
}

