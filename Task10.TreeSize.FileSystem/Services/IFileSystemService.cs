using Task10.TreeSize.FileSystem.Models;

namespace Task10.TreeSize.FileSystem.Services;

public interface IFileSystemService
{
    Task<IEnumerable<FileSystemItem>> GetFileSystemItemsAsync(string path);
}