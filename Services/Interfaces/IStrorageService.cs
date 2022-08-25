using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Models;

namespace Services.Interfaces
{
    public interface IStrorageService
    {
        StorageFile GetFile(string fileName);

        List<StorageFile> GetIncludedFiles(string directoryName);

        List<StorageFile> GetIncludedFiles(StorageFile storageFile);

    }
}
