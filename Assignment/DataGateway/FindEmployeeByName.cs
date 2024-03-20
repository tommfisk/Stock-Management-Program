using DataGateway;
using Library;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataGateway
{
    // Single Responsibility Principle
    // Liskov Substitution Principle
    public class FindEmployeeByName : OracleDatabaseSelector<Employee>
    {

        private string employeeName;

        public FindEmployeeByName(string employeeName)
        {
            this.employeeName = employeeName;
        }

        protected override string GetSQL()
        {
            return
                "SELECT ID, Employee_Name " +
                "FROM Employee " +
                "WHERE Employee_Name = :EmployeeName";
        }

        protected override Employee DoSelect(OracleCommand command)
        {
            Employee employee = null;

            try
            {
                command.Prepare();
                command.Parameters.Add(":EmployeeName", employeeName);
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
