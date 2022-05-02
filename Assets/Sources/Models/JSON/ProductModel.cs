using Newtonsoft.Json;

namespace Models.JSON
{
    public struct ProductResponseModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("item_image")]
        public string ItemImage { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("currency_sign")]
        public string CurrencySign { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
    }
}