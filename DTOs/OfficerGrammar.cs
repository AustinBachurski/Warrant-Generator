using System.Linq;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct OfficerGrammar : IReplacementData
{
    public string target { get; set; } = "{{OFFICER_GRAMMAR}}";
    public string data { get; set; }

    public OfficerGrammar(string title)
    {
        data = CorrectGrammar(title.First());
    }

    private string CorrectGrammar(char c)
    {
        switch (c)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return "an";
            default:
                return "a";
        }
    }
}

