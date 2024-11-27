using WarrantGenerator.ViewModels;

using Avalonia.Controls;

namespace WarrantGenerator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(this);
    }

}

