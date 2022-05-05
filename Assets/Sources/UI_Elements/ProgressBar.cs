using System;
using System.Threading.Tasks;
using Factories.TaskFactories;
using MPUIKIT;
using UnityEngine;

namespace UI_Elements
{
    public class ProgressBar : MonoBehaviour, IProgress<float>
    {
        [SerializeField] private MPImage image;
        private float progressState;

        private void Update()
        {
            ProgressState = progressState;
        }

        public void Report(float value)
        {
            progressState = value;
        }

        private float ProgressState
        {
            set
            {
                if (Math.Abs(image.fillAmount - progressState) < 0.01f) return;
                image.fillAmount = value;
            }
        }
    }
}