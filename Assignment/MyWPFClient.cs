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
        private bool clientRunning;
        public List<EmployeeDTO> employees;
        public List<ItemDTO> items;
        public List<TransactionDTO> transactions;
        public List<TransactionDTO> personalTransactions;
        public EmployeeDTO selectedEmployee { get; set; }

        private ConcurrentQueue<RequestDTO> requests;
        public ConcurrentQueue<Type> responses { get; set; }


        public MyWPFClient()
        {
            tcpClient = new TcpClient();
            requests = new ConcurrentQueue<RequestDTO>();
            responses = new ConcurrentQueue<Type>();
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

            if (request.command == 0)
            {
                clientRunning = false;
            }

            lock (writer)
            {
                writer.WriteLine(serialisedRequest);
                writer.Flush();
            }
        }

        private void ReadFromServer()
        {
            while (clientRunning)
            {
                string serverResponse = reader.ReadLine();
                ResponseDTO response = JsonConvert.DeserializeObject<ResponseDTO>(serverResponse);
                switch (response.command)
                {
                    case 1:
                    case 2:
                    case 3:
                        if (response.numRowsAffected != 1)
                        {
                            MessageBox.Show("Rows not affected");
                        }
                        break;
                    case 4:
                    case 5:
                        items = response.items;
                        break;
                    case 6:
                        transactions = response.transactions;
                        break;
                    case 7:
                        personalTransactions = response.transactions;
                        break;
                    case 8:
                        employees = response.employees;
                        break;
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
                QueueRequest(new RequestDTOBuilder().WithCommand(8).Build());
            }
            
        }
    }
}
