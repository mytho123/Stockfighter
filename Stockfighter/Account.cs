using System;
using System.Threading.Tasks;
using Stockfighter.Helpers;
using Stockfighter.HttpModels;

namespace Stockfighter
{
    public class Account
    {
        public const string ApiUrl = "https://api.stockfighter.io/ob/api/";

        public string Venue { get; set; }
        public string AccountId { get; set; }
        public string ApiKey { get; set; }

        public Account(string venue, string account, string apiKey)
        {
            Venue = venue;
            AccountId = account;
            ApiKey = apiKey;
        }

        public async Task<Order> Buy(string stock, int priceInCents, int quantity, string type = OrderType.Limit)
        {
            using (var client = new Client(ApiKey))
            {
                var body = new NewOrderRequest
                {
                    Account = AccountId,
                    Venue = Venue,
                    Stock = stock,
                    PriceInCents = priceInCents,
                    Quantity = quantity,
                    Direction = OrderDirection.Buy,
                    OrderType = type
                };

                var response = await client.Post<OrderResponse>(ApiUrl, $"venues/{Venue}/stocks/{stock}/orders", body).ConfigureAwait(false);

                if (!response.IsOk)
                {
                    throw new Exception($"Got ok == false while creating buy order for {stock} at {Venue}.");
                }

                response.ApiKey = ApiKey;

                return response;
            }
        }

        public async Task<Order> Sell(string stock, int priceInCents, int quantity, string type = OrderType.Limit)
        {
            using (var client = new Client(ApiKey))
            {
                var body = new NewOrderRequest
                {
                    Account = AccountId,
                    Venue = Venue,
                    Stock = stock,
                    PriceInCents = priceInCents,
                    Quantity = quantity,
                    Direction = OrderDirection.Sell,
                    OrderType = type
                };

                var response = await client.Post<OrderResponse>(ApiUrl, $"venues/{Venue}/stocks/{stock}/orders", body).ConfigureAwait(false);

                if (!response.IsOk)
                {
                    throw new Exception($"Got ok == false while creating sell order for {stock} at {Venue}.");
                }

                response.ApiKey = ApiKey;

                return response;
            }
        }

        public async Task<Order> GetOrder(int id, string stock)
        {
            using (var client = new Client(ApiKey))
            {
                var response = await client.Get<OrderResponse>(ApiUrl, $"venues/{Venue}/stocks/{stock}/orders/{id}").ConfigureAwait(false);

                if (!response.IsOk)
                {
                    throw new Exception($"Got ok == false while getting status of order id {id} on {stock} at {Venue}.");
                }

                response.ApiKey = ApiKey;

                return response;
            }
        }

        public async Task<Order[]> GetAllOrders()
        {
            using (var client = new Client(ApiKey))
            {
                var response = await client.Get<OrderListResponse>(ApiUrl, $"venues/{Venue}/accounts/{AccountId}/orders").ConfigureAwait(false);

                if (!response.IsOk)
                {
                    throw new Exception($"Got ok == false while getting orders of {AccountId} at {Venue}.");
                }

                foreach (var order in response.Orders)
                    order.ApiKey = ApiKey;

                return response.Orders;
            }
        }

        public async Task<Order[]> GetAllOrdersForStock(string stock)
        {
            using (var client = new Client(ApiKey))
            {
                var response = await client.Get<OrderListResponse>(ApiUrl, $"venues/{Venue}/accounts/{AccountId}/stocks/{stock}/orders").ConfigureAwait(false);

                if (!response.IsOk)
                {
                    throw new Exception($"Got ok == false while getting orders of {AccountId} for {stock} at {Venue}.");
                }

                foreach (var order in response.Orders)
                    order.ApiKey = ApiKey;

                return response.Orders;
            }
        }
    }
}
