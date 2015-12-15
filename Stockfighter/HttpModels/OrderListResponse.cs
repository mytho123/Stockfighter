using Newtonsoft.Json;

namespace Stockfighter.HttpModels
{
    internal class OrderListResponse
    {
        [JsonProperty("ok")]
        public bool IsOk { get; set; }
        [JsonProperty("orders")]
        public Order[] Orders { get; set; }
    }
}
