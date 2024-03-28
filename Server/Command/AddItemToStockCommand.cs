using System;
using System.Collections.Generic;
using System.Text;
using Library;
using DTO;
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
            
        }
    }
}
