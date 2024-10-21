using Avalonia.Controls;
using WarrantGenerator.ViewModels;

namespace WarrantGenerator.Views;

public partial class DocumentedGeneratedDialog : Window
{
    public DocumentedGeneratedDialog()
    {
        InitializeComponent();
        DataContext = new DocumentGeneratedDialogViewModel(this);
    }
}
