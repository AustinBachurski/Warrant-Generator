using WarrantGenerator.Constants;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private string ResidenceDocument()
    {
        List<string> documents = [];

        if (_generateWarrantApplicationDocument)
        {
            documents.Add(SearchWarrantApplicationDocument());
        }

        if (_generateWarrantDocument)
        {
            documents.Add(SearchWarrantDocument());
        }

        return string.Join("\n\t", documents);
    }

    private string SearchWarrantApplicationDocument()
    {
        const string suffix = " - APPLICATION";
        using var newDocument = WordprocessingDocument.Create(_outputPath + suffix + Extension.Docx, WordprocessingDocumentType.Document);

        _document = newDocument.AddMainDocumentPart();
        _document.Document = new Document();
        _body = new();
        InitializeDocument();

        /* Document Content
        *****************************************/

        DistrictBoilerplate("APPLICATION FOR", "SEARCH WARRANT");
        AppendEmptyLine();
        AppendText($"Address: {_residenceAddress}");
        AppendText($"Description: {_residenceDescription}.");
        AppendEmptyLine();
        if (!_telephonic)
        {
            StateOfMontanaCountyOfFlathead();
        }
        else
        {
            AppendBoldText("(JUDGE WILL ADMINISTER OATH OVER THE TELEPHONE)");
        }
        AppendEmptyLine();
        AppendText(
            $"I, {_officerName}, do solemnly affirm or swear that I am the person who signed the below Application for Search Warrant and knows the contents to be true and correct of my own personal knowledge."
            );
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText(ConstantData.SignHere);
        AppendIndentedText(_officerName);
        AppendIndentedText(_organization);
        AppendEmptyLine();
        OfficerDeposesAndSays();
        AppendText(
            $"I make this affidavit in support of an application for a search warrant for the above described location, particularly, {_residenceDescription}."
            );
        AppendEmptyLine();
        AppendText(
            "This affidavit is intended to show merely that there is sufficient probable cause for the requested warrant and does not set forth all of my knowledge about this matter."
            );
        AppendEmptyLine();
        AppendText(
            $"Based on my training and experience and the facts as set forth in this affidavit, there is probable cause to believe that violations of Montana Code Annotated {_crimesCombined} have been committed by suspects or unknown person(s)."
            );
        AppendEmptyLine();
        AppendHeading("PROBABLE CAUSE");
        AppendEmptyLine();
        AppendMultilineText(_probableCause);
        AppendEmptyLine();
        AppendHeading("CONCLUSION");
        AppendEmptyLine();
        AppendText(
            $"Wherefore, Affiant verily believes there is located within the above-described area, evidence of the {_crimeGrammar} of {_crimeDescriptions}, including but not limited to, {_seizableProperty}, contrary to the provisions of {_crimeCodes}, Montana Code Annotated.  Affiant requests a Search Warrant be issued authoring a search of said area and to seize any evidence of the {_crimeGrammar} observed therein."
            );
        AppendEmptyLine();
        if (_requestToDelayNotification) { RequestToDelayNotification(); }
        if (_requestToSeal) { RequestToSeal(); }
        AppendHeading("OATH/VERIFICATION");
        AppendEmptyLine();
        AppendText(
            $"I declare under penalty of perjury and under the laws of the State of Montana that all statements and information contained in the foregoing affidavit are true and correct.  Signed this {_todaysDate}."
            );
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText(ConstantData.SignHere);
        AppendIndentedText(_officerName);

        /***************************************** 
         * End Document Content*/

        _document.Document.Append(_body);
        _document.Document.Save();
        return _outputPath + suffix + Extension.Docx;
    }

    private string SearchWarrantDocument()
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

        /***************************************** 
         * End Document Content*/

        _document.Document.Append(_body);
        _document.Document.Save();
        return _outputPath + suffix + Extension.Docx;
    }

}

