using Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;

namespace Task10.TreeSize.FileSystem.Wrappers.FileInfoWrappers;

public interface IFileInfo : IFileSystemInfo
{
    long Length { get; }
}