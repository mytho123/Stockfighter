using Newtonsoft.Json;

namespace Stockfighter.HttpModels
{
    internal class OrderResponse : Order
    {
        [JsonProperty("ok")]
        public bool IsOk { get; set; }
    }
}
