using DTO;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTests.DTOTests
{
    [TestClass]
    public class DTOConverterTests
    {
        private static readonly DTO_Converter converter = new DTO_Converter();

        [TestMethod]
        public void TestConvertItemEntityToDTO()
        {
            ItemDTO itemDTO = new ItemDTO(1, "ruler", 1, 1);
            Item item = new Item(1, "ruler", 1, 1, DateTime.Now);
            Assert.AreEqual(itemDTO.Item_Name, converter.Convert(item).Item_Name);
        }

        [TestMethod]
        public void TestConvertItemDTOToEntity()
        {
            ItemDTO itemDTO = new ItemDTO(1, "ruler", 1, 1);
            Item item = new Item(1, "ruler", 1, 1, DateTime.Now);
            Assert.AreEqual(item.Item_Name, converter.Convert(itemDTO).Item_Name);
        }

        [TestMethod]
        public void TestConvertEmployeeEntityToDTO()
        {
            EmployeeDTO employeeDTO = new EmployeeDTO(1, "Tom");
            Employee employee = new Employee(1, "Tom");
            Assert.AreEqual(employeeDTO.Employee_Name, converter.Convert(employee).Employee_Name);
        }

        [TestMethod]
        public void TestConvertEmployeeDTOToEntity()
        {
            EmployeeDTO employeeDTO = new EmployeeDTO(1, "Tom");
            Employee employee = new Employee(1, "Tom");
            Assert.AreEqual(employee.Employee_Name, converter.Convert(employeeDTO).Employee_Name);
        }

        [TestMethod]
        public void TestConvertTransactionEntityToDTO()
        {
            TransactionDTO transactionDTO = new TransactionDTO(1, "Item Added", 1, 1, 1, DateTime.Now);
            Transaction transaction = new Transaction(1, "Item Added", 1, 1, 1, DateTime.Now);
            Assert.AreEqual(transactionDTO.ID, converter.Convert(transaction).ID);
        }

        [TestMethod]
        public void TestConvertTransactionDTOToEntity()
        {
            TransactionDTO transactionDTO = new TransactionDTO(1, "Item Added", 1, 1, 1, DateTime.Now);
            Transaction transaction = new Transaction(1, "Item Added", 1, 1, 1, DateTime.Now);
            Assert.AreEqual(transaction.ID, converter.Convert(transactionDTO).ID);
        }
    }
}
