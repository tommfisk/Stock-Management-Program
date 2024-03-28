using System;
using DTO;
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
            
        }

    }
}
