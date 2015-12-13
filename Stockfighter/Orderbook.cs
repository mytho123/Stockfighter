using Newtonsoft.Json;

namespace Stockfighter
{
    public class Orderbook
    {
        [JsonProperty("ok")]
        public bool IsOk { get; set; }

        [JsonProperty("venue")]
        public string Venue { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        
        [JsonProperty("bids")]
        public Order[] Bids { get; set; }
        [JsonProperty("asks")]
        public Order[] Asks { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }

        public class Order
        {
            [JsonProperty("price")]
            public int PriceInCents { get; set; }
            [JsonProperty("qty")]
            public int Quantity { get; set; }
            [JsonProperty("isBuy")]
            public bool IsBuy { get; set; }
        }
    }
}
