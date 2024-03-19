using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;

namespace EntityTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Test_WhenBookIsAvailable_ExpectBorrowBookToReturnTrue()
        {
            Book b = 
                new BookBuilder()
                    .WithState("Available")
                    .Build();

            Assert.IsTrue(b.Borrow());
        }

        [TestMethod]
        public void Test_WhenBookIsOnLoan_ExpectBorrowBookToReturnFalse()
        {
            Book b = 
                new BookBuilder()
                    .WithState("On loan")
                    .Build();

            Assert.IsFalse(b.Borrow());
        }

        [TestMethod]
        public void Test_WhenBookIsAvailable_ExpectReturnBookToReturnFalse()
        {
            Book b = 
                new BookBuilder()
                    .WithState("Available")
                    .Build();

            Assert.IsFalse(b.Return());
        }

        [TestMethod]
        public void Test_WhenBookIsOnLoan_ExpectReturnBookToReturnTrue()
        {
            Book b = 
                new BookBuilder()
                    .WithState("On loan")
                    .Build();

            Assert.IsTrue(b.Return());
        }

        [TestMethod]
        public void Test_WhenBookIsAvailable_ExpectBorrowBookToMakeStateOnLoan()
        {
            Book b =
                new BookBuilder()
                    .WithState("Available")
                    .Build();
            
            b.Borrow();

            Assert.AreEqual("On loan", b.State);
        }

        [TestMethod]
        public void Test_WhenBookIsOnLoan_ExpectBorrowBookNotToChangeTheBooksState()
        {
            Book b =
                new BookBuilder()
                    .WithState("On loan")
                    .Build();

            string stateBeforeBorrow = b.State;
            b.Borrow();

            Assert.AreEqual(stateBeforeBorrow, b.State);
        }

        [TestMethod]
        public void Test_WhenBookIsOnLoan_ExpectReturnBookToMakeStateAvailable()
        {
            Book b =
                new BookBuilder()
                    .WithState("On loan")
                    .Build();
            
            b.Return();

            Assert.AreEqual("Available", b.State);
        }

        [TestMethod]
        public void Test_WhenBookIsAvailable_ExpectReturnBookNotToChangeTheBooksState()
        {
            Book b =
                new BookBuilder()
                    .WithState("Available")
                    .Build();

            string stateBeforeReturn = b.State;
            b.Return();

            Assert.AreEqual(stateBeforeReturn, b.State);
        }
    }
}
