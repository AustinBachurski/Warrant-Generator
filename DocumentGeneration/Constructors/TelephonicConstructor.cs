﻿using WarrantGenerator.ViewModels;

namespace WarrantGenerator.DocumentGeneration;

public partial class DocumentGenerator
{
    public DocumentGenerator(TelephonicContentViewModel model)
    {
        GenerateDocument = TelephonicDocument;
    }
}

