using System.Collections.Generic;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct CrimeGrammar(int count) : IReplacementData
{
    public string target { get; set; } = "{{CRIME_GRAMMAR}}";
    public string data { get; set; } = count == 1 ? "crime" : "crimes";
}

