using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Stockfighter.Helpers;
using Stockfighter.HttpModels;

namespace Stockfighter
{
    public class Order
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        public string ApiKey { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }
        [JsonProperty("originalQty")]
        public int OriginalQuantity { get; set; }
        [JsonProperty("qty")]
        public int QuantityLeft { get; set; }
        [JsonProperty("price")]
        public int PriceInCents { get; set; }
        [JsonProperty("orderType")]
        public string Type { get; set; }
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("ts")]
        public string Timestamp { get; set; }
        [JsonProperty("totalFilled")]
        public int TotalFilled { get; set; }
        [JsonProperty("open")]
        public bool IsOpen { get; set; }

        [JsonProperty("fills")]
        public Fill[] Fills { get; set; }

        protected Order() { }
        public Order(string venue, string stock, int id, string apiKey)
        {
            Venue = venue;
            Symbol = stock;
            Id = id;
            ApiKey = apiKey;
        }

        public async Task<Order> Cancel()
        {
            using (var client = new Client(ApiKey))
            {
                var response = await client.Delete<OrderResponse>($"venues/{Venue}/stocks/{Symbol}/orders/{Id}").ConfigureAwait(false);

                if (!response.IsOk)
                {
                    throw new Exception($"Got ok == false while cancelling order {Id} for {Symbol} at {Venue}.");
                }

                return response;
            }
        }

        public class Fill
        {
            [JsonProperty("price")]
            public int PriceInCents { get; set; }
            [JsonProperty("qty")]
            public int Quantity { get; set; }
            [JsonProperty("ts")]
            public string Timestamp { get; set; }
        }
    }
}
