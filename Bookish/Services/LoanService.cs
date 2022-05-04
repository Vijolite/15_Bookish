using Bookish.Repositories;
using Bookish.Models;
using Bookish.Models.Request;


namespace Bookish.Services
{
    public interface ILoanService
    {
        public Loan CreateLoan(CreateLoanRequest createLoanRequest);
        public Loan UpdateLoan(UpdateLoanRequest updateLoanRequest);
        public List<Loan> GetAllLoans();

    }
    public class LoanService : ILoanService
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
            }
            
            return result;
        }

        public Loan CreateLoan(CreateLoanRequest createLoanRequest)
        {
            var insertedLoan = _loans.CreateLoan(createLoanRequest);
            return new Loan(insertedLoan);    
        }

        public Loan UpdateLoan(UpdateLoanRequest updateLoanRequest)
        {
            var insertedLoan = _loans.UpdateLoan(updateLoanRequest);
            return new Loan(insertedLoan);    
        }
    }
}
