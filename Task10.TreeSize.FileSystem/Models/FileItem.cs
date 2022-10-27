using Task10.TreeSize.FileSystem.Wrappers.FileInfoWrappers;

namespace Task10.TreeSize.FileSystem.Models;

public class FileItem : FileSystemItem
{
    private readonly IFileInfo _fileInfo;

    public FileItem(IFileInfo fileInfo, FileSystemItem parrent = null) : base(fileInfo, FileSystemItemType.File, parrent)
    {
        _fileInfo = fileInfo;

        Size = _fileInfo.Length;
    }

}