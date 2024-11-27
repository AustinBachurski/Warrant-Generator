using Avalonia.Controls;

using System;


namespace WarrantGenerator.Views;

public partial class AboutWindow : Window
{
    public AboutWindow()
    {
        InitializeComponent();
    }

    public string AvaloniaURL { get; } = "https://avaloniaui.net/";
    public string AvaloniaSpellCheckerURL { get; } = "https://github.com/GustavoHennig/Avalonia.SpellChecker";
    public string CommunityMVVMToolkitURL { get; } = "https://github.com/CommunityToolkit/dotnet";
    public string CSharpURL { get; } = "https://dotnet.microsoft.com/en-us/languages/csharp";
    public string GitHubRepoURL { get; } = "https://github.com/AustinBachurski/Warrant-Generator";
    public string OpenXMLSDKURL { get; } = "https://github.com/dotnet/Open-XML-SDK";
    public string MITLicenseURL { get; } = "https://opensource.org/license/MIT";

    public void OpenAvaloniaWebsite(object? sender, Avalonia.Input.PointerPressedEventArgs _)
    {
        Launcher.LaunchUriAsync(new Uri(AvaloniaURL));
    }

    public void OpenAvaloniaSpellCheckerWebsite(object? sender, Avalonia.Input.PointerPressedEventArgs _)
    {
        Launcher.LaunchUriAsync(new Uri(AvaloniaSpellCheckerURL));
    }

    public void OpenCommunityMVVMToolkitWebsite(object? sender, Avalonia.Input.PointerPressedEventArgs _)
    {
        Launcher.LaunchUriAsync(new Uri(CommunityMVVMToolkitURL));
    }

    public void OpenCSharpWebsite(object? sender, Avalonia.Input.PointerPressedEventArgs _)
    {
        Launcher.LaunchUriAsync(new Uri(CSharpURL));
    }

    public void OpenGitHubRepository(object? sender, Avalonia.Input.PointerPressedEventArgs _)
    {
        Launcher.LaunchUriAsync(new Uri(GitHubRepoURL));
    }

    public void OpenOpenXMLSDKWebsite(object? sender, Avalonia.Input.PointerPressedEventArgs _)
    {
        Launcher.LaunchUriAsync(new Uri(OpenXMLSDKURL));
    }

    public void OpenMITLicenseWebsite(object? sender, Avalonia.Input.PointerPressedEventArgs _)
    {
        Launcher.LaunchUriAsync(new Uri(MITLicenseURL));
    }

}

