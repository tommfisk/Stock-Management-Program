using System;
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

        }
    }
}
