using Bookish.Models.Database;
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

        public Member()
        {
        }
        public Member(MemberDbModel memberDbModel)
        {
            FirstName = memberDbModel.FirstName;
            LastName = memberDbModel.LastName;
            Id = memberDbModel.Id;
            Address = memberDbModel.Address;
            MobilePhone = memberDbModel.MobilePhone;
                    
            LoanListHistory = memberDbModel
                        .Loans?
                        .Where(loan => loan.HasReturned == true)
                        .Select( q => new Loan
                            {
                                IssueDate=q.IssueDate,
                                ReturnDate=q.ReturnDate,
                                HasReturned=q.HasReturned, 
                                Copy = new Copy { CopyId = q.Copy.CopyId,
                                    Book = new Book {
                                    Title=q.Copy?.Book?.Title,
                                    CoverPhotoUrl=q.Copy?.Book?.CoverPhotoUrl,
                                    // Authors = q.Copy.Book.Authors
                                    //     .Select(a => new Author
                                    //         {
                                    //             Name = a.Name,
                                    //             AuthorPhotoUrl = a.AuthorPhotoUrl
                                    //         })
                                    //     .ToList(),
                                    },},
                            })
                    .ToList();
            LoanListActual = memberDbModel
                        .Loans?
                        .Where(loan => loan.HasReturned == false)
                        .Select( q => new Loan
                            {
                                IssueDate=q.IssueDate,
                                ReturnDate=q.ReturnDate,
                                HasReturned=q.HasReturned, 
                                Copy = new Copy {CopyId = q.Copy.CopyId,
                                    Book = new Book {
                                    Title=q.Copy?.Book?.Title,
                                    CoverPhotoUrl=q.Copy?.Book?.CoverPhotoUrl,
                                },},
                            })
                    .ToList();

        }
    }
}
