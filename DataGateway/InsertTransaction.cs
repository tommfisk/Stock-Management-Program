using DataGateway;
using Library;
using Oracle.ManagedDataAccess.Client;
using System;

namespace Assignment.DataGateway
{
    // Single Responsibility Principle
    // Liskov Substitution Principle
    public class InsertTransaction : OracleDatabaseInserter<Transaction>
    {

        public InsertTransaction(Transaction transactionToInsert) : base(transactionToInsert)
        {
        }

        protected override string GetSQL()
        {
            return
                "INSERT INTO Transaction (ID, Type, Item_ID, Employee_ID, Quantity, Date_Created) " +
                "VALUES (Transaction_Seq.nextval, :type, :item_id, :employee_id, :quantity, :date_created )";
        }

        protected override int DoInsert(OracleCommand command, Transaction transactionToInsert)
        {
            command.Prepare();
            command.Parameters.Add(":type", transactionToInsert.Type);
            command.Parameters.Add(":item_id", transactionToInsert.Item_ID);
            command.Parameters.Add(":employee_id", transactionToInsert.Employee_ID);
            command.Parameters.Add(":quantity", transactionToInsert.Quantity);
            command.Parameters.Add(":date_created", DateTime.Now);
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: transaction not inserted");
            }

            return numRowsAffected;
        }
    }
}
