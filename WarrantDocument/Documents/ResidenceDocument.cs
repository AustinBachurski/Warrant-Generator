using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.WarrantDocument;
using WarrantGenerator.WarrantDocument.Boilerplate;
using WarrantGenerator.WarrantDocument.Formatters;

using System.Collections.Generic;


namespace WarrantGenerator.DocumentGeneration;

public partial class ResidenceDocument(ResidenceData data)
{
    public string GenerateDocuments()
    {
        List<string> documents = [];

        if (_data.GenerateWarrantApplicationDocument)
        {
            documents.Add(GenerateApplicationDocument());
        }

        if (_data.GenerateWarrantDocument)
        {
            documents.Add(GenerateSearchWarrantDocument());
        }

        return string.Join("\n\t", documents);
    }

    private string GenerateApplicationDocument()
    {
        const string suffix = " - APPLICATION";

        using var doc = new DocxDocument(_data.OutputFile + suffix + Extension.Docx);

        /* Document Content
        *****************************************/

        doc.AppendContent(DocxBoilerplate.DistrictBoilerplate("APPLICATION FOR", "SEARCH WARRANT"));
        doc.AppendText();
        doc.AppendText($"Address: {_data.ResidenceAddress}");
        doc.AppendText($"Description: {_data.ResidenceDescription}.");
        doc.AppendText();
        if (!_data.Telephonic)
        {
            doc.AppendContent(DocxBoilerplate.StateOfMontanaBoilerplate);
        }
        else
        {
            doc.AppendText("(JUDGE WILL ADMINISTER OATH OVER THE TELEPHONE)", new BoldText());
        }
        doc.AppendText();
        doc.AppendText(
             $"I, {_data.OfficerName}, do solemnly affirm or swear that I am the person who "
            + "signed the below Application for Search Warrant and knows the contents to be "
            + "true and correct of my own personal knowledge."
            );
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText(_data.OfficerName, new IndentedText());
        doc.AppendText(ConstantData.KPD, new IndentedText());
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
        doc.AppendText(
               "I make this affidavit in support of an application for a search warrant for the "
            + $"above described location, particularly, {_data.ResidenceDescription}."
            );
        doc.AppendText();
        doc.AppendText(
              "This affidavit is intended to show merely that there is sufficient probable cause "
            + "for the requested warrant and does not set forth all of my knowledge about this matter."
            );
        doc.AppendText();
        doc.AppendText(
               "Based on my training and experience and the facts as set forth in this affidavit, there "
            +  "is probable cause to believe that violations of Montana Code Annotated "
            + $"{FormatContent.CrimesCombinedAsString(_data.Crimes)} have been committed by "
            +  "suspects or unknown person(s)."
            );
        doc.AppendText();
        doc.AppendText("PROBABLE CAUSE", new BoldText(), new UnderlinedText(), new AlignCenter());
        doc.AppendText();
        doc.AppendMultilineText(_data.ProbableCause);
        doc.AppendText();
        doc.AppendText("CONCLUSION", new BoldText(), new UnderlinedText(), new AlignCenter());
        doc.AppendText();
        doc.AppendText(
               "Wherefore, Affiant verily believes there is located within the above-described area, "
            + $"evidence of the {_data.CrimeGrammar} of "
            + $"{FormatContent.CrimeDescriptionsAsString(_data.Crimes)}, including but not limited "
            + $"to, {_data.SeizableProperty}, contrary to the provisions of "
            + $"{FormatContent.CrimeCodesAsString(_data.Crimes)}, Montana Code Annotated.  "
            + $"Affiant requests a Search Warrant be issued authoring a search of said area and to "
            + $"seize any evidence of the {_data.CrimeGrammar} observed therein."
            );
        doc.AppendText();
        if (_data.RequestToSeal) { doc.AppendContent(DocxBoilerplate.RequestToSeal); }
        doc.AppendText("OATH/VERIFICATION", new BoldText(), new UnderlinedText(), new AlignCenter());
        doc.AppendText();
        doc.AppendText(
               "I declare under penalty of perjury and under the laws of the State of Montana that all "
            +  "statements and information contained in the foregoing affidavit are true and correct.  "
            + $"Signed this {_data.TodaysDate}."
            );
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText(_data.OfficerName, new IndentedText());

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + suffix + Extension.Docx;
    }

    private string GenerateSearchWarrantDocument()
    {
        const string suffix = " - WARRANT";

        using var doc = new DocxDocument(_data.OutputFile + suffix + Extension.Docx);

        /* Document Content
        *****************************************/

        doc.AppendContent(DocxBoilerplate.DistrictBoilerplate("SEARCH WARRANT"));
        doc.AppendText();
        doc.AppendText(_data.ResidenceDescription);
        doc.AppendText();
        doc.AppendText($"{_data.OfficerRank} {_data.OfficerName}, {ConstantData.KPD}");
        doc.AppendText();
        doc.AppendText(
              $"A sworn application having been made before me by {_data.OfficerRank} "
            + $"{_data.OfficerName}, with the {ConstantData.KPD}, that {_data.OfficerSubjectivePronoun} "
            +  "has reason to believe that in the above described area, namely, "
            + $"{_data.ResidenceDescription}, there is now located evidence of the crime of "
            + $"{FormatContent.CrimeDescriptionsAsString(_data.Crimes)}, namely, {_data.SeizableProperty}.",
            new IndentedText()
            );
        doc.AppendText(
              "I have examined the Application for Search Warrant and am satisfied that there is probable "
            + "cause to believe that said evidence is located within the above described area.",
            new IndentedText()
            );
        doc.AppendText(
               "You are hereby commanded to serve this Warrant and search said area for, including, "
            + $"but not limited to, {_data.SeizableProperty}.  If said evidence is found there, to "
            + $"seize it, together with any other evidence of the {_data.CrimeGrammar} of "
            + $"{FormatContent.CrimeDescriptionsAsString(_data.Crimes)}, give a receipt for the same, "
            +  "prepare a written inventory verified by you and the evidence seized and bring said "
            +  "evidence before me, all in the manner provided and required by law.",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendText($"Dated this {_data.TodaysDate}.");
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere);
        doc.AppendText("District Court Judge");

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + suffix + Extension.Docx;
    }

    private ResidenceData _data= data;
}

