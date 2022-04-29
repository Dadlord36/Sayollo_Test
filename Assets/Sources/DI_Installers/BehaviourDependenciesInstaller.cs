using Controllers;
using Controllers.Interfaces;
using Repositories;
using REST_API;
using REST_API.Interfaces;
using UnityEngine;
using ViewModels;
using ViewModels.Interfaces;
using Views;
using Zenject;

namespace DI_Installers
{
    public class BehaviourDependenciesInstaller : MonoInstaller
    {
        [SerializeField] private MainView mainView;
        [SerializeField] private VideoPlayerController videoPlayerController;

        public override void InstallBindings()
        {
            Container.Bind<IVideoPlayerController>().FromInstance(videoPlayerController).AsSingle();

            Container.Bind<MainView>().FromInstance(mainView).AsSingle();

            Container.Bind<I_API_Provider>().To<SayolloTestAPIProvider>().AsSingle().NonLazy();
            Container.Bind<I_API_Repository>().To<API_Repository>().AsSingle().NonLazy();

            Container.Bind<IMainViewModel>().To<MainViewModel>().AsSingle().NonLazy();
        }
    }
}