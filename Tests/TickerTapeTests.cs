using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Stockfighter;

namespace Tests
{
    [TestClass]
    public class TickerTapeTests
    {
        [TestMethod]
        public async Task CanUseTickerTape()
        {
            bool received = false, started = false, stopped = false, error = false;
            var tape = new TickerTape(Config.Account, Config.Venue);
            tape.QuoteReceived += (o, quote) =>
            {
                received = true;
            };
            tape.Started += (o, e) =>
            {
                started = true;
            };
            tape.Stopped += (o, e) =>
            {
                stopped = true;
            };
            tape.ErrorOccured += (o, e) =>
            {
                error = true;
            };

            tape.Start();

            var account = new Account(Config.Venue, Config.Account, Config.ApiKey);
            await account.Buy(Config.Stock, 50, 100);

            await Task.Delay(500);

            tape.Stop();

            Assert.IsTrue(started);
            Assert.IsTrue(received);
            Assert.IsTrue(stopped);
            Assert.IsFalse(error);
        }
    }
}
