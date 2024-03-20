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
    public class FindTransaction : OracleDatabaseSelector<Transaction>
    {

        private int transactionId;

        public FindTransaction(int transactionId)
        {
            this.transactionId = transactionId;
        }

        protected override string GetSQL()
        {
            return
                "SELECT ID, Type, Item_ID, Employee_ID, Quantity, Date_Created " +
                "FROM Transaction " +
                "WHERE id = :TransactionId";
        }

        protected override Transaction DoSelect(OracleCommand command)
        {
            Transaction transaction = null;

            try
            {
                command.Prepare();
                command.Parameters.Add(":TransactionId", transactionId);
                OracleDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    transaction
                        = new TransactionBuilder()
                            .WithID(dr.GetInt32(0))
                            .WithType(dr.GetString(1))
                            .WithItemId(dr.GetInt32(2))
                            .WithEmployeeId(dr.GetInt32(3))
                            .WithQuantity(dr.GetInt32(4))
                            .WithDateCreated(dr.GetDateTime(5))
                        .Build();
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of transaction failed", e);
            }

            return transaction;
        }
    }
}
