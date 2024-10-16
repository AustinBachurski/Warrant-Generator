using WarrantGenerator.Enums;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct Crime : IReplacementData
{
    public string target { get; set; } = "{{CRIME}}";
    public string data { get; set; }

    public Crime()
    {
    }
}

