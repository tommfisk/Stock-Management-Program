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
    public class InsertItem : OracleDatabaseInserter<Item>
    {

        public InsertItem(Item itemToInsert) : base(itemToInsert)
        {
        }

        protected override string GetSQL()
        {
            return
                "INSERT INTO Item (ID, Item_Name, Quantity, Price, Date_Created) " +
                "VALUES (Item_Seq.nextval, :item_name, :quantity, :price, :date_created)";
        }

        protected override int DoInsert(OracleCommand command, Item itemToInsert)
        {
            command.Prepare();
            command.Parameters.Add(":item_name", itemToInsert.Item_Name);
            command.Parameters.Add(":quantity", itemToInsert.Quantity);
            command.Parameters.Add(":price", itemToInsert.Price);
            command.Parameters.Add(":date_created", DateTime.Now);
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: item not inserted");
            }

            return numRowsAffected;
        }
    }
}
