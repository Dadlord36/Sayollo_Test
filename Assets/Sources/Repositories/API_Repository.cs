using System.Threading.Tasks;
using REST_API.Interfaces;

namespace Repositories
{
    public class API_Repository : I_API_Repository
    {
        private readonly I_API_Provider _apiProvider;

        public API_Repository(I_API_Provider apiProvider)
        {
            _apiProvider = apiProvider;
        }

        #region Properties

        public Task<string> VideoSource => _apiProvider.GetVideoUrl();

        #endregion
    }
}