using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models.XML;
using REST_API.Interfaces;
using UnityEngine;

namespace REST_API
{
    public class SayolloTestAPIProvider : I_API_Provider
    {
        private readonly HttpClient _webClient;

        public SayolloTestAPIProvider()
        {
            _webClient = new HttpClient { BaseAddress = new Uri("https://6u3td6zfza.execute-api.us-east-2.amazonaws.com/prod/") };
            _webClient.DefaultRequestHeaders.Accept.Clear();
            _webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        ~SayolloTestAPIProvider()
        {
            _webClient.CancelPendingRequests();
            _webClient.Dispose();
        }

        public async Task<string> GetVideoUrl()
        {
            try
            {
                using var result = await _webClient.GetAsync("ad/vast").ConfigureAwait(false);
                if (!result.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(result.ReasonPhrase);
                }

                await using var reader = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
                var model = (VAST_Model)new XmlSerializer(typeof(VAST_Model)).Deserialize(reader);
                return model.Ad.InLine.Creatives.Creative.Linear.MediaFiles.MediaFile;
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
                throw;
            }
        }
    }
}