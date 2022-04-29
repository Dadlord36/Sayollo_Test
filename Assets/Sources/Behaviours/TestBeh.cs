using REST_API;
using UnityEngine;

namespace Behaviours
{
    public class TestBeh : MonoBehaviour
    {
        private SayolloTestAPIProvider _client;

        private async void Start()
        {
            _client = new SayolloTestAPIProvider();
            Debug.Log(await _client.GetVideoUrl());
        }
    }
}