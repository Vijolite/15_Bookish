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
            
            return result;
        }
    }
}
