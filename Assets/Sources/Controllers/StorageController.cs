using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Controllers.Interfaces;
using Structures;
using Utilities;

namespace Controllers
{
    public class DefaultStorageController : IStorageController
    {
        public Task SaveFile(in FileSaveData data)
        {
            Directory.CreateDirectory(data.FolderPath);
            return File.WriteAllBytesAsync(data.FullPath, data.BinaryData, CancellationToken.None);
        }

        public Task<byte[]> LoadFile(in FileData fileData)
        {
            return File.ReadAllBytesAsync(FileDataExtension.GetAppDataStorageRelativeFilePath(fileData), CancellationToken.None);
        }
    }
}