using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct SuspectDriversLicense(string licenseNumber) : IReplacementData
{
    public string target { get; set; } = "{{SUSPECT_DRIVERS_LICENSE_NUMBER}}";
    public string data { get; set; } = licenseNumber;
}

