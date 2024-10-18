using WarrantGenerator.Interfaces;

namespace WarrantGenerator.DocumentObjects;

internal struct OfficerGender(bool maleChecked) : IReplacementData
{
    public string target { get; set; } = "{{OFFICER_GENDER}}";
    public string data { get; set; } = maleChecked ? "he" : "she";
}

