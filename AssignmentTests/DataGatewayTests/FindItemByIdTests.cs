using DataGateway;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests.DataGatewayTests
{
    [TestClass]
    public class FindItemByIdTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestFindingExistingItemById()
        {
            ItemDTO itemDTO = dataGatewayFacade.FindItemById(1);
            Assert.AreEqual("pen", itemDTO.Item_Name);
        }

        [TestMethod]
        public void TestFindingNonExistingItemById()
        {
            
            ItemDTO itemDTO = dataGatewayFacade.FindItemById(0);
            Assert.ThrowsException<NullReferenceException>(() => itemDTO.Item_Name );

        }
    }
}
