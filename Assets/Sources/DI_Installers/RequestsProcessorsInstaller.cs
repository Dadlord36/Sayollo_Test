using REST_API.RequestProcessors.Post;
using UnityEngine;
using Zenject;

namespace DI_Installers
{
    [CreateAssetMenu(fileName = nameof(RequestsProcessorsInstaller), menuName = nameof(DI_Installers) + "/" + nameof(RequestsProcessorsInstaller))]
    public class RequestsProcessorsInstaller : ScriptableObjectInstaller<RequestsProcessorsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PurchaseItemPostRequest>().AsSingle().NonLazy();
            Container.Bind<UserActionPostRequest>().AsSingle().NonLazy();
        }
    }
}