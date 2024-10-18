using System.Collections.Generic;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct CrimeGrammar(List<string> crimesList) : IReplacementData
{
    public string target { get; set; } = "{{CRIME_GRAMMAR}}";
    public string data { get; set; } = crimesList.Count == 1 ? "crime" : "crimes";
}

