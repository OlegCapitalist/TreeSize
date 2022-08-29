namespace Task10.TreeSize.FileSystem.Models;

internal class FileItem : FileSystemItem
{
    private readonly FileInfo _fileInfo;

    public FileItem(FileInfo fileInfo) : base(fileInfo, FileSystemItemType.File)
    {
        _fileInfo = fileInfo;
    }

    public override long Size => _fileInfo.Length;
}