using System;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WarrantGenerator.DocumentGeneration;
using WarrantGenerator.DTOs;
using WarrantGenerator.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Avalonia.Controls;
using Avalonia;
using System.IO;

namespace WarrantGenerator.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public AdministrativeContentViewModel AdministrativeTab { get; } = new();
    public ReturnInventoryContentViewModel ReturnInventoryTab { get; } = new();
    public AppOrderContentViewModel AppOrderTab { get; } = new();
    public StructureContentViewModel StructureTab { get; } = new();
    public DnaContentViewModel DnaTab { get; } = new();
    public GsrContentViewModel GsrTab { get; } = new();
    public SubpoenaContentViewModel SubpoenaTab { get; } = new();
    public TelephonicContentViewModel TelephonicTab { get; } = new();
    public SocialMediaContentViewModel SocialMediaTab { get; } = new();
}

