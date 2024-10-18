using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct TargetAddress(string address) : IReplacementData
{
    public string target { get; set; } = "{{TARGET_ADDRESS}}";
    public string data { get; set; } = address;
}

