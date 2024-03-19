using DTOs;
using Entities;

namespace UseCase
{
    public class ViewCurrentLoans_UseCase : AbstractUseCase
    {

        public ViewCurrentLoans_UseCase(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override IDto Execute()
        {
            List<LoanDTO> loans = new List<LoanDTO>();
            LoanConverter converter = new LoanConverter();

            foreach (Loan loan in gatewayFacade.GetCurrentLoans())
            {
                loans.Add(converter.ConvertEntityToDto(loan));
            }

            return new LoanDTO_List(loans);
        }
    }
}
