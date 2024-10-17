using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct CrimeDescription() : IReplacementData
{
    public string target { get; set; } = "{{CRIME_DESCRIPTION}}";
    public string data { get; set; }
}

