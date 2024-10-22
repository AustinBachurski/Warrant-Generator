namespace WarrantGenerator.DTOs;

public struct MCACrime(string code, string description)
{
    public string Code { get; set; } = code;
    public string Description { get; set; } = description;
}

