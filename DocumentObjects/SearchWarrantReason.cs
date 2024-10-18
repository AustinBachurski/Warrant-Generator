using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct SearchWarrantReason(string reason) : IReplacementData
{
    public string target { get; set; } = "{{SEARCH_WARRANT_REASON}}";
    public string data { get; set; } = reason;
}

