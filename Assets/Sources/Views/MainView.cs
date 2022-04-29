using System;
using ScriptableDataModels.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views
{
    public class MainView : MonoBehaviour
    {
        public event Action PlayVideoFromInternetButtonClicked;

        [SerializeField] private Button playVideoFromInternetButton;
        [SerializeField] private RawImage planeToProjectVideoOnto;

        [Inject]
        private void Initialize(IMainResourcesHub mainResourcesHub)
        {
            planeToProjectVideoOnto.texture = mainResourcesHub.VideoStreamRenderTexture;
        }

        protected void OnPlayVideoFromInternetButtonClicked()
        {
            PlayVideoFromInternetButtonClicked?.Invoke();
        }

        private void OnEnable()
        {
            playVideoFromInternetButton.onClick.AddListener(OnPlayVideoFromInternetButtonClicked);
        }

        private void OnDisable()
        {
            playVideoFromInternetButton.onClick.RemoveListener(OnPlayVideoFromInternetButtonClicked);
        }
    }
}