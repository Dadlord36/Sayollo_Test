using ScriptableDataModels;
using ScriptableDataModels.Interfaces;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableDependenciesInstaller", menuName = "Installers/ScriptableDependenciesInstaller")]
public class ScriptableDependenciesInstaller : ScriptableObjectInstaller<ScriptableDependenciesInstaller>
{
    [SerializeField]
    private MainResourcesHub mainResourcesHub;
    public override void InstallBindings()
    {
        Container.Bind<IMainResourcesHub>().To<MainResourcesHub>().FromInstance(mainResourcesHub).AsSingle();
    }
}