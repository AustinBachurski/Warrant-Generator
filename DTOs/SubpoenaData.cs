using CommunityToolkit.Mvvm.ComponentModel;
using WarrantGenerator.Constants;
using WarrantGenerator.Interfaces;
using WarrantGenerator.ViewModels;


namespace WarrantGenerator.DTOs;

public class SubpoenaData(SubpoenaContentViewModel model) : ISubpoenaData
{
    public string OutputFile => _outputFile;
    public string DateTrapped => _dateTrapped;
    public string StartTime => _startTime;
    public string EndTime => _endTime;
    public string AttourneyName => _attourneyName;
    public string AttourneyGender => _attourneyGender;
    public string PhoneNumber => _phoneNumber;
    public string ReportNumber => _reportNumber;
    public string CompanyName => _companyName;
    public string CompanyAddress => _companyAddress;
    public string CityStateZip => _cityStateZip;
    public bool GenerateWarrantApplicationDocument => _generateWarrantApplicationDocument;
    public bool GenerateWarrantDocument => _generateWarrantDocument;

    private readonly string _outputFile = FormattedContent.ValidFileName(model.OutputFileNameText);
    private readonly string _dateTrapped = "TODO";
    private readonly string _startTime = "TODO";
    private readonly string _endTime = "TODO";
    private readonly string _attourneyName = "TODO";
    private readonly string _attourneyGender = "TODO";
    private readonly string _phoneNumber = "TODO";
    private readonly string _reportNumber = "TODO";
    private readonly string _companyName = "TODO";
    private readonly string _companyAddress = "TODO";
    private readonly string _cityStateZip = "TODO";
    private readonly bool _generateWarrantApplicationDocument = model.SearchWarrantApplicationChecked;
    private readonly bool _generateWarrantDocument = model.SearchWarrantChecked;

}

