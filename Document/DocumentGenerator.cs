using System.IO;
using Xceed.Document.NET;
using Xceed.Words.NET;
using WarrantGenerator.Interfaces;

namespace WarrantGenerator.Document;

internal static class DocumentGenerator
{
    internal static void GenerateDocument(string templatePath, string outputFile, IReplacementData[] data)
    {
        using (var document = DocX.Load(templatePath))
        {
            if (document == null)
            {
                throw new FileLoadException("Failed to open template file.");
            }

            foreach (var entry in data)
            {
                var text = new StringReplaceTextOptions
                {
                    SearchValue = entry.target,
                    NewValue = entry.data,
                };

                document.ReplaceText(text);
            }

            document.SaveAs(outputFile);
        }
    }
}

