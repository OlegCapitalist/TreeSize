using Storage.Models;
using Services.Interfaces;
using System.IO;

namespace Services
{
    public class StorageService : IStrorageService
    {
        public StorageFile GetFile(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            return GetFile(fileInfo);
        }

        public StorageFile GetFile(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
                throw new IOException("File not exist");

            var storageFile = new StorageFile()
            {
                FullName = fileInfo.FullName,
                Name = fileInfo.Name,
                Path = fileInfo.DirectoryName,
                Size = fileInfo.Length,
                ParrentDirectoryName = fileInfo.DirectoryName
            };

            return storageFile;
        }

        public StorageDirectory GetDirectory(string directoryName)
        {
            var directoryInfo = new DirectoryInfo(directoryName);

            if (!directoryInfo.Exists)
                throw new IOException("File not exist");

            var storageDirectory = new StorageDirectory()
            {
                FullName = directoryInfo.FullName,
                Name = directoryInfo.Name,
                ParrentDirectoryName = directoryInfo.Parent?.FullName

            };

            return storageDirectory;
        }

        public List<StorageFile> GetIncludedFiles(string directoryName)
        {
            var Dir = new DirectoryInfo(directoryName);
            
            var result = new  List<StorageFile>();

            foreach (var file in Dir.GetFiles().ToList())
                result.Add(GetFile(file));

            return result;
        }

        public List<StorageFile> GetIncludedFiles(StorageFile storageFile)
        {
            return GetIncludedFiles(storageFile.FullName);
        }

        public List<StorageDirectory> GetIncludedDirectories(string directoryName)
        {
            var Dir = new DirectoryInfo(directoryName);

            var result = new List<StorageDirectory>();

            foreach (var dir in Dir.GetDirectories().ToList())
                result.Add(GetDirectory(dir.FullName));

            return result;
        }

        public List<StorageDirectory> GetIncludedDirectories(StorageDirectory storageDirectory)
        {
            return GetIncludedDirectories(storageDirectory.FullName);
        }
    }
}