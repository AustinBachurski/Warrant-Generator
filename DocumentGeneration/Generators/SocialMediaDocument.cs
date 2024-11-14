using WarrantGenerator.Constants;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private string SocialMediaDocument()
    {
        List<string> documents = [];

        if (_generateWarrantApplicationDocument)
        {
            documents.Add(SocialMediaApplicationDocument());
        }

        if (_generateWarrantDocument)
        {
            documents.Add(SocialMediaWarrantDocument());
        }

        return string.Join("\n\t", documents);
    }

    private string SocialMediaApplicationDocument()
    {
        const string suffix = " - APPLICATION";
        using var newDocument = WordprocessingDocument.Create(_outputPath + suffix + Extension.Docx, WordprocessingDocumentType.Document);

        _document = newDocument.AddMainDocumentPart();
        _document.Document = new Document();
        _body = new();
        InitializeDocument();

        /* Document Content
        *****************************************/

        InsertWarrantApplicationBoilerplate();
        if (_requestToSeal) { FiledUnderSeal(); }
        if (_socialMediaPlatform == SocialMedia.Facebook)
        {
            FacebookAndFacebookMessenger();
            AppendEmptyLine();
            AppendSocialMediaAccounts();
            AppendText("Which is under control of:");
            InsertFacebookAddressBlock();
            AppendEmptyLine();
        }
        StateOfMontanaCountyOfFlathead();
        AppendEmptyLine();
        OfficerDeposesAndSays();
        if (_socialMediaPlatform == SocialMedia.Facebook)
        {
            FacebookRecords();
            AppendEmptyLine();
            AppendSocialMediaAccounts();
        }
        AppendIndentedText(
            $"and in the following paragraphs.  This affidavit is made in support of an application for a search warrant under 18 U.S.C. §§ 2703(a), 2703(b)(1)(A) and 2703(c)(1)(A) to require {_socialMediaPlatform} to disclose to the government copies of the information (including the content of communications) further described in Section I of Attachment A."
            );
        AppendEmptyLine();
        AffidavitIntent();
        AppendEmptyLine();
        AppendHeading("PROBABLE CAUSE");
        AppendEmptyLine();
        AppendMultilineText(_probableCause);
        AppendEmptyLine();
        CommonForSocialMediaCriminalActivity();
        AppendEmptyLine();
        AppendHeading("CONCLUSION");
        AppendEmptyLine();
        AppendIndentedText(
            $"Based on the forgoing, I request that the Court issue the proposed search warrant.  Because the warrant will be served on {_socialMediaPlatform}, who will then compile the requested records at a time convenient to it, reasonable cause exists to permit the execution of the requested warrant at any time in the day or night."
            );
        AppendEmptyLine();
        if (_requestToDelayNotification) { RequestToDelayNotification(); }
        if (_requestToSeal) { RequestToSeal(); }
        AppendText($"Dated this {_todaysDate}.");
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText(ConstantData.SignHere);
        AppendIndentedText(_officerName);
        AppendIndentedText(_organization);
        AppendEmptyLine();
        AppendEmptyLine();
        AppendText($"Subscribed and sworn to before me this {_todaysDate}.");
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText(ConstantData.SignHere);
        AppendIndentedText("District Court Judge");

        /***************************************** 
         * End Document Content*/

        _document.Document.Append(_body);
        _document.Document.Save();
        return _outputPath + suffix + Extension.Docx;
    }

    private string SocialMediaWarrantDocument()
    {
        const string suffix = " - WARRANT";
        using var newDocument = WordprocessingDocument.Create(_outputPath + suffix + Extension.Docx, WordprocessingDocumentType.Document);

        _document = newDocument.AddMainDocumentPart();
        _document.Document = new Document();
        _body = new();
        InitializeDocument();

        /* Document Content
        *****************************************/

        /*
        InsertWarrantBoilerplate();
        AppendEmptyLine();
        AppendText(_residenceDescription);
        AppendEmptyLine();
        AppendText($"{_officerRank} {_officerName}, {_organization}");
        AppendEmptyLine();
        AppendIndentedText(
            $"A sworn application having been made before me by {_officerRank} {_officerName}, with the {_organization}, that {_officerSubjectivePronoun} has reason to believe that in the above described area, namely, {_residenceDescription}, there is now located evidence of the crime of {_crimeDescriptions}, namely, {_seizableProperty}."
            );
        AppendIndentedText(
            $"I have examined the Application for Search Warrant and am satisfied that there is probable cause to believe that said evidence is located within the above described area."
            );
        AppendIndentedText(
            $"You are hereby commanded to serve this Warrant and search said area for, including, but not limited to, {_seizableProperty}.  If said evidence is found there, to seize it, together with any other evidence of the {_crimeGrammar} of {_crimeDescriptions}, give a receipt for the same, prepare a written inventory verified by you and the evidence seized and bring said evidence before me, all in the manner provided and required by law."
            );
        AppendEmptyLine();
        AppendText($"Dated this {_todaysDate}.");
        AppendEmptyLine();
        AppendEmptyLine();
        AppendText(ConstantData.SignHere);
        AppendText("District Court Judge");
        */

        /***************************************** 
         * End Document Content*/

        _document.Document.Append(_body);
        _document.Document.Save();
        return _outputPath + suffix + Extension.Docx;
    }

}

