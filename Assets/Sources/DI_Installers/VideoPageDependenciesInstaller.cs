using Controllers;
using Controllers.Interfaces;
using Repositories;
using Repositories.Interfaces;
using UnityEngine;
using ViewModels;
using Views;
using Zenject;

namespace DI_Installers
{
    public class VideoPageDependenciesInstaller : MonoInstaller
    {
        [SerializeField] private VideoPageView videoPageView;
        [SerializeField] private VideoPlayerController videoPlayerController;

        public override void InstallBindings()
        {
            Container.Bind<IVideoPlayerController>().FromInstance(videoPlayerController).AsSingle();
            Container.Bind<VideoPageView>().FromInstance(videoPageView).AsSingle();
            Container.Bind<IVideoRepository>().To<VideoRepository>().AsSingle().NonLazy();
            Container.Bind<VideoPageViewModel>().AsSingle().NonLazy();
        }
    }
}