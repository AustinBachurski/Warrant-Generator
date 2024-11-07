using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.Linq;
using WarrantGenerator.Constants;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private string ReturnInventoryDocument()
    {
        List<string> documents = new();

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

        return string.Join('\n', documents);
    }

    private string ReturnAndRequestDocument()
    {
        const string suffix = " - RETURN.docx";
        using var newDocument = WordprocessingDocument.Create(_outputPath + suffix, WordprocessingDocumentType.Document);
        _body = new();

        var document = newDocument.AddMainDocumentPart();
        document.Document = new Document();
        SetDocumentFormatting(document);

        InsertReturnBoilerplate();
        AppendText(_searchableProperty);
        AppendEmptyLine();
        StateOfMontanaCountyOfFlathead();
        AppendText( $"TO {_warrantSignedBy}" );
        AppendEmptyLine();
        AppendIndentedText(
            $"Returned herewith is the Warrant, dated the {_signedDate}, signed by the Honorable {_warrantSignedBy} for who said Warraant was executed on the {_servedDate}, and as a result of said execution, the property seized was inventoried and is as follows:"
            );
        AppendEmptyLine();
        AppendMultilineText(_seizedProperty);
        AppendEmptyLine();
        AppendIndentedText(
            $"I, {_officerTitle} {_officerName}, declare under penalty of perjury that this inventory is correct and was returned along with the original warrant to the designated judge."
            );
        AppendEmptyLine();
        AppendEmptyLine();
        AppendCenteredText(ConstantData.SignHere);
        AppendCenteredText(_officerName);
        AppendCenteredText(_organization);
        AppendEmptyLine();
        AppendEmptyLine();
        AppendText($"Subscribed and sworn before me on the {_nthDayOfMonthYear}");
        AppendEmptyLine();
        AppendEmptyLine();
        AppendText(ConstantData.SignHere);
        AppendCenteredText("Judge's Signature");















        document.Document.Append(_body);
        document.Document.Save();
        return _outputPath + suffix;
    }

    private string InventoryDocument()
    {
        const string suffix = " - INVENTORY.docx";
        using var newDocument = WordprocessingDocument.Create(_outputPath + suffix, WordprocessingDocumentType.Document);
        _body = new();

        var document = newDocument.AddMainDocumentPart();
        document.Document = new Document();
        SetDocumentFormatting(document);

        InsertInventoryBoilerplate();
        AppendEmptyLine();
        // TODO


        document.Document.Append(_body);
        document.Document.Save();
        return _outputPath + suffix;
    }

    private string OrderDocument()
    {
        const string suffix = " - ORDER.docx";
        using var newDocument = WordprocessingDocument.Create(_outputPath + suffix, WordprocessingDocumentType.Document);
        _body = new();

        var document = newDocument.AddMainDocumentPart();
        document.Document = new Document();
        SetDocumentFormatting(document);

        InsertOrderBoilerplate();
        AppendEmptyLine();
        AppendText(
            "Return of Warrant having been made before the undersigned; and a verified copy of the Inventory of Property seized being presented; and deeming the custody of appropriate disposition is necessary,"
            );
        // TODO


        document.Document.Append(_body);
        document.Document.Save();
        return _outputPath + suffix;
    }
}

