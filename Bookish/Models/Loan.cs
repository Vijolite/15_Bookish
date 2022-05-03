using Bookish.Models.Database;
namespace Bookish.Models
{
    public class Loan
    {

        public Copy Copy { get; set; }
        public Member Member { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool HasReturned { get; set; }

        public Loan()
        {

        }

        public Loan(LoanDbModel loanDbModel)
        {
            IssueDate = loanDbModel.IssueDate;
            ReturnDate = loanDbModel.ReturnDate;
            HasReturned = loanDbModel.HasReturned;
            Member = new Member {FirstName = loanDbModel.Member?.FirstName, LastName=loanDbModel.Member?.LastName};
            Copy = new Copy 
                {Book = new Book {Title = loanDbModel.Copy?.Book?.Title, CoverPhotoUrl=loanDbModel.Copy?.Book?.CoverPhotoUrl}};
        }
    }
}
