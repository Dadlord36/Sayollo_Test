using System;
using System.Threading.Tasks;
using Controllers.Interfaces;
using REST_API.Interfaces;
using ScriptableDataModels.Interfaces;
using Structures;
using Tools.Interfaces;
using UnityEngine;
using Zenject;

namespace Repositories
{
    public class API_Repository : I_API_Repository
    {
        [Inject] private readonly I_API_Provider _apiProvider;
        [Inject] private readonly IFileDownloader _fileDownloader;
        [Inject] private readonly IStorageController _storageController;
        [Inject] private readonly IStoragePathsSource _storagePathsSource;

        public async Task TryDownloadAndSaveVideoFile()
        {
            try
            {
                byte[] byteData = await _fileDownloader.TryDownloadFile();
                await TrySaveVideoFile(byteData).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        public Task TrySaveVideoFile(byte[] binaryData)
        {
            try
            {
                return _storageController.SaveFile(new FileSaveData(_storagePathsSource.VideoFileData, binaryData));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        #region Properties

        public Task<string> InternetVideoSource => _apiProvider.GetVideoUrl();
        public string LocalVideoSource => _storagePathsSource.VideoFileFullPath;
        public Task<byte[]> StoredVideoData => _storageController.LoadFile(_storagePathsSource.VideoFileData);

        #endregion
    }
}