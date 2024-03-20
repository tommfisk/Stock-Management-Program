using Assignment.Command;
using DataGateway;
using System;
using Assignment.Util;

namespace Assignment
{
    class Program
    {

        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        static void Main(string[] args)
        {
            dataGatewayFacade.InitialiseOracleDatabase();

            CommandFactory factory = new CommandFactory();

            ICommand displayMenu = factory.Create(ICommand.DISPLAY_MENU);

            displayMenu.Execute();
            int command = GetUserChoice();

            while (command != ICommand.EXIT)
            {
                factory
                    .Create(command)
                    .Execute();

                displayMenu.Execute();
                command = GetUserChoice();
            }
        }

        private static int GetUserChoice()
        {
            int option = ConsoleReader.ReadInteger("\nOption");
            while (option < ICommand.ADD_ITEM_TO_STOCK || option > ICommand.EXIT)
            {
                Console.WriteLine("\nChoice not recognised, Please enter again");
                option = ConsoleReader.ReadInteger("\nOption");
            }
            return option;
        }
   
    }
}
