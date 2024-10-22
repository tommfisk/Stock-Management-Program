﻿using System;
using DataGateway;
using DTO;
using Newtonsoft.Json;

namespace Server.Command
{
    public class ViewFinancialReportCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private RequestDTO request;
        private StreamWriter writer;

        public ViewFinancialReportCommand(RequestDTO request, StreamWriter writer) 
        { 
            this.request = request;
            this.writer = writer;
        }

        public void Execute() 
        {
            List<ItemDTO> itemList = dataGatewayFacade.GetAllItems();

            ResponseDTO responseDTO = new ResponseDTOBuilder().WithCommand(request.command).WithItems(itemList).Build();
            string response = JsonConvert.SerializeObject(responseDTO);

            lock (writer)
            {
                writer.WriteLine(response);
                writer.Flush();
            }
        }
    }
}
