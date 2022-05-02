using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using REST_API.Interfaces;
using UnityEngine;
using Zenject;

namespace REST_API.RequestProcessors
{
    /*[Serializable]
    public enum HttpRequestType : byte
    {
        GET,POST,PUT,DELETE
    }*/

    public abstract class BaseRequest<TResponse>
    {
        [Inject] private I_API_Provider _apiProvider;
        private readonly HttpMethod _httpRequestType;
        private readonly string _endPoint;

        protected BaseRequest(HttpMethod httpRequestType, string endPoint)
        {
            _httpRequestType = httpRequestType;
            _endPoint = endPoint;
        }

        public async Task<TResponse> SendRequest(HttpContent content = null)
        {
            try
            {
                using (var requestMessage = new HttpRequestMessage(_httpRequestType, _endPoint) { Content = content })
                {
                    HttpResponseMessage response = await _apiProvider.WebClient.SendAsync(requestMessage).ConfigureAwait(false);
                    string jsonAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<TResponse>(jsonAsString);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        /*private HttpMethod GetHttpMethod()
        {
            switch (_httpRequestType)
            {
                case HttpRequestType.GET:
                    return HttpMethod.Get;
                case HttpRequestType.POST:
                    return HttpMethod.Post;
                case HttpRequestType.PUT:
                    return HttpMethod.Put;
                case HttpRequestType.DELETE:
                    return HttpMethod.Delete;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }*/
    }
}