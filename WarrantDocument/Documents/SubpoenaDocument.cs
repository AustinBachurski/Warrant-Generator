using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.WarrantDocument;
using WarrantGenerator.WarrantDocument.Boilerplate;
using WarrantGenerator.WarrantDocument.Formatters;

using System.Collections.Generic;


namespace WarrantGenerator.WarrantDocument.Documents;

public class SubpoenaDocument(SubpoenaData data)
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

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + suffix + Extension.Docx;
    }

    private readonly SubpoenaData _data= data;
}
