using DataGateway;
using Library;
using Oracle.ManagedDataAccess.Client;

namespace Assignment.DataGateway
{
    // Single Responsibility Principle
    // Liskov Substitution Principle
    public class GetAllEmployees : OracleDatabaseSelector<List<Employee>>
    {

        public GetAllEmployees()
        {
        }

        protected override string GetSQL()
        {
            return
                "SELECT ID, Employee_Name " +
                "FROM Employee " +
                "ORDER BY ID";
        }

        protected override List<Employee> DoSelect(OracleCommand command)
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = null;

            try
            {
                OracleDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    employee = new Employee(dr.GetInt32(0), dr.GetString(1));
                    employees.Add(employee);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of employees failed", e);
            }

            return employees;
        }
    }
}
