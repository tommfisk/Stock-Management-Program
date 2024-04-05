using System;
using DTO;
using System.Globalization;
using DataGateway;
using Newtonsoft.Json;

namespace Server.Command
{
    public class ViewTransactionLogCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private RequestDTO request;
        private StreamWriter writer;

        public ViewTransactionLogCommand(RequestDTO request, StreamWriter writer) 
        { 
            this.request = request;
            this.writer = writer;
        }

        public void Execute() 
        {

            List<TransactionDTO> transactionList = dataGatewayFacade.GetAllTransactions();

            ResponseDTO responseDTO = new ResponseDTOBuilder().WithCommand(request.command).WithTransactions(transactionList).Build();
            string response = JsonConvert.SerializeObject(responseDTO);

            lock (writer)
            {
                writer.WriteLine(response);
                writer.Flush();
            }
        }
    }
}
