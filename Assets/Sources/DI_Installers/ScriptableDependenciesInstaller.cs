using ScriptableDataModels;
using ScriptableDataModels.Interfaces;
using UnityEngine;
using Zenject;

namespace DI_Installers
{
    [CreateAssetMenu(fileName = "ScriptableDependenciesInstaller", menuName = "Installers/ScriptableDependenciesInstaller")]
    public class ScriptableDependenciesInstaller : ScriptableObjectInstaller<ScriptableDependenciesInstaller>
    {
        [SerializeField] private MainResourcesHub mainResourcesHub;
        [SerializeField] private StoragePathsSource storagePathsSource;

        public override void InstallBindings()
        {
            Container.Bind<IMainResourcesHub>().To<MainResourcesHub>().FromInstance(mainResourcesHub).AsSingle();
            Container.Bind<IStoragePathsSource>().To<StoragePathsSource>().FromInstance(storagePathsSource).AsSingle();
        }
    }
}