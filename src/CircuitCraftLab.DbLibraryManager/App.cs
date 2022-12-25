using System.Windows;

namespace CircuitCraftLab.DbLibraryManager;

public class App : Application {
    private readonly MainWindow _mainWindow;

    public App(MainWindow mainWindow) {
        _mainWindow = mainWindow;
    }

    protected override void OnStartup(StartupEventArgs e) {
        base.OnStartup(e);

        _mainWindow.Show();
    }
}
