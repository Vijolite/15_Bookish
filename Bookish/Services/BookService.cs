// using Bookish.Repositories;
// using Bookish.Models;

// namespace Bookish.Services
// {
//     public class BookService
//     {
//         private BookRepo _books = new BookRepo();
//         //private AuthorRepo _authors = new AuthorRepo();

//         public List<Book> GetAllBooks()
//         {
//             var dbBooks = _books.GetAllBooks();
//             //var dbAuthors = _authors.GetAllAuthors();

//             List<Book> result = new List<Book>();

//             // foreach(var dbBook in dbBooks)
//             // {
//             //     var dbAuthor = dbAuthors.Find(a => a.Id == dbBook.AuthorId);

//             //     if (dbAuthor == null)
//             //     {
//             //         throw new NullReferenceException("Could not find author");
//             //     }

//             //     result.Add(new Book
//             //     {
//             //         Isbn = dbBook.Isbn,
//             //         Title = dbBook.Title,
//             //         CoverPhotoUrl = dbBook.CoverPhotoUrl,
//             //         Blurb = dbBook.Blurb,
//             //         Author = new Author
//             //         {
//             //             Name = dbAuthor.Name
//             //         }
//             //     });
//             // }

//             foreach (var dbBook in dbBooks)
//             {
//                 result.Add(new Book
//                 {
//                     Isbn = dbBook.Isbn,
//                     Title = dbBook.Title,
//                     Blurb = dbBook.Blurb,
//                     CoverPhotoUrl = dbBook.CoverPhotoUrl,
//                     Authors = dbBook
//                         .Authors
//                         .Select(a => new Author
//                             {
//                                 Name = a.Name,
//                                 AuthorPhotoUrl = a.AuthorPhotoUrl
//                             })
//                         .ToList(),
//                 });
//             }

//             return result;
//         }
//     }
// }

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
                // result.Add(new Book
                // {
                //     Isbn = dbBook.Isbn,
                //     Title = dbBook.Title,
                //     Blurb = dbBook.Blurb,
                //     CoverPhotoUrl = dbBook.CoverPhotoUrl,
                //     Authors = dbBook
                //         .Authors
                //         .Select(a => new Author
                //             {
                //                 Name = a.Name,
                //                 AuthorPhotoUrl = a.AuthorPhotoUrl
                //             })
                //         .ToList(),
                // });
                result.Add(new Book(dbBook));
            }

            return result;
        }

        public Book CreateBook(CreateBookRequest createBookRequest)
        {
            var insertedAuthors = new List<AuthorDbModel>();

            if (createBookRequest.AuthorNames != null)
            {
                foreach (var authorName in createBookRequest.AuthorNames)
                {
                    insertedAuthors.Add(
                        new AuthorDbModel
                        {
                            Name = authorName,
                        }
                    );
                }
            }

            var insertedBook = _books.CreateBook(
                new BookDbModel
                {
                    Isbn = createBookRequest.Isbn,
                    Title = createBookRequest.Title,
                    CoverPhotoUrl = createBookRequest.CoverPhotoUrl,
                    Blurb = createBookRequest.Blurb,
                    Authors = insertedAuthors,
                }
            );

            return new Book(insertedBook);
        }
    }
}