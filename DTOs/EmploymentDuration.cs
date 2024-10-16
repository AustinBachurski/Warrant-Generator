using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DTOs;

internal struct EmploymentDuration : IReplacementData
{
    public string target {  get; set; } = "{{EMPLOYMENT_DURATION}}";
    public string data { get; set; }

    public EmploymentDuration(string duration)
    {
        data = duration;
    }
}

