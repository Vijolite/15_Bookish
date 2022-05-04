using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;
using Bookish.Models.Request;


namespace Bookish.Repositories
{
    public interface ILoanRepo
        {
            public List<LoanDbModel> GetAllLoans();
            public LoanDbModel CreateLoan(CreateLoanRequest createLoanRequest);
            public LoanDbModel UpdateLoan(UpdateLoanRequest updateLoanRequest);
        }
    public class LoanRepo : ILoanRepo
    {

        private BookishContext context = new BookishContext();

        public List<LoanDbModel> GetAllLoans()
        {
            return context
                .Loans
                .Include(m => m.Member)
                .Include(c => c.Copy)
                .ThenInclude (b=>b.Book)
                .ToList();
        }

        public CopyDbModel GetCopyById(int id)
        {
            return context
            .Copies
            .Single(l => l.CopyId == id);
        }
        public MemberDbModel GetMemberById(int id)
        {
            return context
            .Members
            .Single(l => l.Id == id);
        }
        public LoanDbModel CreateLoan(CreateLoanRequest createLoanRequest)
        {

            var loanNoId = new LoanDbModel
            {
                IssueDate = DateTime.Today,
                HasReturned = false,
                Copy = GetCopyById (createLoanRequest.CopyId),
                Member = GetMemberById (createLoanRequest.MemberId)
            };

            var insertedLoan = context.Loans.Add(loanNoId).Entity;

            if (createLoanRequest.CopyId != null)
            {
                insertedLoan.Copy = GetCopyById (createLoanRequest.CopyId);

            }
            if (createLoanRequest.MemberId != null)
            {
                insertedLoan.Member = GetMemberById (createLoanRequest.MemberId);

            }

            context.SaveChanges();

            return insertedLoan;
        }
        
        public LoanDbModel UpdateLoan(UpdateLoanRequest updateLoanRequest)
        {
            var loan = context.Loans
                .Where(l => l.Member.Id == updateLoanRequest.MemberId && l.Copy.CopyId == updateLoanRequest.CopyId).First();
            loan.ReturnDate = DateTime.Today;
            loan.HasReturned = true;

            context.Loans.Update(loan);
            context.SaveChanges();
            return loan;
        }

        public List<LoanDbModel> GetOldLoans(int id)
        {
            return context
            .Loans
            .Where(loan => loan.HasReturned == true && loan.Member.Id==id)
            .Include (c => c.Copy)
            .ToList();
        }

        
        public List<LoanDbModel> GetActualsLoans(int id)
        {
            return context
            .Loans
            .Where(loan => loan.HasReturned == false && loan.Member.Id==id)
            .ToList();
        }


        

    }
}
// using Bookish.Models.Database;

// namespace Bookish.Repositories
// {
//     public class LoanRepo
//     {
//         public List<LoanDbModel> GetAllLoans()
//         {
//             return new List<LoanDbModel>
//             {
//                 new LoanDbModel
//                 {
//                     LoanId = 1,
//                     CopyId=1,
//                     MemberId=1,
//                     IssueDate = new DateTime(2021,12,12),
//                     ReturnDate = null,
//                     HasReturned=false,
//                 },
//                 new LoanDbModel
//                 {
//                     LoanId = 2,
//                     CopyId=2,
//                     MemberId=2,
//                     IssueDate = new DateTime(2021,12,15),
//                     ReturnDate = new DateTime(2021,12,25),
//                     HasReturned=true,
//                 },
//                 new LoanDbModel
//                 {
//                     LoanId = 3,
//                     CopyId=6,
//                     MemberId=2,
//                     IssueDate = new DateTime(2021,12,25),
//                     ReturnDate = null,
//                     HasReturned=false,
//                 },
//                 new LoanDbModel
//                 {
//                     LoanId = 4,
//                     CopyId=4,
//                     MemberId=1,
//                     IssueDate = new DateTime(2021,12,15),
//                     ReturnDate = new DateTime(2021,12,16),
//                     HasReturned=true,
//                 },
//                 new LoanDbModel
//                 {
//                     LoanId = 5,
//                     CopyId=5,
//                     MemberId=2,
//                     IssueDate = new DateTime(2021,12,15),
//                     ReturnDate = null,
//                     HasReturned=false,
//                 },
//                 new LoanDbModel
//                 {
//                     LoanId = 6,
//                     CopyId=7,
//                     MemberId=2,
//                     IssueDate = new DateTime(2021,12,15),
//                     ReturnDate = null,
//                     HasReturned=false,
//                 },
//                 new LoanDbModel
//                 {
//                     LoanId = 7,
//                     CopyId=8,
//                     MemberId=1,
//                     IssueDate = new DateTime(2021,12,15),
//                     ReturnDate = new DateTime(2022,01,05),
//                     HasReturned=true,
//                 },

//             };
//         }
//     }
// }
