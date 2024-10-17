using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct SearchWarrantContent(string content) : IReplacementData
{
    public string target { get; set; } = "{{SEARCH_WARRANT_CONTENT}}";
    public string data { get; set; } = content;
}

