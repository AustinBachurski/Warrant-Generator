using WarrantGenerator.ViewModels;

using System.Diagnostics;



namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(SocialMediaContentViewModel model)
    {
        GenerateDocument = SocialMediaDocument;

#pragma warning disable CS8629  // model values are checked for null prior to construction call.
        _outputPath += ValidFileName(model.OutputFileNameText);
        _officerName = model.OfficerNameText;
        _officerRank = GetOfficerRank(model);
        _officerSubjectivePronoun = SubjectivePronoun(model.OfficerGenderSelection);
        _officerPosessivePronoun = PosessivePronoun(model.OfficerGenderSelection);
        _employmentDuration = ((decimal)model.EmploymentDurationValue).ToString("N0");
        _employmentDurationType = model.DurationTypeSelection;
        _courtDistrict = model.CourtDistrictSelection;
        _startDate = FormattedDateString(model.StartDateSelection
            ?? throw new UnreachableException("model.StartDateSelection was null."));
        _socialMediaPlatform = model.PlatformSelection;
        _requestToSeal = model.SealChecked;
        _requestToDelayNotification = model.DelayChecked;
        _accountNamesCombined = AccountDataCombinedAsString(model.Accounts);
        _accountURLs = AccountURLsCombinedAsString(model.Accounts);
        _individual = model.Accounts.Count > 1 ? "individuals" : "individual";
        _account = model.Accounts.Count > 1 ? "accounts" : "account";
        _isOrAre = model.Accounts.Count > 1 ? "are" : "is";
        _certainAccounts = model.Accounts.Count > 1 ? "certain accounts" : "a certain account";
        _crimesCombined = CrimesCombinedAsString(model.Crimes);
        _crimeCodes = CrimeCodesAsString(model.Crimes);
        _crimeDescriptions = CrimeDescriptionsAsString(model.Crimes);
        _crimeGrammar = model.Crimes.Count > 1 ? "crimes" : "crime";
        _probableCause = model.ProbableCauseText;
        _legalCriteriaForOffenses = model.LegalCriteriaText;
        _generateWarrantApplicationDocument = model.SearchWarrantApplicationChecked;
        _generateWarrantDocument = model.SearchWarrantChecked;
#pragma warning restore CS8629
    }

}

