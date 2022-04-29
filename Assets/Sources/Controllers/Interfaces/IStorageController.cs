using System.Threading.Tasks;
using Structures;

namespace Controllers.Interfaces
{
    public interface IStorageController
    {
        Task SaveFile(in FileSaveData data);
        Task<byte[]> LoadFile(in FileData fileData);
    }
}