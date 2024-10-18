using System.Linq;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct OfficerGrammar(string title) : IReplacementData
{
    public string target { get; set; } = "{{OFFICER_GRAMMAR}}";
    public string data { get; set; } = CorrectGrammar(title.First());

    private static string CorrectGrammar(char c)
    {
        return char.ToUpper(c) switch
        {
            'A' or 'E' or 'I' or 'O' or 'U' => "an",
            _ => "a",
        };
    }
}

