using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Command
{
    // Command design pattern
    // Dependency Inversion Principle
    public interface ICommand
    {
        public const int ADD_ITEM_TO_STOCK = 1;
        public const int ADD_QUANTITY_TO_ITEM = 2;
        public const int TAKE_QUANTITY_FROM_ITEM = 3;
        public const int VIEW_INVENTORY_REPORT = 4;
        public const int VIEW_FINANCIAL_REPORT = 5;
        public const int VIEW_TRANSACTION_LOG = 6;
        public const int VIEW_PERSONAL_USAGE_REPORT = 7;

        public abstract void Execute();
    }
}
