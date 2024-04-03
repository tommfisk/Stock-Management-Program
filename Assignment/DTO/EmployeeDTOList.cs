
using DTO;
using Newtonsoft.Json;
public class EmployeeDTOList
{
    [JsonProperty("EmployeeDTOs")]
    public List<EmployeeDTO> EmployeeDTOs { get; set; }

    public EmployeeDTOList()
    {
        EmployeeDTOs = new List<EmployeeDTO>();
    }
}

