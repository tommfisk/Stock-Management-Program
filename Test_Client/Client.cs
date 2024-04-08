using DTO;
using System.Net.Sockets;
using Newtonsoft.Json;

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


        public Client()
        {
            tcpClient = new TcpClient();
            if(!Connect("localhost", 4444))
            {
                Console.WriteLine("COULD NOT CONNECT TO SERVER");
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
                Console.WriteLine("Exception: " + e.Message);
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
    }
}
