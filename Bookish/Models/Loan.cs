namespace Bookish.Models
{
    public class Loan
    {

        public Copy? Copy { get; set; }
        public Member? Member { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool HasReturned { get; set; }
    }
}
