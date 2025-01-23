using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.Interfaces;
using WarrantGenerator.WarrantDocument.Formatters;


namespace WarrantGenerator.WarrantDocument.Documents;

public class AdministrativeDocument(IAdministrativeData data)
{
    public string GenerateDocument()
    {
        using var doc = new DocxDocument(_data.OutputFile + Extension.Docx);

        /* Document Content
        *****************************************/ 

        doc.AppendText("ADMINISTRATIVE WARRANT", new BoldText(), new UnderlinedText(), new AlignCenter());
        doc.AppendText();
        doc.AppendText($"CR# {_data.ReportNumber}  OFFICER: {_data.OfficerName}");
        doc.AppendText();
        doc.AppendText($"To: {_data.PawnBrokerName}");
        doc.AppendText();
        doc.AppendText(
                "You are hereby commanded, pursuant to the provisions of Montana Code "
            +   "Annotated, 46-5-212, and by the authority of the Undersigned Issuing "
            +   "Peace Officer of Flathead County, Montana, to hold the following described "
            +  $"property pawned by {_data.SuspectName} in your possession for a period of "
            +   "30 days from the date of issuance of this warrant, as suspected stolen property:"
            );
        doc.AppendText();
        doc.AppendMultilineText(_data.ItemsPawned);
        doc.AppendText();
        doc.AppendText(
              "The property may not be sold or otherwise be disposed of during, or after, "
            + "this 30-day period.  Following expiration of this Administrative Warrant, "
            + "you are commanded to surrender the property upon demand to the undersigned "
            +  "or the designated agent of the undersigned, unless instructed otherwise."
            );
        doc.AppendText();
        doc.AppendText(
              "You have the right to appeal the validity of this warrant in either Justice or "
            + "Municipal court within 30 days of the date of issuance."
            );
        doc.AppendText();
        doc.AppendText( $"Issued this {_data.TodaysDate}." );
        doc.AppendText();
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new AlignCenter());
        doc.AppendText("Issuing Peace Officer", new AlignCenter());
        doc.AppendText();
        doc.AppendText();
        doc.AppendText( $"Administrative Warrant received this ______ day of _____________, 20____." );
        doc.AppendText();
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new AlignCenter());
        doc.AppendText("Signature of Pawnbroker or Dealer", new AlignCenter());
        doc.AppendText();
        doc.AppendText();
        doc.AppendText("REQUEST FOR RESTITUTION", new BoldText(), new UnderlinedText(), new AlignCenter());
        doc.AppendText();
        doc.AppendText($"CR# {_data.ReportNumber}");
        doc.AppendText();
        doc.AppendText($"Restitution is due to: {_data.PawnBrokerName}");
        doc.AppendText($"Address: {_data.PawnBrokerAddress}");
        doc.AppendText();
        doc.AppendText(
              "In the amount of $_______________ upon the adjudication of this case for the seizure "
            + "of the following evidence, loss through damage, or unrecovered property."
            );
        doc.AppendText();
        doc.AppendMultilineText(_data.ItemsPawned);
        doc.AppendText();
        doc.AppendText($"{_data.OfficerName} {_data.TodaysDate}.");

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + Extension.Docx;
    }

    private readonly IAdministrativeData _data = data;

}

