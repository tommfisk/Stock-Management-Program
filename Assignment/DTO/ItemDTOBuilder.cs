
using DTO;
using System;

namespace DTO
{
    // Builder Design Pattern
    public class ItemDTOBuilder
    {
        public int ID;
        public string Item_Name;
        public int Quantity;
        public double Price;
        public DateTime Date_Created;

        public ItemDTOBuilder()
        {
            this.ID = -1;
            this.Item_Name = "Name not specified";
            this.Quantity = -1;
            this.Price = -1;
            this.Date_Created = DateTime.Now;
        }

        public ItemDTO Build()
        {
            return new ItemDTO(ID, Item_Name, Quantity, Price, Date_Created);
        }

        public ItemDTOBuilder WithID(int id)
        {
            this.ID = id;
            return this;
        }

        public ItemDTOBuilder WithName(string name)
        {
            this.Item_Name = name;
            return this;
        }

        public ItemDTOBuilder WithQuantity(int quantity)
        {
            this.Quantity= quantity;
            return this;
        }

        public ItemDTOBuilder WithPrice(double price)
        {
            this.Price = price;
            return this;
        }

        public ItemDTOBuilder WithDate(DateTime DateTime)
        {
            this.Date_Created = DateTime;
            return this;
        }
    }
}
