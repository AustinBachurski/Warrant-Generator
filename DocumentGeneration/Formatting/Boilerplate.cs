using WarrantGenerator.Constants;

using DocumentFormat.OpenXml.Wordprocessing;
using System;
using DocumentFormat.OpenXml;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private void AffidavitIntent()
    {
        AppendText(
            "This affidavit is intended to show merely that there is sufficient probable cause for the requested warrant and does not set forth all of my knowledge about this matter."
            );
        AppendEmptyLine();
        AppendText(
            $"Based on my training and experience and the facts as set forth in this affidavit, there is probable cause to believe that violations of {_crimesCombined} have been committed by suspects or unknown person(s)."
            );
    }

    private void InsertFacebookAddressBlock()
    {
        AppendText("Meta Platforms, Inc.");
        AppendText("Attn: Legal Process Department");
        AppendText("1 Meta Way");
        AppendText("Menlo Park, CA 94025");
    }

    private void FacebookAndFacebookMessenger()
    {
        AppendText("Facebook and Facebook messenger for ");
        AppendText($"the following {_individual} and user");
        AppendText($"{_account} identified by their name");
        AppendText("followed by the account URL:");
    }

    private void FacebookRecords()
    {
        string recordsURL = "https://www.facebook.com/records";
        var linkRelationship = _document.AddHyperlinkRelationship(new Uri(recordsURL), true);

        var paragraph = new Paragraph();
        var runBeforeLink = new Run();
        runBeforeLink.Append(new Text(
            $"I make this affidavit in support of an application for a search warrant for information associated with {_certainAccounts} stored at premises controlled by {SocialMedia.MetaCompany}, "
            ) { Space = SpaceProcessingModeValues.Preserve });
        paragraph.Append(runBeforeLink);

        var linkRun = new Run(new Text(recordsURL));
        linkRun.PrependChild(new RunProperties(new RunStyle() { Val = Doc.Styles.Hyperlink }));
        Hyperlink link = new(linkRun) { Id = linkRelationship.Id, };
        paragraph.Append(link);

        var runAfterLink = new Run(new Text(".  The information to be searched is described as:"));
        paragraph.Append(runAfterLink);
        _body.Append(paragraph);
    }

    private void FiledUnderSeal()
    {
        AppendFormattedLine("\t\t\t\t\t\t\t\t\tFiled Under Seal");
    }

    private void DistrictBoilerplate(string text)
    {
        DistrictBoilerplate(string.Empty, text);
    }

    private void DistrictBoilerplate(string option1 = "", string option2 = "")
    {
        var boilerplate = new[]
        {
            $"IN THE {_courtDistrict}, COUNTY OF FLATHEAD, STATE OF MONTANA",
            "STATE OF MONTANA\t\t\t\t\t\t)",
            $"\t\t\tPlaintiff,\t\t\t\t)\t\t{option1}",
            $"\t\t\t\t-vs-\t\t\t\t\t)\t\t{option2}",
            "\t\t\tDefendant,\t\t\t\t)",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private void OfficerDeposesAndSays()
    {
        AppendIndentedText(
            $"On this {_todaysDate}, {_officerRank} {_officerName}, of the {_organization}, being first duly sworn and upon oath, deposes and says:"
            );
        AppendEmptyLine();
        AppendText(
            $"Affiant, {_officerRank} {_officerName}, hereinafter referred to as I, is {IndefiniteArticle(_officerRank[0])} {_officerRank} with the {_organization} and has been a Law Enforcement Officer for the {_organization} for {_employmentDuration} {_employmentDurationType}.{UtilizeSWAT()}{UtilizeCrimeUnit()}"
            );
        AppendEmptyLine();
    }

    private void RequestToDelayNotification()
    {
        AppendHeading("REQUEST TO DELAY NOTIFICATION");
        AppendEmptyLine();
        AppendIndentedText(
            "This Court has jurisdiction Pursuant to M.C.A. § 46-5-605(2), a governmental entity that is seeking a warrant or investigative subpoena under M.C.A. § 46-5-602 may include in the application for the warrant or investigative subpoena a request for an order delaying the notification required under subsection (1) of this section for a period of not more than 1 year.  A court shall grant a request for delayed notification made under subsection (2)(a) or (2)(b) if the court determines that there is reason to believe that notification of the existence of the warrant or investigative subpoena may result in:"
            );
        AppendEmptyLine();
        AppendIndentedText("(i) endangering the life or physical safety of an ");
        AppendIndentedText("individual;");
        AppendIndentedText("(ii) flight from prosecution;" );
        AppendIndentedText("(iii) destruction or tampering with evidence;");
        AppendIndentedText("(iv) intimidation of potential witnesses; or");
        AppendIndentedText("(v) otherwise seriously jeopardizing an investigation or ");
        AppendIndentedText("unduly delaying a trial.");
        AppendEmptyLine();
        AppendIndentedText("This Court has jurisdiction Upon request by a governmental ");
        AppendIndentedText("entity, a court may grant one or more extensions of the ");
        AppendIndentedText("delay of notification granted under subsection (2)(c) of ");
        AppendIndentedText("not more than 180 days each.");
        AppendEmptyLine();
        AppendIndentedText(
            $"{_officerRank} {_officerName} believes based on {_officerPosessivePronoun} training and experiences that notifying the subscriber of the existence of this Search Warrant could result in the above referenced concerns for the integrity of the investigation, most specifically the destruction or tampering with evidence, flight from prosecution, and the placing of the investigation in serious jeopardy.  {_officerRank} {_officerName} knows from experience that the individuals under an investigation of this nature often take steps to eliminate evidence, leave the jurisdiction or conceal their location, and take other steps to conceal their activities and impede the investigation.  Such steps include the deletion of electronic evidence, the encryption of electronic evidence, the transfer of electronic evidence to other locations, notifying other individuals involved in illicit activity of the investigation, as well as the physical flight from the area."
            );
        AppendIndentedText(
            "Accordingly, affiant requests an Order pursuant to M.C.A. § 46-5-605 delaying the notification required under subsection M.C.A. 46-5-605(1) for a period of not more than 1 year from the date of the warrant issued in this case."
            );
        AppendEmptyLine();
    }

    private void RequestToSeal()
    {
        AppendHeading("REQUEST TO SEAL");
        AppendEmptyLine();
        AppendIndentedText(
            "Pursuant to M.C.A. § 46-11-701(6)(b), and based on the facts and statements set forth above, affiant further requests that the Court order that all papers in support of this application, including the affidavit and search warrant, be sealed until further order of the Court.  These documents discuss an ongoing criminal investigation that is neither public nor known to all of the targets of the investigation.  Accordingly, there is good cause to seal these documents because their premature disclosure may seriously jeopardize that investigation."
            );
        AppendEmptyLine();
    }

    private void CommonForSocialMediaCriminalActivity()
    {
        AppendIndentedText(
            "In my training and experience, it is common for people involved in criminal activity to use social media platforms to communicate and discuss their activities, both legal and illegal. Often contained on social media platforms are photographs of the fruits of the crime as well as discussion of the disposal, sales or trades of the fruits of the crime. "
            );
    }

    private void StateOfMontanaCountyOfFlathead()
    {
        var boilerplate = new[]
        {
            "STATE OF MONTANA\t\t)",
            "\t\t\t\t:ss",
            "COUNTY OF FLATHEAD\t\t)",
        };

        foreach (var line in boilerplate)
        {
            AppendFormattedLine(line);
        }
    }

    private string UtilizeSWAT()
    {
        if (!_utilizeSWAT)
        {
            return string.Empty;
        }

        return "  Affiant may use the services of the Flathead County Special Weapons and Tactics (SWAT) team acting under affiant's direction to conduct a search of said area and to seize any evidence indicated in the issued search warrant.";
    }

    private string UtilizeCrimeUnit()
    {
        if (!_utilizeCrimeUnit)
        {
            return string.Empty;
        }

        return "  Affiant may use the services of the designated Crime Scene Team Leader acting under affiant's direction to process any evidence that may be seized in connection with the issued search warrant.";
    }

}

