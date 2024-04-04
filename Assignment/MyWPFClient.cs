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
    public sealed class MyWPFClient
    {
        private static MyWPFClient instance = null;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private bool clientRunning;
        public List<EmployeeDTO> employees;
        public EmployeeDTO selectedEmployee { get; set; }

        private ConcurrentQueue<RequestDTO> requests;
        public ConcurrentQueue<Type> responses { get; set; }


        private MyWPFClient()
        {
            tcpClient = new TcpClient();
            requests = new ConcurrentQueue<RequestDTO>();
            responses = new ConcurrentQueue<Type>();
        }

        public static MyWPFClient getInstance()
        {
            if (instance == null)
            {
                return new MyWPFClient();
            }
            return instance;
        }

        public void Run()
        {
            clientRunning = true;
            
            if (Connect("localhost", 4444))
            {
                Task.Run(ReadFromServer);

                GetAllEmployees();

                while (clientRunning)
                {
                    if (requests.TryDequeue(out RequestDTO request))
                    {
                        WriteToServer(request);
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR: Connection to server not successful");
            }
            tcpClient.Close();
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
            switch (request.command)
            {
                case 0:
                    clientRunning = false;
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    lock (writer)
                    {
                        writer.WriteLine(serialisedRequest);
                        writer.Flush();
                    }
                    break;
                default:
                    MessageBox.Show("Choice not recognised");
                    break;
            } 
        }

        private void ReadFromServer()
        {
            while (clientRunning)
            {
                string serverResponse = reader.ReadLine();
                List<EmployeeDTO> DTOs = JsonConvert.DeserializeObject<List<EmployeeDTO>>(serverResponse);
                if (DTOs != null)
                {
                    employees = DTOs;
                }

            }
        }

        public void QueueRequest(RequestDTO request)
        {
            requests.Enqueue(request);
        }

        private void GetAllEmployees()
        {
            if (employees == null)
            {
                QueueRequest(new RequestDTOBuilder().WithCommand(1).Build());
            }
            
        }
    }
}
