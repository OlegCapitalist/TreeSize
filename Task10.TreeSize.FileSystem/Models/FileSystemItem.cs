using Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;

namespace Task10.TreeSize.FileSystem.Models
{
    public abstract class FileSystemItem
    {
        private readonly IFileSystemInfo _fileSystemInfo;

        public FileSystemItem(
            IFileSystemInfo fileSystemInfo,
            FileSystemItemType itemType,
            IEnumerable<FileSystemItem>? fileSystemItems = null,
            FileSystemItem? parrent = null)
        {
            _fileSystemInfo = fileSystemInfo;

            ItemType = itemType;
            FileSystemItems = fileSystemItems ?? new List<FileSystemItem>();
            Parrent = parrent;
        }

        public FileSystemItemType ItemType { get; }
        public string Name => _fileSystemInfo.Name;
        public string FullName => _fileSystemInfo.FullName;
        public virtual int FileCount => 0;
        public virtual int FolderCount => 0;
        public virtual long Size => 0;

        public FileSystemItem Parrent { get;}
        //public long ParrentSize => Parrent.Size;
        public long ParrentSize { get; set; }

        public IEnumerable<FileSystemItem> FileSystemItems { get; }
    }
}