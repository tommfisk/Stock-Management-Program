using DataGateway;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests.DataGatewayTests
{
    [TestClass]
    public class InsertItemTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestInsertingItemWithCorrectValues()
        {
            Assert.AreEqual(dataGatewayFacade.FindItemById(1).Item_Name, "pen");
        }

        [TestMethod]
        public void TestInsertingItemWithEmptyNameThrowsException()
        {
            ItemDTO itemDTO = new ItemDTO("", 10, 1);
            Assert.ThrowsException<Exception>(() => dataGatewayFacade.AddItem(itemDTO));
        }

        [TestMethod]
        public void TestInsertingItemWithNullValueThrowsException()
        {
            ItemDTO itemDTO = new ItemDTO(null, 10, 1);
            Assert.ThrowsException<Exception>(() => dataGatewayFacade.AddItem(itemDTO));
        }
    }
}
