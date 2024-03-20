
using System;

namespace Library
{
    // Builder Design Pattern
    public class TransactionBuilder
    {
        private int ID;
        private string Type;
        private int Item_ID;
        private int Employee_ID;
        private int Quantity;
        private DateTime Date_Created;

        public TransactionBuilder()
        {
            this.ID = -1;
            this.Type = "Type not specified";
            this.Item_ID = -1;
            this.Employee_ID = -1;
            this.Quantity = -1;
            this.Date_Created = DateTime.Now;
        }

        public Transaction Build()
        {
            return new Transaction(ID, Type, Item_ID, Employee_ID, Quantity, Date_Created);
        }

        public TransactionBuilder WithID(int id)
        {
            this.ID = id;
            return this;
        }

        public TransactionBuilder WithType(string type)
        {
            this.Type = type;
            return this;
        }

        public TransactionBuilder WithItemId(int id)
        {
            this.Item_ID = id;
            return this;
        }

        public TransactionBuilder WithEmployeeId(int id)
        {
            this.Employee_ID = id;
            return this;
        }

        public TransactionBuilder WithQuantity(int quantity)
        {
            this.Quantity = quantity;
            return this;
        }

        public TransactionBuilder WithDateCreated(DateTime date)
        {
            this.Date_Created = date;
            return this;
        }
    }
}
