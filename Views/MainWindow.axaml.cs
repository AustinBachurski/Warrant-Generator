using Avalonia.Controls;
using Avalonia.SpellChecker;

namespace WarrantGenerator.Views;

public partial class MainWindow : Window
{
    private readonly TextBoxSpellChecker _spellChecker;

    public MainWindow()
    {
        InitializeComponent();

        _spellChecker = new TextBoxSpellChecker(SpellCheckerConfig.Create("en_US"));

        string[] textboxes = [
            "TargetAddressTextBox", 
            "TargetDescriptionTextBox",
            "WarrantReasonTextBox",
            "WarrantContentTextBox",
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

