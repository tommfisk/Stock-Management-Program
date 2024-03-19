namespace DTOs
{
    [Serializable]
    public class BookDTO : IDto
    {
        public int Id { get; }
        public string Author { get; }
        public string ISBN { get; }
        public string Title { get; }
        public string State { get; }

        public BookDTO(int id, string author, string isbn, string title, string state)
        {
            this.Id = id;
            this.Author = author;
            this.ISBN = isbn;
            this.Title = title;
            this.State = state;
        }
    }
}
