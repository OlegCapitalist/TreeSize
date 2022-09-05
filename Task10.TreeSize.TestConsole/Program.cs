using Task10.TreeSize.FileSystem.Models;
using Task10.TreeSize.FileSystem.Services;

string path = "D:\\Games";
var FSS = new FileSystemService();

var collection = await FSS.GetFileSystemItemsAsync(path);

foreach (var item in collection)
    Console.WriteLine(item.Name);





