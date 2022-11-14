using Task10.TreeSize.FileSystem.Wrappers.FileInfoWrappers;
using Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;

namespace Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers
{
    public interface IDirectoryInfo : IFileSystemInfo
    {
        IDirectoryInfo? Parent { get; }

        IEnumerable<IFileInfo> GetFiles();
        IEnumerable<IDirectoryInfo> GetDirectories();
    }
}
