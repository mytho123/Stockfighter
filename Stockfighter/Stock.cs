using Newtonsoft.Json;

namespace Stockfighter
{
    public class Stock
    {
        public Stock(string venue, string symbol)
        {
            Venue = venue;
            Symbol = symbol;
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        public string Venue { get; set; }
    }
}
