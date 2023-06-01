using System;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using Microsoft.Extensions.DependencyInjection;

using CircuitCraftLab.DbLibraryManager.ViewModels;
using CircuitCraftLab.DbLibraryManager.Views;

namespace CircuitCraftLab.DbLibraryManager;

public partial class App : Application {
    private readonly IServiceProvider _serviceProvider = null!;

    public App() {
        var services = new ServiceCollection();

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>();

        _serviceProvider = services.BuildServiceProvider();
    }

    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted() {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            ExpressionObserver.DataValidators.RemoveAll(x => x is DataAnnotationsValidationPlugin);
            desktop.MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            desktop.MainWindow.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
