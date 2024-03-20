using DataGateway;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests.DataGatewayTests
{
    [TestClass]
    public class TakeQuantityFromItemTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestTakingQuantityFromExistingItem()
        {
            int rowsAffected = dataGatewayFacade.TakeQuantityFromItem(1, 1);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void TestTakingQuantityFromNonExistingItem()
        {
            var ex = Assert.ThrowsException<Exception>(() => dataGatewayFacade.TakeQuantityFromItem(-1, 1));
            Assert.AreEqual("ERROR: quantity not taken", ex.Message);

        }
    }
}
