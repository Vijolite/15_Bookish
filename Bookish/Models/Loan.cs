namespace Bookish.Models
{
    public class Loan
    {

        public Copy? Copy { get; set; }
        public Member? Member { get; set; }
        public DateOnly? IssueDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public bool HasReturned { get; set; }
    }
}
