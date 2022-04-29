using Tools;
using Tools.Interfaces;
using Zenject;

namespace DI_Installers
{
    public class ToolsDependenciesInstaller : Installer<ToolsDependenciesInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IFileDownloader>().To<DefaultFileDownloader>().AsSingle().NonLazy();
        }
    }
}