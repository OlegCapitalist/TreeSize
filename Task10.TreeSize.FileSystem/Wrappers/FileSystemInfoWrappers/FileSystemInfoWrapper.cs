using System.Diagnostics.CodeAnalysis;

namespace Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;

[ExcludeFromCodeCoverage]
public abstract class FileSystemInfoWrapper : IFileSystemInfo
{
    private readonly FileSystemInfo _fileSystemInfo;

    public FileSystemInfoWrapper(FileSystemInfo fileSystemInfo)
    {
        _fileSystemInfo = fileSystemInfo;
    }

    public string Name => _fileSystemInfo.Name;
    public string FullName => _fileSystemInfo.FullName;
    public bool Exists => _fileSystemInfo.Exists;

}