using WarrantGenerator.Interfaces;

namespace Warrant_Generator.DTOs;

internal struct OfficerName : IReplacementData
{
    public string target { get; set; } = "{{OFFICER_NAME}}";
    public string data { get; set; }

    public OfficerName(string name)
    {
        data = name;
    }
}

