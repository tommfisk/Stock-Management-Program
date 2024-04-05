using System;
using System.Collections.Generic;
using System.Text;
using Library;
using DTO;
using DataGateway;
using Newtonsoft.Json;

namespace Server.Command
{
    public class AddItemToStockCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private RequestDTO request;
        private StreamWriter writer;

        public AddItemToStockCommand(RequestDTO request, StreamWriter writer)
        {
            this.request = request;
            this.writer = writer;
        }

        public void Execute()
        {
            int numRowsAffected = 0;
            ResponseDTOBuilder responseDTOBuilder = new ResponseDTOBuilder().WithCommand(request.command);

            numRowsAffected = dataGatewayFacade.AddItem(request.item);

            if (numRowsAffected == 1 )
            {
                ItemDTO itemAdded = dataGatewayFacade.FindItemByName(request.item.Item_Name);
                dataGatewayFacade.AddTransaction(new TransactionDTO("Item Added", itemAdded.ID, request.employee_id, request.item.Quantity));
            }

            ResponseDTO responseDTO = responseDTOBuilder.WithNumRowsAffected(numRowsAffected).Build();
            string response = JsonConvert.SerializeObject(responseDTO);
            
            lock (writer)
            {
                writer.WriteLine(response);
                writer.Flush();
            }
            
        }
    }
}
