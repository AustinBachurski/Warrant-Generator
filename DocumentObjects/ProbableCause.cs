using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct ProbableCause(string reason) : IReplacementData
{
    public string target { get; set; } = "{{PROBABLE_CAUSE}}";
    public string data { get; set; } = reason;
}

