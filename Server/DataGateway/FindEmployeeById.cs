using DataGateway;
using Library;
using Oracle.ManagedDataAccess.Client;

namespace Assignment.DataGateway
{
    // Single Responsibility Principle
    // Liskov Substitution Principle
    public class FindEmployeeById : OracleDatabaseSelector<Employee>
    {

        private int employeeId;

        public FindEmployeeById(int employeeId)
        {
            this.employeeId = employeeId;
        }

        protected override string GetSQL()
        {
            return
                "SELECT ID, Employee_Name " +
                "FROM Employee " +
                "WHERE ID = :EmployeeId";
        }

        protected override Employee DoSelect(OracleCommand command)
        {
            Employee employee = null;

            try
            {
                command.Prepare();
                command.Parameters.Add(":EmployeeId", employeeId);
                OracleDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    employee = new Employee(dr.GetInt32(0), dr.GetString(1));
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of employee failed", e);
            }

            return employee;
        }
    }
}
