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
    public class GetAllItems : OracleDatabaseSelector<List<Item>>
    {

        public GetAllItems()
        {
        }

        protected override string GetSQL()
        {
            return
                "SELECT ID, Item_Name, Quantity, Price, Date_Created " +
                "FROM Item " + 
                "ORDER BY ID";
        }

        protected override List<Item> DoSelect(OracleCommand command)
        {
            List<Item> items = new List<Item>();
            Item item = null;

            try
            {
                OracleDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    item = new Item(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetDouble(3), dr.GetDateTime(4));
                    items.Add(item);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of items failed", e);
            }

            return items;
        }
    }
}
