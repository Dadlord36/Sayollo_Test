using System.Threading.Tasks;
using Factories.TaskFactories;
using REST_API;
using REST_API.Interfaces;
using UnityEngine;
using Zenject;

namespace DI_Installers
{
    [CreateAssetMenu(fileName = nameof(AppInstaller), menuName = nameof(DI_Installers) + "/" + nameof(AppInstaller))]
    public class AppInstaller : ScriptableObjectInstaller<AppInstaller>
    {
        public override void InstallBindings()
        {
            TasksFactories.MainThreadTaskFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());

            ControllersInstaller.Install(Container);
            Container.Bind<I_API_Provider>().To<SayolloTestAPIProvider>().AsSingle().NonLazy();
            ToolsDependenciesInstaller.Install(Container);
        }
    }
}