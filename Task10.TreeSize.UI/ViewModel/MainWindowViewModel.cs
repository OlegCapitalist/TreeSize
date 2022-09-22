using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Task10.TreeSize.FileSystem.Services;

namespace Task10.TreeSize.UI.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private IFileSystemService _fileSystemService;

        public MainWindowViewModel(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }
    }
}

