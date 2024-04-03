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
    class MyWPFClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private bool clientRunning;
        public List<EmployeeDTO> employees;
        public string selectedEmployee { get; set; }

        private BlockingCollection<int> commands;
        public ConcurrentQueue<Type> responses { get; set; }

        private ShowMessage ShowMessage;
        private GetItemDTO GetItemDTO;


        public MyWPFClient(ShowMessage ShowMessage, GetItemDTO GetItemDTO)
        {
            tcpClient = new TcpClient();
            commands = new BlockingCollection<int>();
            responses = new ConcurrentQueue<Type>();
            this.ShowMessage = ShowMessage;
            this.GetItemDTO = GetItemDTO;
        }

        public void Run()
        {
            clientRunning = true;
            
            if (Connect("localhost", 4444))
            {
                Task.Run(ReadFromServer);

                commands.Add(1);

                while (clientRunning)
                {
                    if (commands.Count > 0)
                    {
                        int command = commands.Take();

                        ItemDTO itemDTO = GetItemDTO();
                        string serialisedItem = JsonConvert.SerializeObject(itemDTO);

                        WriteToServer(command, serialisedItem);
                    }
                }
            }
            else
            {
                ShowMessage("ERROR: Connection to server not successful");
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
                ShowMessage("Exception: " + e.Message);
                return false;
            }
            return true;
        }

        private void WriteToServer(int command, string item)
        {
            switch (command)
            {
                case 0:
                    clientRunning = false;
                    break;
                case 1:
                    lock (writer)
                    {
                        writer.WriteLine(command);
                        writer.Flush();
                    }    
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    lock (writer)
                    {
                        writer.WriteLine(command);
                        writer.WriteLine(item);
                        writer.Flush();
                    }
                    break;
                default:
                    ShowMessage("Choice not recognised");
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

        public void AddCommand(int command)
        {
            commands.Add(command);
        }
    }
}
