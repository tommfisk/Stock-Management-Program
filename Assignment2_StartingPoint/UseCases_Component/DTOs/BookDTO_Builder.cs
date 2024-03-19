using Entities.State;

namespace DTOs
{
    public class BookDTO_Builder
    {
        private int id;
        private string author;
        private string isbn;
        private string title;
        private string state;

        public BookDTO Build()
        {
            return
                new BookDTO(id, author, isbn, title, state);
        }

        public BookDTO_Builder WithAuthor(string author)
        {
            this.author = author;
            return this;
        }

        public BookDTO_Builder WithId(int id)
        {
            this.id = id;
            return this;
        }

        public BookDTO_Builder WithISBN(string isbn)
        {
            this.isbn = isbn;
            return this;
        }

        public BookDTO_Builder WithState(int numRenewals)
        {
            this.state = BookStateFactory.Create(numRenewals).ToString();
            return this;
        }

        public BookDTO_Builder WithState(string state)
        {
            this.state = state;
            return this;
        }

        public BookDTO_Builder WithTitle(string title)
        {
            this.title = title;
            return this;
        }
    }
}
