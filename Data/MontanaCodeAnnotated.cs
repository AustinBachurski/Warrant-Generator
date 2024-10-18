using System.Collections.ObjectModel;
using WarrantGenerator.DTOs;
using System.Collections.Generic;
using System.Xml.Linq;

namespace WarrantGenerator.Data;

public static class MontanaCodeAnnotated
{
    private const string _chapter = "CHAPTER";
    private const string _part = "Part";

    private static readonly ObservableCollection<MCATreeNode> _data = [];

    static MontanaCodeAnnotated()
    {
#pragma warning disable CS8602
        // Chapter 4: [0]
        _data.Add(new(_chapter, "4", "INCHOATE OFFENSES"));
            _data[0].Children.Add(new(_part, "1", "Enumeration of Offenses and Extent of Liability"));
                _data[0].Children[0].Children.Add(new("45-4-101", "Solicitation"));
                _data[0].Children[0].Children.Add(new("45-4-102", "Conspiracy"));
                _data[0].Children[0].Children.Add(new("45-4-103", "Attempt"));

        // Chapter 5: [1]
        _data.Add(new(_chapter, "5", "OFFENSES AGAINST THE PERSON"));
            _data[1].Children.Add(new(_part, "1", "Homicide"));
                _data[1].Children[0].Children.Add(new("45-5-101", "Repealed"));
                _data[1].Children[0].Children.Add(new("45-5-102", "Deliberate homicide"));
                _data[1].Children[0].Children.Add(new("45-5-103", "Mitigated deliberate homicide"));
                _data[1].Children[0].Children.Add(new("45-5-104", "Negligent homicide"));
                _data[1].Children[0].Children.Add(new("45-5-105", "Aiding or soliciting suicide"));
                _data[1].Children[0].Children.Add(new("45-5-106", "Vehicular homicide while under influence"));
                _data[1].Children[0].Children.Add(new("45-5-107", "through 45-5-110 reserved"));
                _data[1].Children[0].Children.Add(new("45-5-111", "Extrajudicial confession"));
                _data[1].Children[0].Children.Add(new("45-5-112", "Inference of mental state"));
                _data[1].Children[0].Children.Add(new("45-5-113", "through 45-5-115 reserved"));
                _data[1].Children[0].Children.Add(new("45-5-116", "Harm to fetus of another"));
            _data[1].Children.Add(new(_part, "2", "Assault and Related Offenses"));
                _data[1].Children[1].Children.Add(new("45-5-201", "Assault"));
                _data[1].Children[1].Children.Add(new("45-5-202", "Aggravated assault"));
                _data[1].Children[1].Children.Add(new("45-5-203", "Intimidation"));
                _data[1].Children[1].Children.Add(new("45-5-204", "Mistreating prisoners"));
                _data[1].Children[1].Children.Add(new("45-5-205", "Negligent vehicular assault"));
                _data[1].Children[1].Children.Add(new("45-5-206", "Partner or family member assault"));
                _data[1].Children[1].Children.Add(new("45-5-207", "Criminal endangerment"));
                _data[1].Children[1].Children.Add(new("45-5-208", "Negligent endangerment"));
                _data[1].Children[1].Children.Add(new("45-5-209", "Partner or family member assault"));
                _data[1].Children[1].Children.Add(new("45-5-210", "Assault on peace officer or judicial officer"));
                _data[1].Children[1].Children.Add(new("45-5-211", "Assault upon sports official"));
                _data[1].Children[1].Children.Add(new("45-5-212", "Assault on minor"));
                _data[1].Children[1].Children.Add(new("45-5-213", "Assault with weapon"));
                _data[1].Children[1].Children.Add(new("45-5-214", "Assault with bodily fluid"));
                _data[1].Children[1].Children.Add(new("45-5-215", "Strangulation of partner or family member"));
                _data[1].Children[1].Children.Add(new("45-5-216", "through 45-5-219 reserved"));
                _data[1].Children[1].Children.Add(new("45-5-220", "Stalking"));
                _data[1].Children[1].Children.Add(new("45-5-221", "Malicious intimidation or harassment relating to civil or human rights"));
                _data[1].Children[1].Children.Add(new("45-5-222", "Sentence enhancement"));
                _data[1].Children[1].Children.Add(new("45-5-223", "Surreptitious visual observation or recordation"));
                _data[1].Children[1].Children.Add(new("45-5-224", "through 45-5-230 reserved"));
#pragma warning restore CS8602
    }

    public static ObservableCollection<MCATreeNode> GetMCAData()
    {
        return _data;
    }
}
