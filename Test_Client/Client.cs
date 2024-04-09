using DTO;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Test_Client
{
    public class Client
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        public List<EmployeeDTO> employees { get; set; }
        public EmployeeDTO selectedEmployee { get; set; }
        private bool clientRunning = true;
        private ConcurrentQueue<RequestDTO> requests;
        private ConcurrentQueue<ResponseDTO> responses;


        public Client()
        {
            tcpClient = new TcpClient();
            requests = new ConcurrentQueue<RequestDTO>();
            responses = new ConcurrentQueue<ResponseDTO>();
        }

        public void Run()
        {
            if (Connect("localhost", 4444))
            {
                Task.Run(ReadFromServer);
                Task.Run(DisplayMessages);

                while (clientRunning)
                {
                    if (requests.TryDequeue(out RequestDTO request))
                    {
                        WriteToServer(request);
                    }
                }
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
            catch (Exception)
            {
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

        private void ReadFromServer()
        {
            while (clientRunning)
            {
                string serverResponse = reader.ReadLine();
                responses.Enqueue(JsonConvert.DeserializeObject<ResponseDTO>(serverResponse));
            }

        }

        private void DisplayMessages()
        {
            while (clientRunning)
            {
                if (responses.TryDequeue(out ResponseDTO response))
                {
                    Console.WriteLine("Request command " + response.command + " completed");
                }
            }
        }

        public void QueueRequest(RequestDTO request)
        {
            requests.Enqueue(request);
        }
    }
}
