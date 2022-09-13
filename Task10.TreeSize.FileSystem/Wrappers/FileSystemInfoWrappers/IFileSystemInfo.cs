namespace Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;

public interface IFileSystemInfo
{
    string Name { get; }
    string FullName { get; }
    bool Exists { get; }
}