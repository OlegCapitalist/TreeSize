﻿using System;
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

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public ObservableCollection<FileSystemItem> FileSystemItems { get; set; } = new ObservableCollection<FileSystemItem>();

        public MainWindowViewModel(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;

            AssignCommands();
        }
        
        public ICommand ChoseDirCommand { get; set; } 
        //    = new DelegateCommand(() =>
        //{
        //    var dialog = new FolderBrowserDialog();

        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        LoadFIleSystemTree(dialog.SelectedPath);
        //    }

        //});

        public ICommand StopScanCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        private async Task LoadFIleSystemTree(string path)
        {
            var items = await _fileSystemService.GetFileSystemItemsAsync(path, _cancellationTokenSource.Token);
            FileSystemItems = new ObservableCollection<FileSystemItem>(items.FileSystemItems);
        }

        private void AssignCommands()
        {
            ChoseDirCommand = new DelegateCommand(() =>
            {
                var dialog = new FolderBrowserDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadFIleSystemTree(dialog.SelectedPath);
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
