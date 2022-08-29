using System.Collections.Concurrent;
using System.Diagnostics;
using Task10.TreeSize.FileSystem.Models;

namespace Task10.TreeSize.FileSystem.Services;

public class FileSystemService : IFileSystemService
{
    public async Task<IEnumerable<FileSystemItem>> GetFileSystemItemsAsync(string path)
    {
        var directoryInfo = new DirectoryInfo(path);

        if (!directoryInfo.Exists)
        {
            throw new DirectoryNotFoundException($"Directory was not found. Path: {path}");
        }

        var result = await GetFileSystemItemsRecursiveAsync(directoryInfo);

        return result;
    }

    private static async Task<IEnumerable<FileSystemItem>> GetFileSystemItemsRecursiveAsync(DirectoryInfo directoryInfo)
    {
        var fileInfos = directoryInfo.GetFiles();
        var directoryInfos = directoryInfo.GetDirectories();

        var output = new ConcurrentBag<FileSystemItem>();

        foreach (var fileInfo in fileInfos)
        {
            output.Add(new FileItem(fileInfo));
        }

        await Parallel.ForEachAsync(directoryInfos, async (info, _) =>
        {
            try
            {
                var childrenItems = await GetFileSystemItemsRecursiveAsync(info);
                output.Add(new DirectoryItem(info, childrenItems));
            }
            catch (UnauthorizedAccessException exception)
            {
                Debug.WriteLine(exception);
            }
        });

        return output;
    }
}