using Library;
using System;

namespace DTO
{
    // DTO Design Pattern
    [Serializable]
    public class TransactionDTO
    {
        public int ID { get; }
        public string Type { get; set; }
        public int Item_ID { get; }
        public int Employee_ID { get; }
        public int Quantity { get; }
        public DateTime Date_Created { get; }


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
