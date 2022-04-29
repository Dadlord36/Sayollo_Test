using System;

namespace Structures
{
    [Serializable]
    public struct FileData
    {
        public string FolderName, FileName, Extension;

        public FileData(string folderName, string fileName, string extension)
        {
            FolderName = folderName;
            FileName = fileName;
            Extension = extension;
        }
    }
}