using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct DurationType(string type) : IReplacementData
{
    public string target { get; set; } = "{{DURATION_TYPE}}";
    public string data { get; set; } = type;
}

