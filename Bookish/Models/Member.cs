namespace Bookish.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Address { get; set; }

        public List<Loan>? LoanListHistory {get; set;}
        public List<Loan>? LoanListActual {get; set;}
    }
}
