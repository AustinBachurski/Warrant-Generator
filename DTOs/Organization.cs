using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct Organization : IReplacementData
{
    public string target { get; set; } = "{{ORGANIZATION}}";
    public string data { get; set; }

    public Organization(string organization)
    {
        data = organization;
    }
}

