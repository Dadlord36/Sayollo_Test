using Controllers;
using Controllers.Interfaces;
using Repositories;
using REST_API;
using REST_API.Interfaces;
using UnityEngine;
using ViewModels;
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
            ControllersInstaller.Install(Container);
            
            Container.Bind<IVideoPlayerController>().FromInstance(videoPlayerController).AsSingle();

            Container.Bind<MainView>().FromInstance(mainView).AsSingle();
            
            Container.Bind<I_API_Provider>().To<SayolloTestAPIProvider>().AsSingle().NonLazy();
            ToolsDependenciesInstaller.Install(Container);
            Container.Bind<I_API_Repository>().To<API_Repository>().AsSingle().NonLazy();

            Container.Bind<MainViewModel>().AsSingle().NonLazy();
        }
    }
}