using CommunityToolkit.Mvvm.ComponentModel;


namespace WarrantGenerator.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public AdministrativeContentViewModel AdministrativeTab { get; } = new();
    public ReturnInventoryContentViewModel ReturnInventoryTab { get; } = new();
    public ResidenceContentViewModel ResidenceTab { get; } = new();
    public VehicleContentViewModel VehicleTab { get; } = new();
    public DnaContentViewModel DnaTab { get; } = new();
    public GsrContentViewModel GsrTab { get; } = new();
    public SubpoenaContentViewModel SubpoenaTab { get; } = new();
    public SocialMediaContentViewModel SocialMediaTab { get; } = new();

}

