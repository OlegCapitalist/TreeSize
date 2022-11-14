using Task10.TreeSize.FileSystem.Wrappers.FileSystemInfoWrappers;

namespace Task10.TreeSize.FileSystem.Wrappers.FileInfoWrappers
{
    public class FileInfoWrapper : FileSystemInfoWrapper, IFileInfo
    {
        private readonly FileInfo _fileInfo;

        public FileInfoWrapper(FileInfo fileInfo) : base(fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public long Length => _fileInfo.Length;
    }
}