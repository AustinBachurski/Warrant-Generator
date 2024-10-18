using System.Collections.Generic;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct Crime(List<string> crimesList) : IReplacementData
{
    public string target { get; set; } = "{{CRIME}}";
    public string data { get; set; } = string.Concat(crimesList, '\n');
}

