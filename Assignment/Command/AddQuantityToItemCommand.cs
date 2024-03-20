using System;
using Assignment.Util;
using DataGateway;
using DTO;

namespace Assignment.Command
{
    public class AddQuantityToItemCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public AddQuantityToItemCommand() 
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
                int quantityToAdd = ConsoleReader.ReadInteger("How many items would you like to add?");
                while (quantityToAdd < 0)
                {
                    Console.WriteLine("Please enter a quantity above 0");
                    quantityToAdd = ConsoleReader.ReadInteger("How many items would you like to add?");
                }

                dataGatewayFacade.AddQuantityToItem(itemId, quantityToAdd);
                dataGatewayFacade.AddTransaction(new TransactionDTO("Quantity Added", itemId, employeeDTO.ID, quantityToAdd));

                Console.WriteLine(
                    "{0} has added {1} to Item ID: {2} on {3}",
                    employeeName,
                    quantityToAdd,
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
