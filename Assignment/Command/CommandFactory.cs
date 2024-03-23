namespace Assignment.Command
{
    // Factory design pattern
    public class CommandFactory
    {
        public CommandFactory()
        {
        }

        public ICommand Create(int commandCode)
        {
            switch (commandCode)
            {
                case ICommand.ADD_ITEM_TO_STOCK:
                    return new AddItemToStockCommand();
                case ICommand.ADD_QUANTITY_TO_ITEM:
                    return new AddQuantityToItemCommand();
                case ICommand.TAKE_QUANTITY_FROM_ITEM:
                    return new TakeQuantityFromItemCommand();
                case ICommand.VIEW_INVENTORY_REPORT:
                    return new ViewInventoryReportCommand();
                case ICommand.VIEW_FINANCIAL_REPORT:
                    return new ViewFinancialReportCommand();
                case ICommand.VIEW_TRANSACTION_LOG:
                    return new ViewTransactionLogCommand();
                case ICommand.VIEW_PERSONAL_USAGE_REPORT:
                    return new ViewPersonalUsageCommand();
                default:
                    return new NullCommand();
            }
        }
    }
}
