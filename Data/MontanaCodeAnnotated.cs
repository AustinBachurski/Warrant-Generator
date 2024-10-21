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
        // Chapter 4: _data[0]
        _data.Add(new(_chapter, "4", "INCHOATE OFFENSES"));
            // Enumeration of Offenses: Part 1, Children[0]
            _data[0].Children.Add(new(_part, "1", "Enumeration of Offenses and Extent of Liability"));
                _data[0].Children[0].Children.Add(new("45-4-101", "Solicitation"));
                _data[0].Children[0].Children.Add(new("45-4-102", "Conspiracy"));
                _data[0].Children[0].Children.Add(new("45-4-103", "Attempt"));

        // Chapter 5: _data[1]
        _data.Add(new(_chapter, "5", "OFFENSES AGAINST THE PERSON"));
            // Homicide: Part 1, Children[0]
            _data[1].Children.Add(new(_part, "1", "Homicide"));
                _data[1].Children[0].Children.Add(new("45-5-102", "Deliberate homicide"));
                _data[1].Children[0].Children.Add(new("45-5-103", "Mitigated deliberate homicide"));
                _data[1].Children[0].Children.Add(new("45-5-104", "Negligent homicide"));
                _data[1].Children[0].Children.Add(new("45-5-105", "Aiding or soliciting suicide"));
                _data[1].Children[0].Children.Add(new("45-5-106", "Vehicular homicide while under influence"));
            // Assault: Part 2, Children[1]
            _data[1].Children.Add(new(_part, "2", "Assault and Related Offenses"));
                _data[1].Children[1].Children.Add(new("45-5-201", "Assault"));
                _data[1].Children[1].Children.Add(new("45-5-202", "Aggravated assault"));
                _data[1].Children[1].Children.Add(new("45-5-203", "Intimidation"));
                _data[1].Children[1].Children.Add(new("45-5-204", "Mistreating prisoners"));
                _data[1].Children[1].Children.Add(new("45-5-205", "Negligent vehicular assault"));
                _data[1].Children[1].Children.Add(new("45-5-206", "Partner or family member assault"));
                _data[1].Children[1].Children.Add(new("45-5-207", "Criminal endangerment"));
                _data[1].Children[1].Children.Add(new("45-5-208", "Negligent endangerment"));
                _data[1].Children[1].Children.Add(new("45-5-209", "Violation of a no contact order"));
                _data[1].Children[1].Children.Add(new("45-5-210", "Assault on peace officer or judicial officer"));
                _data[1].Children[1].Children.Add(new("45-5-211", "Assault upon sports official"));
                _data[1].Children[1].Children.Add(new("45-5-212", "Assault on minor"));
                _data[1].Children[1].Children.Add(new("45-5-213", "Assault with weapon"));
                _data[1].Children[1].Children.Add(new("45-5-214", "Assault with bodily fluid"));
                _data[1].Children[1].Children.Add(new("45-5-215", "Strangulation of partner or family member"));
                _data[1].Children[1].Children.Add(new("45-5-220", "Stalking"));
                _data[1].Children[1].Children.Add(new("45-5-221", "Malicious intimidation or harassment relating to civil or human rights"));
                _data[1].Children[1].Children.Add(new("45-5-223", "Surreptitious visual observation or recordation"));
            // Kidnapping: Part 3, Children[2]
            _data[1].Children.Add(new(_part, "3", "Kidnapping"));
                _data[1].Children[2].Children.Add(new("45-5-301", "Unlawful restraint"));
                _data[1].Children[2].Children.Add(new("45-5-302", "Kidnapping"));
                _data[1].Children[2].Children.Add(new("45-5-303", "Aggravated kidnapping"));
                _data[1].Children[2].Children.Add(new("45-5-304", "Custodial interference"));
            // Robbery: Part 3, Children[3]
            _data[1].Children.Add(new(_part, "4", "Robbery"));
                _data[1].Children[3].Children.Add(new("45-5-401", "Robbery"));
            // Sexual Crimes: Part 5, Children[4]
            _data[1].Children.Add(new(_part, "5", "Sexual Crimes"));
                _data[1].Children[4].Children.Add(new("45-5-502", "Sexual assault"));
                _data[1].Children[4].Children.Add(new("45-5-503", "Sexual intercourse without consent"));
                _data[1].Children[4].Children.Add(new("45-5-504", "Indecent exposure"));
                _data[1].Children[4].Children.Add(new("45-5-507", "Incest"));
                _data[1].Children[4].Children.Add(new("45-5-508", "Aggravated sexual intercourse without consent"));
            // Offenses Against the Family: Part 6, Children[5]
            _data[1].Children.Add(new(_part, "6", "Offenses Against the Family"));
                _data[1].Children[5].Children.Add(new("45-5-601", "Prostitution"));
                _data[1].Children[5].Children.Add(new("45-5-611", "Bigamy"));
                _data[1].Children[5].Children.Add(new("45-5-612", "Marrying a bigamist"));
                _data[1].Children[5].Children.Add(new("45-5-621", "Nonsupport"));
                _data[1].Children[5].Children.Add(new("45-5-622", "Endangering welfare of children"));
                _data[1].Children[5].Children.Add(new("45-5-623", "Unlawful transactions with children"));
                _data[1].Children[5].Children.Add(new("45-5-624", "Possession of or unlawful attempt to purchase intoxicating substance"));
                _data[1].Children[5].Children.Add(new("45-5-625", "Sexual abuse of children"));
                _data[1].Children[5].Children.Add(new("45-5-626", "Violation of order of protection"));
                _data[1].Children[5].Children.Add(new("45-5-627", "Ritual abuse of minor"));
                _data[1].Children[5].Children.Add(new("45-5-628", "Criminal child endangerment"));
                _data[1].Children[5].Children.Add(new("45-5-631", "Interference with parent-child contact"));
                _data[1].Children[5].Children.Add(new("45-5-632", "Aggravated interference with parent-child contact"));
                _data[1].Children[5].Children.Add(new("45-5-634", "Parenting interference"));
                _data[1].Children[5].Children.Add(new("45-5-637", "Possession or consumption of tobacco products, alternative nicotine products, or vapor products"));
                _data[1].Children[5].Children.Add(new("45-5-637", "QUESTION!!!  -- This one seems to have 2 definitions?"));
                _data[1].Children[5].Children.Add(new("45-5-637", "Attempt to purchase a tobacco product, alternative nicotine product, or vapor product"));
            // Human Trafficking: Part 7, Children[6]
            _data[1].Children.Add(new(_part, "7", "Human Trafficking"));
                _data[1].Children[6].Children.Add(new("45-5-702", "Sex trafficking"));
                _data[1].Children[6].Children.Add(new("45-5-703", "Labor trafficking"));
                _data[1].Children[6].Children.Add(new("45-5-705", "Patronizing victim of sex trafficking"));
                _data[1].Children[6].Children.Add(new("45-5-706", "Aggravated sex trafficking"));
                _data[1].Children[6].Children.Add(new("45-5-707", "Use or possession of property subject to criminal forfeiture for human trafficking"));
                _data[1].Children[6].Children.Add(new("45-5-711", "Child sex trafficking"));

        // Chapter 6: _data[2]
        _data.Add(new(_chapter, "6", "OFFENSES AGAINST PROPERTY"));
            // Criminal Mischief and Arson: Part 1, Children[0]
            _data[2].Children.Add(new(_part, "1", "Criminal Mischief and Arson"));
                _data[2].Children[0].Children.Add(new("45-6-101", "Criminal mischief"));
                _data[2].Children[0].Children.Add(new("45-6-102", "Negligent arson"));
                _data[2].Children[0].Children.Add(new("45-6-103", "Arson"));
                _data[2].Children[0].Children.Add(new("45-6-104", "Desecration of capitol, place of worship, cemetery, or public memorial"));
                _data[2].Children[0].Children.Add(new("45-6-105", "Criminal destruction of or tampering with communication device"));
                _data[2].Children[0].Children.Add(new("45-6-106", "Criminal mischief damage to rental property"));
            // Criminal Trespass and Burglary: Part 2, Children[1]
            _data[2].Children.Add(new(_part, "2", "Criminal Trespass and Burglary"));
                _data[2].Children[1].Children.Add(new("45-6-202", "Criminal trespass to vehicles"));
                _data[2].Children[1].Children.Add(new("45-6-203", "Criminal trespass to property"));
                _data[2].Children[1].Children.Add(new("45-6-204", "Burglary"));
                _data[2].Children[1].Children.Add(new("45-6-205", "Possession of burglary tools"));
            // Theft and Related Offenses: Part 3, Children[2]
            _data[2].Children.Add(new(_part, "3", "Theft and Related Offenses"));
                _data[2].Children[2].Children.Add(new("45-6-301", "Theft"));
                _data[2].Children[2].Children.Add(new("45-6-302", "Theft of lost or mislaid property"));
                _data[2].Children[2].Children.Add(new("45-6-305", "Theft of labor or services or use of property"));
                _data[2].Children[2].Children.Add(new("45-6-307", "Aiding the avoidance of telecommunications charges"));
                _data[2].Children[2].Children.Add(new("45-6-308", "Unauthorized use of motor vehicles"));
                _data[2].Children[2].Children.Add(new("45-6-309", "Failure to return rented or leased personal property"));
                _data[2].Children[2].Children.Add(new("45-6-311", "Unlawful use of a computer"));
                _data[2].Children[2].Children.Add(new("45-6-312", "Unauthorized acquisition or transfer of food stamps"));
                _data[2].Children[2].Children.Add(new("45-6-313", "Medicaid fraud"));
                _data[2].Children[2].Children.Add(new("45-6-314", "Theft by disposal of stolen property"));
                _data[2].Children[2].Children.Add(new("45-6-315", "Defrauding creditors"));
                _data[2].Children[2].Children.Add(new("45-6-316", "Issuing a bad check"));
                _data[2].Children[2].Children.Add(new("45-6-317", "Deceptive practices"));
                _data[2].Children[2].Children.Add(new("45-6-318", "Deceptive business practices"));
                _data[2].Children[2].Children.Add(new("45-6-320", "Theft of nonferrous metal"));
                _data[2].Children[2].Children.Add(new("45-6-321", "Illegal transportation of catalytic converters"));
                _data[2].Children[2].Children.Add(new("45-6-325", "Forgery"));
                _data[2].Children[2].Children.Add(new("45-6-326", "Obscuring identity of machine"));
                _data[2].Children[2].Children.Add(new("45-6-327", "Illegal branding or altering or obscuring of brand"));
                _data[2].Children[2].Children.Add(new("45-6-332", "Theft of identity"));
                _data[2].Children[2].Children.Add(new("45-6-333", "Exploitation of incapacitated person or vulnerable adult"));
                _data[2].Children[2].Children.Add(new("45-6-341", "Money laundering"));

        // Chapter 7: _data[3]
        _data.Add(new(_chapter, "7", "OFFENSES AGAINST PUBLIC ADMINISTRATION"));
            // Bribery and Corrupt Influence: Part 1, Children[0]
            _data[3].Children.Add(new(_part, "1", "Bribery and Corrupt Influence"));
                _data[3].Children[0].Children.Add(new("45-7-101", "Bribery in official and political matters"));
                _data[3].Children[0].Children.Add(new("45-7-102", "Threats and other improper influence in official and political matters"));
                _data[3].Children[0].Children.Add(new("45-7-103", "Criminal use of office or position"));
            // Perjury and Other Falsification in Official Matters: Part 2, Children[1]
            _data[3].Children.Add(new(_part, "2", "Perjury and Other Falsification in Official Matters"));
                _data[3].Children[1].Children.Add(new("45-7-201", "Perjury"));
                _data[3].Children[1].Children.Add(new("45-7-202", "False swearing"));
                _data[3].Children[1].Children.Add(new("45-7-203", "Unsworn falsification to authorities"));
                _data[3].Children[1].Children.Add(new("45-7-204", "False alarms to agencies of public safety"));
                _data[3].Children[1].Children.Add(new("45-7-205", "False reports to peace officers"));
                _data[3].Children[1].Children.Add(new("45-7-206", "Tampering with witnesses and informants"));
                _data[3].Children[1].Children.Add(new("45-7-207", "Tampering with or fabricating physical evidence"));
                _data[3].Children[1].Children.Add(new("45-7-210", "Tampering with public records or information"));
                _data[3].Children[1].Children.Add(new("45-7-211", "Impersonation of public servant"));
                _data[3].Children[1].Children.Add(new("45-7-212", "False claim to public agency"));
            // Obstructing Governmental Operations: Part 3, Children[2]
            _data[3].Children.Add(new(_part, "3", "Obstructing Governmental Operations"));
                _data[3].Children[2].Children.Add(new("45-7-301", "Resisting arrest"));
                _data[3].Children[2].Children.Add(new("45-7-302", "Obstructing peace officer or other public servant"));
                _data[3].Children[2].Children.Add(new("45-7-303", "Obstructing justice"));
                _data[3].Children[2].Children.Add(new("45-7-304", "Failure to aid peace officer"));
                _data[3].Children[2].Children.Add(new("45-7-305", "Compounding of felony"));
                _data[3].Children[2].Children.Add(new("45-7-306", "Escape"));
                _data[3].Children[2].Children.Add(new("45-7-307", "Transferring illegal articles"));
                _data[3].Children[2].Children.Add(new("45-7-308", "Bail-jumping"));
                _data[3].Children[2].Children.Add(new("45-7-309", "Criminal contempt"));
            // Official Misconduct: Part 4, Children[3]
            _data[3].Children.Add(new(_part, "4", "Official Misconduct"));
                _data[3].Children[3].Children.Add(new("45-7-401", "Official misconduct"));
            // Employer Misconduct: Part 5, Children[4]
            _data[3].Children.Add(new(_part, "5", "Employer Misconduct"));
                _data[3].Children[4].Children.Add(new("45-7-501", "Employer misconduct"));
            // Confidential Criminal Justice Information: Part 6, Children[5]
            _data[3].Children.Add(new(_part, "6", "Confidential Criminal Justice Information"));
                _data[3].Children[5].Children.Add(new("45-7-601", "Misuse of confidential criminal justice information"));

        // Chapter 8: _data[4]
        _data.Add(new(_chapter, "6", "OFFENSES AGAINST PUBLIC ORDER"));
            // Conduct Disruptive of Public Order: Part 1, Children[0]
            _data[4].Children.Add(new(_part, "1", "Conduct Disruptive of Public Order"));
                _data[4].Children[0].Children.Add(new("45-8-101", "Disorderly conduct"));
                _data[4].Children[0].Children.Add(new("45-8-102", "Failure of disorderly persons to disperse"));
                _data[4].Children[0].Children.Add(new("45-8-103", "Riot"));
                _data[4].Children[0].Children.Add(new("45-8-104", "Incitement to riot"));
                _data[4].Children[0].Children.Add(new("45-8-105", "Criminal incitement"));
                _data[4].Children[0].Children.Add(new("45-8-106", "Bringing armed individuals into state"));
                _data[4].Children[0].Children.Add(new("45-8-110", "Obstructing health care facility access"));
                _data[4].Children[0].Children.Add(new("45-8-111", "Public nuisance"));
                _data[4].Children[0].Children.Add(new("45-8-113", "Creating hazard"));
                _data[4].Children[0].Children.Add(new("45-8-114", "Failure to yield party line"));
                _data[4].Children[0].Children.Add(new("45-8-115", "Illegal posting of state and federal land"));
                _data[4].Children[0].Children.Add(new("45-8-116", "Funeral picketing"));
            // Offensive, Indecent, and Inhumane Conduct: Part 2, Children[1]
            _data[4].Children.Add(new(_part, "2", "Offensive, Indecent, and Inhumane Conduct"));
                _data[4].Children[1].Children.Add(new("45-8-201", "Obscenity"));
                _data[4].Children[1].Children.Add(new("45-8-206", "Public display or dissemination of obscene material to minors"));
                _data[4].Children[1].Children.Add(new("45-8-209", "Harming a police dog"));
                _data[4].Children[1].Children.Add(new("45-8-210", "Causing animals to fight"));
                _data[4].Children[1].Children.Add(new("45-8-211", "Cruelty to animals"));
                _data[4].Children[1].Children.Add(new("45-8-212", "Criminal defamation"));
                _data[4].Children[1].Children.Add(new("45-8-213", "Privacy in communications"));
                _data[4].Children[1].Children.Add(new("45-8-214", "Bribery in contests"));
                _data[4].Children[1].Children.Add(new("45-8-215", "Desecration of flags"));
                _data[4].Children[1].Children.Add(new("45-8-216", "Unlawful automated telephone solicitation"));
                _data[4].Children[1].Children.Add(new("45-8-217", "Aggravated animal cruelty"));
                _data[4].Children[1].Children.Add(new("45-8-218", "Deviate sexual conduct"));
                _data[4].Children[1].Children.Add(new("45-8-220", "Criminal invasion of personal privacy"));
                _data[4].Children[1].Children.Add(new("45-8-221", "Predatory loitering by sexual offender"));
            // Weapons: Part 3, Children[2]
            _data[4].Children.Add(new(_part, "3", "Weapons"));
                _data[4].Children[2].Children.Add(new("45-8-303", "Possession or use of machine gun in connection with a crime"));
                _data[4].Children[2].Children.Add(new("45-8-304", "Possession or use of machine gun for offensive purpose"));
                _data[4].Children[2].Children.Add(new("45-8-305", "Presumption of offensive or aggressive purpose"));
                _data[4].Children[2].Children.Add(new("45-8-313", "Unlawful possession of firearm by convicted person"));
                _data[4].Children[2].Children.Add(new("45-8-316", "Carrying concealed firearms"));
                _data[4].Children[2].Children.Add(new("45-8-318", "Possession of deadly weapon by prisoner or youth in facility"));
                _data[4].Children[2].Children.Add(new("45-8-327", "Carrying concealed weapon while under influence"));
                _data[4].Children[2].Children.Add(new("45-8-328", "Carrying concealed weapon in prohibited place -- penalty"));
                _data[4].Children[2].Children.Add(new("45-8-333", "Reckless or malicious use of explosives"));
                _data[4].Children[2].Children.Add(new("45-8-334", "Possession of destructive device"));
                _data[4].Children[2].Children.Add(new("45-8-335", "Possession of explosives"));
                _data[4].Children[2].Children.Add(new("45-8-336", "Possession of silencer"));
                _data[4].Children[2].Children.Add(new("45-8-337", "Possession of unregistered silencer or of bomb or similar device prima facie evidence of unlawful purpose"));
                _data[4].Children[2].Children.Add(new("45-8-340", "Sawed-off firearm"));
                _data[4].Children[2].Children.Add(new("45-8-361", "Possession Or Allowing Possession Of Weapon In School Building"));
#pragma warning restore CS8602
    }

    public static ObservableCollection<MCATreeNode> GetMCAData()
    {
        return _data;
    }
}
