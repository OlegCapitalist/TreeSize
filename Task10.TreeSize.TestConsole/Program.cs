using Task10.TreeSize.FileSystem.Models;
using Task10.TreeSize.FileSystem.Services;
using System.Threading;
using System.Diagnostics;
using Task10.TreeSize.FileSystem.Factories;



string path = "D:\\Games";


var FSS = new FileSystemService(new DirectoryInfoFactory());

var root = await FSS.GetFileSystemItemsAsync(path, new CancellationToken());

foreach (var item in root.FileSystemItems)
    Console.WriteLine(item.Name);





