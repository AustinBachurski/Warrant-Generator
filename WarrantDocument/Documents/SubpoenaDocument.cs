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

        doc.AppendContent(DocxBoilerplate.SubpoenaHeaderApplicationBoilerplate(_data.AttorneyName));
        doc.AppendContent(DocxBoilerplate.StateOfMontanaBoilerplate);
        doc.AppendText();
        doc.AppendText($"{_data.AttorneyName}, Deputy County Attorney, upon oath, states as follows:", new IndentedText());
        doc.AppendText("1. That he has a duty to investigate alleged unlawful activity.", new IndentedText());
        doc.AppendText("2. That as a result of the information presented to the Flathead County Attorney's Office by the Kalispell Police Department, there is probable cause to believe that the offense of Privacy in Communications has been, or is about to be, committed.", new IndentedText());
        doc.AppendText($"3. That {FormattedContent.SubjectivePronoun(_data.AttorneyGender)} believes the proper administration of justice requires that an Investigative Subpoena be issues in this matter, directing the Custodian of Records, {_data.CompanyName}, {_data.CompanyAddress}, {_data.CityStateZip} to provide to the Kalispell Police Department copies of their records relating to a *57 number trapped on {_data.DateTrapped} to the telephone number {_data.PhoneNumber} between the hours of {_data.StartTime} and {_data.EndTime}; that the belief being based upon the facts and events described in Kalispell Police Department's Office Incident Report number {_data.ReportNumber} attached hereto as Exhibit A.", new IndentedText());
        doc.AppendText($"WHEREFORE, {_data.AttorneyName} requests that this Court find the foregoing records and information to be necessary and proper to this investigation.  Upon such a finding, the State further requests that an Investigative Subpoena be issued to the Custodian of Records for {_data.CompanyName}, {_data.CityStateZip}, requiring copies of any records belonging to phone number {_data.PhoneNumber} for {_data.DateTrapped} between the hours of {_data.StartTime} and {_data.EndTime} or any calls pertinent to this subpoena during the time period of this telephone trap and any extension thereof.  That said records are to be made available to the Kalispell Police Department's Office pursuant to Section 46-4-301, Montana Code Annotated.  It is necessary and proper for the investigation of said suspected unlawful activity and for the proper administration of justice, and the issuance of the same is hereby requested.", new IndentedText());
        doc.AppendText();
        doc.AppendText();
        doc.AppendText();
        doc.AppendText($"Dated this {_data.TodaysDate}.", new IndentedText());
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText(_data.AttorneyName, new IndentedText());
        doc.AppendText();
        doc.AppendText($"Subscribed and sworn to before me this {_data.TodaysDate}.");
        doc.AppendText();
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText("Notary", new IndentedText());
        doc.AppendText("Notary Public for the State of Montana", new IndentedText());
        doc.AppendText("County of Flathead", new IndentedText());
        doc.AppendText("Residing at Kalispell, Montana", new IndentedText());
        doc.AppendText("My Commission Expires: _________________, 20____", new IndentedText());

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

        doc.AppendContent(DocxBoilerplate.SubpoenaHeaderWarrantBoilerplate(_data.AttorneyName));
        doc.AppendContent(DocxBoilerplate.StateOfMontanaTo(_data.CompanyName, _data.CompanyAddress, _data.CityStateZip));
        doc.AppendText();
        doc.AppendText("Having considered the State's request for the issuance of an Investigative Subpoena, this Court finds:", new IndentedText());
        doc.AppendText("1. There is probable cause to believe that the offense of Privacy in Communications has been committed.", new IndentedText());
        doc.AppendText("2. The proper administration of justice requires the issuance of an investigative subpoena and the disclosure of the information requested by the State.", new IndentedText());
        doc.AppendText($"Accordingly, the Custodian of Records for {_data.CompanyName}, {_data.CompanyAddress}, {_data.CityStateZip}, is hereby ordered to provide copies of their records relating to a *57 number trapped on {_data.DateTrapped} to the telephone number {_data.PhoneNumber} between the hours of {_data.StartTime} and {_data.EndTime}.", new IndentedText());
        doc.AppendText("It is further ordered that the contents of this subpoena and the State's request not be disclosed without prior authorization from the Court to do so.", new IndentedText());
        doc.AppendText();
        doc.AppendText();
        doc.AppendText();
        doc.AppendText($"Dated this {_data.TodaysDate}.", new IndentedText());
        doc.AppendText();
        doc.AppendText(ConstantData.SignHere, new IndentedText());
        doc.AppendText("District Judge", new IndentedText());

        /***************************************** 
         * End Document Content*/

        doc.FinalizeDocument();
        return _data.OutputFile + suffix + Extension.Docx;
    }

    private readonly SubpoenaData _data= data;
}
