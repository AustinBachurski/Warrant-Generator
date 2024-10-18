using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WarrantGenerator.ViewModels;

partial class AddCrimeDialogViewModel(MainWindowViewModel mainViewModel, AddCrimeDialog window) : ObservableObject
{
    private MainWindowViewModel _mainWindowViewModel = mainViewModel;
    private AddCrimeDialog _window = window;

    [ObservableProperty]
    private IBrush _mcaCodeBorder = Brushes.Transparent;

    [ObservableProperty]
    private IBrush _descriptionBorder = Brushes.Transparent;

    [ObservableProperty]
    private string _mcaCodeText = string.Empty;

    [ObservableProperty]
    private string _descriptionText = string.Empty;

    partial void OnMcaCodeTextChanged(string value)
    {
        McaCodeBorder = Brushes.Transparent;
    }

    partial void OnDescriptionTextChanged(string value)
    {
        DescriptionBorder = Brushes.Transparent;
    }

    [RelayCommand]
    public void AddCrime()
    {
        if (!ValidateInput())
        {
            return;
        }

        _mainWindowViewModel.Crimes.Add(new(McaCodeText, DescriptionText));
        _mainWindowViewModel.CrimesBorder = Brushes.Transparent;

        _window.Close();
    }

    private bool ValidateInput()
    {
        bool result = true;

        if (McaCodeText == string.Empty)
        {
            result = false;
            McaCodeBorder = Brushes.Red;
        }

        if (DescriptionText == string.Empty)
        {
            result = false;
            DescriptionBorder = Brushes.Red;
        }

        return result;
    }
}

