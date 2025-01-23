using WarrantGenerator.Views;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace WarrantGenerator.ViewModels;

public partial class MainWindowViewModel(MainWindow window) : ObservableObject
{
    public AdministrativeContentViewModel AdministrativeTab { get; } = new();
    public ReturnInventoryContentViewModel ReturnInventoryTab { get; } = new();
    public ResidenceContentViewModel ResidenceTab { get; } = new();
    public VehicleContentViewModel VehicleTab { get; } = new();
    public DnaContentViewModel DnaTab { get; } = new();
    public GsrContentViewModel GsrTab { get; } = new();
    public SubpoenaContentViewModel SubpoenaTab { get; } = new();
    public SocialMediaContentViewModel SocialMediaTab { get; } = new();

    [RelayCommand]
    public void Exit()
    {
        _application.Close();
    }

    [RelayCommand]
    public static void SpawnAboutWindow()
    {
        var window = new AboutWindow();
        window.Show();
    }

    [RelayCommand]
    public static void SpawnSetupWindow()
    {
        var window = new SetupWindow();
        window.Show();
    }

    private readonly MainWindow _application = window;

}

