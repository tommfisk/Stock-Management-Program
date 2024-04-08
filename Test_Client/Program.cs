using DTO;
using System;

namespace Test_Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Sleeping for 10 seconds");
            Thread.Sleep(10000);
            Console.WriteLine("Requesting server");

            RequestDTO request = new RequestDTOBuilder().WithCommand(4).Build();

            Client client = new Client();
            ResponseDTO response = await client.QueueRequest(request);

            Console.WriteLine(response.items.Count);
        }
    }
}