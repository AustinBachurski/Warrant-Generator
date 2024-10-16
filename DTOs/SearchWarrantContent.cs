using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct SearchWarrantContent : IReplacementData
{
    public string target { get; set; } = "{{SEARCH_WARRANT_CONTENT}}";
    public string data { get; set; }

    public SearchWarrantContent(string content)
    {
        data = content;
    }
}

