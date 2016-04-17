using Newtonsoft.Json;
using Stockfighter.Helpers;
using Stockfighter.HttpModels;
using System;
using System.Threading.Tasks;

namespace Stockfighter
{
    public class OrderMessage
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("standingId")]
        public int StandingId { get; set; }

        [JsonProperty("incomingId")]
        public int IncomingId { get; set; }

        [JsonProperty("price")]
        public int PriceInCents { get; set; }

        [JsonProperty("filled")]
        public int Filled { get; set; }

        [JsonProperty("filledAt")]
        public string FilledAt { get; set; }

        [JsonProperty("standingComplete")]
        public bool StandingComplete { get; set; }

        [JsonProperty("incomingComplete")]
        public bool IncomingComplete { get; set; }
    }
}