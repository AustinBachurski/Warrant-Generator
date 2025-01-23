using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.Interfaces;
using WarrantGenerator.WarrantDocument.Boilerplate;
using WarrantGenerator.WarrantDocument.Formatters;

using System.Collections.Generic;


namespace WarrantGenerator.WarrantDocument.Documents;

public class ReturnInventoryDocument(IReturnInventoryData data)
{
    public string GenerateDocuments()
    {
        List<string> documents = [];

        if (_data.GenerateReturnAndRequestDocument)
        {
            documents.Add(GenerateReturnAndRequestDocument());
        }

        if (_data.GenerateInventoryDocument)
        {
            documents.Add(GenerateInventoryDocument());
        }

        if (_data.GenerateOrderDocument)
        {
            documents.Add(GenerateOrderDocument());
        }

        return string.Join("\n\t", documents);
    }

    private string GenerateReturnAndRequestDocument()
    {
        const string suffix = " - RETURN";

        using var doc = new DocxDocument(_data.OutputFile + suffix + Extension.Docx);

        /* Document Content
        *****************************************/

        doc.AppendContent(DocxBoilerplate.DistrictBoilerplate(_data.CourtDistrict, "RETURN OF WARRANT", "AND INVENTORY"));
        doc.AppendText();
        doc.AppendText(_data.SeizableProperty);
        doc.AppendText();
        doc.AppendContent(DocxBoilerplate.StateOfMontanaBoilerplate);
        doc.AppendText();
        doc.AppendText( $"TO: {_data.WarrantSignedBy}" );
        doc.AppendText();
        doc.AppendText(
              $"Returned herewith is the Warrant, dated the {_data.SignedDate}, "
            + $"signed by the Honorable {_data.WarrantSignedBy} for who said Warrant "
            + $"was executed on the {_data.ServedDate}, and as a result of said execution, "
            +  "the property seized was inventoried and is as follows:",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendMultilineText(_data.SeizedProperty);
        doc.AppendText();
        doc.AppendText(
              $"I, {_data.OfficerRank} {_data.OfficerName}, declare under penalty of "
            +  "perjury that this inventory is correct and was returned along with the "
            +  "original warrant to the designated judge.",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText(_data.OfficerName, new IndentedText());
        doc.AppendText(ConstantData.KPD, new IndentedText());
        doc.AppendText();
        doc.AppendText();
        doc.AppendText($"Subscribed and sworn before me on the {_data.TodaysDate}.");
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText("Judge's Signature", new IndentedText());

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + suffix + Extension.Docx;
    }

    private string GenerateInventoryDocument()
    {
        const string suffix = " - INVENTORY";

        using var doc = new DocxDocument(_data.OutputFile + suffix + Extension.Docx);

        /* Document Content
        *****************************************/

        doc.AppendContent(DocxBoilerplate.DistrictBoilerplate(_data.CourtDistrict, "INVENTORY"));
        doc.AppendText();
        doc.AppendText(_data.SeizableProperty);
        doc.AppendText();
        doc.AppendText(
              $"{_data.OfficerRank} {_data.OfficerName} does hereby state that on the "
            + $"{_data.ServedDate} {_data.OfficerSubjectivePronoun} executed the Warrant "
            + $"issued on the {_data.SignedDate}, and as a result of said execution, "
            +  "the property seized was inventoried and is as follows:",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendMultilineText(_data.SeizedProperty);
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText(_data.OfficerName, new IndentedText());
        doc.AppendText();
        doc.AppendContent(DocxBoilerplate.StateOfMontanaBoilerplate);
        doc.AppendText();
        doc.AppendText(
              $"{_data.OfficerRank} {_data.OfficerName}, being first duly sworn deposes "
            + $"and says that {_data.OfficerSubjectivePronoun} is the person who signed "
            +  "the above Inventory and knows the contents to be true and correct of "
            + $"{_data.OfficerPosessivePronoun} own personal knowledge.",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText(_data.OfficerName, new IndentedText());
        doc.AppendText();
        doc.AppendText($"Subscribed and sworn before me this {_data.TodaysDate}.");
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText("District Court Judge", new IndentedText());

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + suffix + Extension.Docx;
    }

    private string GenerateOrderDocument()
    {
        const string suffix = " - ORDER";

        using var doc = new DocxDocument(_data.OutputFile + suffix + Extension.Docx);

        /* Document Content
        *****************************************/

        doc.AppendContent(DocxBoilerplate.DistrictBoilerplate(_data.CourtDistrict, "ORDER FOR CUSTODY"));
        doc.AppendText();
        doc.AppendText(_data.SeizableProperty);
        doc.AppendText();
        doc.AppendText(
              "Return of Warrant having been made before the undersigned; and a verified "
            + "copy of the Inventory of Property seized being presented; and deeming the "
            + "custody of appropriate disposition is necessary,"
            );
        doc.AppendText("NOW THEREFORE;");
        doc.AppendText("IT IS HEREBY ORDERED:");
        doc.AppendText();
        doc.AppendText(
             $"That the {ConstantData.KPD} shall take custody of all the evidence of the "
            + "crime recovered herein, to retain said property for safekeeping and evidence, "
            + "in a locked enclosure until further order of the court.",
            new IndentedText()
            );
        doc.AppendText();
        doc.AppendText($"Dated this {_data.TodaysDate}.");
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText(_data.WarrantSignedBy, new IndentedText());

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + suffix + Extension.Docx;
    }

    private readonly IReturnInventoryData _data = data;

}

