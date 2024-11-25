using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.WarrantDocument.Boilerplate;
using WarrantGenerator.WarrantDocument.Formatters;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

using System;
using System.Collections.Generic;
using System.Linq;
using WarrantGenerator.DocumentGeneration.Formatters;


namespace WarrantGenerator.WarrantDocument.Documents;

public class FacebookDocument(FacebookData data)
{
    public string GenerateDocuments()
    {
        List<string> documents = [];

        if (_data.GenerateApplicationDocument)
        {
            documents.Add(GenerateApplicationDocument());
        }

        if (_data.GenerateWarrantDocument)
        {
            documents.Add(GenerateWarrantDocument());
        }

        return string.Join("\n\t", documents);
    }

    private string GenerateApplicationDocument()
    {
        const string suffix = " - APPLICATION";

        using var doc = new DocxDocument(_data.OutputFile + suffix + Extension.Docx);

        /* Document Content
        ****************************************/

        doc.AppendContent(DocxBoilerplate.DistrictBoilerplate("APPLICATION FOR", "SEARCH WARRANT"));
        if (_data.RequestToSeal) { doc.AppendContent(DocxBoilerplate.FiledUnderSeal); }
        doc.AppendText("Facebook and Facebook messenger for ");
        doc.AppendText($"the following {_data.Individual} and user");
        doc.AppendText($"{_data.Account} identified by their name");
        doc.AppendText("followed by the account URL:");
        doc.AppendText();
        doc.AppendContent(SocialMediaAccounts());
        doc.AppendText("Which is under control of:");
        doc.AppendContent(FacebookAddress());
        doc.AppendText();
        doc.AppendContent(DocxBoilerplate.StateOfMontanaBoilerplate);
        doc.AppendText();
        doc.AppendText(
            $"On this {_data.TodaysDate}, {_data.OfficerRank} {_data.OfficerName}, "
           + "of the {ConstantData.KPD}, being first duly sworn and upon oath, deposes and says:",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendText(
              $"Affiant, {_data.OfficerRank} {_data.OfficerName}, hereinafter referred to as I, is "
            + $"{FormatContent.IndefiniteArticle(_data.OfficerRank[0])} {_data.OfficerRank} with "
            + $"the {ConstantData.KPD} and has been a Law Enforcement Officer for the "
            + $"{ConstantData.KPD} for {_data.EmploymentDuration} {_data.EmploymentDurationType}."
            );
        doc.AppendInlineUrl(
               "I make this affidavit in support of an application for a search warrant "
            + $"for information associated with {_data.CertainAccounts} stored at premises "
            + "controlled by Meta Platforms, Inc., a Social Media provider headquartered "
            + "at 1 Meta Way, Menlo Park, CA 94025, ",
            "https://www.facebook.com/records",
            ".  The information to be searched is described as:"
            );
        doc.AppendText();
        doc.AppendContent(SocialMediaAccounts());
        doc.AppendText(
              "and in the following paragraphs.  This affidavit is made in support of an "
            + "application for a search warrant under 18 U.S.C. §§ 2703(a), 2703(b)(1)(A) "
            + "and 2703(c)(1)(A) to require Facebook, Inc. to disclose to the "
            + "government copies of the information (including the content of communications) "
            + "further described in Section I of Attachment A.",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendContent(DocxBoilerplate.AffidavitsIntent(_data.Crimes));
        doc.AppendText();
        doc.AppendText("PROBABLE CAUSE", new UnderlinedText(), new BoldText(), new AlignCenter());
        doc.AppendText();
        doc.AppendMultilineText(_data.ProbableCause);
        doc.AppendText();
        doc.AppendContent(DocxBoilerplate.SocialMediaCriminalActivityPostsAreCommon);
        doc.AppendText();
        doc.AppendText("CONCLUSION", new UnderlinedText(), new BoldText(), new AlignCenter());
        doc.AppendText();
        doc.AppendText(
              "Based on the forgoing, I request that the Court issue the proposed search "
            + "warrant.  Because the warrant will be served on Facebook, Inc., who will then "
            + "compile the requested records at a time convenient to it, reasonable cause exists "
            + "to permit the execution of the requested warrant at any time in the day or night.",
            new IndentedText()
            );
        doc.AppendText();
        if (_data.RequestToDelayNotification)
        {
            doc.AppendContent(DocxBoilerplate.RequestToDelayNotification(
                _data.OfficerName, _data.OfficerRank, _data.OfficerPosessivePronoun));
        }
        if (_data.RequestToSeal) { doc.AppendContent(DocxBoilerplate.RequestToSeal); }
        doc.AppendText($"Dated this {_data.TodaysDate}.");
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText(_data.OfficerName, new IndentedText());
        doc.AppendText(ConstantData.KPD, new IndentedText());
        doc.AppendText();
        doc.AppendText();
        doc.AppendText($"Subscribed and sworn to before me this {_data.TodaysDate}.");
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText("District Court Judge", new IndentedText());

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + suffix + Extension.Docx;
    }

    private string GenerateWarrantDocument()
    {
        const string suffix = " - WARRANT";
        using var newDocument = WordprocessingDocument.Create(_outputPath + suffix + Extension.Docx, WordprocessingDocumentType.Document);

        _document = newDocument.AddMainDocumentPart();
        _document.Document = new Document();
        _body = new();
        InitializeDocument();

        /* Document Content
        *****************************************/

        DistrictBoilerplate("SEARCH WARRANT");
        if (_socialMediaPlatform == SocialMedia.Facebook)
        {
            FacebookAndFacebookMessenger();
            AppendEmptyLine();
            AppendSocialMediaAccounts();
            AppendText("Which is under control of:");
            InsertFacebookAddressBlock();
        }
        AppendEmptyLine();
        AppendText($"To: {_officerRank} {_officerName}, {_organization}");
        AppendEmptyLine();
        AppendIndentedText(
            $"A sworn application having been made before me by {_officerRank} {_officerName}, with the {_organization}, that {_officerSubjectivePronoun} has reason to believe that {SocialMedia.MetaCompany}, has control over records and information of the {_account} specifically identified above as their name followed by the account URL:"
            );
        AppendEmptyLine();
        AppendSocialMediaAccounts();
        AppendIndentedText(
            $"and those records which may be evidence of the crimes of {_crimesCombined}, namely the items listed in Attachment A."
            );
        AppendEmptyLine();
        AppendIndentedText(
            $"I have examined the Application for Search Warrant and    am satisfied that there is probable cause to believe that an offense has been committed, and that said evidence, as described in Attachment A, of those crimes may be found in records within the control of {SocialMedia.MetaCompany}, specifically related to the accounts described as:"
            );
        AppendEmptyLine();
        AppendSocialMediaUrls();
        AppendIndentedText(
            $"{_socialMediaPlatform}, Inc. shall disclose responsive data, if any, by sending to {ConstantData.KpdAddress}, attention {_officerName}, {_organization}, using the US Postal Service or another courier service, notwithstanding 18 U.S.C. 2252A or similar statue or code."
            );
        AppendEmptyLine();
        AppendIndentedText(
            $"You are hereby commanded to serve this Warrant, seize the described property, and search said property for evidence of {_crimeGrammar} described herein.  Such evidence includes, but is not limited to the items identified in Attachment A.  If said evidence is found within or upon the property, you are ordered to seize it, together with any other evidence of the {_crimeGrammar} identified herein, give a receipt for same, prepare a written inventory verified by you and the evidence seized and bring said evidence before me, all in the manner provided and required by law."
            );
        AppendEmptyLine();
        if (_requestToSeal)
        {
            AppendIndentedText(
                "It is further ordered that the affidavit, attachments and this search warrant shall be SEALED under further order of the Court. "
                );
            AppendEmptyLine();
        }
        if (_requestToDelayNotification)
        {
            AppendIndentedText(
                "It is further ordered that the request to delay notification to the subscriber or customer is granted.  Absent a request for an extension of delay of notification, the affiant shall inform the subscriber or customer of the existence of this search warrant no later than one (1) year from the date of this order."
                );
            AppendEmptyLine();
        }
        AppendText($"Dated this {_todaysDate}.");
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText(ConstantData.SignHere);
        AppendIndentedText("District Court Judge");

        PageBreak();
        /******************************************
         *              Attachment A              *
         ******************************************/

        AppendHeading("ATTACHMENT A");
        AppendCenteredText("Particular Things to be Seized");
        AppendEmptyLine();
        AppendBoldUnderlinedText($"I.  Information to be disclosed by {_socialMediaPlatform}, Inc.");
        AppendEmptyLine();
        AppendText($"To the extent that the information described as {_account}:");
        AppendEmptyLine();
        AppendSocialMediaUrls();
        AppendText(
            $"{_isOrAre} within the possession, custody, or control of {_socialMediaPlatform}, Inc., {_socialMediaPlatform}, Inc. is required to disclose the following information to the government for each user account from {_startDate} through the date of this warrant:"
            );
        AppendEmptyLine();
        AppendBoldText("A.  Basic Subscriber Information:");
        AppendEmptyLine();
        AppendBulletedText("User Identification Number;");
        AppendBulletedText("Any and all names associated with the current account to include the current name, screen names, alternate names such as maiden names, and all name changes that the user has made to their account;");
        AppendBulletedText("E-mail addresses to include addresses added to the account as well as those that may have been removed;");
        AppendBulletedText("Date and Time Stamp of account creation date displayed in Coordinated Universal Time;");
        AppendBulletedText("Most recent logins in Coordinated Universal Time;");
        AppendBulletedText("Phone numbers to include registered mobile numbers, mobile numbers that have been verified, and other numbers added to the account for security purposes;");
        AppendEmptyLine();
        AppendBoldText("B.  User Photos:");
        AppendEmptyLine();
        AppendBulletedText("All photos uploaded by the user including EXIF data, META Data, date uploaded, IP address uploaded from, and any photos uploaded by other users that have the requested user tagged in them;");
        AppendEmptyLine();
        AppendBoldText("C.  Group Information");
        AppendEmptyLine();
        AppendBulletedText($"A list of groups that the user belongs to on {_socialMediaPlatform}, Inc.;");
        AppendEmptyLine();
        AppendBoldText("D.  Private Messages, Chats, and E-mail Content");
        AppendEmptyLine();
        AppendBulletedText("All other communications and messages to include a complete history of the conversations made or received by the user as well as archived messages;");
        AppendEmptyLine();
        AppendBoldText("E.  IP Logs");
        AppendEmptyLine();
        AppendBulletedText("All IP logs, including all records of the IP addresses that logged into the account;");
        AppendBulletedText("Active Sessions to include all stored active sessions, including date, time, device, machine cookie, and browser information;");
        AppendEmptyLine();
        AppendBoldText("F.  Activity Log");
        AppendEmptyLine();
        AppendBulletedText("All activities to include places the user as checked into, events the user has joined or has been invited to, a list of all the people the user has followed or is currently following, user’s last location that was associated with an update, posts, photos, or other content the user has “liked”, to include likes on other people’s posts as well as the user’s own posts;");
        AppendEmptyLine();
        AppendBoldUnderlinedText("II.  Information to be seized by the government");
        AppendEmptyLine();
        AppendBoldText("A.  Previously Described Information");
        AppendEmptyLine();
        AppendBulletedText(
            $"All information described in Section I above, including correspondence, records, documents, photographs, videos, electronic mail, chat logs, and electronic messages that constitutes fruits, evidence, and instrumentalities of violations of {_crimesCombined}, for each account or identifier listed as:"
            );
        AppendEmptyLine();
        AppendSocialMediaUrls();
        AppendBulletedText(
            "Information pertaining to the following matters, including attempting and conspiring to engage in the following matters:"
            );
        AppendEmptyLine();
        AppendBoldText("BEGIN LEGAL CRITERIA FOR OFFENSES");
        AppendEmptyLine();
        AppendMultilineText(_legalCriteriaForOffenses);
        AppendEmptyLine();
        AppendBoldText("END LEGAL CRITERIA FOR OFFENSES");
        AppendEmptyLine();
        AppendBulletedText(
            "Communications and all contact between each account or identifier listed as:"
            );
        AppendEmptyLine();
        AppendSocialMediaUrls();
        AppendBulletedText(
            $"and any of the suspects, associates, or victims in this investigation, the identification of other possible victims, and/or suspects of {_crimeDescriptions}."
            );
        AppendEmptyLine();
        AppendBoldText("B.  Creation and Communication");
        AppendEmptyLine();
        AppendBulletedText(
            $"Records relating to who created, used, or communicated with the user {_account}, including records about their identities, IP addresses, and whereabouts. "
            );
        AppendEmptyLine();
        AppendBoldText("C.  Financial Information");
        AppendEmptyLine();
        AppendBulletedText(
            $"Credit card and other financial information including but not limited to bills and payment records;"
            );
        AppendEmptyLine();
        AppendBoldText("D.  Account Users and Owners");
        AppendEmptyLine();
        AppendBulletedText(
            "Evidence of who used, owned, or controlled each account or identifier listed as:"
            );
        AppendEmptyLine();
        AppendSocialMediaUrls();

        AppendBoldText("E.  Account Use");
        AppendEmptyLine();
        AppendBulletedText(
            "Evidence of the times each account or identifier listed as:"
            );
        AppendEmptyLine();
        AppendSocialMediaUrls();
        AppendIndentedText("was used.");

        PageBreak();
        /*****************************************
         *              Certificate              *
         *****************************************/

        AppendHeading("CERTIFICATE OF AUTHENTICITY OF DOMESTIC");
        AppendHeading("RECORDS PURSUANT TO FEDERAL RULES OF");
        AppendHeading("EVIDENCE 902(11) AND 902(13)");
        AppendEmptyLine();
        AppendIndentedText(
            $"I, {ConstantData.SignHere}, attest, under penalties of perjury by the laws of the United States of America pursuant to 28 U.S.C. § 1746, that the information contained in this certification is true and correct.  I am employed by {_socialMediaPlatform}, Inc., and my title is {ConstantData.SignHere}.  I am qualified to authenticate the records attached hereto because I am familiar with how the records were created, managed, stored, and retrieved.  I state that the records attached hereto are true duplicates of the original records in the custody of {_socialMediaPlatform}, Inc."
            );
        AppendIndentedText($"The Attached records consist of:");
        AppendIndentedText(new string('_', ConstantData.GenerallyDescribeRecords.Length));
        AppendIndentedText(ConstantData.GenerallyDescribeRecords);
        AppendEmptyLine();
        AppendText("I further state that:");
        AppendIndentedText(
            $"A. All records attached to this certificate were made at or near the time of the occurrence of the matter set forth by, or from information transmitted by, a person with knowledge of those matters, they were kept in the ordinary course of the regularly conducted business activity of {_socialMediaPlatform}, Inc., and they were made by {_socialMediaPlatform}, Inc. as a regular practice; and"
            );
        AppendIndentedText(
            $"B. such records were generated by {_socialMediaPlatform}, Inc. electronic process or system that produces an accurate result, to wit:"
            );
        AppendDoublyIndentedText(
            $"1. the records were copied from electronic device(s), storage medium(s), or file(s) in the custody of {_socialMediaPlatform}, Inc. in a manner to ensure that they are true duplicates of the original records; and"
            );
        AppendDoublyIndentedText(
            $"2. the process or system is regularly verified by {_socialMediaPlatform}, Inc., and at all times pertinent to the records certified here the process and system functioned properly and normally."
            );
        AppendIndentedText(
            "I further state that this certification is intended to satisfy Rules 902(11) and 902(13) of the Federal Rules of Evidence."
            );
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText($"{ConstantData.DateHere}  {ConstantData.SignHere}");
        AppendIndentedText($"Date{new string(' ', ConstantData.DateHere.Length - 2)}Signature");  // - 2 for the Length of "Date" minus the two spaces between lines.

        /***************************************** 
         * End Document Content*/

        _document.Document.Append(_body);
        _document.Document.Save();
        return _outputPath + suffix + Extension.Docx;
    }

    private readonly FacebookData _data = data;

    private static Paragraph[] FacebookAddress()
    {
        return [
            new Paragraph(
                new Run(
                    new Text("Meta Platforms, Inc.")
                )
            ),
            new Paragraph(
                new Run(
                    new Text("Attn: Legal Process Department")
                )
            ),
            new Paragraph(
                new Run(
                    new Text("1 Meta Way")
                )
            ),
            new Paragraph(
                new Run(
                    new Text("Menlo Park, CA 94025")
                )
            ),
        ];
    }

    private void AppendIndentedUrl(string url)
    {
        _body.Append(
            new Paragraph(
                new Run(
                    new TabChar()
                ),
                new Hyperlink(
                    new Run(
                        new RunProperties(
                            new RunStyle() { Val = DocxStyle.Hyperlink }
                        ),
                        new Text(url)
                    )
                )
                { Id = _document.AddHyperlinkRelationship(new Uri(url), true).Id }
            )
        );
    }

    private void AppendUrl(string url)
    {
        _body.Append(
            new Paragraph(
                new Hyperlink(
                    new Run(
                        new RunProperties(
                            new RunStyle() { Val = DocxStyle.Hyperlink }
                        ),
                        new Text(url)
                    )
                )
                { Id = _document.AddHyperlinkRelationship(new Uri(url), true).Id }
            )
        );
    }

    private Paragraph[] SocialMediaAccounts()
    {
        var content = new List<Paragraph>();

        foreach (var account in _data.Profiles)
        {
            content.Add(
                new Paragraph(
                    new Run(
                        new Text(account.Name)
                    )
                )
            );

            content.Add(
                new Paragraph(
                    new Run(
                        new TabChar(),
                        new Text(account.URL)
                    )
                )
            );

            content.Add(new());
        }
        
        return content.ToArray();
    }

    private void AppendSocialMediaUrls()
    {
        var accounts = _accountNamesCombined.Split(Environment.NewLine);

        foreach (var account in  accounts)
        {
            var _data = account.Split(ConstantData.Separator);

            AppendIndentedUrl(_data[1]);  // URL
            AppendEmptyLine();
        }
    }

}
