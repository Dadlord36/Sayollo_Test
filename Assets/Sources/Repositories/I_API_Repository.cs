using System.Threading.Tasks;

namespace Repositories
{
    public interface I_API_Repository
    {
        Task<string> VideoSource { get; }
    }
}