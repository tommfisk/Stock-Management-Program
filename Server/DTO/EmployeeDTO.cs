using System;

namespace DTO
{
    // DTO Design Pattern
    [Serializable]
    public class EmployeeDTO
    {
        public int ID { get; }
        public string Employee_Name { get; set; }


        public EmployeeDTO(int id, string Employee_Name)
        {
            this.ID = id;
            this.Employee_Name = Employee_Name;
        }

        public EmployeeDTO(string Employee_Name)
        {
            this.Employee_Name = Employee_Name;
        }

        public EmployeeDTO()
        {

        }
    }
}
