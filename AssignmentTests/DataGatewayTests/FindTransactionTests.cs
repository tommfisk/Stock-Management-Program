using DataGateway;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTests.DataGatewayTests
{
    [TestClass]
    public class FindTransactionTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestFindingExistingTransactionById()
        {
            TransactionDTO transactionDTO = dataGatewayFacade.FindTransaction(1);
            Assert.AreEqual("Item Added", transactionDTO.Type);
        }

        [TestMethod]
        public void TestFindingNonExistingTransactionById()
        {
            TransactionDTO transactionDTO = dataGatewayFacade.FindTransaction(0);
            Assert.ThrowsException<NullReferenceException>(() => transactionDTO.Item_ID);
        }
    }
}
