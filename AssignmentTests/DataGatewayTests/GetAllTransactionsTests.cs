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
    public class GetAllTransactionsTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestGetAllTransactionReturnsCorrectValues()
        {
            dataGatewayFacade.InitialiseOracleDatabase();
            List<TransactionDTO> transactionDTOs = dataGatewayFacade.GetAllTransactions();
            Assert.AreEqual("Item Added", transactionDTOs[0].Type);
        }
    }
}
