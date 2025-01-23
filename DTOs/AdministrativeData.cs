using WarrantGenerator.Interfaces;
using WarrantGenerator.ViewModels;


namespace WarrantGenerator.DTOs;

public class AdministrativeData(AdministrativeContentViewModel model) : IAdministrativeData
{
    public string OutputFile => _outputFile;
    public string OfficerName => _officerName;
    public string ReportNumber => _reportNumber;
    public string PawnBrokerName => _pawnBrokerName;
    public string PawnBrokerAddress => _pawnBrokerAddress;
    public string SuspectName => _suspectName;
    public string ItemsPawned => _itemsPawned;
    public string TodaysDate => _todaysDate;

    private readonly string _outputFile = FormattedContent.ValidFileName(model.OutputFileNameText);
    private readonly string _officerName = model.OfficerNameText;
    private readonly string _reportNumber = model.ReportNumberText;
    private readonly string _pawnBrokerName = model.PawnBrokerNameText;
    private readonly string _pawnBrokerAddress = model.PawnBrokerAddressText;
    private readonly string _suspectName = model.SuspectNameText;
    private readonly string _itemsPawned = model.ItemsPawnedText;
    private readonly string _todaysDate = FormattedContent.FormattedDateString();

}

