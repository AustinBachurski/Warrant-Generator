using Avalonia.Controls;
using Avalonia.SpellChecker;

namespace WarrantGenerator.Views;

public partial class ResidenceContentTab : UserControl
{
    private readonly TextBoxSpellChecker _spellChecker;

    public ResidenceContentTab()
    {
        InitializeComponent();

        _spellChecker = new TextBoxSpellChecker(SpellCheckerConfig.Create("en_US"));

        // From x:Name in the .axaml
        string[] textboxes = [
            "LegalDescriptionTextBox",
            "McaDescriptionTextBox",
            "ProbableCauseTextBox",
            "SeizablePropertyTextBox",
        ];

        foreach (string textbox in textboxes)
        {
            var box = this.FindControl<TextBox>(textbox);
            if (box != null)
            {
                _spellChecker.Initialize(box);
            }
        }
    }

}

