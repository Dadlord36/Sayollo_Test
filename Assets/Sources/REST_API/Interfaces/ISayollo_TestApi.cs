using System.Net.Http;
using System.Threading.Tasks;

namespace REST_API.Interfaces
{
    public interface I_API_Provider
    {
        Task<string> GetVideoUrl();
        HttpClient WebClient { get; }
    }
}