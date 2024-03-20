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
    public class InsertTransactionTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestInsertingTransactionWithCorrectValues()
        {
            Assert.AreEqual(dataGatewayFacade.FindTransaction(1).Item_ID, 1);
        }

        [TestMethod]
        public void TestInsertingTransactionWithEmptyTypeThrowsException()
        {
            TransactionDTO transactionDTO = new TransactionDTO("", 1, 1, 15);
            Assert.ThrowsException<Exception>(() => dataGatewayFacade.AddTransaction(transactionDTO));
        }

        [TestMethod]
        public void TestInsertingTransactionWithNullValueThrowsException()
        {
            TransactionDTO transactionDTO = new TransactionDTO(null, 1, 1, 15);
            Assert.ThrowsException<Exception>(() => dataGatewayFacade.AddTransaction(transactionDTO));
        }
    }
}
