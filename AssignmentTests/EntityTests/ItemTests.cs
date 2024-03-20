using Assignment;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests.EntityTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void TestNewItemHasCorrectId()
        {
            Item item = new Item(1, "a", 1, 0.10, DateTime.Now);
            Assert.AreEqual(1, item.ID);
        }

        [TestMethod]
        public void TestNewItemHasCorrectName()
        {
            Item item = new Item(1, "a", 1, 0.10, DateTime.Now);
            Assert.AreEqual("a", item.Item_Name);
        }

        [TestMethod]
        public void TestNewItemHasCorrectQuantity()
        {
            Item item = new Item(1, "a", 1, 0.10, DateTime.Now);
            Assert.AreEqual(1, item.Quantity);
        }

        [TestMethod]
        public void TestNewItemHasCorrectCreationDate()
        {
            DateTime now = DateTime.Now;
            Item item = new Item(1, "a", 1, 0.10, now);
            Assert.AreEqual(now, item.Date_Created);
        }

        [TestMethod]
        public void TestInvalidValuesForNewItemProducesException()
        {
            try
            {
                Item item = new Item(0, "", 0, 0, DateTime.Now);
            }
            catch (Exception)
            {
                Assert.Fail("Invalid Values");
            }

        }

        [TestMethod]
        public void TestInvalidValuesForNewItemProducesCorrectErrorMessage()
        {
            try
            {
                Item item = new Item(0, "", 0, 0, DateTime.Now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: ID below 1; Quantity below 1; Item name is empty; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
            }
        }
    }
}
