using Task10.TreeSize.FileSystem.Models;

namespace Task10.TreeSize.FileSystem.Services;

public interface IFileSystemService
{
    Task<DirectoryItem> GetFileSystemItemsAsync(string path, CancellationToken cancellationToken);
}