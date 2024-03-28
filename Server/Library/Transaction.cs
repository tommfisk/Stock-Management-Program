using System;

namespace Library
{
    [Serializable]
    public class Transaction
    {
        public int ID { get; }
        public string Type { get; }
        public int Item_ID { get; }
        public int Employee_ID { get; }
        public int Quantity { get; }
        public DateTime Date_Created { get; }


        public Transaction(int id, string Type, int Item_ID, int Employee_ID, int Quantity, DateTime Date_Created)
        {
            this.ID = id;
            this.Type = Type;
            this.Item_ID = Item_ID;
            this.Employee_ID = Employee_ID;
            this.Quantity = Quantity;
            this.Date_Created = Date_Created;
        }
    }
}
