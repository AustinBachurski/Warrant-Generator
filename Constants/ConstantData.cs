namespace WarrantGenerator.Constants;

public static class ConstantData
{
    public static string CloseFile { get; } = "Unable to write output file.\nIf the file is open, please close it.";

    public static string[] CourtDistricts { get; } = [
        "11TH JUDICIAL DISTRICT COURT",
        "FLATHEAD COUNTY JUSTICE COURT",
        "KALISPELL MUNICIPAL COURT",
    ];

    public static string DateHere { get; } = "_______________";

    public static string DefaultCourtSelection { get; } = "11TH JUDICIAL DISTRICT COURT";

    public static string DefaultDurationTypeSelection { get; set; } = "years";

    public static string DefaultOfficerRank { get; } = "Enter Rank";

    public static string DocumentGeneratedAs { get; } = "Document(s) generated as:\n\t";

    public static string[] DurationTypes { get; } = [
        "years", "year", "months", "month", "days", "day",
    ];

    public static string ErrorUrlTitleText { get; } = "URL for Account - MUST BE A VALID URL - i.e. http://example.com/user";

    public static string[] Genders { get; } = [ "Female", "Male", ];

    public static string GenerallyDescribeRecords { get; } = "[GENERALLY DESCRIBE RECORDS(pages/CDs/megabytes/etc.)]";

    public static string KPD { get; } = "Kalispell Police Department";

    public static string KpdAddress { get; } = "312 1st Ave E, Kalispell, MT 59901";

    public static string MissingField { get; } = "All fields must be filled out first.";

    public static string NormalUrlTitleText { get; } = "URL for Account";

    public static string[] OfficerRanks { get; } = [
        "Captain", "Chief", "Detective", "Detective Sergeant", "Lieutenant",
        "Master Patrol Officer", "Officer", "Sergeant", "Other",
    ];

    public static string OfficerRanksOther { get; } = "Other";

    public static string[] Platforms { get; } = [
        SocialMedia.Facebook, SocialMedia.SnapChat,
        ];

    public static char Separator { get; } = '|';

    public static string SignHere { get; } = "_____________________________________";

    public static string UnexpectedError { get; } = "Unexpected Error Encountered, Error Details:\n\n";

}

