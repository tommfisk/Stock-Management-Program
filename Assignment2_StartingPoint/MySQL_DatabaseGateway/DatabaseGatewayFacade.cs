using Entities;
using System.Collections.Generic;
using UseCase;

namespace DatabaseGateway
{

    // This class illustrates the Liskov Substitution Principle
    // This class illustrates the Dependency Inversion Principle
    public class DatabaseGatewayFacade : IDatabaseGatewayFacade
    {

        public DatabaseGatewayFacade()
        {

        }

        public int AddBook(Book b)
        {
            return new DatabaseOperationFactoryForBooks()
                .CreateInserter()
                .Insert(b);
        }

        public int AddMember(Member m)
        {
            return new DatabaseOperationFactoryForMembers()
                .CreateInserter()
                .Insert(m);
        }

        public int CreateLoan(Loan loan)
        {
            return new DatabaseOperationFactoryForLoans()
                .CreateInserter()
                .Insert(loan);
        }

        public int EndLoan(int memberId, int bookId)
        {
            Loan loanToUpdate = FindLoan(memberId, bookId);

            if (loanToUpdate == null)
            {
                throw new Exception("ERROR: loan not found");
            }

            return new DatabaseOperationFactoryForLoans()
                .CreateUpdater(DatabaseOperationFactoryForLoans.UPDATE_LOAN_RETURN_DATE)
                .Update(loanToUpdate);
        }

        public Book FindBook(int bookId)
        {
            return new DatabaseOperationFactoryForBooks()
                .CreateSelector(DatabaseOperationFactoryForBooks.SELECT_BY_ID, bookId)
                .Select();
        }

        public Loan FindLoan(int memberId, int bookId)
        {
            return new DatabaseOperationFactoryForLoans()
                .CreateSelector(DatabaseOperationFactoryForLoans.SELECT_BY_BOOK_ID_AND_MEMBER_ID, bookId, memberId)
                .Select();
        }

        public Member FindMember(int memberId)
        {
            return new DatabaseOperationFactoryForMembers()
                .CreateSelector(DatabaseOperationFactoryForMembers.SELECT_BY_ID, memberId)
                .Select();
        }

        public List<Book> GetAllBooks()
        {
            return new DatabaseOperationFactoryForBooks()
                .CreateSelector(DatabaseOperationFactoryForBooks.SELECT_ALL)
                .Select();
        }

        public List<Member> GetAllMembers()
        {
            return new DatabaseOperationFactoryForMembers()
                .CreateSelector(DatabaseOperationFactoryForMembers.SELECT_ALL)
                .Select();
        }

        public List<Loan> GetCurrentLoans()
        {
            return new DatabaseOperationFactoryForLoans()
                .CreateSelector(DatabaseOperationFactoryForLoans.SELECT_ALL_CURRENT_LOANS)
                .Select();
        }

        public void InitialiseDatabase()
        {
            new DatabaseInitialiser().Initialise();
        }

        public int RenewLoan(Loan loan)
        {
            return new DatabaseOperationFactoryForLoans()
                .CreateUpdater(DatabaseOperationFactoryForLoans.UPDATE_LOAN_RENEWAL)
                .Update(loan);
        }
    }
}
