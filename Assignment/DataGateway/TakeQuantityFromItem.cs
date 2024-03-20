using DataGateway;
using Library;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataGateway
{
    // Single Responsibility Principle
    // Liskov Substitution Principle
    public class TakeQuantityFromItem : OracleDatabaseUpdater<Item>
    {

        private int id;
        private int quantity;

        public TakeQuantityFromItem(int id, int quantity)
        {
            this.id = id;
            this.quantity = quantity;
        }

        protected override string GetSQL()
        {
            return
                "UPDATE Item " +
                "SET Quantity = Quantity - :QuantityToTake " +
                "WHERE Id = :ItemId";
        }

        protected override int DoUpdate(OracleCommand command)
        {
            int numRowsAffected = 0;

            try
            {
                command.Prepare();
                command.Parameters.Add(":QuantityToTake", quantity);
                command.Parameters.Add(":ItemId", id);
                numRowsAffected = command.ExecuteNonQuery();

                if (numRowsAffected != 1)
                {
                    throw new Exception("ERROR: quantity not taken");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            return numRowsAffected;
        }
    }
}
