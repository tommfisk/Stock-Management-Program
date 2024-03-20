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
    public class FindEmployeeByIdTests
    {
        private DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        [TestMethod]
        public void TestFindingExistingEmployeeById()
        {
            EmployeeDTO employeeDTO = dataGatewayFacade.FindEmployeeById(1);
            Assert.AreEqual("Graham", employeeDTO.Employee_Name);
        }

        [TestMethod]
        public void TestFindingNonExistingEmployeeById()
        {
            EmployeeDTO employeeDTO = dataGatewayFacade.FindEmployeeById(0);
            Assert.ThrowsException<NullReferenceException>(() => employeeDTO.Employee_Name);
        }
    }
}
