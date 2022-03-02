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
            var dbLoans = _loans.GetAllLoans();
            var dbBooks = _books.GetAllBooks();
            var dbCopies = _copies.GetAllCopies();

            List<Member> result = new List<Member>();

            foreach(var dbMember in dbMembers)
            {
                // var dbLoan = dbMembers.Find(a => a.Id == dbLoan.MemberId);

                // if (dbMember == null)
                // {
                //     throw new NullReferenceException("Could not find member");
                // }

                List<Loan> loanListHistory = new List<Loan>();
                List<Loan> loanListActual = new List<Loan>();

                foreach (var dbLoan in dbLoans)
                {
                    var dbCopy = dbCopies.Find(a => a.CopyId == dbLoan.CopyId);

                    if (dbCopy == null)
                    {
                        throw new NullReferenceException("Could not find copy");
                    }

                    var dbBook = dbBooks.Find(a => a.Isbn == dbCopy.Isbn);
                    if (dbBook == null)
                    {
                        throw new NullReferenceException("Could not find book");
                    }
                    if (dbLoan.MemberId == dbMember.Id)
                        {
                            if (dbLoan.HasReturned)
                            {
                                loanListHistory.Add(new Loan
                                {
                                    IssueDate=dbLoan.IssueDate,
                                    ReturnDate=dbLoan.ReturnDate,
                                    HasReturned=dbLoan.HasReturned,
                                    Member = new Member 
                                    {
                                        Id = dbMember.Id,
                                        FirstName = dbMember.FirstName,
                                        LastName = dbMember.LastName,
                                        Address = dbMember.Address,
                                        MobilePhone = dbMember.MobilePhone,
                                    },
                                    Copy = new Copy
                                    {
                                        Book = new Book 
                                        {
                                            Isbn = dbBook.Isbn, 
                                            Title = dbBook.Title,
                                            CoverPhotoUrl = dbBook.CoverPhotoUrl
                                        },
                                    },
                                });
                            }
                            else
                            {
                                loanListActual.Add(new Loan
                                {
                                    IssueDate=dbLoan.IssueDate,
                                    ReturnDate=dbLoan.ReturnDate,
                                    HasReturned=dbLoan.HasReturned,
                                    Member = new Member 
                                    {
                                        Id = dbMember.Id,
                                        FirstName = dbMember.FirstName,
                                        LastName = dbMember.LastName,
                                        Address = dbMember.Address,
                                        MobilePhone = dbMember.MobilePhone,
                                    },
                                    Copy = new Copy
                                    {
                                        Book = new Book 
                                        {
                                            Isbn = dbBook.Isbn, 
                                            Title = dbBook.Title,
                                            CoverPhotoUrl = dbBook.CoverPhotoUrl
                                        },
                                    },
                                });
                            }
                        }
                }

                
                result.Add(new Member
                {
                    Id = dbMember.Id,
                    FirstName = dbMember.FirstName,
                    LastName = dbMember.LastName,
                    Address = dbMember.Address,
                    MobilePhone = dbMember.MobilePhone,
                    LoanListHistory = loanListHistory,
                    LoanListActual = loanListActual,
                });
                
            }
            
            foreach (Member r in result)
                {
                    Console.WriteLine(r.FirstName);
                    foreach (Loan l in r.LoanListHistory)
                        Console.WriteLine(l.Copy.Book.Title);

                }
            return result;
        }
    }
}
