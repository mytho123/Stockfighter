using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stockfighter;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public async Task CanCreateFetchAndCancelOrder()
        {
            var account = new Account(Config.Venue, Config.Account, Config.ApiKey);

            // Buy 25 FOOBAR at 1.50
            var order = await account.Buy(Config.Stock, 150, 25);

            Assert.IsNotNull(order);
            Assert.AreEqual(Config.Stock, order.Symbol);

            var status = await account.GetOrder(order.Id, Config.Stock);

            Assert.IsNotNull(status);
            Assert.AreEqual(Config.Stock, status.Symbol);

            var final = await order.Cancel();

            Assert.IsNotNull(final);
            Assert.AreEqual(Config.Stock, final.Symbol);
            Assert.IsFalse(final.IsOpen);
        }
    }
}
