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
        private readonly Progress<float> _progress;


        private ProgressBar()
        {
            _progress = new Progress<float>(delegate(float newValue)
            {
                try
                {
                    TasksFactories.MainThreadTaskFactory.StartNew(delegate { ProgressState = newValue; })
                        .ContinueWith(delegate(Task task) { task.Dispose(); });
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    throw;
                }
            });
        }

        private float ProgressState
        {
            set => image.fillAmount = value;
        }


        public void Report(float value)
        {
            Debug.Log($"ProgressReport: {value.ToString()}");
            (_progress as IProgress<float>).Report(value);
        }
    }
}