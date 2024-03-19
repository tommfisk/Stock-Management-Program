using DTOs;
using System.Collections.Generic;
using UseCase;

namespace CommandLineUI.Presenters
{
    class AllBooksPresenter : AbstractPresenter
    {

        public override IViewData ViewData
        {
            get
            {
                List<BookDTO> books = ((BookDTO_List)DataToPresent).List;
                List<string> lines = new List<string>(books.Count + 2);
                lines.Add("\nAll books");
                lines.Add(string.Format("\t{0, -4} {1, -20} {2, -20} {3, -15} {4}", "ID", "Title", "Author", "ISBN", "Status"));

                books.ForEach(b => lines.Add(DisplayBook(b)));

                return new CommandLineViewData(lines);
            }
        }

        private string DisplayBook(BookDTO b)
        {
            return string.Format(
                "\t{0, -4} {1, -20} {2, -20} {3, -15} {4}",
                b.Id,
                b.Title,
                b.Author,
                b.ISBN,
                b.State);
        }
    }
}
