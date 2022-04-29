using System.IO;
using Structures;
using UnityEngine;

namespace Utilities
{
    public class FileDataExtension
    {
        public static string GetAppDataStorageRelativeFilePath(in FileData fileData)
        {
            return Path.Combine(new[] { Application.persistentDataPath, fileData.FolderName, $"{fileData.FileName}.{fileData.Extension}" });
        }

        public static string GetAppDataStorageRelativeFolderPath(in FileData fileData)
        {
            return Path.Combine(Application.persistentDataPath, fileData.FolderName);
        }
    }
}