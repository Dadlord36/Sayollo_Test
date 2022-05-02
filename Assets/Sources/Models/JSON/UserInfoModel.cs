using Newtonsoft.Json;

namespace Models.JSON
{
    [JsonObject]
    public struct UserInfoModel
    {
        public string Email { get; set; }
        public string Number { get; set; }
        public string ExpirationDate { get; set; }
    }
}