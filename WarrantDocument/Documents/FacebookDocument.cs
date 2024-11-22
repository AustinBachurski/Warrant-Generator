using DocumentFormat.OpenXml.Wordprocessing;

using System;


namespace WarrantGenerator.DocumentGeneration.DocxDocument;

public class FacebookDocument(string filePath) : DocxDocument(filePath)
{
    private void AppendIndentedUrl(string url)
    {
        _body.Append(
            new Paragraph(
                new Run(
                    new TabChar()
                ),
                new Hyperlink(
                    new Run(
                        new RunProperties(
                            new RunStyle() { Val = DocxStyle.Hyperlink }
                        ),
                        new Text(url)
                    )
                )
                { Id = _document.AddHyperlinkRelationship(new Uri(url), true).Id }
            )
        );
    }

    private void AppendUrl(string url)
    {
        _body.Append(
            new Paragraph(
                new Hyperlink(
                    new Run(
                        new RunProperties(
                            new RunStyle() { Val = DocxStyle.Hyperlink }
                        ),
                        new Text(url)
                    )
                )
                { Id = _document.AddHyperlinkRelationship(new Uri(url), true).Id }
            )
        );
    }

    private void AppendSocialMediaAccounts()
    {
        var accounts = _accountNamesCombined.Split(Environment.NewLine);

        foreach (var account in  accounts)
        {
            var data = account.Split(ConstantData.Separator);

            AppendText(data[0]);         // Name
            AppendIndentedUrl(data[1]);  // URL
            AppendEmptyLine();
        }
    }

    private void AppendSocialMediaUrls()
    {
        var accounts = _accountNamesCombined.Split(Environment.NewLine);

        foreach (var account in  accounts)
        {
            var data = account.Split(ConstantData.Separator);

            AppendIndentedUrl(data[1]);  // URL
            AppendEmptyLine();
        }
    }

    private void FacebookRecords()
    {
        string recordsURL = "https://www.facebook.com/records";
        var linkRelationship = _document.AddHyperlinkRelationship(new Uri(recordsURL), true);

        var paragraph = new Paragraph();
        var runBeforeLink = new Run();
        runBeforeLink.Append(new Text(
            $"I make this affidavit in support of an application for a search warrant for information associated with {_certainAccounts} stored at premises controlled by {SocialMedia.MetaCompany}, "
            ) { Space = SpaceProcessingModeValues.Preserve });
        paragraph.Append(runBeforeLink);

        var linkRun = new Run(new Text(recordsURL));
        linkRun.PrependChild(new RunProperties(new RunStyle() { Val = DocxStyle.Hyperlink }));
        Hyperlink link = new(linkRun) { Id = linkRelationship.Id, };
        paragraph.Append(link);

        var runAfterLink = new Run(new Text(".  The information to be searched is described as:"));
        paragraph.Append(runAfterLink);
        _body.Append(paragraph);
    }

}
