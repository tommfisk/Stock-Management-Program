using System;
using DTO;
using System.Globalization;
using DataGateway;

namespace Assignment.Command
{
    public class ViewInventoryReportCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public ViewInventoryReportCommand() 
        { 
        }

        public void Execute() 
        {
            Console.WriteLine("\nAll items");
            Console.WriteLine(
                "\t{0, -4} {1, -20} {2, -20} {3, -10}",
                "ID",
                "Name",
                "Quantity",
                "Price"
                );

            foreach (ItemDTO itemDTO in dataGatewayFacade.GetAllItems())
            {
                Console.WriteLine(
                    "\t{0, -4} {1, -20} {2, -20} {3, -10}",
                    itemDTO.ID,
                    itemDTO.Item_Name,
                    itemDTO.Quantity,
                    itemDTO.Price.ToString("C", CultureInfo.CurrentCulture)
                    );
            }
        }
    }
}
