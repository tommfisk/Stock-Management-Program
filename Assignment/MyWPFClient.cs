using Assignment;
using DTO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

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

        private ConcurrentDictionary<int, ItemDTO> requests;


        private MyWPFClient()
        {
            tcpClient = new TcpClient();
            requests = new ConcurrentDictionary<int, ItemDTO>();
        }

        public static MyWPFClient getInstance()
        {
            if (instance == null)
            {
                instance = new MyWPFClient();
            }
            return instance;
        }

        public void Run()
        {
            clientRunning = true;
            
            if (Connect("localhost", 4444))
            {
                /*Task.Run(ReadFromServer);*/

                while (clientRunning)
                {
                    if (requests.Count > 0)
                    {
                        KeyValuePair<int, ItemDTO> request = requests.Last();

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

        private string serialise(ItemDTO item)
        {
            return JsonSerializer.Serialize(item);
        }

        private void WriteToServer(KeyValuePair<int, ItemDTO> request)
        {
            int command = request.Key;
            if (command == 0)
            {
                clientRunning = false;
            }
            else if (command >= 1 && command <= 3)
            {
                string serialisedItem = serialise(request.Value);
                lock (writer)
                {
                    writer.WriteLine(command);
                    writer.WriteLine(serialisedItem);
                    writer.Flush();
                }
            }
            else if (command >= 4 && command <= 7)
            {
                lock (writer)
                {
                    writer.WriteLine(command);
                    writer.Flush();
                }
            }
            else
            {
                MessageBox.Show("Choice not recognised");
            }
            
        }

        private void ReadFromServer()
        {
            while (clientRunning)
            {
                string serverResponse = reader.ReadLine();
                List<string> msg = JsonSerializer.Deserialize<List<string>>(serverResponse);
            }
        }

        public void setEmployee(string employeeName)
        {
            lock (writer)
            {
                writer.WriteLine("Employee: " + employeeName);
                writer.Flush();
            }
        }

        public EmployeeDTO getEmployee()
        {
            string serverResponse = reader.ReadLine();
            return JsonSerializer.Deserialize<EmployeeDTO>(serverResponse);
        }

        public List<EmployeeDTO> getEmployeeList()
        {
            string serverResponse = reader.ReadLine();
            return JsonSerializer.Deserialize<List<EmployeeDTO>>(serverResponse);
        }

        public void AddRequest(int command, ItemDTO item)
        {
            lock (requests)
            {
                requests.TryAdd(command, item);
            }
            
        }
    }
}
