using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using Library;

namespace AssignmentTests.EntityTests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void TestNewEmployeeHasCorrectId()
        {
            Employee employee = new Employee(1, "Tom");
            Assert.AreEqual(1, employee.ID);
        }

        [TestMethod]
        public void TestNewEmployeeHasCorrectName()
        {
            Employee employee = new Employee(1, "Dave");
            Assert.AreEqual("Dave", employee.Employee_Name);
        }

        [TestMethod]
        public void TestInvalidValuesForNewEmployeeProducesException()
        {
            try
            {
                Employee employee = new Employee(0, "");
            }
            catch (Exception)
            {
                Assert.Fail("Invalid Values");
            }

        }

        [TestMethod]
        public void TestInvalidValuesForNewEmployeeProducesCorrectErrorMessage()
        {
            try
            {
                Employee employee = new Employee(0, "");
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: ID below 1; Employee name is empty; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
            }
        }
    }
}
