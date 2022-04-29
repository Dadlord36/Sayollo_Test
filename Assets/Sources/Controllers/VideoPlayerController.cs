using Controllers.Interfaces;
using ScriptableDataModels.Interfaces;
using UnityEngine;
using UnityEngine.Video;
using Zenject;

namespace Controllers
{
    public class VideoPlayerController : MonoBehaviour, IVideoPlayerController
    {
        private VideoPlayer _videoPlayer;
        
        public string SourceUrl
        {
            set => _videoPlayer.url = value;
        }

        [Inject]
        public void Initialize(IMainResourcesHub mainResourcesHub)
        {
            _videoPlayer = gameObject.AddComponent<VideoPlayer>();
            _videoPlayer.source = VideoSource.Url;
            _videoPlayer.targetTexture = mainResourcesHub.VideoStreamRenderTexture;
        }
        
        public void PlayVideo()
        {
            _videoPlayer.Play();
        }


    }
}