using ScriptableDataModels.Interfaces;
using UnityEngine;

namespace ScriptableDataModels
{
    [CreateAssetMenu(fileName = nameof(MainResourcesHub), menuName = nameof(ScriptableDataModels) + "/" + nameof(MainResourcesHub), order = 0)]
    public class MainResourcesHub : ScriptableObject, IMainResourcesHub
    {
        [SerializeField] private RenderTexture videoStreamRenderTexture;
        
        public RenderTexture VideoStreamRenderTexture => videoStreamRenderTexture;
    }
}