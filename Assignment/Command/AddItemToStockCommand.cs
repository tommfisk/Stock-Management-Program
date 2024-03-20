using System;
using System.Collections.Generic;
using System.Text;
using Library;
using DTO;
using Assignment.Util;
using DataGateway;

namespace Assignment.Command
{
    public class AddItemToStockCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public AddItemToStockCommand()
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

                string itemName = ConsoleReader.ReadString("Item Name");
                while (itemName == null || itemName == "" || itemName.Contains(" "))
                {
                    if (itemName.Contains(" "))
                    {
                        Console.WriteLine("Please do not use spaces in the name");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a name for the item");
                    }
                    itemName = ConsoleReader.ReadString("Item Name");
                }

                int itemQuantity = ConsoleReader.ReadInteger("Item Quantity");
                while (itemQuantity < 0)
                {
                    Console.WriteLine("Please enter a quantity above 0");
                    itemQuantity = ConsoleReader.ReadInteger("Item Quantity");
                }

                double itemPrice = ConsoleReader.ReadDouble("Item Price");
                while (itemPrice < 0)
                {
                    Console.WriteLine("Please enter a price above 0");
                    itemPrice = ConsoleReader.ReadDouble("Item Price");
                }
                
                
                

                dataGatewayFacade.AddItem(new ItemDTO(itemName, itemQuantity, itemPrice));
                ItemDTO itemDTO = dataGatewayFacade.FindItemByName(itemName);

                dataGatewayFacade.AddTransaction(
                    new TransactionDTO("Item Added", itemDTO.ID, employeeDTO.ID, itemDTO.Quantity));

                Console.WriteLine("Item Added");
                CommandFactory commandFactory = new CommandFactory();
                commandFactory
                    .Create(4)
                    .Execute();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
