using System;
using System.Transactions;

namespace Library
{
    [Serializable]
    public class Item
    {
        public int ID { get; }
        public string Item_Name { get; }
        public int Quantity { get; }
        public double Price { get; }
        public DateTime Date_Created { get; }

        public Item(int id, string item_name, int quantity, double price, DateTime date_created)
        {
            this.ID = id;
            this.Item_Name = item_name;
            this.Quantity = quantity;
            this.Price = price;
            this.Date_Created = date_created;
        }
    }
}
