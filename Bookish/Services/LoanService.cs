using Bookish.Repositories;
using Bookish.Models;

namespace Bookish.Services
{
    public class LoanService
    {
        private BookRepo _books = new BookRepo();
        private CopyRepo _copies = new CopyRepo();
        private MemberRepo _members = new MemberRepo();
        private LoanRepo _loans = new LoanRepo();

        public List<Loan> GetAllLoans()
        {
            var dbCopies = _copies.GetAllCopies();
            var dbBooks = _books.GetAllBooks();
            var dbMembers = _members.GetAllMembers();
            var dbLoans = _loans.GetAllLoans();

            List<Loan> result = new List<Loan>();

            foreach (var dbLoan in dbLoans)
            {
                result.Add(new Loan(dbLoan));
                // result.Add(new Loan
                // {
                //     IssueDate = dbLoan.IssueDate,
                //     ReturnDate = dbLoan.ReturnDate,
                //     HasReturned = dbLoan.HasReturned,
                //     Member = new Member {FirstName = dbLoan.Member.FirstName, LastName=dbLoan.Member.LastName},
                //     Copy = new Copy 
                //     {Book = new Book {Title = dbLoan.Copy.Book.Title, CoverPhotoUrl=dbLoan.Copy.Book.CoverPhotoUrl}},

                // });


                
            }




            // foreach(var dbLoan in dbLoans)
            // {
            //     var dbMember = dbMembers.Find(a => a.Id == dbLoan.MemberId);

            //     if (dbMember == null)
            //     {
            //         throw new NullReferenceException("Could not find member");
            //     }

            //     var dbCopy = dbCopies.Find(a => a.CopyId == dbLoan.CopyId);

            //     if (dbCopy == null)
            //     {
            //         throw new NullReferenceException("Could not find copy");
            //     }

            //     var dbBook = dbBooks.Find(a => a.Isbn == dbCopy.Isbn);
            //     if (dbBook == null)
            //     {
            //         throw new NullReferenceException("Could not find book");
            //     }

            //     result.Add(new Loan
            //     {

            //         Member = new Member
            //         {
            //             FirstName = dbMember.FirstName,
            //             LastName = dbMember.LastName
            //         },
            //         Copy = new Copy
            //         {
            //             Book = new Book 
            //             {
            //                 Isbn = dbBook.Isbn, 
            //                 Title = dbBook.Title,
            //                 CoverPhotoUrl = dbBook.CoverPhotoUrl
            //             },
            //         },
            //         IssueDate = dbLoan.IssueDate,
            //         ReturnDate = dbLoan.ReturnDate,
            //         HasReturned = dbLoan.HasReturned,
            //     });
            // }
            
            return result;
        }
    }
}
