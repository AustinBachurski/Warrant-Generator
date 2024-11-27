using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using WarrantGenerator.Constants;


namespace WarrantGenerator.Views;

public partial class SetupWindow : Window
{
    public SetupWindow()
    {
        InitializeComponent();
        DocumentOutPathButton.Text = EnVars.DocumentOutPath;
        OfficerNameButton.Text = EnVars.OfficerName;
        OfficerGenderButton.Text = EnVars.OfficerGender;
        OfficerRankButton.Text = EnVars.OfficerRank;
        HireDateButton.Text = EnVars.HireDate;

        CurrentDocumentOutPathValue.Text = Environment.GetEnvironmentVariable(EnVars.DocumentOutPath) ?? "NOT SET";
        CurrentOfficerNameValue.Text = Environment.GetEnvironmentVariable(EnVars.OfficerName) ?? "NOT SET";
        CurrentOfficerRankValue.Text = Environment.GetEnvironmentVariable(EnVars.OfficerRank) ?? "NOT SET";
        CurrentOfficerGenderValue.Text = Environment.GetEnvironmentVariable(EnVars.OfficerGender) ?? "NOT SET";
        CurrentHireDateValue.Text = Environment.GetEnvironmentVariable(EnVars.HireDate) ?? "NOT SET";
    }

    public void CopyDocumentOutPath (object sender, RoutedEventArgs _)
    {
        Clipboard?.SetTextAsync(EnVars.DocumentOutPath);
    }

    public void CopyOfficerName (object sender, RoutedEventArgs _)
    {
        Clipboard?.SetTextAsync(EnVars.OfficerName);
    }

    public void CopyOfficerGender (object sender, RoutedEventArgs _)
    {
        Clipboard?.SetTextAsync(EnVars.OfficerGender);
    }

    public void CopyOfficerRank (object sender, RoutedEventArgs _)
    {
        Clipboard?.SetTextAsync(EnVars.OfficerRank);
    }

    public void CopyHireDate (object sender, RoutedEventArgs _)
    {
        Clipboard?.SetTextAsync(EnVars.HireDate);
    }

}