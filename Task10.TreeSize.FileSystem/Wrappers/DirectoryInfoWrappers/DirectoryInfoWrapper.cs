using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;

namespace Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers
{
    public class DirectoryInfoWrapper : FileSystemInfoWrapper, IDirectoryInfo
    {
        private readonly DirectoryInfo _directoryInfo;

        public DirectoryInfoWrapper(DirectoryInfo directoryInfo) : base(directoryInfo)
        {
            _directoryInfo = directoryInfo;
        }

        public IEnumerable<FileInfo> GetFiles() => _directoryInfo.GetFiles();

        public IEnumerable<DirectoryInfo> GetDirectories() => _directoryInfo.GetDirectories();
    }
}
