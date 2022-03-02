namespace Bookish.Models.Database
{
    public class LoanDbModel
    {
        public int LoanId { get; set; }
        public int CopyId { get; set; }
        public int MemberId { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public bool HasReturned { get; set; }

    }
}
