using System.ComponentModel.DataAnnotations;
namespace Bookish.Models.Database
{
    public class CopyDbModel
    {
        [Key]
        public int? CopyId { get; set; }
        public BookDbModel? Book { get; set; }
        //public string? Isbn { get; set; }
        public List<LoanDbModel>? Loans { get; set; }
    }
}
