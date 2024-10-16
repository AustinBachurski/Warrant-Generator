using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct Template : IReplacementData
{
    public string target { get; set; }
    public string data { get; set; }
}

