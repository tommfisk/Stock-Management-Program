using System;
using DTO;
using System.Globalization;
using DataGateway;

namespace Assignment.Command
{
    public class ViewTransactionLogCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public ViewTransactionLogCommand() 
        { 
        }

        public void Execute() 
        {

            Console.WriteLine("\nTransaction Log:");
            Console.WriteLine(
                "\t{0, -4} {1, -12} {2, -16} {3, -10} {4, -10} {5, -16} {6, -12} {7, -16}",
                "ID",
                "Date",
                "Type",
                "Item ID",
                "Item Name",
                "Item Quantity",
                "Item Price",
                "Employee Name");

            foreach (TransactionDTO entry in dataGatewayFacade.GetAllTransactions())
            {
                ItemDTO itemDTO = dataGatewayFacade.FindItemById(entry.Item_ID);
                EmployeeDTO employeeDTO = dataGatewayFacade.FindEmployeeById(entry.Employee_ID);

                Console.WriteLine(
                    "\t{0, -4} {1, -12} {2, -16} {3, -10} {4, -10} {5, -16} {6, -12} {7, -16}",
                    entry.ID,
                    entry.Date_Created.ToString("dd/MM/yyyy"),
                    entry.Type,
                    itemDTO.ID,
                    itemDTO.Item_Name,
                    entry.Quantity,
                    itemDTO.Price.ToString("C", CultureInfo.CurrentCulture),
                    employeeDTO.Employee_Name
                    );
            }
        }
    }
}
