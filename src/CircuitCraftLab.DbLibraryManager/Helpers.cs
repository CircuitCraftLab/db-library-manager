using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace CircuitCraftLab.DbLibraryManager;

public static class Helpers {
    public static Window GetMainWindow() {
        if (Application.Current?.ApplicationLifetime != null) {
            return ((IClassicDesktopStyleApplicationLifetime) Application.Current.ApplicationLifetime).MainWindow;
        }
        return null!;
    }
}
