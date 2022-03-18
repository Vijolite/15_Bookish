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
// using Bookish.Models.Database;

// namespace Bookish.Repositories
// {
//     public class BookRepo
//     {
//         public List<BookDbModel> GetAllBooks()
//         {
//             return new List<BookDbModel>
//             {
//                 new BookDbModel
//                 {
//                     Isbn = "0060125632",
//                     Title = "The Dispossessed",
//                     CoverPhotoUrl = "https://upload.wikimedia.org/wikipedia/en/f/fc/TheDispossed%281stEdHardcover%29.jpg",
//                     Blurb = "The Dispossessed (in later printings titled The Dispossessed: An Ambiguous Utopia[1]) is a 1974 utopian science fiction novel by American writer Ursula K. Le Guin, set in the fictional universe of the seven novels of the Hainish Cycle (e.g., The Left Hand of Darkness). It won the Hugo, Locus and Nebula Awards for Best Novel in 1975.[2] It achieved a degree of literary recognition unusual for science fiction due to its exploration of themes such as anarchism (on a satellite planet called Anarres) and revolutionary societies, capitalism, and individualism and collectivism.",
//                     AuthorId = 1,
//                 },
//                 new BookDbModel
//                 {
//                     Isbn ="9780747532743",
//                     Title = "Harry Potter and the Philosopher's Stone",
//                     CoverPhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/81YOuOGFCJL.jpg",
//                     Blurb = "A young wizard learns he is a wizard",
//                     AuthorId = 2,
//                 },
//                 new BookDbModel
//                 {
//                     Isbn="9781841499895",
//                     Title = "Leviathan Wakes",
//                     CoverPhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/91Zzw-Mc5xL.jpg",
//                     Blurb = "The first book in 'The Expanse' series",
//                     AuthorId = 3,
//                 },
//                 new BookDbModel
//                 {
//                     Isbn="9781405233378",
//                     Title = "Friend or Foe",
//                     CoverPhotoUrl = "https://th.bing.com/th/id/OIP.lxqtqy610iBIv5J_EdTxBQHaLV?pid=ImgDet&rs=1",
//                     Blurb = "People we meet and choices we make",
//                     AuthorId = 4,
//                 },
//                 new BookDbModel
//                 {
//                     Isbn="9780440237686",
//                     Title = "The Giver",
//                     AuthorId = 5,
//                     CoverPhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/5106zg-84tL._SX324_BO1,204,203,200_.jpg",
//                     Blurb = "Utopian novel. Set in a futuristic society",
//                 }
//             };
//         }
//     }
// }
