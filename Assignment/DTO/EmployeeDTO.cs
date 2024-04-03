using Newtonsoft.Json;

public class EmployeeDTO
{
    [JsonProperty("ID")]
    public int ID { get; set; }
    [JsonProperty("Employee_Name")]
    public string Employee_Name { get; set; }

    [JsonConstructor]
    public EmployeeDTO(int id, string Employee_Name)
    {
        this.ID = id;
        this.Employee_Name = Employee_Name;
    }

    public EmployeeDTO(string Employee_Name)
    {
        this.Employee_Name = Employee_Name;
    }
}

