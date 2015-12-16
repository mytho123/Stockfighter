using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stockfighter;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class OrderFeedTest
    {
        [TestMethod]
        public async Task CanUseOrderFeed()
        {
            bool received = false, started = false, stopped = false, error = false;
            var feed = new OrderFeed(Config.Account, Config.Venue);
            feed.OrderReceived += (o, order) =>
            {
                received = true;
            };
            feed.Started += (o, e) =>
            {
                started = true;
            };
            feed.Stopped += (o, e) =>
            {
                stopped = true;
            };
            feed.ErrorOccured += (o, e) =>
            {
                error = true;
            };

            feed.Start();

            var account = new Account(Config.Venue, Config.Account, Config.ApiKey);
            await account.Buy(Config.Stock, 50, 100);
            await account.Sell(Config.Stock, 49, 100);

            await Task.Delay(500);

            feed.Stop();

            Assert.IsTrue(started);
            Assert.IsTrue(received);
            Assert.IsTrue(stopped);
            Assert.IsFalse(error);
        }
    }
}
