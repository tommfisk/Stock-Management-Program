using System;
using DTO;
using Assignment.Util;
using DataGateway;

namespace Assignment.Command
{
    public class TakeQuantityFromItemCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public TakeQuantityFromItemCommand()
        {
        }

        public void Execute() 
        {
            try
            {
                string employeeName = ConsoleReader.ReadString("\nEmployee Name");
                EmployeeDTO employeeDTO = dataGatewayFacade.FindEmployeeByName(employeeName);
                while (employeeDTO == null)
                {
                    Console.WriteLine("Employee does not exist");
                    employeeName = ConsoleReader.ReadString("\nEmployee Name");
                    employeeDTO = dataGatewayFacade.FindEmployeeByName(employeeName);
                }

                int itemId = ConsoleReader.ReadInteger("Item ID");
                ItemDTO itemDTO = dataGatewayFacade.FindItemById(itemId);
                while (itemDTO == null)
                {
                    Console.WriteLine("Item does not exist");
                    itemId = ConsoleReader.ReadInteger("Item ID");
                    itemDTO = dataGatewayFacade.FindItemById(itemId);
                }

                int quantityToRemove = ConsoleReader.ReadInteger("How many items would you like to remove?");
                while (quantityToRemove < 0)
                {
                    Console.WriteLine("Please enter a quantity above 0");
                    quantityToRemove = ConsoleReader.ReadInteger("How many items would you like to remove?");
                }

                dataGatewayFacade.TakeQuantityFromItem(itemId, quantityToRemove);
                dataGatewayFacade.AddTransaction(new TransactionDTO("Quantity Taken", itemId, employeeDTO.ID, quantityToRemove));

                Console.WriteLine(
                    "{0} has removed {1} from Item ID: {2} on {3}",
                    employeeName,
                    quantityToRemove,
                    itemId,
                    DateTime.Now.ToString("dd/MM/yyyy"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
