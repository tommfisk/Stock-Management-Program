using Entities;

namespace DTOs
{
    public class LoanConverter : Converter<LoanDTO, Loan>
    {
        public Loan ConvertDtoToEntity(LoanDTO loanDTO)
        {
            if (loanDTO == null)
            {
                return null;
            }

            return
                new LoanBuilder()
                    .WithID(loanDTO.ID)
                    .WithMember(new MemberConverter().ConvertDtoToEntity(loanDTO.Member))
                    .WithBook(new BookConverter().ConvertDtoToEntity(loanDTO.Book))
                    .WithLoanDate(loanDTO.LoanDate)
                    .WithNumberOfRenewals(loanDTO.NumberOfRenewals)
                    .WithDueDate(loanDTO.DueDate)
                    .WithReturnDate(loanDTO.ReturnDate)
                    .Build();
        }

        public LoanDTO ConvertEntityToDto(Loan loan)
        {
            if (loan == null)
            {
                return null;
            }

            return
                new LoanDTO_Builder()
                    .WithID(loan.ID)
                    .WithMember(new MemberConverter().ConvertEntityToDto(loan.Member))
                    .WithBook(new BookConverter().ConvertEntityToDto(loan.Book))
                    .WithLoanDate(loan.LoanDate)
                    .WithDueDate(loan.DueDate)
                    .WithReturnDate(loan.ReturnDate)
                    .WithNumberOfRenewals(loan.NumberOfRenewals)
                    .Build();
        }
    }
}
