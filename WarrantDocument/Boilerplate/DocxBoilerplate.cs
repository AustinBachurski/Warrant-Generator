using DocumentFormat.OpenXml.Wordprocessing;
using WarrantGenerator.DTOs;


namespace WarrantGenerator.WarrantDocument.Boilerplate;

public static class DocxBoilerplate
{
    public static Paragraph[] AffidavitsIntent(MCACrime[] crimes)
    {
        return [
            new Paragraph(
                new Run(
                    new Text(
                          "This affidavit is intended to show merely that there is sufficient "
                          + "probable cause for the requested warrant and does not set forth "
                          + "all of my knowledge about this matter."
                    )
                )
            ),
            new Paragraph(),
            new Paragraph(
                new Run(
                    new Text(
                          "Based on my training and experience and the facts as set forth in "
                       +  "this affidavit, there is probable cause to believe that violations "
                       + $"of {FormattedContent.CrimesCombinedAsString(crimes)} have been committed "
                       + "by suspects or unknown person(s)."
                    )
                )
            ),
        ];
    }

    public static Paragraph[] DistrictBoilerplate(string district, string option1 = "", string option2 = "")
    {
        return [
            new Paragraph(
                new Run(
                    new Text($"IN THE {district}, COUNTY OF FLATHEAD, STATE OF MONTANA")
                )
            ),
            new Paragraph(
                new Run(
                    new Text("STATE OF MONTANA"),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text(")")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text("Plaintiff,"),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text(")")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text("-vs-"),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text(")"),
                    new TabChar(),
                    new Text(option1)
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text("Defendant,"),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text(")"),
                    new TabChar(),
                    new Text(option2)
                )
            ),
        ];
    }

    public static Paragraph[] FiledUnderSeal
    {
        get => [
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text("Filed Under Seal")
                )
            ),
        ];
    }

    public static Paragraph[] RequestToDelayNotification(
        string officerName, string officerRank, string posessivePronoun)
    {
        return [
            new Paragraph(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Center }
                ),
                new Run(
                    new RunProperties(
                        new Bold(),
                        new Underline() { Val = UnderlineValues.Single }
                    ),
                    new Text("REQUEST TO DELAY NOTIFICATION")
                )
            ),
            new Paragraph(),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text(
                      "This Court has jurisdiction Pursuant to M.C.A. § 46-5-605(2), "
                    + "a governmental entity that is seeking a warrant or investigative "
                    + "subpoena under M.C.A. § 46-5-602 may include in the application for "
                    + "the warrant or investigative subpoena a request for an order delaying "
                    + "the notification required under subsection (1) of this section for a "
                    + "period of not more than 1 year.  A court shall grant a request for "
                    + "delayed notification made under subsection (2)(a) or (2)(b) if the "
                    + "court determines that there is reason to believe that notification "
                    + "of the existence of the warrant or investigative subpoena may result in:"
                    )
                )
            ),
            new Paragraph(),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("(i) endangering the life or physical safety of an ")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("individual;")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("(ii) flight from prosecution;")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("(iii) destruction or tampering with evidence;")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("(iv) intimidation of potential witnesses; or")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("(v) otherwise seriously jeopardizing an investigation or ")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("unduly delaying a trial.")
                )
            ),
            new Paragraph(),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("This Court has jurisdiction Upon request by a governmental ")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("entity, a court may grant one or more extensions of the ")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("delay of notification granted under subsection (2)(c) of ")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text("not more than 180 days each.")
                )
            ),
            new Paragraph(),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text(
                          $"{officerRank} {officerName} believes based on {posessivePronoun} "
                        +  "training and experiences that notifying the subscriber of the "
                        +  "existence of this Search Warrant could result in the above referenced "
                        +  "concerns for the integrity of the investigation, most specifically the "
                        +  "destruction or tampering with evidence, flight from prosecution, and "
                        +  "the placing of the investigation in serious jeopardy.  "
                        + $"{officerRank} {officerName} knows from experience that the individuals "
                        +  "under an investigation of this nature often take steps to eliminate "
                        +  "evidence, leave the jurisdiction or conceal their location, and take "
                        +  "other steps to conceal their activities and impede the investigation.  "
                        +  "Such steps include the deletion of electronic evidence, the encryption "
                        +  "of electronic evidence, the transfer of electronic evidence to other "
                        +  "locations, notifying other individuals involved in illicit activity of "
                        +  "the investigation, as well as the physical flight from the area."
                    )
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text(
                          "Accordingly, affiant requests an Order pursuant to M.C.A. § 46-5-605 "
                        + "delaying the notification required under subsection M.C.A. 46-5-605(1) "
                        + "for a period of not more than 1 year from the date of the warrant "
                        + "issued in this case."
                    )
                )
            ),
            new Paragraph(),
        ];
    }

    public static Paragraph[] RequestToSeal
    {
        get => [
            new Paragraph(
                new RunProperties(
                    new Justification() { Val = JustificationValues.Center }
                ),
                new Run(
                    new RunProperties(
                        new Bold(),
                        new Underline() { Val = UnderlineValues.Single }
                    ),
                    new Text("REQUEST TO SEAL")
                )
            ),
            new Paragraph(),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text(
                          "Pursuant to M.C.A. § 46-11-701(6)(b), and based on the facts and "
                          + "statements set forth above, affiant further requests that the "
                          + "Court order that all papers in support of this application, "
                          + "including the affidavit and search warrant, be sealed until "
                          + "further order of the Court.  These documents discuss an ongoing "
                          + "criminal investigation that is neither public nor known to all "
                          + "of the targets of the investigation.  Accordingly, there is good "
                          + "cause to seal these documents because their premature disclosure "
                          + "may seriously jeopardize that investigation."
                    )
                )
            ),
            new Paragraph(),
        ];
    }

    public static Paragraph[] SocialMediaCriminalActivityPostsAreCommon
    {
        get => [
            new Paragraph(
                new Run(
                    new TabChar(),
                    new Text(
                          "In my training and experience, it is common for people involved in "
                          + "criminal activity to use social media platforms to communicate "
                          + "and discuss their activities, both legal and illegal. Often "
                          + "contained on social media platforms are photographs of the fruits "
                          + "of the crime as well as discussion of the disposal, sales or "
                          + "trades of the fruits of the crime. "
                    )
                )
            ),
        ];
    }

    public static Paragraph[] StateOfMontanaBoilerplate
    {
        get => [
            new Paragraph(
                new Run(
                    new Text("STATE OF MONTANA"),
                    new TabChar(),
                    new Text(")")
                )
            ),
            new Paragraph(
                new Run(
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new TabChar(),
                    new Text(":ss")
                )
            ),
            new Paragraph(
                new Run(
                    new Text("COUNTY OF FLATHEAD"),
                    new TabChar(),
                    new Text(")")
                )
            ),
        ];
    }

    public static string UtilizeCrimeUnitText
    {
        get =>
        "  Affiant may use the services of the designated Crime Scene Team Leader acting under "
        + "affiant's direction to process any evidence that may be seized in connection with "
        + "the issued search warrant.";
    }

    public static string UtilizeSwatText
    {
        get => 
        "  Affiant may use the services of the Flathead County Special Weapons and Tactics (SWAT) "
        + "team acting under affiant's direction to conduct a search of said area and to seize any "
        + "evidence indicated in the issued search warrant.";
    }

}
