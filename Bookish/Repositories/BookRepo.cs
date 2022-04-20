// using Bookish.Models.Database;
// using Microsoft.EntityFrameworkCore;

// namespace Bookish.Repositories
// {
//     public class BookRepo
//     {
//         private BookishContext context = new BookishContext();

//         public List<BookDbModel> GetAllBooks()
//         {
//             return context
//                 .Books
//                 .Include(b => b.Authors)
//                 .ToList();
//         }
//     }
// }

using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;
using Bookish.Models.Request;

namespace Bookish.Repositories
{
    public interface IBookRepo
    {
        public List<BookDbModel> GetAllBooks();
        public BookDbModel CreateBook(BookDbModel newBook);
    }

    public class BookRepo : IBookRepo
    {
        private BookishContext context = new BookishContext();

        public List<BookDbModel> GetAllBooks()
        {
            return context
                .Books
                .Include(b => b.Authors)
                .Include(b => b.Copies)
                .ToList();
        }

        public BookDbModel CreateBook(BookDbModel newBook)
        {
            var insertedBookEntry = context.Books.Add(newBook);
            context.SaveChanges();

            return insertedBookEntry.Entity;
        }
        
        // public BookDbModel Create(CreateBookRequest newBook)
        // {
        //     var insertResponse = context.Books.Add(new BookDbModel
        //     {
        //         Isbn = newBook.Isbn,
        //         Title = newBook.Title,
        //     });
        //     context.SaveChanges();

        //     return insertResponse.Entity;
        // }
    }


}