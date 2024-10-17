using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct EmploymentDuration(string duration) : IReplacementData
{
    public string target {  get; set; } = "{{EMPLOYMENT_DURATION}}";
    public string data { get; set; } = duration;
}

