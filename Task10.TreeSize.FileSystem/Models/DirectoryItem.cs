namespace Task10.TreeSize.FileSystem.Models;

public class DirectoryItem : FileSystemItem
{
    public DirectoryItem(DirectoryInfo directoryInfo, IEnumerable<FileSystemItem> fileSystemItems) 
        : base(directoryInfo, FileSystemItemType.Folder, fileSystemItems)
    {
        
    }

    public override int FileCount { get; }
    public override int FolderCount { get; }
    public override long Size { get; }
}