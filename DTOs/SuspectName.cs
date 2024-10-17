using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct SuspectName(string name) : IReplacementData
{
    public string target { get; set; } = "{{SUSPECT_NAME}}";
    public string data { get; set; } = name;
}

