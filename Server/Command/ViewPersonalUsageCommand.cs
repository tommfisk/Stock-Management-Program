using System;
using DTO;
using System.Globalization;
using DataGateway;
using Newtonsoft.Json;

namespace Server.Command
{
    public class ViewPersonalUsageCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private RequestDTO request;
        private StreamWriter writer;

        public ViewPersonalUsageCommand(RequestDTO request, StreamWriter writer) 
        {
            this.request = request;
            this.writer = writer;
        }

        public void Execute()
        {
            List<TransactionDTO> transactionList = dataGatewayFacade.GetAllTransactions();
            List<TransactionDTO> personalTransactionList = new List<TransactionDTO>();

            foreach (TransactionDTO transaction in transactionList)
            {
                if (transaction.Employee_ID == request.employee_id)
                {
                    personalTransactionList.Add(transaction);
                }
            }

            ResponseDTO responseDTO = new ResponseDTOBuilder().WithCommand(request.command).WithTransactions(personalTransactionList).Build();
            string response = JsonConvert.SerializeObject(responseDTO);

            lock (writer)
            {
                writer.WriteLine(response);
                writer.Flush();
            }
        }
    }
}
