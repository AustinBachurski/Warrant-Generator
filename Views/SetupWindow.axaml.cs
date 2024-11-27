using WarrantGenerator.Constants;

using Avalonia.Controls;
using Avalonia.Interactivity;
using System;


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

        CurrentDocumentOutPathValue.Text = Environment.GetEnvironmentVariable(EnVars.DocumentOutPath) ?? ConstantData.NotSet;
        CurrentOfficerNameValue.Text = Environment.GetEnvironmentVariable(EnVars.OfficerName) ?? ConstantData.NotSet;
        CurrentOfficerRankValue.Text = Environment.GetEnvironmentVariable(EnVars.OfficerRank) ?? ConstantData.NotSet;
        CurrentOfficerGenderValue.Text = Environment.GetEnvironmentVariable(EnVars.OfficerGender) ?? ConstantData.NotSet;
        CurrentHireDateValue.Text = Environment.GetEnvironmentVariable(EnVars.HireDate) ?? ConstantData.NotSet;
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