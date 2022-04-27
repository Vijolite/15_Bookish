using Bookish.Repositories;
using Bookish.Models;
using Bookish.Models.Request;
using Bookish.Models.Database;

namespace Bookish.Services
{
    public interface IMemberService
    {
        public List<Member> GetAllMembers();
        public Member CreateMember(CreateMemberRequest createMemberRequest);
    }
    public class MemberService : IMemberService
    {
        //private MemberRepo _members = new MemberRepo();
        private IMemberRepo _members;
        public MemberService(IMemberRepo members)
        {
            _members = members;
        }


        public List<Member> GetAllMembers()
        {
            var dbMembers = _members.GetAllMembers();

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

        public Member CreateMember(CreateMemberRequest createAuthorRequest)
        {

            var insertedMember = _members.CreateMember(
                new MemberDbModel
                {


                    FirstName = createAuthorRequest.FirstName,
                    LastName = createAuthorRequest.LastName,
                    MobilePhone = createAuthorRequest.MobilePhone,
                    Address = createAuthorRequest.Address,

                }
            );
            return new Member(insertedMember);
        }
    }
}
