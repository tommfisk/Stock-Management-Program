using Newtonsoft.Json;
namespace DTO
{
    public class ItemDTO
    {
        [JsonProperty("ID")]
        public int ID { get; }

        [JsonProperty("Item_Name")]
        public string Item_Name { get; }

        [JsonProperty("Quantity")]
        public int Quantity { get; }

        [JsonProperty("Price")]
        public double Price { get; }

        [JsonProperty("Date_Created")]
        public DateTime Date_Created { get; }

        [JsonConstructor]
        public ItemDTO(int id, string item_name, int quantity, double price, DateTime date_created)
        {
            this.ID = id;
            this.Item_Name = item_name;
            this.Quantity = quantity;
            this.Price = price;
            this.Date_Created = date_created;
        }
    }
}

