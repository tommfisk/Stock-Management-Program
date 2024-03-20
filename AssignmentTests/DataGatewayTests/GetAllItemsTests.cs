using DataGateway;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace AssignmentTests.DataGatewayTests
{
    [TestClass]
    public class GetAllItemsTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestGetAllItemsReturnsCorrectValues()
        {
            dataGatewayFacade.InitialiseOracleDatabase();
            List<ItemDTO> itemDTOs = dataGatewayFacade.GetAllItems();
            Assert.AreEqual("pen", itemDTOs[0].Item_Name);
        }
    }
}
