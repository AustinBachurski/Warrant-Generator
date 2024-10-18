using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct EmploymentDuration(string duration) : IReplacementData
{
    public string target { get; set; } = "{{EMPLOYMENT_DURATION}}";
    public string data { get; set; } = duration;
}

