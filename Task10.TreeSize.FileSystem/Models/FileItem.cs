using Task10.TreeSize.FileSystem.Wrappers.FileInfoWrappers;

namespace Task10.TreeSize.FileSystem.Models;

public class FileItem : FileSystemItem
{
    private readonly IFileInfo _fileInfo;

    public FileItem(IFileInfo fileInfo) : base(fileInfo, FileSystemItemType.File)
    {
        _fileInfo = fileInfo;
    }

    public override long Size => _fileInfo.Length;
}