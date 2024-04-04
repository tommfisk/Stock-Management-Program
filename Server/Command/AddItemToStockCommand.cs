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
        private RequestDTO request;

        public AddItemToStockCommand(RequestDTO request)
        {
            this.request = request;
        }

        public void Execute()
        {
            dataGatewayFacade.AddItem(request.item);
            ItemDTO itemAdded = dataGatewayFacade.FindItemByName(request.item.Item_Name);
            dataGatewayFacade.AddTransaction(new TransactionDTO("Item Added", itemAdded.ID, request.employee_id, request.item.Quantity));
        }
    }
}
