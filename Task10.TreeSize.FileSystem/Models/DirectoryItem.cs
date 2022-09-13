using Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers;


namespace Task10.TreeSize.FileSystem.Models;

public class DirectoryItem : FileSystemItem
{
    public DirectoryItem(IDirectoryInfo directoryInfo, IEnumerable<FileSystemItem> fileSystemItems)
        : base(directoryInfo, FileSystemItemType.Folder, fileSystemItems)
    {
        var (fileCount, folderCount, size) = GetCalculatedProperties();

        FileCount = fileCount;
        FolderCount = folderCount;
        Size = size;
    }

    public override int FileCount { get; }
    public override int FolderCount { get; }
    public override long Size { get; }

    private (int FileCount, int FolderCount, long Size) GetCalculatedProperties()
    {
        int fileCount = 0;
        int folderCount = 0;
        long size = 0;

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

        return (fileCount, folderCount, size);
    }
}