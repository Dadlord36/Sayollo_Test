using System;
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
        [Inject]
        private I_API_Provider _provider;

        public ItemsViewModel(IItemsRepository itemsRepository, ItemsPageView itemsPageView, ItemView itemView)
        {
            _itemsRepository = itemsRepository;
            _itemView = itemView;
            itemsPageView.ItemPurchaseRequested += PurchaseAnItem;
        }

        private async void PurchaseAnItem()
        {
            try
            {
                ProductResponseModel itemData = await _itemsRepository.GetPresentItem();

                _itemView.Title = itemData.Title;
                _itemView.Currency = itemData.Currency;
                _itemView.CurrencySign = itemData.CurrencySign;
                byte[] result = await _provider.WebClient.GetByteArrayAsync(itemData.ItemImage);
                //TODO: make async
                {
                    var tex = new Texture2D(0, 0, TextureFormat.RGB24, false);
                    tex.LoadImage(result);
                    _itemView.Icon = tex;
                }
               
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
    }
}