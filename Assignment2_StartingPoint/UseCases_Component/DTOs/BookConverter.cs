using Entities;

namespace DTOs
{
    public class BookConverter : Converter<BookDTO, Book>
    {
        public Book ConvertDtoToEntity(BookDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return
                new BookBuilder()
                    .WithId(dto.Id)
                    .WithTitle(dto.Title)
                    .WithAuthor(dto.Author)
                    .WithISBN(dto.ISBN)
                    .WithState(dto.State)
                .Build();
        }

        public BookDTO ConvertEntityToDto(Book entity)
        {
            if (entity == null)
            {
                return null;
            }

            return
                new BookDTO_Builder()
                    .WithAuthor(entity.Author)
                    .WithId(entity.ID)
                    .WithISBN(entity.ISBN)
                    .WithState(entity.State)
                    .WithTitle(entity.Title)
                .Build();
        }
    }
}
