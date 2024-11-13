using WarrantGenerator.Constants;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private string ReturnInventoryDocument()
    {
        List<string> documents = [];

        if (_generateReturnAndRequestDocument)
        {
            documents.Add(ReturnAndRequestDocument());
        }

        if (_generateInventoryDocument)
        {
            documents.Add(InventoryDocument());
        }

        if (_generateOrderDocument)
        {
            documents.Add(OrderDocument());
        }

        return string.Join("\n\t", documents);
    }

    private string ReturnAndRequestDocument()
    {
        const string suffix = " - RETURN";
        using var newDocument = WordprocessingDocument.Create(_outputPath + suffix + Extension.Docx, WordprocessingDocumentType.Document);

        _document = newDocument.AddMainDocumentPart();
        _document.Document = new Document();
        _body = new();
        InitializeDocument();

        /* Document Content
        *****************************************/ 

        InsertReturnBoilerplate();
        AppendEmptyLine();
        AppendText(_seizableProperty);
        AppendEmptyLine();
        StateOfMontanaCountyOfFlathead();
        AppendEmptyLine();
        AppendText( $"TO: {_warrantSignedBy}" );
        AppendEmptyLine();
        AppendIndentedText(
            $"Returned herewith is the Warrant, dated the {_signedDate}, signed by the Honorable {_warrantSignedBy} for who said Warrant was executed on the {_servedDate}, and as a result of said execution, the property seized was inventoried and is as follows:"
            );
        AppendEmptyLine();
        AppendMultilineText(_seizedProperty);
        AppendEmptyLine();
        AppendIndentedText(
            $"I, {_officerRank} {_officerName}, declare under penalty of perjury that this inventory is correct and was returned along with the original warrant to the designated judge."
            );
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText(ConstantData.SignHere);
        AppendIndentedText(_officerName);
        AppendIndentedText(_organization);
        AppendEmptyLine();
        AppendEmptyLine();
        AppendText($"Subscribed and sworn before me on the {_todaysDate}.");
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText(ConstantData.SignHere);
        AppendIndentedText("Judge's Signature");

        /***************************************** 
         * End Document Content*/

        _document.Document.Append(_body);
        _document.Document.Save();
        return _outputPath + suffix + Extension.Docx;
    }

    private string InventoryDocument()
    {
        const string suffix = " - INVENTORY";
        using var newDocument = WordprocessingDocument.Create(_outputPath + suffix + Extension.Docx, WordprocessingDocumentType.Document);

        _document = newDocument.AddMainDocumentPart();
        _document.Document = new Document();
        _body = new();
        InitializeDocument();

        /* Document Content
        *****************************************/ 

        InsertInventoryBoilerplate();
        AppendEmptyLine();
        AppendText(_seizableProperty);
        AppendEmptyLine();
        AppendIndentedText(
            $"{_officerRank} {_officerName} does hereby state that on the {_servedDate} {_officerSubjectivePronoun} executed the Warrant issued on the {_signedDate}, and as a result of said execution, the property seized was inventoried and is as follows:"
            );
        AppendEmptyLine();
        AppendMultilineText(_seizedProperty);
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText(ConstantData.SignHere);
        AppendIndentedText(_officerName);
        AppendEmptyLine();
        StateOfMontanaCountyOfFlathead();
        AppendEmptyLine();
        AppendIndentedText(
            $"{_officerRank} {_officerName}, being first duly sworn deposes and says that {_officerSubjectivePronoun} is the person who signed the above Inventory and knows the contents to be true and correct of {_officerPosessivePronoun} own personal knowledge."
            );
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText(ConstantData.SignHere);
        AppendIndentedText(_officerName);
        AppendEmptyLine();
        AppendText($"Subscribed and sworn before me this {_todaysDate}.");
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

    private string OrderDocument()
    {
        const string suffix = " - ORDER";
        using var newDocument = WordprocessingDocument.Create(_outputPath + suffix + Extension.Docx, WordprocessingDocumentType.Document);

        _document = newDocument.AddMainDocumentPart();
        _document.Document = new Document();
        _body = new();
        InitializeDocument();

        /* Document Content
        *****************************************/ 

        InsertOrderBoilerplate();
        AppendEmptyLine();
        AppendText(_seizableProperty);
        AppendEmptyLine();
        AppendText(
            "Return of Warrant having been made before the undersigned; and a verified copy of the Inventory of Property seized being presented; and deeming the custody of appropriate disposition is necessary,"
            );
        AppendText("NOW THEREFORE;");
        AppendText("IT IS HEREBY ORDERED:");
        AppendEmptyLine();
        AppendIndentedText($"That the {_organization} shall take custody of all the evidence of the crime recovered herein, to retain said property for safekeeping and evidence, in a locked enclosure until further order of the court.");
        AppendEmptyLine();
        AppendText($"Dated this {_todaysDate}.");
        AppendEmptyLine();
        AppendEmptyLine();
        AppendIndentedText(ConstantData.SignHere);
        AppendIndentedText(_warrantSignedBy);

        /***************************************** 
         * End Document Content*/

        _document.Document.Append(_body);
        _document.Document.Save();
        return _outputPath + suffix + Extension.Docx;
    }

}

