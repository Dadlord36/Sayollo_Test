using System;
using System.IO;
using Controllers.Interfaces;
using Repositories;
using Repositories.Interfaces;
using UnityEngine;
using Views;

namespace ViewModels
{
    public class VideoPageViewModel
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IVideoPlayerController _videoPlayerController;
        private readonly VideoPageView _videoPageView;

        public VideoPageViewModel(VideoPageView videoPageView, IVideoPlayerController videoPlayerController, IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
            _videoPlayerController = videoPlayerController;
            _videoPageView = videoPageView;
            videoPageView.PlayVideoStreamClicked += PlayVideoFromInternet;
            videoPageView.DownloadAndSaveClicked += DownloadAndSaveVideo;
            videoPageView.LoadAndPlayClicked += PlayVideoFromStorage;
        }
        
        private async void DownloadAndSaveVideo()
        {
            try
            {
                await _videoRepository.TryDownloadAndSaveVideoFile();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        ~VideoPageViewModel()
        {
            _videoPageView.PlayVideoStreamClicked -= PlayVideoFromInternet;
        }

        private void PlayVideoFromStorage()
        {
            if (!File.Exists(_videoRepository.LocalVideoSource))
            {
                Debug.Log("Video file is not Exists!");
                return;
            }
            _videoPlayerController.SourceUrl = _videoRepository.LocalVideoSource;
        }

        private async void PlayVideoFromInternet()
        {
            try
            {
                _videoPlayerController.SourceUrl = await _videoRepository.InternetVideoSource;
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