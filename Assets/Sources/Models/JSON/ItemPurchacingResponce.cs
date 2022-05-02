using Newtonsoft.Json;

namespace Models.JSON
{
    [JsonObject]
    public struct UserActionResponseModel
    {
        public string UserMessage { get; set; }
        public string Status { get; set; }
        public int ErrorCode { get; set; }
    }
}