using DTOs;
using Entities;

namespace UseCase
{
    // This class is a use case interactor in the Clean Architecture model
    public class ViewAllBooks_UseCase : AbstractUseCase
    {

        public ViewAllBooks_UseCase(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override IDto Execute()
        {
            List<BookDTO> books = new List<BookDTO>();
            BookConverter converter = new BookConverter();

            foreach (Book b in gatewayFacade.GetAllBooks())
            {
                books.Add(converter.ConvertEntityToDto(b));
            }

            return new BookDTO_List(books);
        }
    }
}
