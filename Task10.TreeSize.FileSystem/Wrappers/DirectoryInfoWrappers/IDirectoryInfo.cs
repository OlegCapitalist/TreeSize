using Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;

namespace Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers
{
    public interface IDirectoryInfo : IFileSystemInfo
    {
        IEnumerable<FileInfo> GetFiles();

        IEnumerable<DirectoryInfo> GetDirectories();

    }
}
