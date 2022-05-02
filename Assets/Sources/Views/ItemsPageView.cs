using System;
using UnityEngine;

namespace Views
{
    public sealed class ItemsPageView : MonoBehaviour
    {
        public event Action ItemPurchaseRequested;

        public void RequestItemPurchase()
        {
            OnItemPurchaseRequested();
        }
        
        private void OnItemPurchaseRequested()
        {
            ItemPurchaseRequested?.Invoke();
        }
    }
}