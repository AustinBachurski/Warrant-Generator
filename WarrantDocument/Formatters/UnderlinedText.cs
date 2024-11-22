﻿using WarrantGenerator.Interfaces;

using DocumentFormat.OpenXml.Wordprocessing;


namespace WarrantGenerator.DocumentGeneration.Formatters;

public class UnderlinedText : IDocxFormatOption
{
    public void Apply(ParagraphProperties paragraphProperties, RunProperties runProperties)
    {
        runProperties.Append(new Underline() { Val = UnderlineValues.Single });
    }
}

