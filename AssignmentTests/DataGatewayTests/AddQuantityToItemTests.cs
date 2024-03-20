using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGateway;
using System;

namespace AssignmentTests.DataGatewayTests
{
    [TestClass]
    public class AddQuantityToItemTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestAddingQuantityToExistingItem()
        {
            int rowsAffected = dataGatewayFacade.AddQuantityToItem(1, 1);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void TestAddingQuantityToNonExistingItem()
        {
            var ex = Assert.ThrowsException<Exception>(() => dataGatewayFacade.AddQuantityToItem(-1, 1));
            Assert.AreEqual("ERROR: quantity not added", ex.Message);

        }
    }
}
