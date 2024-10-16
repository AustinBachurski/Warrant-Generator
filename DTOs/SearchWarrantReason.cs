using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct SearchWarrantReason : IReplacementData
{
    public string target { get; set; } = "{{SEARCH_WARRANT_REASON}}";
    public string data { get; set; }

    public SearchWarrantReason(string reason)
    {
        data = reason;
    }
}

