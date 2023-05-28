using System.Collections.Generic;
using System.Linq;

using Avalonia.Controls;

using IniFile;

using ImeSense.Helpers.Mvvm.ComponentModel;
using ImeSense.Helpers.Mvvm.Input;

namespace CircuitCraftLab.DbLibraryManager.ViewModels;

public class MainViewModel : ObservableObject {
    private IRelayCommand? _openFileCommand;

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

        var result = await openDialog.ShowAsync(Helpers.GetMainWindow());
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
