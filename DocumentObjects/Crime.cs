using System.Collections.ObjectModel;
using WarrantGenerator.Interfaces;
using WarrantGenerator.DTOs;
using System.Text;
using System.Linq;

namespace WarrantGenerator.DocumentObjects;

internal struct Crime(ObservableCollection<MCACrime> crimesList) : IReplacementData
{
    public string target { get; set; } = "{{CRIME}}";
    public string data { get; set; } = CrimesAsString(crimesList);

    private static string CrimesAsString(ObservableCollection<MCACrime> crimesList)
    {
        StringBuilder builder = new();

        foreach (MCACrime each in crimesList)
        {
            builder.Append("MCA ");
            builder.Append(each.Code);
            builder.Append(": ");
            builder.Append(each.Description);
            builder.Append(", ");
        }

        builder.Insert(StartingPositionOfLastEntry(builder, crimesList), "and ");

        // Trailing ", " is intentional.
        return builder.ToString();
    }

    private static int StartingPositionOfLastEntry(StringBuilder builder, ObservableCollection<MCACrime> crimesList)
    {
        int contentLength = 8;  // Starting with the length of added content.

        contentLength += crimesList.Last().Code.Length;
        contentLength += crimesList.Last().Description.Length;

        return builder.Length - contentLength;
    }
}
