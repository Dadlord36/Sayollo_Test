using System.Net.Http;
using Models.JSON;

namespace REST_API.RequestProcessors.Post
{
    public class UserActionPostRequest : BaseRequest<UserActionResponseModel>
    {
        public UserActionPostRequest() : base(HttpMethod.Post, "v1/gcom/action")
        {
        }
    }
}