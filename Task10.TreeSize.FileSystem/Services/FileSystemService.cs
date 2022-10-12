using System.Collections.Concurrent;
using System.Diagnostics;
using Task10.TreeSize.FileSystem.Models;
using Task10.TreeSize.FileSystem.Factories;
using Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers;
using Task10.TreeSize.FileSystem.Wrappers.FileInfoWrappers;

namespace Task10.TreeSize.FileSystem.Services;

public class FileSystemService : IFileSystemService
{
    private readonly IDirectoryInfoFactory _directoryInfoFactory;

    public FileSystemService(IDirectoryInfoFactory directoryInfoFactory)
    {
        _directoryInfoFactory = directoryInfoFactory;
    }

    public async Task<DirectoryItem> GetFileSystemItemsAsync(string path, CancellationToken cancellationToken)
    {
        var directoryInfo = _directoryInfoFactory.CreateDirectoryInfo(path);

        if (!directoryInfo.Exists)
        {
            throw new DirectoryNotFoundException($"Directory was not found. Path: {path}");
        }

        var childrenItems = await GetFileSystemItemsRecursiveAsync(directoryInfo, cancellationToken);
        return new DirectoryItem(directoryInfo, childrenItems);
    }

    private async Task<IEnumerable<FileSystemItem>> GetFileSystemItemsRecursiveAsync(IDirectoryInfo directoryInfo, CancellationToken cancellationToken)
    {
        var fileInfos = directoryInfo.GetFiles();
        var directoryInfos = directoryInfo.GetDirectories();

        var output = new ConcurrentBag<FileSystemItem>();

        foreach (var fileInfo in fileInfos)
        {
            output.Add(new FileItem(fileInfo));
        }

        var task = Parallel.ForEachAsync(directoryInfos, cancellationToken, async (DirInfo, token) =>
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            try
            {
                var childrenItems = await GetFileSystemItemsRecursiveAsync(DirInfo, token);
                output.Add(new DirectoryItem(DirInfo, childrenItems));
            }
            catch (UnauthorizedAccessException exception)
            {
                Debug.WriteLine(exception);
            }
        });

        return output;
    }
}