using System.Diagnostics;
using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(ResidenceContentViewModel model)
    {
        GenerateDocument = ResidenceDocument;

#pragma warning disable CS8629  // model values are checked for null prior to construction call.
        _outputPath += ValidFileName(model.OutputFileNameText);
        _officerName = model.OfficerNameText;
        _officerRank = GetOfficerRank(model);
        _officerSubjectivePronoun = SubjectivePronoun(model.OfficerGenderSelection);
        _officerPosessivePronoun = PosessivePronoun(model.OfficerGenderSelection);
        _employmentDuration = ((decimal)model.EmploymentDurationValue).ToString("N0");
        _employmentDurationType = model.DurationTypeSelection;
        _courtDistrict = model.CourtDistrictSelection;
        _utilizeSWAT = model.SWATChecked;
        _utilizeCrimeUnit = model.CrimeUnitChecked;
        _requestToSeal = model.SealChecked;
        _telephonic = model.TelephonicChecked;
        _residenceAddress = model.ResidenceAddressText;
        _residenceDescription = RemoveTrailingPunctuation(model.ResidenceDescriptionText);
        _crimesCombined = CrimesCombinedAsString(model.Crimes);
        _crimeCodes = CrimeCodesAsString(model.Crimes);
        _crimeDescriptions = CrimeDescriptionsAsString(model.Crimes);
        _crimeGrammar = model.Crimes.Count > 1 ? "crimes" : "crime";
        _probableCause = model.ProbableCauseText;
        _seizableProperty = LowercaseStartAndRemoveTrailingPunctuation(model.SeizablePropertyText);
        _generateWarrantApplicationDocument = model.SearchWarrantApplicationChecked;
        _generateWarrantDocument = model.SearchWarrantChecked;
#pragma warning restore CS8629
    }

}

