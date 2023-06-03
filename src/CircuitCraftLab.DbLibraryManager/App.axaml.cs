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
        _serviceProvider = new ServiceCollection()
            .AddViews()
            .AddViewModels()
            .BuildServiceProvider();
    }

    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted() {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            // Remove Avalonia data validation
            ExpressionObserver.DataValidators
                .RemoveAll(x => x is DataAnnotationsValidationPlugin);

            desktop.MainWindow = _serviceProvider
                .GetRequiredService<MainWindow>();
            desktop.MainWindow.DataContext = _serviceProvider
                .GetRequiredService<MainViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
