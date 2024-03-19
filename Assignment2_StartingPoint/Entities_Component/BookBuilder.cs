using Entities.State;

namespace Entities
{
    public class BookBuilder
    {
        private int id;
        private string author;
        private string isbn;
        private string title;
        private BookState state;

        public BookBuilder()
        {
            this.id = -1;
            this.author = "";
            this.isbn = "";
            this.title = "";
            this.state = null;
        }

        public Book Build()
        {
            return new Book(id, author, title, isbn, state);
        }

        public BookBuilder WithAuthor(string author)
        {
            this.author = author;
            return this;
        }

        public BookBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }

        public BookBuilder WithISBN(string isbn)
        {
            this.isbn = isbn;
            return this;
        }

        public BookBuilder WithState(int numRenewals)
        {
            this.state = BookStateFactory.Create(numRenewals);
            return this;
        }

        public BookBuilder WithState(string state)
        {
            this.state = BookStateFactory.Create(state);
            return this;
        }

        public BookBuilder WithTitle(string title)
        {
            this.title = title;
            return this;
        }
    }
}
