using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct Template() : IReplacementData
{
    public string target { get; set; } = "{{}}";
    public string data { get; set; }
}

