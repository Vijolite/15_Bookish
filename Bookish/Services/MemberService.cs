using Bookish.Repositories;
using Bookish.Models;

namespace Bookish.Services
{
    public class MemberService
    {
        private MemberRepo _members = new MemberRepo();
        private LoanRepo _loans = new LoanRepo();
        
        private BookRepo _books = new BookRepo();
        private CopyRepo _copies = new CopyRepo();

        public List<Member> GetAllMembers()
        {
            var dbMembers = _members.GetAllMembers();
            // var dbLoans = _loans.GetAllLoans();
            var dbBooks = _books.GetAllBooks();
            var dbCopies = _copies.GetAllCopies();

            List<Member> result = new List<Member>();

            foreach(var dbMember in dbMembers)
            {
                var dbLoansOld = _loans.GetOldLoans(dbMember.Id);
                var dbLoansActual = _loans.GetActualsLoans(dbMember.Id);
                
                List<Loan> loanListHistory = new List<Loan>();
                foreach (var dbLoan in dbLoansOld) {
                    
                    //Console.WriteLine (dbLoan.Copy?.Book.Title);
                    // int copyId = dbLoan.Copy?.CopyId;
                    // var dbcopy = _copies.GetCopyById (dbLoan.Copy.CopyId);
                    // Console.WriteLine (dbcopy.Book.Title);

                    loanListHistory.Add(new Loan
                                {
                                    IssueDate=dbLoan.IssueDate,
                                    ReturnDate=dbLoan.ReturnDate,
                                    HasReturned=dbLoan.HasReturned,

                                });
                    // var dbCopy = dbCopies.Find(a => a.CopyId == dbLoan.Copy?.CopyId);
                    // if (dbCopy != null)
                    // {
                    //     var dbBook = dbBooks.Find(a => a.Isbn == dbCopy.Book?.Isbn);
                    //     if (dbBook != null)
                    //     {
                    //         loanListHistory.Add(new Loan
                    //             {
                    //                 IssueDate=dbLoan.IssueDate,
                    //                 ReturnDate=dbLoan.ReturnDate,
                    //                 HasReturned=dbLoan.HasReturned,
                    //                 Member = new Member 
                    //                 {
                    //                     Id = dbMember.Id,
                    //                     FirstName = dbMember.FirstName,
                    //                     LastName = dbMember.LastName,
                    //                     Address = dbMember.Address,
                    //                     MobilePhone = dbMember.MobilePhone,
                    //                 },
                    //                 Copy = new Copy
                    //                 {
                    //                     Book = new Book 
                    //                     {
                    //                         Isbn = dbBook.Isbn, 
                    //                         Title = dbBook.Title,
                    //                         CoverPhotoUrl = dbBook.CoverPhotoUrl
                    //                     },
                    //                 },
                    //             });
                    //     }
                    // }

                }


                result.Add(new Member
                {
                    Id = dbMember.Id,
                    FirstName = dbMember.FirstName,
                    LastName = dbMember.LastName,
                    Address = dbMember.Address,
                    MobilePhone = dbMember.MobilePhone,
                    
                    LoanListHistory = //loanListHistory,
                    dbMember
                        .Loans
                        .Where(loan => loan.HasReturned == true)
                        .Select( q => new Loan
                            {
                                IssueDate=q.IssueDate,
                                ReturnDate=q.ReturnDate,
                                HasReturned=q.HasReturned, 
                                Copy = new Copy {Book = new Book {
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
                    .ToList(),
                    LoanListActual = dbMember
                        .Loans
                        .Where(loan => loan.HasReturned == false)
                        .Select( q => new Loan
                            {
                                IssueDate=q.IssueDate,
                                ReturnDate=q.ReturnDate,
                                HasReturned=q.HasReturned, 
                                Copy = new Copy {Book = new Book {
                                    Title=q.Copy?.Book?.Title,
                                    CoverPhotoUrl=q.Copy?.Book?.CoverPhotoUrl,
                                },},
                            })
                    .ToList(),
                });
                
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
