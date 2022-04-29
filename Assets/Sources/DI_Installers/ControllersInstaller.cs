using Controllers;
using Controllers.Interfaces;
using Zenject;

namespace DI_Installers
{
    public class ControllersInstaller : Installer<ControllersInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IStorageController>().To<DefaultStorageController>().AsSingle().NonLazy();
        }
    }
}