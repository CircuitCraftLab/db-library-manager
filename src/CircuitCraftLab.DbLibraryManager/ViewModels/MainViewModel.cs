using System;
using System.Collections.Generic;
using System.Linq;

using Avalonia.Controls;

using Microsoft.Extensions.DependencyInjection;

using ImeSense.Helpers.Mvvm.ComponentModel;
using ImeSense.Helpers.Mvvm.Input;

using IniFile;

using CircuitCraftLab.DbLibraryManager.Views;

namespace CircuitCraftLab.DbLibraryManager.ViewModels;

public class MainViewModel : ObservableObject {
    private readonly IServiceProvider _serviceProvider;
    private IRelayCommand? _openFileCommand;

    public MainViewModel(IServiceProvider serviceProvider) {
        _serviceProvider = serviceProvider;
    }

    private async void OpenFileActionAsync() {
        var openDialog = new OpenFileDialog {
            Title = "Open database library file",
            Filters = new List<FileDialogFilter>() {
                 new FileDialogFilter() {
                    Name = "Altium Database Library File (*.DbLib)",
                    Extensions = new List<string> {
                        "DbLib"
                    },
                },
            },
            AllowMultiple = false,
        };

        var result = await openDialog.ShowAsync(_serviceProvider
            .GetRequiredService<MainWindow>());
        if (result is null) {
            return;
        }

        var list = new List<string>();
        var config = new Ini(result.FirstOrDefault());
        foreach (var section in config) {
            list.Add("[" + section.Name + "]");
            foreach (var item in section) {
                list.Add(item.Name + "=" + item.Value);
            }
        }
    }

    public IRelayCommand OpenFileCommand =>
        _openFileCommand ??= new RelayCommand(OpenFileActionAsync);
}
