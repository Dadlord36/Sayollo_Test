using System.Threading.Tasks;

namespace Repositories
{
    public interface I_API_Repository
    {
        Task<string> InternetVideoSource { get; }
        string LocalVideoSource { get; }
        Task TryDownloadAndSaveVideoFile();
    }
}