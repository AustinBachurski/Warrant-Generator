using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WarrantGenerator.ViewModels;

public partial class DnaContentViewModel : ObservableObject
{
    [ObservableProperty]
    private IBrush _suspectNameBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _suspectNameText = string.Empty;

    [ObservableProperty]
    private IBrush _suspectDriversLicenseBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _suspectDriversLicenseText = string.Empty;

    [ObservableProperty]
    private IBrush _suspectDateOfBirthBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _suspectDateOfBirthText = string.Empty;

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



}
