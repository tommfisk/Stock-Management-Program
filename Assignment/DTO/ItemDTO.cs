using System;
using System.Transactions;

namespace DTO
{
    // DTO Design Pattern
    [Serializable]
    public class ItemDTO
    {
        public int ID { get; }
        public string Item_Name { get; }
        public int Quantity { get; }
        public double Price { get; }
        public DateTime Date_Created { get; }

        public ItemDTO(int id, string item_name, int quantity, double price, DateTime date_created)
        {
            this.ID = id;
            this.Item_Name = item_name;
            this.Quantity = quantity;
            this.Price = price;
            this.Date_Created = date_created;
        }
        public ItemDTO(int id, string item_name, int quantity, double price)
        {
            this.ID = id;
            this.Item_Name = item_name;
            this.Quantity = quantity;
            this.Price = price;
        }

        public ItemDTO(string item_name, int quantity, double price)
        {
            this.Item_Name = item_name;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
