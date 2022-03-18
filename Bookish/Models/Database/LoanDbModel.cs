using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Database
{
    public class LoanDbModel
    {
        [Key]
        public int LoanId { get; set; }
        public MemberDbModel? Member { get; set; }
        public CopyDbModel Copy { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool HasReturned { get; set; }

        public string? GetBookTitle()
        {
            return Copy.Book.Title;
        }

    }
}
