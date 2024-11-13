using Avalonia.Controls;
using Avalonia.SpellChecker;

namespace WarrantGenerator.Views;

public partial class VehicleContentTab : UserControl
{
    private readonly TextBoxSpellChecker _spellChecker;

    public VehicleContentTab()
    {
        InitializeComponent();

        _spellChecker = new TextBoxSpellChecker(SpellCheckerConfig.Create("en_US"));

        // From x:Name in the .axaml
        string[] textboxes = [
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

