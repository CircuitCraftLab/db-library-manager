using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CircuitCraftLab.DbLibraryManager.Views;

/// <summary>
/// Interaction logic for MainWindow.axaml
/// </summary>
public class MainWindow : Window {
    private void InitializeComponent() =>
        AvaloniaXamlLoader.Load(this);

    public MainWindow() =>
        InitializeComponent();
}
