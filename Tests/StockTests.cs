using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stockfighter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    // Note that these tests assume that Stockfighter's test exchange is up and functionning as expected.

    [TestClass]
    public class StockTests
    {
        [TestMethod]
        public async Task CanGetStockQuote()
        {
            var stock = new Stock(Config.Venue, Config.Stock);
            var quote = await stock.GetQuote();

            Assert.IsNotNull(quote);
        }

        [TestMethod]
        public async Task CanGetStockOrderbook()
        {
            var stock = new Stock(Config.Venue, Config.Stock);
            var book = await stock.GetOrderbook();

            Assert.IsNotNull(book);
        }
    }
}
