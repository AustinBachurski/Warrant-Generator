using WarrantGenerator.Interfaces;
using WarrantGenerator.ViewModels;


namespace WarrantGenerator.DTOs;

public class ResidenceData(ResidenceContentViewModel model) : IResidenceData
{
    public string OutputFile => _outputFile;
    public string OfficerName => _officerName;
    public string OfficerRank => _officerRank;
    public string OfficerSubjectivePronoun => _officerSubjectivePronoun;
    public string OfficerPosessivePronoun => _officerPosessivePronoun;
    public string EmploymentDuration => _employmentDuration;
    public string EmploymentDurationType => _employmentDurationType;
    public string CourtDistrict => _courtDistrict;
    public string ResidenceAddress => _residenceAddress;
    public string ResidenceDescription => _residenceDescription;
    public MCACrime[] Crimes => _crimes;
    public string CrimeGrammar => _crimeGrammar;
    public string ProbableCause => _probableCause;
    public string SeizableProperty => _seizableProperty;
    public string TodaysDate => _todaysDate;
    public bool UtilizeSWAT => _utilizeSWAT;
    public bool UtilizeCrimeUnit => _utilizeCrimeUnit;
    public bool RequestToSeal => _requestToSeal;
    public bool Telephonic => _telephonic;
    public bool GenerateWarrantApplicationDocument => _generateWarrantApplicationDocument;
    public bool GenerateWarrantDocument => _generateWarrantDocument;

#pragma warning disable CS8629  // model values are checked for null prior to construction call.
    private string _outputFile = FormatContent.ValidFileName(model.OutputFileNameText);
    private string _officerName = model.OfficerNameText;
    private string _officerRank = FormatContent.GetOfficerRank(model);
    private string _officerSubjectivePronoun = FormatContent.SubjectivePronoun(model.OfficerGenderSelection);
    private string _officerPosessivePronoun = FormatContent.PosessivePronoun(model.OfficerGenderSelection);
    private string _employmentDuration = ((decimal)model.EmploymentDurationValue).ToString("N0");
    private string _employmentDurationType = model.DurationTypeSelection;
    private string _courtDistrict = model.CourtDistrictSelection;
    private string _residenceAddress = model.ResidenceAddressText;
    private string _residenceDescription = FormatContent.RemoveTrailingPunctuation(model.ResidenceDescriptionText);
    private MCACrime[] _crimes = [.. model.Crimes];
    private string _crimeGrammar = model.Crimes.Count > 1 ? "crimes" : "crime";
    private string _probableCause = model.ProbableCauseText;
    private string _seizableProperty = FormatContent.LowercaseStartAndRemoveTrailingPunctuation(model.SeizablePropertyText);
    private readonly string _todaysDate = FormatContent.FormattedDateString();
    private bool _utilizeSWAT = model.SWATChecked;
    private bool _utilizeCrimeUnit = model.CrimeUnitChecked;
    private bool _requestToSeal = model.SealChecked;
    private bool _telephonic = model.TelephonicChecked;
    private bool _generateWarrantApplicationDocument = model.SearchWarrantApplicationChecked;
    private bool _generateWarrantDocument = model.SearchWarrantChecked;
#pragma warning restore CS8629

}

