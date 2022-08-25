using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    public class StorageDirectory : StorageFile
    {
        public List<StorageFile> IncludedFiles { get; set; }

        public List<StorageDirectory> IncludedDirectories { get; set; }

        public int CountOfIncludeFiles => IncludedFiles.Count;

        public int CountOfIncludeDirectories => IncludedDirectories.Count;
    }
}
