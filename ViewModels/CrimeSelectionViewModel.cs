using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WarrantGenerator.Data;
using WarrantGenerator.DTOs;
using WarrantGenerator.Views;

namespace WarrantGenerator.ViewModels;

partial class CrimeSelectionViewModel(MainWindowViewModel mainViewModel, CrimeSelectionWindow window) : ObservableObject
{
    private MainWindowViewModel _mainWindowViewModel = mainViewModel;
    private CrimeSelectionWindow _window = window;

    public ObservableCollection<MCATreeNode> RootMCATreeNodes { get; } = MontanaCodeAnnotated.GetMCAData();
}

