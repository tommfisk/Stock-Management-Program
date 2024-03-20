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
    public class GetAllTransactions : OracleDatabaseSelector<List<Transaction>>
    {

        public GetAllTransactions()
        {
        }

        protected override string GetSQL()
        {
            return
                "SELECT ID, Type, Item_ID, Employee_ID, Quantity, Date_Created " +
                "FROM Transaction " +
                "ORDER BY ID";
        }

        protected override List<Transaction> DoSelect(OracleCommand command)
        {
            List<Transaction> transactions = new List<Transaction>();
            Transaction transaction = null;

            try
            {
                OracleDataReader dr = command.ExecuteReader();

                while (dr.Read())
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
                    transactions.Add(transaction);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of transactions failed", e);
            }

            return transactions;
        }
    }
}
