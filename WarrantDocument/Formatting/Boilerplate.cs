using WarrantGenerator.Constants;

using DocumentFormat.OpenXml.Wordprocessing;
using System;
using DocumentFormat.OpenXml;


namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    private void AffidavitIntent()
    {
        AppendText(
            "This affidavit is intended to show merely that there is sufficient probable cause for the requested warrant and does not set forth all of my knowledge about this matter."
            );
        AppendEmptyLine();
        AppendText(
            $"Based on my training and experience and the facts as set forth in this affidavit, there is probable cause to believe that violations of {_crimesCombined} have been committed by suspects or unknown person(s)."
            );
    }

    private void FacebookAndFacebookMessenger()
    {
        AppendText("Facebook and Facebook messenger for ");
        AppendText($"the following {_individual} and user");
        AppendText($"{_account} identified by their name");
        AppendText("followed by the account URL:");
    }

    private void OfficerDeposesAndSays()
    {
        AppendIndentedText(
            $"On this {_todaysDate}, {_officerRank} {_officerName}, of the {_organization}, being first duly sworn and upon oath, deposes and says:"
            );
        AppendEmptyLine();
        AppendText(
            $"Affiant, {_officerRank} {_officerName}, hereinafter referred to as I, is {IndefiniteArticle(_officerRank[0])} {_officerRank} with the {_organization} and has been a Law Enforcement Officer for the {_organization} for {_employmentDuration} {_employmentDurationType}.{UtilizeSWAT()}{UtilizeCrimeUnit()}"
            );
        AppendEmptyLine();
    }


}

