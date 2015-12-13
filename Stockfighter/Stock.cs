using Newtonsoft.Json;
using System.Threading.Tasks;
using Stockfighter.Helpers;

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

        public async Task<Orderbook> GetOrderbook()
        {
            using (var client = new Client())
            {
                return await client.Get<Orderbook>($"venues/{Venue}/stocks/{Symbol}").ConfigureAwait(false);
            }
        }
    }
}
