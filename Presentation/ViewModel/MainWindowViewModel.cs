using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Models;
using System.Windows.Input;
using Prism.Commands;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Services;

namespace Presentation.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly StorageService _storageService;

        private ObservableCollection<StorageTree> _storageTree;

        public ObservableCollection<StorageTree> StorageTree
        {
            get { return _storageTree; }
            set { SetProperty(ref _storageTree, value); }
        }

        private string _someText;
        public string SomeText
        {
            get { return _someText; }
            set { SetProperty(ref _someText, value); }
        }

        public ICommand ChoseDirCommand { get; set; }

        public MainWindowViewModel()
        {
            _storageService = new StorageService();

            ChoseDirCommand = new DelegateCommand(() =>
            {
                var dialog = new FolderBrowserDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FillBranch(dialog.SelectedPath);
                }

            });
        }

        public void FillBranch(string directoryName)
        {
            _storageTree = new ObservableCollection<StorageTree>();
            var storageTree = new StorageTree(directoryName);

            foreach (var includedDir in _storageService.GetIncludedDirectories(storageTree.FullName))
                storageTree.IncludedFiles.Add(includedDir); //AddRange?

            _storageTree.Add(storageTree);

        }
    }
}

