using Avalonia.Media;
using System.ComponentModel;
using Warrant_Generator.DTOs;
using WarrantGenerator.Document;
using WarrantGenerator.DTOs;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.ViewModels;

public partial class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private IBrush _organizationBorder = Brushes.Transparent;
    private string _organizationText = string.Empty;
    private IBrush _officerNameBorder = Brushes.Transparent;
    private string _officerNameText = string.Empty;
    private IBrush _officerTitleBorder = Brushes.Transparent;
    private string _officerTitleSelection = string.Empty;
    private IBrush _customOfficerTitleBorder = Brushes.Transparent;
    private string _customOfficerTitleText = "Enter Title";
    private bool _customOfficerTitleVisibility = false;
    private IBrush _employmentDurationBorder = Brushes.Transparent;
    private string _employmentDurationText = string.Empty;
    private IBrush _targetAddressBorder = Brushes.Transparent;
    private string _targetAddressText = string.Empty;
    private IBrush _targetDescriptionBorder = Brushes.Transparent;
    private string _targetDescriptionText = string.Empty;
    private IBrush _searchWarrantReasonBorder = Brushes.Transparent;
    private string _searchWarrantReasonText = string.Empty;
    private IBrush _searchWarrantContentBorder = Brushes.Transparent;
    private string _searchWarrantContentText = string.Empty;
    private IBrush _outputFileNameBorder = Brushes.Transparent;
    private string _outputFileNameText = string.Empty;

    public IBrush OrganizationBorder
    {
        get => _organizationBorder;
        set
        {
            if (_organizationBorder != value)
            {
                _organizationBorder = value;
                OnPropertyChanged(nameof(OrganizationBorder));
            }
        }
    }

    public string OrganizationText
    { 
        get => _organizationText;
        set
        {
            _organizationText = value;
            OrganizationBorder = Brushes.Transparent;
        }
    }

    public IBrush OfficerNameBorder
    {
        get => _officerNameBorder;
        set
        {
            if (_officerNameBorder != value)
            {
                _officerNameBorder = value;
                OnPropertyChanged(nameof(OfficerNameBorder));
            }
        }
    }

    public string OfficerNameText
    {
        get => _officerNameText;
        set
        {
            _officerNameText = value;
            OfficerNameBorder = Brushes.Transparent;
        }
    }

    public IBrush OfficerTitleBorder
    {
        get => _officerTitleBorder;
        set
        {
            if (_officerTitleBorder != value)
            {
                _officerTitleBorder = value;
                OnPropertyChanged(nameof(OfficerTitleBorder));
            }
        }
    }

    public string[] OfficerTitles { get; set; } = { "Captain", "Chief", "Detective", "Detective Sergeant", "Lieutenant", "Master Patrol Officer", "Officer", "Sergeant", "Other" };

    public string OfficerTitleSelection
    {
        get => _officerTitleSelection;
        set
        {
            if (value == "Other")
            {
                CustomOfficerTitleVisibility = true;
            }
            else
            {
                CustomOfficerTitleVisibility = false;
            }

            _officerTitleSelection = value;
            OfficerTitleBorder = Brushes.Transparent;
            CustomOfficerTitleBorder = Brushes.Transparent;
        }
    }

    public IBrush CustomOfficerTitleBorder
    {
        get => _customOfficerTitleBorder;
        set
        {
            if (_customOfficerTitleBorder != value)
            {
                _customOfficerTitleBorder = value;
                OnPropertyChanged(nameof(CustomOfficerTitleBorder));
            }
        }
    }

    public string CustomOfficerTitleText
    {
        get => _customOfficerTitleText;
        set
        {
            _customOfficerTitleText = value;
            CustomOfficerTitleBorder = Brushes.Transparent;
        }
    }

    public bool CustomOfficerTitleVisibility
    {
        get => _customOfficerTitleVisibility;
        set
        {
            if (_customOfficerTitleVisibility != value)
            {
                _customOfficerTitleVisibility = value;
                OnPropertyChanged(nameof(CustomOfficerTitleVisibility));
            }
        }
    }

    public IBrush EmploymentDurationBorder
    {
        get => _employmentDurationBorder;
        set
        {
            if (_employmentDurationBorder != value)
            {
                _employmentDurationBorder = value;
                OnPropertyChanged(nameof(EmploymentDurationBorder));
            }
        }
    }

    public string EmploymentDurationText
    {
        get => _employmentDurationText;
        set
        {
            _employmentDurationText = value;
            EmploymentDurationBorder = Brushes.Transparent;
        }
    }

    public string[] DurationTypes { get; set; } = { "years", "year", "months", "month", "days", "day" };

    public string DurationTypeSelection { get; set; } = "years";

    public IBrush TargetAddressBorder
    {
        get => _targetAddressBorder;
        set
        {
            if (_targetAddressBorder != value)
            {
                _targetAddressBorder = value;
                OnPropertyChanged(nameof(TargetAddressBorder));
            }
        }
    }

    public string TargetAddressText
    {
        get => _targetAddressText;
        set
        {
            _targetAddressText = value;
            TargetAddressBorder = Brushes.Transparent;
        }
    }

    public IBrush TargetDescriptionBorder
    {
        get => _targetDescriptionBorder;
        set
        {
            if (_targetDescriptionBorder != value)
            {
                _targetDescriptionBorder = value;
                OnPropertyChanged(nameof(TargetDescriptionBorder));
            }
        }
    }

    public string TargetDescriptionText
    {
        get => _targetDescriptionText;
        set
        {
            _targetDescriptionText = value;
            TargetDescriptionBorder = Brushes.Transparent;
        }
    }

    public IBrush SearchWarrantReasonBorder
    {
        get => _searchWarrantReasonBorder;
        set
        {
            if (_searchWarrantReasonBorder != value)
            {
                _searchWarrantReasonBorder = value;
                OnPropertyChanged(nameof(SearchWarrantReasonBorder));
            }
        }
    }

    public string SearchWarrantReasonText
    {
        get => _searchWarrantReasonText;
        set
        {
            _searchWarrantReasonText = value;
            SearchWarrantReasonBorder = Brushes.Transparent;
        }
    }

    public IBrush SearchWarrantContentBorder
    {
        get => _searchWarrantContentBorder;
        set
        {
            if (_searchWarrantContentBorder != value)
            {
                _searchWarrantContentBorder = value;
                OnPropertyChanged(nameof(SearchWarrantContentBorder));
            }
        }
    }

    public string SearchWarrantContentText
    {
        get => _searchWarrantContentText;
        set
        {
            _searchWarrantContentText = value;
            SearchWarrantContentBorder = Brushes.Transparent;
        }
    }

    public IBrush OutputFileNameBorder
    {
        get => _outputFileNameBorder;
        set
        {
            if (_outputFileNameBorder != value)
            {
                _outputFileNameBorder = value;
                OnPropertyChanged(nameof(OutputFileNameBorder));
            }
        }
    }

    public string OutputFileNameText
    {
        get => _outputFileNameText;
        set
        {
            _outputFileNameText = value;
            OutputFileNameBorder = Brushes.Transparent;
        }
    }

    public IReplacementData[] AssembleData()
    {
        IReplacementData[] data =
        {
            new ApplicationDate(),
            new Organization(OrganizationText),
            new OfficerName(OfficerNameText),
            new OfficerTitle(OfficerTitleSelection),
            new OfficerGrammar(OfficerTitleSelection),
            new EmploymentDuration(EmploymentDurationText),
            new DurationType(DurationTypeSelection),
            new TargetAddress(TargetAddressText),
            new TargetDescription(TargetDescriptionText),
            new SearchWarrantReason(SearchWarrantReasonText),
            new SearchWarrantContent(SearchWarrantContentText),
        };

        return data;
    }

    public void GenerateWarrantDocument()
    {
        if (!InputsAreValid())
        {
            return;
        }

        // TODO: Testing only - correct inputs to method call.
        DocumentGenerator.GenerateDocument("C:/Temp/template.docx", OutputFileNameText, AssembleData());
    }

    private bool InputsAreValid()
    {
        bool result = true;

        if (OrganizationText == string.Empty)
        {
            result = false;
            OrganizationBorder = Brushes.Red;
        }

        if (OfficerNameText == string.Empty)
        {
            result = false;
            OfficerNameBorder = Brushes.Red;
        }

        if (OfficerTitleSelection == string.Empty)
        {
            result = false;
            OfficerTitleBorder= Brushes.Red;
        }

        if (CustomOfficerTitleVisibility && (CustomOfficerTitleText == "Enter Title" || CustomOfficerTitleText == string.Empty))
        {
            result = false;
            CustomOfficerTitleBorder = Brushes.Red;
        }

        if (EmploymentDurationText == string.Empty)
        {
            result = false;
            EmploymentDurationBorder = Brushes.Red;
        }

        if (TargetAddressText == string.Empty)
        {
            result = false;
            TargetAddressBorder = Brushes.Red;
        }

        if (TargetDescriptionText == string.Empty)
        {
            result = false;
            TargetDescriptionBorder = Brushes.Red;
        }

        if (SearchWarrantReasonText == string.Empty)
        {
            result = false;
            SearchWarrantReasonBorder = Brushes.Red;
        }

        if (SearchWarrantContentText == string.Empty)
        {
            result = false;
            SearchWarrantContentBorder = Brushes.Red;
        }

        if (OutputFileNameText == string.Empty)
        {
            result = false;
            OutputFileNameBorder = Brushes.Red;
        }

        return result;
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

