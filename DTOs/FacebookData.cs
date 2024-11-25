using WarrantGenerator.Interfaces;
using WarrantGenerator.ViewModels;

using System.Diagnostics;


namespace WarrantGenerator.DTOs;

public class FacebookData(SocialMediaContentViewModel model) : IFacebookData
{
    public string CourtDistrict => _courtDistrict;
    public string EmploymentDuration => _employmentDuration;
    public string EmploymentDurationType => _employmentDurationType;
    public string OfficerName => _officerName;
    public string OfficerRank => _officerRank;
    public string OfficerSubjectivePronoun => _officerSubjectivePronoun;
    public string OfficerPosessivePronoun => _officerPosessivePronoun;
    public string OutputFile => _outputFile;
    public string StartDate => _startDate;
    public string TodaysDate => _todaysDate;
    public string Individual => _individual;
    public string Account => _account;
    public string IsOrAre => _isOrAre;
    public string CertainAccounts => _certainAccounts;
    public string CrimeGrammar => _crimeGrammar;
    public string ProbableCause => _probableCause;
    public string LegalCriteriaForOffenses => _legalCriteriaForOffenses;
    public bool GenerateApplicationDocument => _generateApplication;
    public bool GenerateWarrantDocument => _generateWarrant;
    public bool RequestToSeal => _requestToSeal;
    public bool RequestToDelayNotification => _requestToDelayNotification;
    public MCACrime[] Crimes => _crimes;
    public SocialMediaProfile[] Profiles => _profiles;

#pragma warning disable CS8629  // model values are checked for null prior to construction call.
    private readonly string _courtDistrict = model.CourtDistrictSelection;
    private readonly string _employmentDuration = ((decimal)model.EmploymentDurationValue).ToString("N0");
    private readonly string _employmentDurationType = model.DurationTypeSelection;
    private readonly string _officerName = model.OfficerNameText;
    private readonly string _officerRank = FormatContent.GetOfficerRank(model);
    private readonly string _officerSubjectivePronoun = FormatContent.SubjectivePronoun(model.OfficerGenderSelection);
    private readonly string _officerPosessivePronoun = FormatContent.PosessivePronoun(model.OfficerGenderSelection);
    private readonly string _outputFile = FormatContent.ValidFileName(model.OutputFileNameText);
    private readonly string _startDate = FormatContent.FormattedDateString(model.StartDateSelection
        ?? throw new UnreachableException("model.StartDateSelection was null."));
    private readonly string _todaysDate = FormatContent.FormattedDateString();
    private readonly string _individual = model.Accounts.Count > 1 ? "individuals" : "individual";
    private readonly string _account = model.Accounts.Count > 1 ? "accounts" : "account";
    private readonly string _isOrAre = model.Accounts.Count > 1 ? "are" : "is";
    private readonly string _certainAccounts = model.Accounts.Count > 1 ? "certain accounts" : "a certain account";
    private readonly string _crimeGrammar = model.Crimes.Count > 1 ? "crimes" : "crime";
    private readonly string _probableCause = model.ProbableCauseText;
    private readonly string _legalCriteriaForOffenses = model.LegalCriteriaText;
    private readonly bool _generateApplication = model.SearchWarrantApplicationChecked;
    private readonly bool _generateWarrant = model.SearchWarrantChecked;
    private readonly bool _requestToSeal = model.SealChecked;
    private readonly bool _requestToDelayNotification = model.DelayChecked;
    private readonly MCACrime[] _crimes = [.. model.Crimes];
    private readonly SocialMediaProfile[] _profiles = [.. model.Accounts];
#pragma warning restore CS8629

}

