using Task10.TreeSize.FileSystem.Wrappers.FileInfoWrappers;
using Task10.TreeSize.UI.Models;
using Task10.TreeSize.UI.Services.MainThreadDispatcher;

namespace Task10.TreeSize.UI.ViewModels
{
    public class FileItemViewModel : FileSystemItemViewModel
    {
        private readonly IFileInfo _fileInfo;

        public FileItemViewModel(IFileInfo fileInfo, IMainThreadDispatcher mainThreadDispatcher, DirectoryItemViewModel parent) 
            : base(fileInfo, mainThreadDispatcher, parent)
        {
            _fileInfo = fileInfo;
        }

        public override FileSystemItemType ItemType => FileSystemItemType.File;

        public override long Size => _fileInfo.Length;
    }
}
