using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct OfficerTitle : IReplacementData
{
    public string target { get; set; } = "{{OFFICER_TITLE}}";
    public string data { get; set; }

    public OfficerTitle(string title)
    {
        data = title;
    }
}

