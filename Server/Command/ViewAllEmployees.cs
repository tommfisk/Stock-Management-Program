using DataGateway;
using DTO;
using Library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Server.Command
{
    public class ViewAllEmployeesCommand : ICommand
    {
        private static readonly DataGatewayFacade dataGatewayFacade = DataGatewayFacade.getInstance();
        private RequestDTO request;
        private StreamWriter writer;

        public ViewAllEmployeesCommand(RequestDTO request, StreamWriter writer)
        {
            this.request = request;
            this.writer = writer;
        }

        public void Execute()
        {
            List<EmployeeDTO> employeeList = dataGatewayFacade.GetAllEmployees();
            ResponseDTO responseDTO = new ResponseDTOBuilder().WithCommand(request.command).WithEmployees(employeeList).Build();
            string response = JsonConvert.SerializeObject(responseDTO);

            lock (writer)
            {
                writer.WriteLine(response);
                writer.Flush();
            }
        }
    }
}
