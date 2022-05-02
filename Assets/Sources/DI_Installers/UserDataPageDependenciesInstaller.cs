using Repositories;
using Repositories.Interfaces;
using UnityEngine;
using ViewModels;
using Views;
using Zenject;

namespace DI_Installers
{
    public class UserDataPageDependenciesInstaller : MonoInstaller
    {
        [SerializeField] private ItemsPageView itemsPageView;
        [SerializeField] private ItemView itemView;
        [SerializeField] private UserInfoCardView userInfoCardView;

        public override void InstallBindings()
        {
            Container.BindInstance(itemsPageView);
            Container.BindInstance(itemView);
            Container.BindInstance(userInfoCardView);

            Container.Bind<IItemsRepository>().To<ItemsRepository>().AsSingle().NonLazy();
            Container.Bind<ItemsViewModel>().AsSingle().NonLazy();
            Container.Bind<UserInfoCardViewModel>().AsSingle().NonLazy();
        }
    }
}