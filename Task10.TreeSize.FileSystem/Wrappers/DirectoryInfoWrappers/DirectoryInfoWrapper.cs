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

            Parent = _directoryInfo.Parent == null
                ? null
                : new DirectoryInfoWrapper(new DirectoryInfo(_directoryInfo.Parent.FullName));
        }

        public IDirectoryInfo? Parent { get; }

        public IEnumerable<IFileInfo> GetFiles()
        {
            var enumerateOptions = new EnumerationOptions
            {
                IgnoreInaccessible = true
            };

            return _directoryInfo
                .EnumerateFiles("*", enumerateOptions)
                .Select(fileInfo => new FileInfoWrapper(fileInfo))
                .ToList();
        }

        public IEnumerable<IDirectoryInfo> GetDirectories()
        {
            var enumerateOptions = new EnumerationOptions
            {
                IgnoreInaccessible = true
            };

            return _directoryInfo
                .EnumerateDirectories("*", enumerateOptions)
                .Select(directoryInfo => new DirectoryInfoWrapper(directoryInfo))
                .ToList();
        }
    }
}
