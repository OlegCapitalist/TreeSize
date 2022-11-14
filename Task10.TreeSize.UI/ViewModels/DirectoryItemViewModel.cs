using Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers;
using Task10.TreeSize.UI.Models;
using Task10.TreeSize.UI.Services.MainThreadDispatcher;

namespace Task10.TreeSize.UI.ViewModels
{
    public class DirectoryItemViewModel : FileSystemItemViewModel
    {
        private readonly IDirectoryInfo _directoryInfo;

        public DirectoryItemViewModel(IDirectoryInfo directoryInfo, IMainThreadDispatcher mainThreadDispatcher, DirectoryItemViewModel? parent = null) 
            : base(directoryInfo, mainThreadDispatcher, parent)
        {
            _directoryInfo = directoryInfo;
        }

        public override FileSystemItemType ItemType => FileSystemItemType.Folder;

        protected override void ReCalculate()
        {
            var fileCount = 0;
            var folderCount = 0;
            var size = 0L;

            foreach (var fileSystemItem in FileSystemItems)
            {
                if (fileSystemItem.ItemType == FileSystemItemType.Folder)
                {
                    folderCount++;
                }
                else
                {
                    fileCount++;
                }

                fileCount += fileSystemItem.FileCount;
                folderCount += fileSystemItem.FolderCount;
                size += fileSystemItem.Size;
            }

            FileCount = fileCount;
            FolderCount = folderCount;
            Size = size;

            foreach (var fileSystemItem in FileSystemItems)
            {
                fileSystemItem.ReCalculateParentPercent();
            }
        }
    }
}
