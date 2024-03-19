namespace CommandLineUI.Commands
{
    class CommandFactory
    {

        public CommandFactory()
        {
        }

        public Command CreateCommand(int menuChoice)
        {
            switch (menuChoice)
            {
                case RequestUseCase.BORROW_BOOK:
                    return new BorrowBookCommand();

                case RequestUseCase.INITIALISE_DATABASE:
                    return new InitialiseDatabaseCommand();

                case RequestUseCase.RENEW_LOAN:
                    return new RenewLoanCommand();

                case RequestUseCase.RETURN_BOOK:
                    return new ReturnBookCommand();

                case RequestUseCase.VIEW_ALL_BOOKS:
                    return new ViewAllBooksCommand();

                case RequestUseCase.VIEW_ALL_MEMBERS:
                    return new ViewAllMembersCommand();

                case RequestUseCase.VIEW_CURRENT_LOANS:
                    return new ViewCurrentLoansCommand();

                default:
                    return new NullCommand();
            }
        }
    }
}
