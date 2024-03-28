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
    public class AddQuantityToItem : OracleDatabaseUpdater<Item>
    {
        private int id;
        private int quantity;

        public AddQuantityToItem(Item item)
        {
            this.id = item.ID;
            this.quantity = item.Quantity;
        }

        protected override string GetSQL()
        {
            return
                "UPDATE Item " +
                "SET Quantity = Quantity + :QuantityToAdd " +
                "WHERE Id = :ItemId";
        }

        protected override int DoUpdate(OracleCommand command)
        {
            int numRowsAffected = 0;

            try
            {
                command.Prepare();
                command.Parameters.Add(":QuantityToAdd", quantity);
                command.Parameters.Add(":ItemId", id);
                numRowsAffected = command.ExecuteNonQuery();

                if (numRowsAffected != 1)
                {
                    throw new Exception("ERROR: quantity not added");
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

