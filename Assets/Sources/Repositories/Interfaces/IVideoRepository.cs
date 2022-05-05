using System;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IVideoRepository
    {
        Task<string> InternetVideoSource { get; }
        string LocalVideoSource { get; }
        Task TryDownloadAndSaveVideoFile(IProgress<float> progress);
    }
}