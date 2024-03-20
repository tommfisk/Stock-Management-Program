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
    public class InsertEmployee : OracleDatabaseInserter<Employee>
    {

        public InsertEmployee(Employee employeeToInsert) : base(employeeToInsert)
        {
        }

        protected override string GetSQL()
        {
            return
                "INSERT INTO Employee (ID, Employee_Name) " +
                "VALUES (Employee_Seq.nextval, :employee_name)";
        }

        protected override int DoInsert(OracleCommand command, Employee employeeToInsert)
        {
            command.Prepare();
            command.Parameters.Add(":employee_name", employeeToInsert.Employee_Name);
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: employee not inserted");
            }

            return numRowsAffected;
        }
    }
}
