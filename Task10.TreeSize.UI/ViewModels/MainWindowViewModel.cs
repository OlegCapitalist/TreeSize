using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Task10.TreeSize.FileSystem.Services;
using Task10.TreeSize.FileSystem.Models;
using System.Windows.Input;
using System.Windows.Forms;
using System.Threading;

using System.Collections.ObjectModel;

namespace Task10.TreeSize.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IFileSystemService _fileSystemService;

        private string _path;

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public ObservableCollection<FileSystemItem> FileSystemItems { get; set; } = new ObservableCollection<FileSystemItem>();

        public MainWindowViewModel(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;

            AssignCommands();
        }
        
        public ICommand ChoseDirCommand { get; set; } 
        // Почему я не могу сделать так?
        //    = new DelegateCommand(() =>
        //{
        //    var dialog = new FolderBrowserDialog();

        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        LoadFIleSystemTree(dialog.SelectedPath);
        //    }

        //});

        public ICommand StopScanCommand { get; set; }

        public ICommand RefreshCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        private async Task LoadFIleSystemTree(string path)
        {
            var tree = await _fileSystemService.GetFileSystemItemsAsync(path, _cancellationTokenSource.Token);
            FileSystemItems = new ObservableCollection<FileSystemItem>() { tree };
        }

        private void AssignCommands()
        {
            ChoseDirCommand = new DelegateCommand(() =>
            {
                var dialog = new FolderBrowserDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _path = dialog.SelectedPath;
                    //RefreshCommand.Execute(); //Какой тут параметр может быть?
                    LoadFIleSystemTree(_path);
                }

            });

            RefreshCommand = new DelegateCommand(() =>
            {
                if (_path != String.Empty)
                {
                    LoadFIleSystemTree(_path);
                }
            });

            StopScanCommand = new DelegateCommand(() =>
            {
                _cancellationTokenSource.Cancel();
            });

            ExitCommand = new DelegateCommand(() =>
            {
                _cancellationTokenSource.Dispose();
            });
        }

    }
}


