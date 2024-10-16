using WarrantGenerator.Enums;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct CrimeGrammar : IReplacementData
{
    public string target { get; set; } = "{{CRIME_GRAMMAR}}";
    public string data { get; set; }

    public CrimeGrammar(CrimeNumber grammar)
    {
        data = grammar == CrimeNumber.Plural ? "crimes" : "crime";
    }
}

