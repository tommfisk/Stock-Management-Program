﻿using DataGateway;
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
    public class FindItemByName : OracleDatabaseSelector<Item>
    {

        private string itemName;

        public FindItemByName(string itemName)
        {
            this.itemName = itemName;
        }

        protected override string GetSQL()
        {
            return
                "SELECT ID, Item_Name, Quantity, Price, Date_Created " +
                "FROM Item " +
                "WHERE Item_Name = :ItemName " + 
                "AND ROWNUM = 1";
        }

        protected override Item DoSelect(OracleCommand command)
        {
            Item item = null;

            try
            {
                command.Prepare();
                command.Parameters.Add(":ItemName", itemName);
                OracleDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    item = new Item(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetDouble(3), dr.GetDateTime(4));
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of item failed", e);
            }

            return item;
        }
    }
}