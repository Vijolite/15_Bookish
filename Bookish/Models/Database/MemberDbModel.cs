using System.ComponentModel.DataAnnotations;
namespace Bookish.Models.Database
{
    public class MemberDbModel
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Address { get; set; }
        public List<LoanDbModel>? Loans { get; set; }
    }
}