using System;
using System.Threading.Tasks;
using REST_API.Interfaces;
using Tools.Interfaces;
using UnityEngine;
using Zenject;

namespace Tools
{
    public class DefaultFileDownloader : IFileDownloader
    {
        [Inject] private readonly I_API_Provider _apiProvider;

        public async Task<byte[]> TryDownloadFile()
        {
            try
            {
                return  await await _apiProvider.GetVideoUrl().ContinueWith(result => _apiProvider.WebClient.GetByteArrayAsync(result.Result));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
    }
}