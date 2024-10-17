using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct OfficerTitle(string title) : IReplacementData
{
    public string target { get; set; } = "{{OFFICER_TITLE}}";
    public string data { get; set; } = title;
}

