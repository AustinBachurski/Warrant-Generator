using CommunityToolkit.Mvvm.ComponentModel;
using WarrantGenerator.Constants;
using WarrantGenerator.Interfaces;
using WarrantGenerator.ViewModels;

using System.Diagnostics;

namespace WarrantGenerator.DTOs;

public class SubpoenaData(SubpoenaContentViewModel model) : ISubpoenaData
{
    public string OutputFile => _outputFile;
    public string DateTrapped => _dateTrapped;
    public string StartTime => _startTime;
    public string EndTime => _endTime;
    public string AttorneyName => _attourneyName;
    public string AttorneyGender => _attourneyGender;
    public string PhoneNumber => _phoneNumber;
    public string ReportNumber => _reportNumber;
    public string CompanyName => _companyName;
    public string CompanyAddress => _companyAddress;
    public string CityStateZip => _cityStateZip;
    public string TodaysDate => _todaysDate;
    public bool GenerateWarrantApplicationDocument => _generateWarrantApplicationDocument;
    public bool GenerateWarrantDocument => _generateWarrantDocument;

    private readonly string _outputFile = FormattedContent.ValidFileName(model.OutputFileNameText);
    private readonly string _dateTrapped = FormattedContent.ShortDateString(model.TrappedDateSelection
        ?? throw new UnreachableException("model.TrappedDateSelection was null."));
    private readonly string _startTime = FormattedContent.TimeString(model.StartTimeSelection
        ?? throw new UnreachableException("model.StartTimeselection was null."));
    private readonly string _endTime = FormattedContent.TimeString(model.EndTimeSelection
        ?? throw new UnreachableException("model.EndTimeSelection was null."));
    private readonly string _attourneyName = model.AttorneyNameText;
    private readonly string _attourneyGender = model.AttorneyGenderSelection;
    private readonly string _phoneNumber = model.PhoneNumberText;
    private readonly string _reportNumber = model.ReportNumberText;
    private readonly string _companyName = model.CompanyNameText;
    private readonly string _companyAddress = model.CompanyAddressText;
    private readonly string _cityStateZip = model.CityStateZipText;
    private readonly string _todaysDate = FormattedContent.FormattedDateString();
    private readonly bool _generateWarrantApplicationDocument = model.SearchWarrantApplicationChecked;
    private readonly bool _generateWarrantDocument = model.SearchWarrantChecked;

}

