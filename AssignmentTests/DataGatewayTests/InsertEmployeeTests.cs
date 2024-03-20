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
    public class InsertEmployeeTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestInsertingEmployeeWithCorrectValues() 
        {
            Assert.AreEqual(dataGatewayFacade.FindEmployeeById(1).Employee_Name, "Graham");
        }

        [TestMethod]
        public void TestInsertingEmployeeWithEmptyNameThrowsException()
        {
            EmployeeDTO employeeDTO = new EmployeeDTO("");
            Assert.ThrowsException<Exception>(() => dataGatewayFacade.AddEmployee(employeeDTO));
        }

        [TestMethod]
        public void TestInsertingEmployeeWithNullValueThrowsException()
        {
            EmployeeDTO employeeDTO = new EmployeeDTO(null);
            Assert.ThrowsException<Exception>(() => dataGatewayFacade.AddEmployee(employeeDTO));
        }
    }
}
