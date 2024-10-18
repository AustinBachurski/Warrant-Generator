using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct TargetDescription(string description) : IReplacementData
{
    public string target { get; set; } = "{{TARGET_DESCRIPTION}}";
    public string data { get; set; } = description;
}

