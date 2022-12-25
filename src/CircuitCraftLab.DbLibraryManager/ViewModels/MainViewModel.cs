using System.Collections.Generic;

using Microsoft.Win32;

using ImeSense.Helpers.Mvvm.ComponentModel;
using ImeSense.Helpers.Mvvm.Input;

using IniFile;

namespace CircuitCraftLab.DbLibraryManager.ViewModels;

public class MainViewModel : ObservableObject {
    private void OpenFileAction() {
        var openDialog = new OpenFileDialog {
            DefaultExt = "DbLib",
            Filter = "Altium Database Library File (*.DbLib)|*.DbLib|All files (*.*)|*.*",
            Title = "Open database library file"
        };

        var dialogResult = openDialog.ShowDialog() ?? false;
        if (!dialogResult) {
            return;
        }

        var list = new List<string>();
        var config = new Ini(openDialog.FileName);
        foreach (var section in config) {
            list.Add("[" + section.Name + "]");

            foreach (var item in section) {
                list.Add(item.Name + "=" + item.Value);
            }
        }
    }

    private IRelayCommand? _openFileCommand;
    public IRelayCommand OpenFileCommand => _openFileCommand ??= new RelayCommand(OpenFileAction);
}
