using WarrantGenerator.Interfaces;

namespace Warrant_Generator.DTOs;

internal struct OfficerName(string name) : IReplacementData
{
    public string target { get; set; } = "{{OFFICER_NAME}}";
    public string data { get; set; } = name;
}

