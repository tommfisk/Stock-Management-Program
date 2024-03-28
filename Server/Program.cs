using DataGateway;
using System;

namespace ServerSide
{
    class Program
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();

        static void Main(string[] args)
        {
            dataGatewayFacade.InitialiseOracleDatabase();

            Console.WriteLine("Server has started!");
            MyServer srvr = new MyServer();

            srvr.Start(); // a synchronous call

            srvr.Stop();

            Console.WriteLine("Server has finished!");
        }
    }
}
