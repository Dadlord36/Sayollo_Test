using Controllers.Interfaces;
using Repositories;
using UnityEngine;
using ViewModels.Interfaces;
using Views;

namespace ViewModels
{
    public class MainViewModel : IMainViewModel
    {
        private readonly I_API_Repository _apiRepository;
        private readonly IVideoPlayerController _videoPlayerController;
        private readonly MainView _mainView;

        public MainViewModel(MainView mainView, IVideoPlayerController videoPlayerController,I_API_Repository apiRepository)
        {
            _apiRepository = apiRepository;
            _videoPlayerController = videoPlayerController;
            _mainView = mainView;
            mainView.PlayVideoFromInternetButtonClicked += PlayVideoFromInternet;
        }

        ~MainViewModel()
        {
            _mainView.PlayVideoFromInternetButtonClicked -= PlayVideoFromInternet;
        }

        public async void PlayVideoFromInternet()
        {
            _videoPlayerController.SourceUrl = await _apiRepository.VideoSource;
            Debug.Log("Video source Url was retrieved successfully");
            _videoPlayerController.PlayVideo();
        }
    }
}