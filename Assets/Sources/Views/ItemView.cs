using System;
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
        [SerializeField] private ProgressBar progressBar;

        private Texture2D _rawImageTexture;

        private void Awake()
        {
            image.texture = _rawImageTexture = new Texture2D(0, 0, TextureFormat.RGB24, false);
        }

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

        public IProgress<float> ImageDownloadProgressReflector => progressBar;

        public byte[] Icon
        {
            set
            {
                _rawImageTexture.LoadImage(value);
                image.SetAllDirty();
            }
        }
    }
}