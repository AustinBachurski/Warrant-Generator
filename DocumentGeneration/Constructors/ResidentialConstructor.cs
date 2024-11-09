using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(ResidentialContentViewModel model)
    {
        GenerateDocument = ResidentialDocument;

        _outputPath += ValidFileName(model.OutputFileNameText);
        _officerName = model.OfficerNameText;
        _officerRank = GetOfficerRank(model);
        _officerSubjectivePronoun = SubjectivePronoun(model.OfficerGenderSelection);
        _officerPosessivePronoun = PosessivePronoun(model.OfficerGenderSelection);
        _employmentDuration = model.EmploymentDurationText;
        _employmentDurationType = model.DurationTypeSelection;
        _courtDistrict = model.CourtDistrictSelection;
        _utilizeSWAT = model.SWATChecked;
        _utilizeCrimeUnit = model.CrimeUnitChecked;
        _residenceAddress = model.ResidenceAddressText;
        _residenceDescription = model.ResidenceDescriptionText;
        _crimesCombined = CrimesCombinedAsString(model.Crimes);
        _crimeCodes = CrimeCodesAsString(model.Crimes);
        _crimeDescriptions = CrimeDescriptionsAsString(model.Crimes);
        _crimeGrammar = model.Crimes.Count > 1 ? "crime" : "crimes";
        _probableCause = model.ProbableCauseText;
        _seizableProperty = model.SeizablePropertyText;
    }
}

