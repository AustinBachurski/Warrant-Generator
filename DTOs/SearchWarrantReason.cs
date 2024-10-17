using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct SearchWarrantReason(string reason) : IReplacementData
{
    public string target { get; set; } = "{{SEARCH_WARRANT_REASON}}";
    public string data { get; set; } = reason;
}

