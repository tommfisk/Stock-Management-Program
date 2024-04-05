namespace DTO
{
    // Builder Design Pattern
    public class ResponseDTOBuilder
    {
        public int command;
        public int numRowsAffected;
        public List<EmployeeDTO> ?employees;
        public List<ItemDTO> ?items;
        public List<TransactionDTO>? transactions;

        public ResponseDTOBuilder()
        {
            this.command = -1;
            this.numRowsAffected = -1;
            this.employees = null;
            this.items = null;
            this.transactions = null;
        }

        public ResponseDTO Build()
        {
            return new ResponseDTO(command, numRowsAffected, employees, items, transactions);
        }

        public ResponseDTOBuilder WithCommand(int command)
        {
            this.command = command;
            return this;
        }

        public ResponseDTOBuilder WithNumRowsAffected(int numRowsAffected)
        {
            this.numRowsAffected = numRowsAffected;
            return this;
        }

        public ResponseDTOBuilder WithEmployees(List<EmployeeDTO> employees)
        {
            this.employees = employees;
            return this;
        }

        public ResponseDTOBuilder WithItems(List<ItemDTO> items)
        {
            this.items = items;
            return this;
        }

        public ResponseDTOBuilder WithTransactions(List<TransactionDTO> transactions)
        {
            this.transactions = transactions;
            return this;
        }
    }
}


