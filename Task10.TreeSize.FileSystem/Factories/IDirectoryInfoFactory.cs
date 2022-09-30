using Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers;

namespace Task10.TreeSize.FileSystem.Factories;

public interface IDirectoryInfoFactory
{
    IDirectoryInfo CreateDirectoryInfo(string path);
}