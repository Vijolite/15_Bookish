using Bookish.Repositories;
using Bookish.Models;
using Bookish.Models.Request;
using Bookish.Models.Database;

namespace Bookish.Services
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book CreateBook(CreateBookRequest createBookRequest);
    }

    public class BookService : IBookService
    {
        private IBookRepo _books;
        private IAuthorRepo _authors;

         public BookService(IBookRepo books, IAuthorRepo authors)
        {
            _books = books;
            _authors = authors;
        }

        public List<Book> GetAllBooks()
        {
            var allDbBooks = _books.GetAllBooks();

            List<Book> result = new List<Book>();

            foreach (var dbBook in allDbBooks)
            {
                result.Add(new Book(dbBook));
            }

            return result;
        }

        public Book CreateBook(CreateBookRequest createBookRequest)
        {
            // var insertedAuthors = new List<AuthorDbModel>();

            // if (createBookRequest.AuthorNames != null)
            // {
            //     foreach (var authorName in createBookRequest.AuthorNames)
            //     {
            //         insertedAuthors.Add(
            //             new AuthorDbModel
            //             {
            //                 Name = authorName,
            //             }
            //         );
            //     }
            // }

            // var insertedBook = _books.CreateBook(
            //     new BookDbModel
            //     {
            //         Isbn = createBookRequest.Isbn,
            //         Title = createBookRequest.Title,
            //         CoverPhotoUrl = createBookRequest.CoverPhotoUrl,
            //         Blurb = createBookRequest.Blurb,
            //         Authors = insertedAuthors,
            //     }
            // );

            var insertedBook = _books.CreateBook(createBookRequest);

            return new Book(insertedBook);
        }
    }
}