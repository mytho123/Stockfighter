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
                var stocks = await client.Get<Stock[]>($"venues/{Symbol}/stocks");

                foreach (var stock in stocks)
                    stock.Venue = Symbol;

                return stocks;
            }
        }


        private class Heartbeat
        {
            public bool ok { get; set; }
            public string venue { get; set; }
        }
    }
}
