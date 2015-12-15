using System.Threading.Tasks;
using Stockfighter.Helpers;
using Stockfighter.HttpModels;

namespace Stockfighter
{
    public class Venue
    {
        public string Symbol { get; private set; }

        public Venue(string symbol)
        {
            Symbol = symbol;
        }

        public async Task<bool> IsUp()
        {
            using (var client = new Client()) 
            {
                try
                {
                    var response = await client.Get<VenueHeartbeat>($"venues/{Symbol}/heartbeat").ConfigureAwait(false);
                    return response.ok;
                }
                catch 
                {
                    return false;
                }
            }
        }

        public async Task<Stock[]> GetStocks()
        {
            using (var client = new Client())
            {
                var response = await client.Get<StocksResponse>($"venues/{Symbol}/stocks").ConfigureAwait(false);

                if (response.ok == false)
                    throw new System.Exception($"Got ok == false while getting stocks from {Symbol}");

                foreach (var stock in response.symbols)
                    stock.Venue = Symbol;

                return response.symbols;
            }
        }
    }
}
