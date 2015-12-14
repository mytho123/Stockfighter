using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stockfighter
{
    public class Order
    {
        protected Order() { }
        public Order(string venue, string account, string apiKey, int id)
        {

        }

        public async Task<Order> Cancel()
        {
            throw new NotImplementedException();
        }
    }
}
