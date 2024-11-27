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
    private readonly string _outputFile = FormattedContent.ValidFileName(model.OutputFileNameText);
    private readonly string _officerName = model.OfficerNameText;
    private readonly string _officerRank = FormattedContent.GetOfficerRank(model);
    private readonly string _officerSubjectivePronoun = FormattedContent.SubjectivePronoun(model.OfficerGenderSelection);
    private readonly string _officerPosessivePronoun = FormattedContent.PosessivePronoun(model.OfficerGenderSelection);
    private readonly string _employmentDuration = ((decimal)model.EmploymentDurationValue).ToString("N0");
    private readonly string _employmentDurationType = model.DurationTypeSelection;
    private readonly string _courtDistrict = model.CourtDistrictSelection;
    private readonly string _residenceAddress = model.ResidenceAddressText;
    private readonly string _residenceDescription = FormattedContent.RemoveTrailingPunctuation(model.ResidenceDescriptionText);
    private readonly MCACrime[] _crimes = [.. model.Crimes];
    private readonly string _crimeGrammar = model.Crimes.Count > 1 ? "crimes" : "crime";
    private readonly string _probableCause = model.ProbableCauseText;
    private readonly string _seizableProperty = FormattedContent.LowercaseStartAndRemoveTrailingPunctuation(model.SeizablePropertyText);
    private readonly string _todaysDate = FormattedContent.FormattedDateString();
    private readonly bool _utilizeSWAT = model.SWATChecked;
    private readonly bool _utilizeCrimeUnit = model.CrimeUnitChecked;
    private readonly bool _requestToSeal = model.SealChecked;
    private readonly bool _telephonic = model.TelephonicChecked;
    private readonly bool _generateWarrantApplicationDocument = model.SearchWarrantApplicationChecked;
    private readonly bool _generateWarrantDocument = model.SearchWarrantChecked;
#pragma warning restore CS8629

}

