using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;

namespace ServerSide
{
    class ClientService
    {

        private Socket socket;
        private NetworkStream stream;
        public StreamReader reader { get; private set; }
        public StreamWriter writer { get; private set; }

        private RemoveClient removeMe;

        private string employeeName;

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
                string clientMessage = reader.ReadLine();
                while (clientMessage != null)
                {
                    ProcessClientMessage(clientMessage);
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
            if (message.StartsWith("Employee")) 
            {
                this.employeeName = message.Substring(10);
            }
            else if (int.TryParse(message.Substring(0, 1), out int command))
            {
                
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
