using System;
using DataGateway;
using DTO;

namespace Assignment.Command
{
    public class ViewFinancialReportCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public ViewFinancialReportCommand() 
        { 
        }

        public void Execute() 
        {
            double total = 0;

            Console.WriteLine("\nFinancial Report:");

            foreach (ItemDTO item in dataGatewayFacade.GetAllItems())
            {
                    double cost = item.Price * item.Quantity;
                    Console.WriteLine("ID: {0}, Total price of {1}: {2:C}", item.ID, item.Item_Name, cost);
                    total += cost;
            }

            Console.WriteLine("Total price of all items: {0:C}", total);
        }
    }
}
