using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests.EntityTests
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void TestNewTransactionHasCorrectId()
        {
            Transaction transaction = new Transaction(1, "Item Added", 1, 1, 1, DateTime.Now);
            Assert.AreEqual(1, transaction.ID);
        }

        [TestMethod]
        public void TestNewTransactionHasCorrectType()
        {
            Transaction transaction = new Transaction(1, "Item Added", 2, 3, 4, DateTime.Now);
            Assert.AreEqual("Item Added", transaction.Type);
        }

        [TestMethod]
        public void TestNewTransactionHasCorrectItemId()
        {
            Transaction transaction = new Transaction(1, "Item Added", 2, 3, 4, DateTime.Now);
            Assert.AreEqual(2, transaction.Item_ID);
        }

        [TestMethod]
        public void TestNewTransactionHasCorrectEmployeeId()
        {
            Transaction transaction = new Transaction(1, "Item Added", 2, 3, 4, DateTime.Now);
            Assert.AreEqual(3, transaction.Employee_ID);
        }

        [TestMethod]
        public void TestNewTransactionHasCorrectQuantity()
        {
            Transaction transaction = new Transaction(1, "Item Added", 2, 3, 4, DateTime.Now);
            Assert.AreEqual(4, transaction.Quantity);
        }

        [TestMethod]
        public void TestNewTransactionHasCorrectDate()
        {
            DateTime now = DateTime.Now;
            Transaction transaction = new Transaction(1, "Item Added", 2, 3, 4, now);
            Assert.AreEqual(now, transaction.Date_Created);
        }

        [TestMethod]
        public void TestInvalidValuesForNewTransactionProducesException()
        {
            try
            {
                Transaction transaction = new Transaction(0, "", 0, 0, 0, DateTime.Now);
            }
            catch (Exception)
            {
                Assert.Fail("Invalid Values");
            }

        }

        [TestMethod]
        public void TestInvalidValuesForNewTransactionProducesCorrectErrorMessage()
        {
            try
            {
                Transaction transaction = new Transaction(0, "", 0, 0, 0, DateTime.Now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: ID below 1; Type name is empty; Item ID below 1; Employee ID below 1; Quantity below 1;  ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
            }
        }
    }
}
