using UI_Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private LabeledTextField title;
        [SerializeField] private LabeledTextField currency;
        [SerializeField] private LabeledTextField currencySign;
        [SerializeField] private RawImage image;

        public string Title
        {
            set => title.Field = value;
        }
        
        public string Currency
        {
            set => currency.Field = value;
        }
        
        public string CurrencySign
        {
            set => currencySign.Field = value;
        }
        
        public Texture2D Icon
        {
            set => image.texture = value;
        }
    }
}