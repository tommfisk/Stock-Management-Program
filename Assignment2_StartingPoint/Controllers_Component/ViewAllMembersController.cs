using DatabaseGateway;
using DTOs;
using UseCase;

namespace Controllers
{
    public class ViewAllMembersController : AbstractController
    {

        public ViewAllMembersController(
            AbstractPresenter presenter) : base(presenter)
        {
        }

        public override IDto ExecuteUseCase()
        {
            return new ViewAllMembers_UseCase(new DatabaseGatewayFacade()).Execute();
        }
    }
}
