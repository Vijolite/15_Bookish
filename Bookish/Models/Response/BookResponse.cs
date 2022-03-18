using Bookish.Models.Database;

namespace Bookish.Models.Response
{
    public class BookResponse
    {
        private readonly Book _book;

        public BookResponse(Book book)
        {
            _book = book;
        }

        public string Isbn => _book.Isbn;
        public string Title => _book.Title;

    }
}