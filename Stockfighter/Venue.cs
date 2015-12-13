using System.Threading.Tasks;
using Stockfighter.Helpers;

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
                    var response = await client.Get<Heartbeat>($"venues/{Symbol}/heartbeat");
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
                var response = await client.Get<StocksResponse>($"venues/{Symbol}/stocks");

                if (response.ok == false)
                    throw new System.Exception($"Got ok == false while getting stocks from {Symbol}");

                foreach (var stock in response.symbols)
                    stock.Venue = Symbol;

                return response.symbols;
            }
        }


        private class Heartbeat
        {
            public bool ok { get; set; }
            public string venue { get; set; }
        }

        private class StocksResponse
        {
            public bool ok { get; set; }
            public Stock[] symbols { get; set; }
        }
    }
}
