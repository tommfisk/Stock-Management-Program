namespace CommandLineUI
{
    interface RequestUseCase
    {

        public const int INITIALISE_DATABASE = 0;
        public const int BORROW_BOOK = 1;
        public const int RETURN_BOOK = 2;
        public const int RENEW_LOAN = 3;
        public const int VIEW_ALL_BOOKS = 4;
        public const int VIEW_ALL_MEMBERS = 5;
        public const int VIEW_CURRENT_LOANS = 6;
        public const int EXIT = 7;

    }
}
