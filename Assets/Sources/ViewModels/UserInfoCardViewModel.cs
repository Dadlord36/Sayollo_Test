using System;
using System.Net.Http;
using Models.JSON;
using Newtonsoft.Json;
using REST_API.RequestProcessors.Post;
using UnityEngine;
using Views;

namespace ViewModels
{
    public class UserInfoCardViewModel
    {
        private readonly UserInfoCardView _userInfoCardView;
        private readonly UserActionPostRequest _userActionPostRequest;

        public UserInfoCardViewModel(UserInfoCardView userInfoCardView, UserActionPostRequest userActionPostRequest)
        {
            _userInfoCardView = userInfoCardView;
            _userActionPostRequest = userActionPostRequest;
            _userInfoCardView.SubmitRequested += SendUserDataToServer;
        }

        private async void SendUserDataToServer()
        {
            var userInfoData = new UserInfoModel
                { Email = _userInfoCardView.Email, Number = _userInfoCardView.CreditCardNumber, ExpirationDate = _userInfoCardView.ExpirationDate };

            try
            {
                UserActionResponseModel result =
                    await _userActionPostRequest.SendRequest(new StringContent(JsonConvert.SerializeObject(userInfoData)));
                Debug.Log($"Sending user data result is: {result.Status}; {result.UserMessage}");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
    }
}