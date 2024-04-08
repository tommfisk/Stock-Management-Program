using DataGateway;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Newtonsoft.Json;
using Server.Command;

namespace ServerSide
{
    class ClientService
    {
        private Socket socket;
        private NetworkStream stream;
        public StreamReader reader { get; private set; }
        public StreamWriter writer { get; private set; }

        private RemoveClient removeMe;

        public ClientService(Socket socket, RemoveClient rc)
        {
            this.socket = socket;
            removeMe = rc;

            stream = new NetworkStream(socket);
            reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
        }
        public void InteractWithClient()
        {
            try
            {
                string clientRequest = reader.ReadLine();
                while (clientRequest != null)
                {
                    ProcessClientMessage(clientRequest);
                    clientRequest = reader.ReadLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            Console.WriteLine("Goodbye from " + socket.RemoteEndPoint.ToString());
            Close();
        }

        private void ProcessClientMessage(string message)
        {
            RequestDTO request = JsonConvert.DeserializeObject<RequestDTO>(message);
            try
            {
                CommandFactory commandFactory = new CommandFactory();

                commandFactory.Create(request, writer).Execute();
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }  
        }

        public void Close()
        {
            try
            {
                removeMe(this);
                socket.Shutdown(SocketShutdown.Both);
            }
            finally
            {
                socket.Close();
            }
        }
    }
}
