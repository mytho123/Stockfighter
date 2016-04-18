using Newtonsoft.Json;
using Stockfighter.Helpers;
using System;
using System.Threading.Tasks;

namespace Stockfighter
{
    public class Stock
    {
        protected Stock()
        {
        }

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
                var orderbook = await client.Get<Orderbook>(Account.ApiUrl, $"venues/{Venue}/stocks/{Symbol}").ConfigureAwait(false);

                if (!orderbook.IsOk)
                {
                    throw new Exception($"Got ok == false while getting orderbook of {Symbol} at {Venue}.");
                }

                return orderbook;
            }
        }

        public async Task<Quote> GetQuote()
        {
            using (var client = new Client())
            {
                var quote = await client.Get<Quote>(Account.ApiUrl, $"venues/{Venue}/stocks/{Symbol}/quote").ConfigureAwait(false);

                if (!quote.IsOk)
                {
                    throw new Exception($"Got ok == false while getting quote of {Symbol} at {Venue}.");
                }

                return quote;
            }
        }

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

        public class Quote
        {
            [JsonProperty("ok")]
            public bool IsOk { get; set; }

            [JsonProperty("venue")]
            public string Venue { get; set; }

            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("bid")]
            public int BidInCents { get; set; }

            [JsonProperty("ask")]
            public int AskInCents { get; set; }

            [JsonProperty("bidSize")]
            public int BidSize { get; set; }

            [JsonProperty("askSize")]
            public int AskSize { get; set; }

            [JsonProperty("bidDepth")]
            public int BidDepth { get; set; }

            [JsonProperty("askDepth")]
            public int AskDepth { get; set; }

            [JsonProperty("last")]
            public int LastTradePriceInCents { get; set; }

            [JsonProperty("lastSize")]
            public int LastTradeSize { get; set; }

            [JsonProperty("lastTrade")]
            public DateTime LastTradeTimestamp { get; set; }

            [JsonProperty("quoteTime")]
            public DateTime QuoteTimestamp { get; set; }
        }
    }
}