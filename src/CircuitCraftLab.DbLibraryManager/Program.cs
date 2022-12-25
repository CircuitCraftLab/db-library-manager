using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using CircuitCraftLab.DbLibraryManager.Views;

namespace CircuitCraftLab.DbLibraryManager;

public class Program {
    [STAThread]
    public static void Main(string[] args) {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services => {
                services.AddSingleton<App>();
                services.AddSingleton<MainWindow>();
            })
            .Build();

        var app = host.Services.GetService<App>();
        app?.Run();
    }
}
