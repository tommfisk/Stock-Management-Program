namespace CommandLineUI.Menu
{
    class MenuFactory
    {
        public static MenuFactory INSTANCE { get; } = new MenuFactory();

        private Menu menu;

        private MenuFactory()
        {
            menu = CreateMenu();
        }

        public MenuElement Create()
        {
            return menu;
        }

        private Menu CreateMenu()
        {
            Menu menu = new Menu("Library menu");

            menu.Add(CreateLoanMenu());
            menu.Add(CreateViewMenu());
            menu.Add(CreateAppMenu());

            return menu;
        }

        private Menu CreateAppMenu()
        {
            Menu menu = new Menu("App menu");
            menu.Add(new MenuItem(RequestUseCase.EXIT, "Exit"));
            return menu;
        }

        private Menu CreateLoanMenu()
        {
            Menu menu = new Menu("Loan menu");
            menu.Add(new MenuItem(RequestUseCase.BORROW_BOOK, "Borrow book"));
            menu.Add(new MenuItem(RequestUseCase.RETURN_BOOK, "Return book"));
            menu.Add(new MenuItem(RequestUseCase.RENEW_LOAN, "Renew loan"));
            return menu;
        }

        private Menu CreateViewMenu()
        {
            Menu menu = new Menu("View menu");
            menu.Add(new MenuItem(RequestUseCase.VIEW_ALL_BOOKS, "View all books"));
            menu.Add(new MenuItem(RequestUseCase.VIEW_ALL_MEMBERS, "View all members"));
            menu.Add(new MenuItem(RequestUseCase.VIEW_CURRENT_LOANS, "View current loans"));
            return menu;
        }
    }
}
