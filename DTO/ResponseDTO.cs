using Newtonsoft.Json;

namespace DTO
{
    public class ResponseDTO
    {
        [JsonProperty("command")]
        public int command { get; }

        [JsonProperty("numRowsAffected")]
        public int numRowsAffected { get; }

        [JsonProperty("employees")]
        public List<EmployeeDTO> employees { get; }

        [JsonProperty("items")]
        public List<ItemDTO> items { get; }

        [JsonProperty("transactions")]
        public List<TransactionDTO> transactions { get; }

        [JsonConstructor]
        public ResponseDTO(int command, int numRowsAffected, List<EmployeeDTO> employees, List<ItemDTO> items, List<TransactionDTO> transactions)
        {
            this.command = command;
            this.numRowsAffected = numRowsAffected;
            this.employees = employees;
            this.items = items;
            this.transactions = transactions;
        }
    }
}
