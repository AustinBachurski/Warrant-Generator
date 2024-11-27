using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.WarrantDocument.Boilerplate;
using WarrantGenerator.WarrantDocument.Formatters;

using DocumentFormat.OpenXml.Wordprocessing;

using System.Collections.Generic;


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

        doc.AppendContent(DocxBoilerplate.DistrictBoilerplate(_data.CourtDistrict, "APPLICATION FOR", "SEARCH WARRANT"));
        if (_data.RequestToSeal) { doc.AppendContent(DocxBoilerplate.FiledUnderSeal); }
        doc.AppendText("Facebook and Facebook messenger for ");
        doc.AppendText($"the following {_data.Individual} and user");
        doc.AppendText($"{_data.Account} identified by their name");
        doc.AppendText("followed by the account URL:");
        doc.AppendText();
        AppendSocialMediaAccounts(doc);
        doc.AppendText("Which is under control of:");
        doc.AppendContent(FacebookAddress);
        doc.AppendText();
        doc.AppendContent(DocxBoilerplate.StateOfMontanaBoilerplate);
        doc.AppendText();
        doc.AppendText(
             $"On this {_data.TodaysDate}, {_data.OfficerRank} {_data.OfficerName}, "
           + $"of the {ConstantData.KPD}, being first duly sworn and upon oath, deposes and says:",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendText(
              $"Affiant, {_data.OfficerRank} {_data.OfficerName}, hereinafter referred to as I, is "
            + $"{FormattedContent.IndefiniteArticle(_data.OfficerRank[0])} {_data.OfficerRank} with "
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
        AppendSocialMediaAccounts(doc);
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
        using var doc = new DocxDocument(_data.OutputFile + suffix + Extension.Docx);

        /* Document Content
        *****************************************/

        doc.AppendContent(DocxBoilerplate.DistrictBoilerplate(_data.CourtDistrict, "SEARCH WARRANT"));
        doc.AppendText("Facebook and Facebook messenger for ");
        doc.AppendText($"the following {_data.Individual} and user");
        doc.AppendText($"{_data.Account} identified by their name");
        doc.AppendText("followed by the account URL:");
        doc.AppendText();
        AppendSocialMediaAccounts(doc);
        doc.AppendText("Which is under control of:");
        doc.AppendContent(FacebookAddress);
        doc.AppendText();
        doc.AppendText($"To: {_data.OfficerRank} {_data.OfficerName}, {ConstantData.KPD}");
        doc.AppendText();
        doc.AppendText(
              $"A sworn application having been made before me by {_data.OfficerRank} "
            + $"{_data.OfficerName}, with the {ConstantData.KPD}, that "
            + $"{_data.OfficerSubjectivePronoun} has reason to believe that Meta "
            +  "Platforms, Inc., a Social Media provider headquartered at 1 Meta Way, "
            +  "Menlo Park, CA 94025, has control over records and information of the "
            + $"{_data.Account} specifically identified above as their name followed "
            +  "by the account URL:",
            new IndentedText()
            );
        doc.AppendText();
        AppendSocialMediaAccounts(doc);
        doc.AppendText(
               "and those records which may be evidence of the crimes of "
            + $"{FormattedContent.CrimesCombinedAsString(_data.Crimes)}, "
            +  "namely the items listed in Attachment A.",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendText(
              "I have examined the Application for Search Warrant and am satisfied "
            + "that there is probable cause to believe that an offense has been "
            + "committed, and that said evidence, as described in Attachment A, of "
            + "those crimes may be found in records within the control of Meta "
            + "Platforms, Inc., a Social Media provider headquartered at 1 Meta Way, "
            + "Menlo Park, CA 94025, specifically related to the accounts described as:",
            new IndentedText()
            );
        doc.AppendText();
        AppendSocialMediaUrls(doc);
        doc.AppendText(
              $"Facebook, Inc. shall disclose responsive data, if any, by sending to "
            + $"{ConstantData.KpdAddress}, attention {_data.OfficerName}, "
            + $"{ConstantData.KPD}, using the US Postal Service or another courier "
            + $"service, notwithstanding 18 U.S.C. 2252A or similar statue or code.",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendText(
               "You are hereby commanded to serve this Warrant, seize the described "
            + $"property, and search said property for evidence of {_data.CrimeGrammar} "
            +  "described herein.  Such evidence includes, but is not limited to the "
            +  "items identified in Attachment A.  If said evidence is found within or "
            +  "upon the property, you are ordered to seize it, together with any other "
            + $"evidence of the {_data.CrimeGrammar} identified herein, give a receipt "
            +  "for same, prepare a written inventory verified by you and the evidence "
            +  "seized and bring said evidence before me, all in the manner provided "
            +  "and required by law.",
            new IndentedText()
            );
        doc.AppendText();
        if (_data.RequestToSeal)
        {
            doc.AppendText(
                  "It is further ordered that the affidavit, attachments and this search "
                + "warrant shall be SEALED under further order of the Court. "
                );
            doc.AppendText();
        }
        if (_data.RequestToDelayNotification)
        {
            doc.AppendText(
                  "It is further ordered that the request to delay notification to the "
                + "subscriber or customer is granted.  Absent a request for an extension "
                + "of delay of notification, the affiant shall inform the subscriber or "
                + "customer of the existence of this search warrant no later than one "
                + "(1) year from the date of this order."
                );
            doc.AppendText();
        }
        doc.AppendText($"Dated this {_data.TodaysDate}.");
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText("District Court Judge", new IndentedText());

        doc.PageBreak();

        /******************************************
         *              Attachment A              *
         ******************************************/

        doc.AppendText("ATTACHMENT A", new BoldText(), new UnderlinedText(), new AlignCenter());
        doc.AppendText("Particular Things to be Seized", new AlignCenter());
        doc.AppendText();
        doc.AppendText($"I.  Information to be disclosed by Facebook, Inc.",
            new BoldText(),
            new UnderlinedText());
        doc.AppendText();
        doc.AppendText($"To the extent that the information described as {_data.Account}:");
        doc.AppendText();
        AppendSocialMediaUrls(doc);
        doc.AppendText(
              $"{_data.IsOrAre} within the possession, custody, or control of Facebook, Inc., "
            +  "Facebook, Inc. is required to disclose the following information to the "
            + $"government for each user account from {_data.StartDate} through the "
            +  "date of this warrant:"
            );
        doc.AppendText();
        doc.AppendText("A.  Basic Subscriber Information", new BoldText());
        doc.AppendText();
        doc.AppendText("User Identification Number;", new BulletedText());
        doc.AppendText(
              "Any and all names associated with the current account to include the current "
            + "name, screen names, alternate names such as maiden names, and all name "
            + "changes that the user has made to their account;",
            new BulletedText()
            );
        doc.AppendText(
              "E-mail addresses to include addresses added to the account as well as "
            + "those that may have been removed;",
            new BulletedText()
            );
        doc.AppendText(
            "Date and Time Stamp of account creation date displayed in Coordinated Universal Time;",
            new BulletedText());
        doc.AppendText(
            "Most recent logins in Coordinated Universal Time;",
            new BulletedText());
        doc.AppendText(
              "Phone numbers to include registered mobile numbers, mobile numbers that have been "
            + "verified, and other numbers added to the account for security purposes;",
            new BulletedText());
        doc.AppendText();
        doc.AppendText("B.  User Photos", new BoldText());
        doc.AppendText();
        doc.AppendText(
              "All photos uploaded by the user including EXIF data, META Data, date uploaded, IP "
            + "address uploaded from, and any photos uploaded by other users that have the "
            + "requested user tagged in them;",
            new BulletedText());
        doc.AppendText();
        doc.AppendText("C.  Group Information", new BoldText());
        doc.AppendText();
        doc.AppendText(
            $"A list of groups that the user belongs to on Facebook, Inc.;",
            new BulletedText()
            );
        doc.AppendText();
        doc.AppendText("D.  Private Messages, Chats, and E-mail Content", new BoldText());
        doc.AppendText();
        doc.AppendText(
              "All other communications and messages to include a complete history of the "
            + "conversations made or received by the user as well as archived messages;",
            new BulletedText()
            );
        doc.AppendText();
        doc.AppendText("E.  IP Logs", new BoldText());
        doc.AppendText();
        doc.AppendText(
            "All IP logs, including all records of the IP addresses that logged into the account;",
            new BulletedText()
            );
        doc.AppendText(
              "Active Sessions to include all stored active sessions, including date, time, "
            + "device, machine cookie, and browser information;",
            new BulletedText()
            );
        doc.AppendText();
        doc.AppendText("F.  Activity Log", new BoldText());
        doc.AppendText();
        doc.AppendText(
              "All activities to include places the user as checked into, events the user has "
            + "joined or has been invited to, a list of all the people the user has followed or "
            + "is currently following, user’s last location that was associated with an update, "
            + "posts, photos, or other content the user has “liked”, to include likes on other "
            + "people’s posts as well as the user’s own posts;",
            new BulletedText()
            );
        doc.AppendText();
        doc.AppendText("II.  Information to be seized by the government", new BoldText(), new UnderlinedText());
        doc.AppendText();
        doc.AppendText("A.  Previously Described Information", new BoldText());
        doc.AppendText();
        doc.AppendText(
               "All information described in Section I above, including correspondence, records, "
            +  "documents, photographs, videos, electronic mail, chat logs, and electronic "
            +  "messages that constitutes fruits, evidence, and instrumentalities of violations of "
            + $"{FormattedContent.CrimesCombinedAsString(_data.Crimes)}, "
            +  "for each account or identifier listed as:",
            new BulletedText()
            );
        doc.AppendText();
        AppendSocialMediaUrls(doc);
        doc.AppendText(
             "Information pertaining to the following matters, including attempting and "
            + "conspiring to engage in the following matters:",
            new BulletedText()
            );
        doc.AppendText();
        doc.AppendText("BEGIN LEGAL CRITERIA FOR OFFENSES", new BoldText());
        doc.AppendText();
        doc.AppendMultilineText(_data.LegalCriteriaForOffenses);
        doc.AppendText();
        doc.AppendText("END LEGAL CRITERIA FOR OFFENSES", new BoldText());
        doc.AppendText();
        doc.AppendText(
            "Communications and all contact between each account or identifier listed as:",
            new BulletedText()
            );
        doc.AppendText();
        AppendSocialMediaUrls(doc);
        doc.AppendText(
               "and any of the suspects, associates, or victims in this investigation, the "
            + "identification of other possible victims, and/or suspects of "
            + $"{FormattedContent.CrimeDescriptionsAsString(_data.Crimes)}.",
            new BulletedText()
            );
        doc.AppendText();
        doc.AppendText("B.  Creation and Communication", new BoldText());
        doc.AppendText();
        doc.AppendText(
              $"Records relating to who created, used, or communicated with the user {_data.Account}, "
            +  "including records about their identities, IP addresses, and whereabouts. ",
            new BulletedText()
            );
        doc.AppendText();
        doc.AppendText("C.  Financial Information", new BoldText());
        doc.AppendText();
        doc.AppendText(
            $"Credit card and other financial information including but not limited to bills and payment records;",
            new BulletedText()
            );
        doc.AppendText();
        doc.AppendText("D.  Account Users and Owners", new BoldText());
        doc.AppendText();
        doc.AppendText(
            "Evidence of who used, owned, or controlled each account or identifier listed as:",
            new BulletedText()
            );
        doc.AppendText();
        AppendSocialMediaUrls(doc);

        doc.AppendText("E.  Account Use", new BoldText());
        doc.AppendText();
        doc.AppendText(
            "Evidence of the times each account or identifier listed as:",
            new BulletedText()
            );
        doc.AppendText();
        AppendSocialMediaUrls(doc);
        doc.AppendText("was used.", new IndentedText());

        doc.PageBreak();

        /*****************************************
         *              Certificate              *
         *****************************************/

        doc.AppendText(
            "CERTIFICATE OF AUTHENTICITY OF DOMESTIC",
            new BoldText(), new UnderlinedText(), new AlignCenter()
            );
        doc.AppendText(
            "RECORDS PURSUANT TO FEDERAL RULES OF",
            new BoldText(), new UnderlinedText(), new AlignCenter()
            );
        doc.AppendText(
            "EVIDENCE 902(11) AND 902(13)",
            new BoldText(), new UnderlinedText(), new AlignCenter()
            );
        doc.AppendText();
        doc.AppendText(
              $"I, {ConstantData.SignHere}, attest, under penalties of perjury by the laws "
            +  "of the United States of America pursuant to 28 U.S.C. § 1746, that the "
            +  "information contained in this certification is true and correct.  I am "
            +  "employed by Facebook, Inc., and my title is "
            + $"{ConstantData.SignHere}.  I am qualified to authenticate the records attached "
            +  "hereto because I am familiar with how the records were created, managed, stored, "
            +  "and retrieved.  I state that the records attached hereto are true duplicates of "
            + $"the original records in the custody of Facebook, Inc.",
            new IndentedText()
            );
        doc.AppendText($"The Attached records consist of:", new IndentedText());
        doc.AppendText(new string('_', ConstantData.GenerallyDescribeRecords.Length), new IndentedText());
        doc.AppendText(ConstantData.GenerallyDescribeRecords, new IndentedText());
        doc.AppendText();
        doc.AppendText("I further state that:");
        doc.AppendText(
              "A. All records attached to this certificate were made at or near the time of the "
            + "occurrence of the matter set forth by, or from information transmitted by, a "
            + "person with knowledge of those matters, they were kept in the ordinary course of "
            + "the regularly conducted business activity of Facebook, Inc., and they were made by "
            + "Facebook, Inc. as a regular practice; and",
            new IndentedText()
            );
        doc.AppendText(
              "B. such records were generated by Facebook, Inc. electronic process or system that "
            + "produces an accurate result, to wit:",
            new IndentedText()
            );
        doc.AppendText(
              "1. the records were copied from electronic device(s), storage medium(s), or file(s) "
            + "in the custody of Facebook, Inc. in a manner to ensure that they are true duplicates "
            + "of the original records; and",
            new IndentedText()
            );
        doc.AppendText(
              "2. the process or system is regularly verified by Facebook, Inc., and at all times "
            + "pertinent to the records certified here the process and system functioned properly and normally.",
            new IndentedText()
            );
        doc.AppendText(
              "I further state that this certification is intended to satisfy Rules 902(11) "
            + "and 902(13) of the Federal Rules of Evidence.",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendText();
        doc.AppendText($"{ConstantData.DateHere}  {ConstantData.SignHere}", new IndentedText());
        doc.AppendText(
            $"Date{new string(' ', ConstantData.DateHere.Length - 2)}Signature", 
            new IndentedText()
            );  // - 2 for the Length of "Date" minus the two spaces between lines.

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + suffix + Extension.Docx;
    }

    private readonly FacebookData _data = data;

    private static Paragraph[] FacebookAddress
    {
        get => [
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

    private void AppendSocialMediaAccounts(DocxDocument doc)
    {
        foreach (var profile in _data.Profiles)
        {
            doc.AppendText(profile.Name);
            doc.AppendIndentedUrl(profile.URL);
            doc.AppendText();
        }
        
    }

    private void AppendSocialMediaUrls(DocxDocument doc)
    {
        foreach (var profile in _data.Profiles)
        {
            doc.AppendIndentedUrl(profile.URL);
            doc.AppendText();
        }
    }

}
