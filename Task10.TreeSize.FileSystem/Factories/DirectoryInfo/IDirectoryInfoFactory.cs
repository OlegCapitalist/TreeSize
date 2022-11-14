using Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers;

namespace Task10.TreeSize.FileSystem.Factories.DirectoryInfo;

public interface IDirectoryInfoFactory
{
    IDirectoryInfo CreateDirectoryInfo(string path);
}