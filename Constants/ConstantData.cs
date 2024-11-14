namespace WarrantGenerator.Constants;

public static class ConstantData
{
    public static string KPD { get; } = "Kalispell Police Department";

    public static string[] CourtDistricts { get; } = [
        "11TH JUDICIAL DISTRICT COURT",
        "FLATHEAD COUNTY JUSTICE COURT",
        "KALISPELL MUNICIPAL COURT",
    ];

    public static string DefaultCourtSelection { get; } = "11TH JUDICIAL DISTRICT COURT";

    public static string[] DurationTypes { get; } = [
        "years", "year", "months", "month", "days", "day",
    ];

    public static string DefaultDurationTypeSelection { get; set; } = "years";

    public static string[] OfficerRanks { get; } = [
        "Captain", "Chief", "Detective", "Detective Sergeant", "Lieutenant",
        "Master Patrol Officer", "Officer", "Sergeant", "Other",
    ];

    public static string[] Platforms { get; } = [
        SocialMedia.Facebook, SocialMedia.SnapChat,
        ];

    public static string OfficerRanksOther { get; } = "Other";

    public static string[] Genders { get; } = [ "Female", "Male", ];

    public static string DefaultOfficerRank { get; } = "Enter Rank";

    public static string MissingField { get; } = "All fields must be filled out first.";

    public static string DocumentGeneratedAs { get; } = "Document(s) generated as:\n\t";

    public static string CloseFile { get; } = "Unable to write output file.\nIf the file is open, please close it.";

    public static string UnexpectedError { get; } = "Unexpected Error Encountered, Error Details:\n\n";

    public static string SignHere { get; } = "_____________________________________";

    public static string NormalUrlTitleText { get; } = "URL for Account";

    public static string ErrorUrlTitleText { get; } = "URL for Account - MUST BE A VALID URL - i.e. http://example.com/user";

    public static char Separator { get; } = '|';

}

