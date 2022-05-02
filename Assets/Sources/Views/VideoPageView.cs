using System;
using ScriptableDataModels.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views
{
    public sealed class VideoPageView : MonoBehaviour
    {
        public event Action PlayVideoStreamClicked;
        public event Action DownloadAndSaveClicked;
        public event Action LoadAndPlayClicked;

        [SerializeField] private Button playVideoStreamButton;
        [SerializeField] private Button downloadAndSaveButton;
        [SerializeField] private Button loadAndPlayButton;
        [SerializeField] private RawImage planeToProjectVideoOnto;

        [Inject]
        private void Initialize(IMainResourcesHub mainResourcesHub)
        {
            planeToProjectVideoOnto.texture = mainResourcesHub.VideoStreamRenderTexture;
        }

        private void OnPlayVideoFromInternetButtonClicked()
        {
            PlayVideoStreamClicked?.Invoke();
        }

        private void OnEnable()
        {
            playVideoStreamButton.onClick.AddListener(OnPlayVideoFromInternetButtonClicked);
            downloadAndSaveButton.onClick.AddListener(OnDownloadAndSaveClicked);
            loadAndPlayButton.onClick.AddListener(OnLoadAndPlayClicked);
        }

        private void OnDisable()
        {
            playVideoStreamButton.onClick.RemoveListener(OnPlayVideoFromInternetButtonClicked);
            downloadAndSaveButton.onClick.RemoveListener(OnDownloadAndSaveClicked);
            loadAndPlayButton.onClick.RemoveListener(OnLoadAndPlayClicked);
        }

        private void OnDownloadAndSaveClicked()
        {
            DownloadAndSaveClicked?.Invoke();
        }

        private void OnLoadAndPlayClicked()
        {
            LoadAndPlayClicked?.Invoke();
        }
    }
}