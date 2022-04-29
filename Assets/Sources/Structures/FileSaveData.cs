namespace Structures
{
    public struct FileSaveData
    {
        private FileData _fileData;
        public readonly byte[] BinaryData;

        public FileSaveData(FileData fileData, byte[] binaryData)
        {
            _fileData = fileData;
            BinaryData = binaryData;
        }

        public string FolderPath => Utilities.FileDataExtension.GetAppDataStorageRelativeFolderPath(_fileData);
        public string FullPath => Utilities.FileDataExtension.GetAppDataStorageRelativeFilePath(_fileData);
    }
}