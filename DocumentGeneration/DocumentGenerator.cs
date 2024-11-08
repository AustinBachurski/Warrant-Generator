using WarrantGenerator.Constants;

using DocumentFormat.OpenXml.Wordprocessing;
using System;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public delegate string DocumentDelegate();
    public DocumentDelegate GenerateDocument;

    private Body _body = new();

    private readonly string _outputPath = Environment.GetEnvironmentVariable("DOCUMENT_OUTPUT_PATH") ?? "./";
    private readonly string _todaysDate = FormattedDateString();
    private readonly string _officerName = string.Empty;
    private readonly string _officerTitle = string.Empty;
    private readonly string _officerSubjectivePronoun = string.Empty;
    private readonly string _officerPosessivePronoun = string.Empty;
    private readonly string _organization = Environment.GetEnvironmentVariable("ORGANIZATION") ?? ConstantData.KPD;
    private readonly string _courtDistrict = string.Empty;
    private readonly string _reportNumber = string.Empty;
    private readonly string _pawnBrokerName = string.Empty;
    private readonly string _pawnBrokerAddress = string.Empty;
    private readonly string _suspectName = string.Empty;
    private readonly string _itemsPawned = string.Empty;
    private readonly string _warrantSignedBy = string.Empty;
    private readonly string _searchableProperty = string.Empty;
    private readonly string _signedDate = string.Empty;
    private readonly string _servedDate = string.Empty;
    private readonly string _seizedProperty = string.Empty;
    private readonly bool _generateReturnAndRequestDocument = false;
    private readonly bool _generateInventoryDocument = false;
    private readonly bool _generateOrderDocument = false;
}

