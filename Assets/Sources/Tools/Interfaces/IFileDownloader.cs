using System;
using System.Threading.Tasks;

namespace Tools.Interfaces
{
    public interface IFileDownloader
    {
        Task<byte[]> TryDownloadFile(IProgress<float> progress);
    }
}