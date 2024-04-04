using Newtonsoft.Json;

namespace DTO
{
    public class RequestDTO
    {
        [JsonProperty("command")]
        public int command { get; }

        [JsonProperty("employee_id")]
        public int employee_id { get; }

        [JsonProperty("item")]
        public ItemDTO item { get; }

        [JsonConstructor]
        public RequestDTO(int command, int employee_id, ItemDTO item)
        {
            this.command = command;
            this.employee_id = employee_id;
            this.item = item;
        }
    }
}

