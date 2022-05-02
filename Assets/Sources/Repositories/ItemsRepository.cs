using System.Net.Http;
using System.Threading.Tasks;
using Models.JSON;
using Repositories.Interfaces;
using REST_API.RequestProcessors.Post;
using UnityEngine;

namespace Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly PurchaseItemPostRequest _purchaseItemPostRequest;
        private readonly UserActionPostRequest _userActionPostRequest;

        public ItemsRepository(PurchaseItemPostRequest purchaseItemPostRequest, UserActionPostRequest userActionPostRequest)
        {
            _purchaseItemPostRequest = purchaseItemPostRequest;
            _userActionPostRequest = userActionPostRequest;
        }

        public Task<ProductResponseModel> GetPresentItem()
        {
            return _purchaseItemPostRequest.SendRequest(new StringContent(JsonUtility.ToJson(new UserInfoModel())));
        }

        public Task<UserActionResponseModel> SubmitUserInfo(in UserInfoModel userInfoModel)
        {
            return _userActionPostRequest.SendRequest(new StringContent(JsonUtility.ToJson(userInfoModel)));
        }
    }
}