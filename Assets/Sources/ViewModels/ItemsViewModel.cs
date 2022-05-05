using System;
using System.Threading.Tasks;
using Models.JSON;
using Repositories.Interfaces;
using REST_API.Interfaces;
using UnityEngine;
using Views;
using Zenject;

namespace ViewModels
{
    public class ItemsViewModel
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly ItemView _itemView;
        [Inject] private I_API_Provider _provider;
        private readonly TaskFactory mainThreadTaskFactory;

        public ItemsViewModel(IItemsRepository itemsRepository, ItemsPageView itemsPageView, ItemView itemView)
        {
            _itemsRepository = itemsRepository;
            _itemView = itemView;
            itemsPageView.ItemPurchaseRequested += PurchaseAnItem;
            mainThreadTaskFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void PurchaseAnItem()
        {
            try
            {
                ProductResponseModel itemData = await _itemsRepository.GetPresentItem().ConfigureAwait(false);
                byte[] result = await _provider.WebClient.GetByteArrayAsync(itemData.ItemImage).ConfigureAwait(false);

                await mainThreadTaskFactory.StartNew(delegate
                {
                    _itemView.Title = itemData.Title;
                    _itemView.Currency = itemData.Currency;
                    _itemView.CurrencySign = itemData.CurrencySign;
                    _itemView.Icon = result;
                }).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
    }
}