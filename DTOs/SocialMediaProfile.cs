namespace WarrantGenerator.DTOs;

public struct SocialMediaProfile(string name, string url)
{
    public string Name { get; set; } = name;
    public string URL { get; set; } = url;

}
