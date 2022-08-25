
using Storage.Models;
using Services;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel
{
    public class StorageTree
    {
        public StorageFile StorageFile { get; set; }

        public string Name => StorageFile.Name;
        public string FullName => StorageFile.FullName;
        public string Path => StorageFile.Path;

        public long Size => StorageFile.Size;


        public decimal SizeKB => StorageFile.SizeKB;

        public ObservableCollection<StorageFile> IncludedFiles { get; set; }

        public StorageTree(string fullName)
        {
            var service = new StorageService();
            StorageFile = service.GetDirectory(fullName);

            IncludedFiles = new ObservableCollection<StorageFile>();
        }
    }
}
