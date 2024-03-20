using System;
using DTO;
using System.Globalization;
using Assignment.Util;
using DataGateway;

namespace Assignment.Command
{
    public class ViewPersonalUsageCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public ViewPersonalUsageCommand() 
        {
        }

        public void Execute()
        {
            string employeeName = ConsoleReader.ReadString("Employee name");
            EmployeeDTO employeeDTO = dataGatewayFacade.FindEmployeeByName(employeeName);
            while (employeeDTO == null)
            {
                Console.WriteLine("Employee does not exist");
                employeeName = ConsoleReader.ReadString("\nEmployee Name");
                employeeDTO = dataGatewayFacade.FindEmployeeByName(employeeName);
            }

            Console.WriteLine("\nPersonal Usage Report for {0}", employeeName);
            Console.WriteLine(
                "\t{0, -4} {1, -12} {2, -16} {3, -10} {4, -12} {5, -16} {6, -12}",
                "ID",
                "Date",
                "Type",
                "Item ID",
                "Item Name",
                "Item Quantity",
                "Item Price"
                );

            foreach (TransactionDTO entry in dataGatewayFacade.GetAllTransactions())
            {
                
                ItemDTO itemDTO = dataGatewayFacade.FindItemById(entry.Item_ID);
                EmployeeDTO employee = dataGatewayFacade.FindEmployeeById(entry.Employee_ID);

                if (employee.Employee_Name == employeeName)
                {
                    Console.WriteLine(
                    "\t{0, -4} {1, -12} {2, -16} {3, -10} {4, -12} {5, -16} {6, -12}",
                    entry.ID,
                    entry.Date_Created.ToString("dd/MM/yyyy"),
                    entry.Type,
                    itemDTO.ID,
                    itemDTO.Item_Name,
                    entry.Quantity,
                    itemDTO.Price.ToString("C", CultureInfo.CurrentCulture)
                    );
                }

                
            }
        }
    }
}
