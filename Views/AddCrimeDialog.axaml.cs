using Avalonia.Controls;
using WarrantGenerator.ViewModels;

namespace WarrantGenerator;

public partial class AddCrimeDialog : Window
{
    public AddCrimeDialog()
    {
        InitializeComponent();
    }

    public AddCrimeDialog(MainWindowViewModel mainViewModel) : this()
    {
        DataContext = new AddCrimeDialogViewModel(mainViewModel, this);
    }

}
