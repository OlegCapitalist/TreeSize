using Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;

namespace Task10.TreeSize.FileSystem.Models
{
    public abstract class FileSystemItem
    {
        private readonly IFileSystemInfo _fileSystemInfo;
        private long _size = 0;

        public FileSystemItem(
            IFileSystemInfo fileSystemInfo,
            FileSystemItemType itemType,
            FileSystemItem parrent = null)
        {
            _fileSystemInfo = fileSystemInfo;

            ItemType = itemType;
            Parrent = parrent;
        }

        public FileSystemItemType ItemType { get; }
        public string Name => _fileSystemInfo.Name;
        public string FullName => _fileSystemInfo.FullName;
        public virtual int FileCount => 0;
        public virtual int FolderCount => 0;

        public long Size 
        { 
            get
            {
                return _size;
            }
            set
            {
                _size = value;

                if (Parrent != null)
                {
                    Parrent.Size += value;
                }
            }
        }

        public FileSystemItem Parrent { get; }

        public virtual IEnumerable<FileSystemItem> FileSystemItems { get; set; } = null;
       
    }
}