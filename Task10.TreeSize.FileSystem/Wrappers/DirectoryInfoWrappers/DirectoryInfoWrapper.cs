using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;
using Task10.TreeSize.FileSystem.Wrappers.FileInfoWrappers;

namespace Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers
{
    public class DirectoryInfoWrapper : FileSystemInfoWrapper, IDirectoryInfo
    {
        private readonly DirectoryInfo _directoryInfo;

        public DirectoryInfoWrapper(DirectoryInfo directoryInfo) : base(directoryInfo)
        {
            _directoryInfo = directoryInfo;
        }

        public IEnumerable<IFileInfo> GetFiles()
        {
            return _directoryInfo.GetFiles().Select(x => new FileInfoWrapper(x));
        }

        public IEnumerable<IDirectoryInfo> GetDirectories()
        {
            return _directoryInfo.GetDirectories().Select(x => new DirectoryInfoWrapper(x));
        }
    }
}
