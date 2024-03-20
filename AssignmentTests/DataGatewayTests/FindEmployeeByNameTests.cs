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
    public class FindEmployeeByNameTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestFindingExistingEmployeeByName()
        {
            EmployeeDTO employeeDTO = dataGatewayFacade.FindEmployeeByName("Graham");
            Assert.AreEqual(1, employeeDTO.ID);
        }

        [TestMethod]
        public void TestFindingNonExistingEmployeeByName()
        {
            EmployeeDTO employeeDTO = dataGatewayFacade.FindEmployeeByName("");
            Assert.ThrowsException<NullReferenceException>(() => employeeDTO.ID);
        }

        [TestMethod]
        public void TestFindingNonExistingEmployeeByNameUsingNullValue()
        {
            EmployeeDTO employeeDTO = dataGatewayFacade.FindEmployeeByName(null);
            Assert.ThrowsException<NullReferenceException>(() => employeeDTO.ID);
        }
    }
}
