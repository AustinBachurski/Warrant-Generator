using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct DurationType : IReplacementData
{
    public string target { get; set; } = "{{DURATION_TYPE}}";
    public string data { get; set; }

    public DurationType(string type)
    {
        data = type;
    }
}

