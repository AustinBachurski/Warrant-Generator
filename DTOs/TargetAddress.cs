using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct TargetAddress : IReplacementData
{
    public string target { get; set; } = "{{TARGET_ADDRESS}}";
    public string data { get; set; }

    public TargetAddress(string address)
    {
        data = address;
    }
}

