using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct TargetDescription : IReplacementData
{
    public string target { get; set; } = "{{TARGET_DESCRIPTION}}";
    public string data { get; set; }

    public TargetDescription(string description)
    {
        data = description;
    }
}

