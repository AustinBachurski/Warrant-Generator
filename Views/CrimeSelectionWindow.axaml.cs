using Avalonia.Controls;
using WarrantGenerator.ViewModels;

namespace WarrantGenerator.Views;

public partial class CrimeSelectionWindow : Window
{
    public CrimeSelectionWindow()
    {
        InitializeComponent();
    }

    public CrimeSelectionWindow(MainWindowViewModel mainViewModel) : this()
    {
        DataContext = new CrimeSelectionViewModel(mainViewModel, this);
    }
}

