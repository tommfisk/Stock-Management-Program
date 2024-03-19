using Entities;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class DatabaseOperationFactoryForLoans
    {
        public const int SELECT_ALL_CURRENT_LOANS = 1;
        public const int SELECT_BY_BOOK_ID_AND_MEMBER_ID = 2;
        public const int UPDATE_LOAN_RENEWAL = 3;
        public const int UPDATE_LOAN_RETURN_DATE = 4;

        public DatabaseInserter<Loan> CreateInserter()
        {
            return new InsertLoan();
        }

        public ISelector<List<Loan>> CreateSelector(int typeOfSelection)
        {
            if (typeOfSelection == SELECT_ALL_CURRENT_LOANS)
            {
                return new GetAllCurrentLoans();
            }
            return new NullSelector<List<Loan>>();
        }

        public ISelector<Loan> CreateSelector(int typeOfSelection, int bookId, int memberId)
        {
            switch (typeOfSelection)
            {
                case SELECT_BY_BOOK_ID_AND_MEMBER_ID:
                    return new FindCurrentLoanById(bookId, memberId);
                default:
                    return new NullSelector<Loan>();
            }
        }

        public IUpdater<Loan> CreateUpdater(int typeOfUpdate)
        {
            switch (typeOfUpdate)
            {
                case UPDATE_LOAN_RENEWAL:
                    return new UpdateLoanRenewal();
                case UPDATE_LOAN_RETURN_DATE:
                    return new UpdateLoanReturnDate();
                default:
                    return new NullUpdater<Loan>();
            }
        }
    }
}
