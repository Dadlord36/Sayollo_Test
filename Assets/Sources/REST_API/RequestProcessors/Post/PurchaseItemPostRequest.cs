using System.Net.Http;
using Models.JSON;

namespace REST_API.RequestProcessors.Post
{
    public class PurchaseItemPostRequest : BaseRequest<ProductResponseModel>
    {
        public PurchaseItemPostRequest() : base(HttpMethod.Post, "v1/gcom/ad")
        {
        }
    }
}