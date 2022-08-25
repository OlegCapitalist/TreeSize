using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

#nullable disable

namespace Storage.Models
{
    public class StorageFile
    {
        //private FileInfo _file;
        //private DirectoryInfo _directory;

        public string FullName { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public string ParrentDirectoryName { get; set; }
        public StorageDirectory ParrentDirectory { get; set; }

        public long Size { get; set; } = 0;

        public decimal SizeKB => Math.Round((decimal)Size / 1024, 2);

        public decimal SizeMB => Math.Round(SizeKB / 1024, 2);

        public decimal SizeGB => Math.Round(SizeMB / 1024, 2);

        //public bool IsDirectory { get; set; } = false; FileInfo не работает на директориях

        public override string ToString() => FullName;

    }
}
