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

namespace Bookish.Services
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
    }

    public class BookService : IBookService
    {
        private IBookRepo _books;

        public BookService(IBookRepo books)
        {
            _books = books;
        }

        public List<Book> GetAllBooks()
        {
            var allDbBooks = _books.GetAllBooks();

            List<Book> result = new List<Book>();

            foreach (var dbBook in allDbBooks)
            {
                result.Add(new Book
                {
                    Isbn = dbBook.Isbn,
                    Title = dbBook.Title,
                    Blurb = dbBook.Blurb,
                    CoverPhotoUrl = dbBook.CoverPhotoUrl,
                    Authors = dbBook
                        .Authors
                        .Select(a => new Author
                            {
                                Name = a.Name,
                                AuthorPhotoUrl = a.AuthorPhotoUrl
                            })
                        .ToList(),
                });
            }

            return result;
        }
    }
}