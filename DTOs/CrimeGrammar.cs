using WarrantGenerator.Enums;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct CrimeGrammar(CrimeNumber grammar) : IReplacementData
{
    public string target { get; set; } = "{{CRIME_GRAMMAR}}";
    public string data { get; set; } = grammar == CrimeNumber.Plural ? "crimes" : "crime";
}

