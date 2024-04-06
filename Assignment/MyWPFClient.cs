using Assignment;
using DTO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace WPF_Client
{
    public class MyWPFClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        public List<EmployeeDTO> employees { get; set; }
        public EmployeeDTO selectedEmployee { get; set; }

        private ConcurrentQueue<RequestDTO> requests;
        public ConcurrentQueue<Type> responses { get; set; }


        public MyWPFClient()
        {
            tcpClient = new TcpClient();
            requests = new ConcurrentQueue<RequestDTO>();
            responses = new ConcurrentQueue<Type>();
            if(!Connect("localhost", 4444))
            {
                MessageBox.Show("COULD NOT CONNECT TO SERVER");
            }
        }

        public ResponseDTO Run(RequestDTO request)
        {
            WriteToServer(request);

            return ReadFromServer();
        }

        private bool Connect(string url, int portNumber)
        {
            try
            {
                tcpClient.Connect(url, portNumber);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
                return false;
            }
            return true;
        }

        private void WriteToServer(RequestDTO request)
        {
            string serialisedRequest = JsonConvert.SerializeObject(request);

            lock (writer)
            {
                writer.WriteLine(serialisedRequest);
                writer.Flush();
            }
        }

        private ResponseDTO ReadFromServer()
        {
            string serverResponse = reader.ReadLine();
            while (serverResponse == null)
            {
                serverResponse = reader.ReadLine();
            }
            return JsonConvert.DeserializeObject<ResponseDTO>(serverResponse);
        }

        public Task<ResponseDTO> QueueRequest(RequestDTO request)
        {
            return Task.Run(() => Run(request));
        }

        private void GetAllEmployees()
        {
            if (employees == null)
            {
                QueueRequest(new RequestDTOBuilder().WithCommand(8).Build());
            }
            
        }
    }
}
