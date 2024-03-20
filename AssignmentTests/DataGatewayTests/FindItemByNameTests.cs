using DataGateway;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests.DataGatewayTests
{
    [TestClass]
    public class FindItemByNameTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestFindingExistingItemByName()
        {
            ItemDTO itemDTO = dataGatewayFacade.FindItemByName("pen");
            Assert.AreEqual(1, itemDTO.ID);
        }

        [TestMethod]
        public void TestFindingNonExistingItemByName()
        {
            ItemDTO itemDTO = dataGatewayFacade.FindItemByName("");
            Assert.ThrowsException<NullReferenceException>(() => itemDTO.ID);
        }

        [TestMethod]
        public void TestFindingNonExistingItemByNameUsingNullValue()
        {
            ItemDTO itemDTO = dataGatewayFacade.FindItemByName(null);
            Assert.ThrowsException<NullReferenceException>(() => itemDTO.ID);
        }
    }
}
