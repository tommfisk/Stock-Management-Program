using DTO;

namespace Assignment.Command
{
    // Factory design pattern
    public class CommandFactory
    {
        public CommandFactory()
        {
        }

        public ICommand Create(RequestDTO request)
        {
            return request.command switch
            {
                ICommand.ADD_ITEM_TO_STOCK => new AddItemToStockCommand(request),
                ICommand.ADD_QUANTITY_TO_ITEM => new AddQuantityToItemCommand(),
                ICommand.TAKE_QUANTITY_FROM_ITEM => new TakeQuantityFromItemCommand(),
                ICommand.VIEW_INVENTORY_REPORT => new ViewInventoryReportCommand(),
                ICommand.VIEW_FINANCIAL_REPORT => new ViewFinancialReportCommand(),
                ICommand.VIEW_TRANSACTION_LOG => new ViewTransactionLogCommand(),
                ICommand.VIEW_PERSONAL_USAGE_REPORT => new ViewPersonalUsageCommand(),
                _ => new NullCommand(),
            };
        }
    }
}
