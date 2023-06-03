using Microsoft.Extensions.DependencyInjection;

using CircuitCraftLab.DbLibraryManager.ViewModels;
using CircuitCraftLab.DbLibraryManager.Views;

namespace CircuitCraftLab.DbLibraryManager;

public static class ServiceExtensions {
    public static IServiceCollection AddViews(this IServiceCollection services) {
        services.AddSingleton<MainWindow>();
        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services) {
        services.AddSingleton<MainViewModel>();
        return services;
    }
}
