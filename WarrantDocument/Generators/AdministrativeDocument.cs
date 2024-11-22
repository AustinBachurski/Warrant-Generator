using WarrantGenerator.Constants;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private string AdministrativeDocument()
    {
        using var newDocument = WordprocessingDocument.Create(_outputPath, WordprocessingDocumentType.Document);

        _document = newDocument.AddMainDocumentPart();
        _document.Document = new Document();
        _body = new();
        InitializeDocument();

        /* Document Content
        *****************************************/ 

        AppendBoldCenteredText("ADMINISTRATIVE WARRANT");
        AppendEmptyLine();
        AppendText($"CR# {_reportNumber}  OFFICER: {_officerName}");
        AppendEmptyLine();
        AppendText($"To: {_pawnBrokerName}");
        AppendEmptyLine();
        AppendText(
            $"You are hereby commanded, pursuant to the provisions of Montana Code Annotated, 46-5-212, and by the authority of the Undersigned Issuing Peace Officer of Flathead County, Montana, to hold the following described property pawned by {_suspectName} in your possession for a period of 30 days from the date of issuance of this warrant, as suspected stolen property:"
            );
        AppendEmptyLine();
        AppendMultilineText(_itemsPawned);
        AppendEmptyLine();
        AppendText(
            "The property may not be sold or otherwise be disposed of during, or after, this 30-day period.  Following expiration of this Administrative Warrant, you are commanded to surrender the property upon demand to the undersigned or the designated agent of the undersigned, unless instructed otherwise."
            );
        AppendEmptyLine();
        AppendText(
            "You have the right to appeal the validity of this warrant in either Justice or Municipal court within 30 days of the date of issuance."
            );
        AppendEmptyLine();
        AppendText( $"Issued this {_todaysDate}." );
        AppendEmptyLine();
        AppendEmptyLine();
        AppendEmptyLine();
        AppendCenteredText(ConstantData.SignHere);
        AppendCenteredText("Issuing Peace Officer");
        AppendEmptyLine();
        AppendEmptyLine();
        AppendText( $"Administrative Warrant received this ______ day of _____________, 20____." );
        AppendEmptyLine();
        AppendEmptyLine();
        AppendEmptyLine();
        AppendCenteredText(ConstantData.SignHere);
        AppendCenteredText("Signature of Pawnbroker or Dealer");
        AppendEmptyLine();
        AppendEmptyLine();
        AppendBoldCenteredText("REQUEST FOR RESTITUTION");
        AppendEmptyLine();
        AppendText($"CR# {_reportNumber}");
        AppendEmptyLine();
        AppendText($"Restitution is due to {_pawnBrokerName}");
        AppendText($"Address: {_pawnBrokerAddress}");
        AppendText("In the amount of $_______________ upon the adjudication of this case for the seizure of the following evidence, loss through damage, or unrecovered property.");
        AppendEmptyLine();
        AppendMultilineText(_itemsPawned);
        AppendEmptyLine();
        AppendText($"{_officerName} {_todaysDate}.");

        /***************************************** 
         * End Document Content*/

        _document.Document.Append(_body);
        _document.Document.Save();
        return _outputPath;
    }

}

