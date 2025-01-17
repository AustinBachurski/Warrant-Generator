using WarrantGenerator.Constants;
using WarrantGenerator.DTOs;
using WarrantGenerator.WarrantDocument.Formatters;


namespace WarrantGenerator.WarrantDocument.Documents;

public class SubpoenaDocument(SubpoenaData data)
{
    public string GenerateDocument()
    {
        using var doc = new DocxDocument(_data.OutputFile + Extension.Docx);

        /* Document Content
        *****************************************/ 

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + Extension.Docx;
    }

    private readonly SubpoenaData _data = data;

}

