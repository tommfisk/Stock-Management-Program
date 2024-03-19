using DTOs;
using Entities;

namespace UseCase
{
    public class ViewAllMembers_UseCase : AbstractUseCase
    {

        public ViewAllMembers_UseCase(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override IDto Execute()
        {
            List<MemberDTO> members = new List<MemberDTO>();
            MemberConverter converter= new MemberConverter();

            foreach (Member m in gatewayFacade.GetAllMembers())
            {
                members.Add(converter.ConvertEntityToDto(m));
            }

            return new MemberDTO_List( members);
        }

    }
}
