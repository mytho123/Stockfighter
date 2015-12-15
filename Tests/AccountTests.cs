using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stockfighter;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class AccountTests
    {
        // NOTE: This API Key is associated with an unused throwaway account.
        private const string YourApiKey = "5d60eade55b7a8c9daf5a62cb7b8ab99bf0a0b98";

        [TestMethod]
        public async Task CanCreateFetchAndCancelOrder()
        {
            var account = new Account("TESTEX", "EXB123456", YourApiKey);

            // Buy 25 FOOBAR at 1.50
            var order = await account.Buy("FOOBAR", 150, 25);

            Assert.IsNotNull(order);
            Assert.AreEqual("FOOBAR", order.Symbol);

            var status = await account.GetOrder(order.Id, "FOOBAR");

            Assert.IsNotNull(status);
            Assert.AreEqual("FOOBAR", status.Symbol);

            var final = await order.Cancel();

            Assert.IsNotNull(final);
            Assert.AreEqual("FOOBAR", final.Symbol);
            Assert.IsFalse(final.IsOpen);
        }
    }
}
