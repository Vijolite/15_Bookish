using Bookish.Repositories;
using Bookish.Models;

namespace Bookish.Services
{
    public class MemberService
    {
        private MemberRepo _members = new MemberRepo();
        // private LoanRepo _loans = new LoanRepo();
        
        // private BookRepo _books = new BookRepo();
        // private CopyRepo _copies = new CopyRepo();

        public List<Member> GetAllMembers()
        {
            var dbMembers = _members.GetAllMembers();
            // var dbLoans = _loans.GetAllLoans();
            // var dbBooks = _books.GetAllBooks();
            // var dbCopies = _copies.GetAllCopies();

            List<Member> result = new List<Member>();

            foreach(var dbMember in dbMembers)
            {

                result.Add(new Member(dbMember));

                // result.Add(new Member
                // {
                //     Id = dbMember.Id,
                //     FirstName = dbMember.FirstName,
                //     LastName = dbMember.LastName,
                //     Address = dbMember.Address,
                //     MobilePhone = dbMember.MobilePhone,
                    
                //     LoanListHistory = //loanListHistory,
                //     dbMember
                //         .Loans
                //         .Where(loan => loan.HasReturned == true)
                //         .Select( q => new Loan
                //             {
                //                 IssueDate=q.IssueDate,
                //                 ReturnDate=q.ReturnDate,
                //                 HasReturned=q.HasReturned, 
                //                 Copy = new Copy {Book = new Book {
                //                     Title=q.Copy?.Book?.Title,
                //                     CoverPhotoUrl=q.Copy?.Book?.CoverPhotoUrl,
                //                     // Authors = q.Copy.Book.Authors
                //                     //     .Select(a => new Author
                //                     //         {
                //                     //             Name = a.Name,
                //                     //             AuthorPhotoUrl = a.AuthorPhotoUrl
                //                     //         })
                //                     //     .ToList(),
                //                     },},
                //             })
                //     .ToList(),
                //     LoanListActual = dbMember
                //         .Loans
                //         .Where(loan => loan.HasReturned == false)
                //         .Select( q => new Loan
                //             {
                //                 IssueDate=q.IssueDate,
                //                 ReturnDate=q.ReturnDate,
                //                 HasReturned=q.HasReturned, 
                //                 Copy = new Copy {Book = new Book {
                //                     Title=q.Copy?.Book?.Title,
                //                     CoverPhotoUrl=q.Copy?.Book?.CoverPhotoUrl,
                //                 },},
                //             })
                //     .ToList(),
                // });
                
                // result.Add(new Member
                // {
                //     Id = dbMember.Id,
                //     FirstName = dbMember.FirstName,
                //     LastName = dbMember.LastName,
                //     Address = dbMember.Address,
                //     MobilePhone = dbMember.MobilePhone,
                //     LoanListHistory = loanListHistory,
                //     LoanListActual = loanListActual,
                // });
                
            }
            
            // foreach (Member r in result)
            //     {
            //         Console.WriteLine(r.FirstName);
            //         foreach (Loan l in r.LoanListHistory)
            //             Console.WriteLine(l.Copy.Book.Title);

            //     }
            return result;
        }
    }
}
