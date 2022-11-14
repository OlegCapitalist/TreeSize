using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;
using Task10.TreeSize.UI.Models;
using Task10.TreeSize.UI.Services.MainThreadDispatcher;
using System;

namespace Task10.TreeSize.UI.ViewModels
{
    public abstract class FileSystemItemViewModel : BindableBase
    {
        private readonly IFileSystemInfo _fileSystemInfo;
        private readonly IMainThreadDispatcher _mainThreadDispatcher;
        private readonly DirectoryItemViewModel? _parent;
        private readonly ObservableCollection<FileSystemItemViewModel> _fileSystemItems;

        protected FileSystemItemViewModel(IFileSystemInfo fileSystemInfo, IMainThreadDispatcher mainThreadDispatcher, DirectoryItemViewModel? parent = null)
        {
            _fileSystemInfo = fileSystemInfo;
            _mainThreadDispatcher = mainThreadDispatcher;
            _parent = parent;
            _fileSystemItems = new ObservableCollection<FileSystemItemViewModel>();
        }

        public abstract FileSystemItemType ItemType { get; }

        public string Name => _fileSystemInfo.Name;
        public string FullName => _fileSystemInfo.FullName;

        public double PercentOfParent { get; set; }

        public int FileCount { get; set; }
        public int FolderCount { get; set; }

        public virtual long Size { get; set; }
        public double SizeKb  => Math.Round(((double)Size / 1024), 2);
        public double SizeMb  => Math.Round(((double) Size / 1048576), 2);
        public double SizeGb => Math.Round(((double)Size / 1073741824), 2);

        public IReadOnlyCollection<FileSystemItemViewModel> FileSystemItems => _fileSystemItems;

        public void AddChildNode(FileSystemItemViewModel node)
        {
            _mainThreadDispatcher.Dispatch(() => _fileSystemItems.Add(node));
            ReCalculateInternal();
        }

        public void AddChildNodes(IEnumerable<FileItemViewModel> nodes)
        {
            _mainThreadDispatcher.Dispatch(() => _fileSystemItems.AddRange(nodes));
            ReCalculateInternal();
        }

        public void ReCalculateParentPercent()
        {
            if (_parent != null && _parent.Size != 0)
            {
                PercentOfParent = Math.Round(Size * 100 / (double)_parent.Size, 2);
            }
        }

        private void ReCalculateInternal()
        {
            _parent?.ReCalculate();
            ReCalculate();
        }

        protected virtual void ReCalculate()
        {
            // do nothing.
        }
    }
}
