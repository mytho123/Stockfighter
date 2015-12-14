using System;
using System.Threading.Tasks;

namespace Stockfighter
{
    public class Account
    {
        public Account(string venue, string account, string apiKey)
        {

        }

        public async Task<Order> Buy(string stock, int priceInCents, int quantity, OrderType type = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Sell(string stock, int priceInCents, int quantity, OrderType type = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order[]> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<Order[]> GetAllOrdersForStock(string stock)
        {
            throw new NotImplementedException();
        }
    }
}
