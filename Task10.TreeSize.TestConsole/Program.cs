using Task10.TreeSize.FileSystem.Models;
using Task10.TreeSize.FileSystem.Services;
using System.Threading;
using System.Diagnostics;



string path = "D:\\Games";
var FSS = new FileSystemService();

var root = await FSS.GetFileSystemItemsAsync(path, new CancellationToken());

foreach (var item in root.FileSystemItems)
    Console.WriteLine(item.Name);





