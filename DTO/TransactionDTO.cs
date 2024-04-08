using Newtonsoft.Json;
using System;

namespace DTO
{
    // DTO Design Pattern
    public class TransactionDTO
    {
        [JsonProperty("ID")]
        public int ID { get; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Item_ID")]
        public int Item_ID { get; }

        [JsonProperty("Employee_ID")]
        public int Employee_ID { get; }

        [JsonProperty("Quantity")]
        public int Quantity { get; }

        [JsonProperty("Date_Created")]
        public DateTime Date_Created { get; }

        [JsonConstructor]
        public TransactionDTO(int ID, string Type, int Item_ID, int Employee_ID, int Quantity, DateTime Date_Created)
        {
            this.ID = ID;
            this.Type = Type;
            this.Item_ID = Item_ID;
            this.Employee_ID = Employee_ID;
            this.Quantity = Quantity;
            this.Date_Created = Date_Created;
        }

        public TransactionDTO(string Type, int Item_ID, int Employee_ID, int Quantity)
        {
            this.Type = Type;
            this.Item_ID = Item_ID;
            this.Employee_ID = Employee_ID;
            this.Quantity = Quantity;
        }
    }
}
