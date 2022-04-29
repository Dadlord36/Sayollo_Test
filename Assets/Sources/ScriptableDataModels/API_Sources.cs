using UnityEngine;

namespace ScriptableDataModels
{
    [CreateAssetMenu(fileName = "API_SourceData", menuName = nameof(ScriptableDataModels) + "/", order = 0)]
    public class API_Sources : ScriptableObject
    {
        [SerializeField] private string videoSourceUrl;
        [SerializeField] private string textSourceUrl;

        public string VideoSourceUrl => videoSourceUrl;
        public string TextSourceUrl => textSourceUrl;
    }
}