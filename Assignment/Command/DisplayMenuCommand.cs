using menu;
using System;
using System.Windows.Input;

namespace Assignment.Command
{
    public class DisplayMenuCommand : ICommand
    {

        private Menu menu;

        public DisplayMenuCommand()
        {
            menu = CreateMenu();
        }

        private Menu CreateMenu()
        {
            Menu menu = new Menu("Menu");

            menu.Add(CreateStockMenu());
            menu.Add(CreateViewMenu());
            menu.Add(CreateAppMenu());

            return menu;
        }

        private Menu CreateAppMenu()
        {
            Menu menu = new Menu("App menu");
            menu.Add(new MenuItem(ICommand.EXIT, "Exit"));
            return menu;
        }

        private Menu CreateStockMenu()
        {
            Menu menu = new Menu("Stock menu");
            menu.Add(new MenuItem(ICommand.ADD_ITEM_TO_STOCK, "Add item to stock"));
            menu.Add(new MenuItem(ICommand.ADD_QUANTITY_TO_ITEM, "Add quantity to item"));
            menu.Add(new MenuItem(ICommand.TAKE_QUANTITY_FROM_ITEM, "Take quantity from item"));
            return menu;
        }

        private Menu CreateViewMenu()
        {
            Menu menu = new Menu("View menu");
            menu.Add(new MenuItem(ICommand.VIEW_INVENTORY_REPORT, "View inventory report"));
            menu.Add(new MenuItem(ICommand.VIEW_FINANCIAL_REPORT, "View financial report"));
            menu.Add(new MenuItem(ICommand.VIEW_TRANSACTION_LOG, "View transaction log"));
            menu.Add(new MenuItem(ICommand.VIEW_PERSONAL_USAGE_REPORT, "View personal usage report"));
            return menu;
        }


        public void Execute()
        {
            menu.Print("");
        }
    }
}
