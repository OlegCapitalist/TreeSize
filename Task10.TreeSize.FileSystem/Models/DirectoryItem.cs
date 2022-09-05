namespace Task10.TreeSize.FileSystem.Models;

public class DirectoryItem : FileSystemItem
{
    public DirectoryItem(DirectoryInfo directoryInfo, IEnumerable<FileSystemItem> fileSystemItems) 
        : base(directoryInfo, FileSystemItemType.Folder, fileSystemItems)
    {
        
    }

    public DirectoryItem(DirectoryInfo directoryInfo)
        : base(directoryInfo, FileSystemItemType.Folder)
    {

    }

    //public override int FileCount { get; }
    //public override int FolderCount { get; }

    public override int FileCount => FileSystemItems.Where(item => item.ItemType == FileSystemItemType.File).ToList().Count;
    public override int FolderCount => FileSystemItems.Where(item => item.ItemType == FileSystemItemType.Folder).ToList().Count;

    public override long Size { get; }
}