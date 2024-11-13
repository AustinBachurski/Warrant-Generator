using WarrantGenerator.Constants;

using DocumentFormat.OpenXml.Wordprocessing;
using System;
using DocumentFormat.OpenXml.Packaging;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public delegate string DocumentDelegate();
    public DocumentDelegate GenerateDocument;

    private MainDocumentPart _document = null;
    private Body _body = null;

    private readonly string _organization = ConstantData.KPD;
    private readonly string _todaysDate = FormattedDateString();
    private readonly string _outputPath = Environment.GetEnvironmentVariable(EnVars.DocumentOutPath) ?? "./";
    private readonly string _officerName = string.Empty;
    private readonly string _officerRank = string.Empty;
    private readonly string _officerSubjectivePronoun = string.Empty;
    private readonly string _officerPosessivePronoun = string.Empty;
    private readonly string _employmentDuration = string.Empty;
    private readonly string _employmentDurationType = string.Empty;
    private readonly string _courtDistrict = string.Empty;
    private readonly string _reportNumber = string.Empty;
    private readonly string _pawnBrokerName = string.Empty;
    private readonly string _pawnBrokerAddress = string.Empty;
    private readonly string _suspectName = string.Empty;
    private readonly string _itemsPawned = string.Empty;
    private readonly string _warrantSignedBy = string.Empty;
    private readonly string _signedDate = string.Empty;
    private readonly string _servedDate = string.Empty;
    private readonly string _startDate = string.Empty;
    private readonly string _socialMediaPlatform = string.Empty;
    private readonly string _seizedProperty = string.Empty;
    private readonly string _residenceAddress = string.Empty;
    private readonly string _residenceDescription = string.Empty;
    private readonly string _accountNamesCombined = string.Empty;
    private readonly string _accountURLs = string.Empty;
    private readonly string _crimesCombined = string.Empty;
    private readonly string _crimeCodes = string.Empty;
    private readonly string _crimeDescriptions = string.Empty;
    private readonly string _crimeGrammar = string.Empty;
    private readonly string _probableCause = string.Empty;
    private readonly string _seizableProperty = string.Empty;
    private readonly string _individual = string.Empty;
    private readonly string _account = string.Empty;


    private readonly bool _generateReturnAndRequestDocument = false;
    private readonly bool _generateInventoryDocument = false;
    private readonly bool _generateOrderDocument = false;
    private readonly bool _generateWarrantApplicationDocument = false;
    private readonly bool _generateWarrantDocument = false;
    private readonly bool _utilizeSWAT = false;
    private readonly bool _utilizeCrimeUnit = false;
    private readonly bool _requestToSeal = false;
    private readonly bool _requestToDelayNotification = false;
    private readonly bool _telephonic = false;

}

