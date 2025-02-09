using WarrantGenerator.DTOs;


namespace WarrantGenerator.Interfaces;

public interface IResidenceData
{
    public string CourtDistrict { get; }
    public string CrimeGrammar { get; }
    public string EmploymentDuration { get; }
    public string EmploymentDurationType { get; }
    public string OutputFile { get; }
    public string OfficerName { get; }
    public string OfficerRank { get; }
    public string OfficerSubjectivePronoun { get; }
    public string OfficerPosessivePronoun { get; }
    public string ProbableCause { get; }
    public string ResidenceAddress { get; }
    public string ResidenceDescription { get; }
    public string SeizableProperty { get; }
    public string TodaysDate { get; }

    public bool GenerateWarrantApplicationDocument { get; }
    public bool GenerateWarrantDocument { get; }
    public bool RequestToSeal { get; }
    public bool Telephonic { get; }
    public bool UtilizeSWAT { get; }
    public bool UtilizeCrimeUnit { get; }

    public MCACrime[] Crimes { get; }

}

