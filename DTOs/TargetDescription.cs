using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct TargetDescription(string description) : IReplacementData
{
    public string target { get; set; } = "{{TARGET_DESCRIPTION}}";
    public string data { get; set; } = description;
}

