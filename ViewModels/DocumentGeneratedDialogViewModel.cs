using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WarrantGenerator.Views;

namespace WarrantGenerator.ViewModels;

public class DocumentGeneratedDialogViewModel : ObservableObject
{
    DocumentedGeneratedDialog _window;

    public DocumentGeneratedDialogViewModel(DocumentedGeneratedDialog window) => _window = window;
}
