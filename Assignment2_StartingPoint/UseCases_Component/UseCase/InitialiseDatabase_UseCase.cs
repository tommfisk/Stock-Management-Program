using DTOs;
using Entities;

namespace UseCase
{
    public class InitialiseDatabase_UseCase : AbstractUseCase
    {

        public InitialiseDatabase_UseCase(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override IDto Execute()
        {
            gatewayFacade.InitialiseDatabase();

            gatewayFacade.AddMember(
                new MemberBuilder()
                    .WithId(1)
                    .WithName("Graham")
                    .Build());

            gatewayFacade.AddMember(
                new MemberBuilder()
                    .WithId(2)
                    .WithName("Phil")
                    .Build());

            gatewayFacade.AddMember(
                new MemberBuilder()
                    .WithId(3)
                    .WithName("Fiona")
                    .Build());

            gatewayFacade.AddBook(
                new BookBuilder()
                    .WithId(1)
                    .WithAuthor("Author 1")
                    .WithTitle("Title 1")
                    .WithISBN("1234567890")
                    .WithState("Available")
                    .Build());

            gatewayFacade.AddBook(
                new BookBuilder()
                    .WithId(2)
                    .WithAuthor("Author 2")
                    .WithTitle("Title 2")
                    .WithISBN("2345678901")
                    .WithState("Available")
                    .Build());

            gatewayFacade.AddBook(
                new BookBuilder()
                    .WithId(3)
                    .WithAuthor("Author 3")
                    .WithTitle("Title 3")
                    .WithISBN("3456789012")
                    .WithState("Available")
                    .Build());

            gatewayFacade.AddBook(
                new BookBuilder()
                    .WithId(4)
                    .WithAuthor("Author 4")
                    .WithTitle("Title 4")
                    .WithISBN("4567890123")
                    .WithState("Available")
                    .Build());

            return new MessageDTO("The database has been initialised");
        }
    }
}
