using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;

namespace EntityTests
{
    [TestClass]
    public class LoanTests
    {
        [TestMethod]
        public void Test_WhenNumberOfRenewalsIsZero_ExpectRenewToReturnTrue()
        {
            Loan loan =
                new LoanBuilder()
                    .WithNumberOfRenewals(0)
                    .WithDueDate(DateTime.Now)
                    .Build();

            Assert.IsTrue(loan.Renew());
        }

        [TestMethod]
        public void Test_WhenNumberOfRenewalsIsOne_ExpectRenewToReturnTrue()
        {
            Loan loan =
                new LoanBuilder()
                    .WithNumberOfRenewals(1)
                    .WithDueDate(DateTime.Now)
                    .Build();

            Assert.IsTrue(loan.Renew());
        }

        [TestMethod]
        public void Test_WhenNumberOfRenewalsIsTwo_ExpectRenewToReturnTrue()
        {
            Loan loan =
                new LoanBuilder()
                    .WithNumberOfRenewals(2)
                    .WithDueDate(DateTime.Now)
                    .Build();

            Assert.IsTrue(loan.Renew());
        }

        [TestMethod]
        public void Test_WhenNumberOfRenewalsIsThree_ExpectRenewToReturnFalse()
        {
            Loan loan =
                new LoanBuilder()
                    .WithNumberOfRenewals(3)
                    .WithDueDate(DateTime.Now)
                    .Build();

            Assert.IsFalse(loan.Renew());
        }
    }
}
