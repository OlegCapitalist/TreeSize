using Storage.Models;
using Services;

string fileName = "D:\\Install";

var service = new StorageService();

var file = service.GetIncludedFiles(fileName);


//Console.WriteLine(file.Size);
//Console.WriteLine(file.SizeKB);
//Console.WriteLine(file.SizeMB);