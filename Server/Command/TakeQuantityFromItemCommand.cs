using System;
using DTO;
using DataGateway;
using Newtonsoft.Json;

namespace Server.Command
{
    public class TakeQuantityFromItemCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private RequestDTO request;
        private StreamWriter writer;

        public TakeQuantityFromItemCommand(RequestDTO request, StreamWriter writer)
        {
            this.request = request;
            this.writer = writer;
        }

        public void Execute() 
        {
            int numRowsAffected = 0;

            ResponseDTOBuilder responseDTOBuilder = new ResponseDTOBuilder().WithCommand(request.command);

            numRowsAffected = dataGatewayFacade.TakeQuantityFromItem(request.item);

            if (numRowsAffected == 1)
            {
                dataGatewayFacade.AddTransaction(new TransactionDTO("Quantity Taken", request.item.ID, request.employee_id, request.item.Quantity));
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
