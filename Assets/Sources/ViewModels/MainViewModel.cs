using System;
using System.IO;
using Controllers.Interfaces;
using Repositories;
using UnityEngine;
using Views;

namespace ViewModels
{
    public class MainViewModel
    {
        private readonly I_API_Repository _apiRepository;
        private readonly IVideoPlayerController _videoPlayerController;
        private readonly MainView _mainView;

        public MainViewModel(MainView mainView, IVideoPlayerController videoPlayerController, I_API_Repository apiRepository)
        {
            _apiRepository = apiRepository;
            _videoPlayerController = videoPlayerController;
            _mainView = mainView;
            mainView.PlayVideoStreamClicked += PlayVideoFromInternet;
            mainView.DownloadAndSaveClicked += DownloadAndSaveVideo;
            mainView.LoadAndPlayClicked += PlayVideoFromStorage;
        }
        
        private async void DownloadAndSaveVideo()
        {
            try
            {
                await _apiRepository.TryDownloadAndSaveVideoFile();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        ~MainViewModel()
        {
            _mainView.PlayVideoStreamClicked -= PlayVideoFromInternet;
        }

        private void PlayVideoFromStorage()
        {
            if (!File.Exists(_apiRepository.LocalVideoSource))
            {
                Debug.Log("Video file is not Exists!");
                return;
            }
            _videoPlayerController.SourceUrl = _apiRepository.LocalVideoSource;
        }

        private async void PlayVideoFromInternet()
        {
            try
            {
                _videoPlayerController.SourceUrl = await _apiRepository.InternetVideoSource;
                Debug.Log("Video source Url was retrieved successfully");
                _videoPlayerController.PlayVideo();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
    }
}