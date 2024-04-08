using System;

namespace Library
{
    [Serializable]
    public class Employee
    {
        public int ID { get; }
        public string Employee_Name { get; set; }


        public Employee(int id, string Employee_Name)
        {
            this.ID = id;
            this.Employee_Name = Employee_Name;
        }
    }
}
