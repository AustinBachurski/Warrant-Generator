using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct Organization(string organization) : IReplacementData
{
    public string target { get; set; } = "{{ORGANIZATION}}";
    public string data { get; set; } = organization;
}

