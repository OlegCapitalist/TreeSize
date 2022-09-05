using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
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

        //var result = await GetFileSystemItemsRecursiveAsync(directoryInfo);

        var directoryItem = new DirectoryItem(directoryInfo);

        var result = new ConcurrentBag<FileSystemItem>();// На выходе мы должны получить коллекцию с одним элементом. В котором будут вложены другие элементы
        directoryItem.FileSystemItems = await GetFileSystemItemsRecursiveAsync(directoryItem);//Почему свойство FileSystemItems мы сделали get?

        result.Add(directoryItem);

        return result;
    }

    //private static async Task<IEnumerable<FileSystemItem>> GetFileSystemItemsRecursiveAsync(DirectoryInfo directoryInfo)
    private static async Task<IEnumerable<FileSystemItem>> GetFileSystemItemsRecursiveAsync(DirectoryItem directoryItem)  //Так и не понял, почему метод static, а не private
    {

        //var fileInfos = directoryInfo.GetFiles();
        //var directoryInfos = directoryInfo.GetDirectories();

        var fileInfos = Directory.GetFiles(directoryItem.FullName);
        var directoryInfos = Directory.GetDirectories(directoryItem.FullName);

        var output = new ConcurrentBag<FileSystemItem>();

        foreach (var fileInfo in fileInfos)
        {
            var fileItem = new FileItem(new FileInfo(fileInfo));
            output.Add(fileItem);
            directoryItem.Size += fileItem.Size;//Как будем считать размер, если свойство Size - get?
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