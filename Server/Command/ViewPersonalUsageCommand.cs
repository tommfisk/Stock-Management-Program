using System;
using DTO;
using System.Globalization;
using DataGateway;

namespace Assignment.Command
{
    public class ViewPersonalUsageCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        public ViewPersonalUsageCommand() 
        {
        }

        public void Execute()
        {
        }
    }
}
