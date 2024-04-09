using DTO;
using System;

namespace Test_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sleeping for 15 seconds");
            Thread.Sleep(15000);
            Console.WriteLine("Requesting server");

            RequestDTO request1 = 
                new RequestDTOBuilder()
                .WithCommand(1)
                .WithEmployeeId(1)
                .WithItem(
                    new ItemDTOBuilder()
                    .WithName("ruler")
                    .WithQuantity(3)
                    .WithPrice(1)
                    .Build())
                .Build();

            RequestDTO request2 = new RequestDTOBuilder().WithCommand(6).Build();

            Client client1 = new Client();
            Client client2 = new Client();

            Task clientTask1 = Task.Run(client1.Run);
            Task clientTask2 = Task.Run(client2.Run);

            while (true)
            {
                client1.QueueRequest(request1);
                client2.QueueRequest(request2);
            }
        }
    }
}