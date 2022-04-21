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
        //public BookDbModel CreateBook(BookDbModel newBook);
        public BookDbModel CreateBook(CreateBookRequest createBookRequest);
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

        public BookDbModel CreateBook(CreateBookRequest createBookRequest)
        {
            //var insertedBookEntry = context.Books.Add(newBook);
             var newBook = new BookDbModel
            {
                Isbn = createBookRequest.Isbn,
                Title = createBookRequest.Title,
                CoverPhotoUrl = createBookRequest.CoverPhotoUrl,
                Blurb = createBookRequest.Blurb,
            };

            var insertedBook = context.Books.Add(newBook).Entity;

            if (createBookRequest.AuthorIds != null)
            {
                insertedBook.Authors = new List<AuthorDbModel>();

                foreach (int authorId in createBookRequest.AuthorIds)
                {
                    insertedBook.Authors.Add(
                        context.Authors.Where(a => a.Id == authorId).Single()
                    );
                }
            }
            context.SaveChanges();

            //return insertedBookEntry.Entity;
            return insertedBook;
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