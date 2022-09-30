using System.Diagnostics.CodeAnalysis;
using Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers;

namespace Task10.TreeSize.FileSystem.Factories;

[ExcludeFromCodeCoverage]
public class DirectoryInfoFactory : IDirectoryInfoFactory
{
    public IDirectoryInfo CreateDirectoryInfo(string path)
    {
        return new DirectoryInfoWrapper(new DirectoryInfo(path));
    }
}