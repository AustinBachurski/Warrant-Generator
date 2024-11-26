namespace WarrantGenerator.Interfaces;

public interface IAdministrativeData
{
    public string OutputFile { get; }
    public string OfficerName { get; }
    public string ReportNumber { get; }
    public string PawnBrokerName { get; }
    public string PawnBrokerAddress { get; }
    public string SuspectName { get; }
    public string ItemsPawned { get; }
}

