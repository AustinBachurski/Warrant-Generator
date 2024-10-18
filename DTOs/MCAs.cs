namespace WarrantGenerator.DTOs;

public struct MCAs(string code, string description)
{
    public string Code { get; set; } = code;
    public string Description { get; set; } = description;
}
