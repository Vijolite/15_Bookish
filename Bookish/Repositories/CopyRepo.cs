using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;
using Bookish.Models.Request;


namespace Bookish.Repositories
{
    public interface ICopyRepo
    {
        public List<CopyDbModel> GetAllCopies();
        public CopyDbModel CreateCopy(CreateCopyRequest createCopyRequest);
        public CopyDbModel CreateCopy(CopyDbModel newCopy);
        public BookDbModel GetBookByIsbn (string isbn);
    }
    public class CopyRepo : ICopyRepo
    {
        private BookishContext context = new BookishContext();

        public List<CopyDbModel> GetAllCopies()
        {
            return context
                .Copies
                .Include(b => b.Loans)
                .ToList();
        }

        public CopyDbModel GetCopyById(int id)
        {
            return context
            .Copies
            .Single(l => l.CopyId == id);
        }

        public BookDbModel GetBookByIsbn (string isbn) {
            return context
            .Books
            .Single(l => l.Isbn == isbn);

        }

        public CopyDbModel CreateCopy(CopyDbModel newCopy)
        {

            var copyNoId = new CopyDbModel
            {
                //Book = new BookDbModel{Isbn = newCopy.Book.Isbn}
                Book = GetBookByIsbn(newCopy.Book.Isbn)

            };

            var insertedCopyEntry = context.Copies.Add(copyNoId);
            context.SaveChanges();

            return insertedCopyEntry.Entity;
        }

        public CopyDbModel CreateCopy(CreateCopyRequest createCopyRequest)
        {
            var insertedCopy = new CopyDbModel();
            var numberOfCopies = createCopyRequest.NumberOfCopies>0?createCopyRequest.NumberOfCopies:1;
            for (int i=0; i <numberOfCopies; i++) 
            {
             var newCopy = new CopyDbModel
            {
            };

            insertedCopy = context.Copies.Add(newCopy).Entity;

            if (createCopyRequest.BookIsbn != null)
            {
                insertedCopy.Book = GetBookByIsbn (createCopyRequest.BookIsbn);

            }
            context.SaveChanges();
            }
            return insertedCopy;
        }

    }
}

// using Bookish.Models.Database;

// namespace Bookish.Repositories
// {
//     public class CopyRepo
//     {
//         public List<CopyDbModel> GetAllCopies()
//         {
//             return new List<CopyDbModel>
//             {
//                 new CopyDbModel
//                 {
//                   CopyId = 1,
//                   Isbn="0060125632"
//                 },
//                 new CopyDbModel
//                 {
//                   CopyId = 2,
//                   Isbn="0060125632"
//                 },
//                 new CopyDbModel
//                 {
//                   CopyId = 3,
//                   Isbn="0060125632"
//                 },
//                 new CopyDbModel
//                 {
//                   CopyId = 4,
//                   Isbn="9780747532743"
//                 },
//                 new CopyDbModel
//                 {
//                   CopyId = 5,
//                   Isbn="9780747532743"
//                 },
//                 new CopyDbModel
//                 {
//                   CopyId = 6,
//                   Isbn="9781405233378"
//                 },
//                 new CopyDbModel
//                 {
//                   CopyId = 7,
//                   Isbn="9780440237686"
//                 },
//                 new CopyDbModel
//                 {
//                   CopyId = 8,
//                   Isbn="9780440237686"
//                 },

//             };
//         }
//     }
// }
