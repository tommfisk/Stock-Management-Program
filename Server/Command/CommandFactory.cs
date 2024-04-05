using DTO;

namespace Server.Command
{
    // Factory design pattern
    public class CommandFactory
    {
        public CommandFactory()
        {
        }

        public ICommand Create(RequestDTO request, StreamWriter writer)
        {
            return request.command switch
            {
                ICommand.ADD_ITEM_TO_STOCK => new AddItemToStockCommand(request, writer),
                ICommand.ADD_QUANTITY_TO_ITEM => new AddQuantityToItemCommand(request, writer),
                ICommand.TAKE_QUANTITY_FROM_ITEM => new TakeQuantityFromItemCommand(request, writer),
                ICommand.VIEW_INVENTORY_REPORT => new ViewInventoryReportCommand(request, writer),
                ICommand.VIEW_FINANCIAL_REPORT => new ViewFinancialReportCommand(request, writer),
                ICommand.VIEW_TRANSACTION_LOG => new ViewTransactionLogCommand(request, writer),
                ICommand.VIEW_PERSONAL_USAGE_REPORT => new ViewPersonalUsageCommand(request, writer),
                ICommand.VIEW_ALL_EMPLOYEES => new ViewAllEmployeesCommand(request, writer),
                _ => new NullCommand(),
            };
        }
    }
}
