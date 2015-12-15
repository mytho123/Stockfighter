using Newtonsoft.Json;

namespace Stockfighter.HttpModels
{
    internal class NewOrderRequest
    {
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("venue")]
        public string Venue { get; set; }
        [JsonProperty("stock")]
        public string Stock { get; set; }
        [JsonProperty("price")]
        public int PriceInCents { get; set; }
        [JsonProperty("qty")]
        public int Quantity { get; set; }
        [JsonProperty("direction")]
        public string Direction { get; set; }
        [JsonProperty("orderType")]
        public string OrderType { get; set; }
    }
}
