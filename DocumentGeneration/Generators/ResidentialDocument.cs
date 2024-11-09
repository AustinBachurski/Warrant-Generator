using WarrantGenerator.Constants;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private string ResidentialDocument()
    {
        List<string> documents = new();

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
        using var newDocument = WordprocessingDocument.Create(_outputPath, WordprocessingDocumentType.Document);

        var document = newDocument.AddMainDocumentPart();
        document.Document = new Document();
        SetDocumentFormatting(document);

        /* Document Content
        *****************************************/

        InsertWarrantApplicationBoilerplate();
        AppendEmptyLine();
        AppendText(_residenceAddress);
        AppendText($"Legal Description: {_residenceDescription}");
        AppendEmptyLine();
        StateOfMontanaCountyOfFlathead();
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
        AppendIndentedText(
            $"On this {_todaysDate}, {_officerRank} {_officerName}, of the {_organization}, being first duly sworn and upon oath, deposes and says:"
            );
        AppendEmptyLine();
        AppendText(
            $"Affiant, {_officerRank} {_officerName}, hereinafter referred to as I, is a {_officerRank} with the {_organization} and has been a Law Enforcement Officer for the {_organization} for {_employmentDuration} {_employmentDurationType}."
            );
        AppendEmptyLine();
        AppendText(
            $"I make this affidavit in support of an application for a search warrrant for the above described location, particularly, {_residenceDescription}."
            );
        AppendEmptyLine();
        AppendText(
            "This affidavit is intended to show merely that there is sufficient probable cause for the requsted warrant and does not set forth all of my knowledge about this matter."
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
        // Working Here: Use conslusion from the Facebook warrant as well as the "WHEREFORE" part of the Application document.


        /***************************************** 
         * End Document Content*/

        document.Document.Append(_body);
        document.Document.Save();
        return _outputPath;
    }

    private string SearchWarrantDocument()
    {
        using var newDocument = WordprocessingDocument.Create(_outputPath, WordprocessingDocumentType.Document);

        var document = newDocument.AddMainDocumentPart();
        document.Document = new Document();
        SetDocumentFormatting(document);

        /* Document Content
        *****************************************/ 


        /***************************************** 
         * End Document Content*/

        document.Document.Append(_body);
        document.Document.Save();
        return _outputPath;
    }
}

