using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct SuspectDateOfBirth(string dateOfBirth) : IReplacementData
{
    public string target { get; set; } = "{{SUSPECT_DATE_OF_BIRTH}}";
    public string data { get; set; } = dateOfBirth;
}

