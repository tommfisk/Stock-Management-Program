namespace DTO
{
    // Builder Design Pattern
    public class RequestDTOBuilder
    {
        public int command;
        public int employee_id;
        public ItemDTO? item;

        public RequestDTOBuilder()
        {
            this.command = -1;
            this.employee_id = -1;
            this.item = null;
        }

        public RequestDTO Build()
        {
            return new RequestDTO(command, employee_id, item);
        }

        public RequestDTOBuilder WithCommand(int command)
        {
            this.command = command;
            return this;
        }

        public RequestDTOBuilder WithEmployeeId(int employee_id)
        {
            this.employee_id = employee_id;
            return this;
        }

        public RequestDTOBuilder WithItem(ItemDTO item)
        {
            this.item = item;
            return this;
        }


    }
}


