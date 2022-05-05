using System;
using System.IO;
using System.Threading.Tasks;
using REST_API.Interfaces;
using Tools.Interfaces;
using UnityEngine;
using Utilities;
using Zenject;

namespace Tools
{
    public class DefaultFileDownloader : IFileDownloader
    {
        [Inject] private readonly I_API_Provider _apiProvider;

        public async Task<byte[]> TryDownloadFile(IProgress<float> progress)
        {
            try
            {
                return await await _apiProvider.GetVideoUrl().ContinueWith(async result =>
                {
                    using var bytesStream = new MemoryStream();
                    await _apiProvider.WebClient.DownloadAsync(result.Result, bytesStream, progress).ConfigureAwait(false);
                    return bytesStream.ToArray();
                });
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
    }
}