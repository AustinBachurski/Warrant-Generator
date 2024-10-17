using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct TargetAddress(string address) : IReplacementData
{
    public string target { get; set; } = "{{TARGET_ADDRESS}}";
    public string data { get; set; } = address;
}

