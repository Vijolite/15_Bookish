using Bookish.Models.Database;

namespace Bookish.Repositories
{
    public class LoanRepo
    {
        public List<LoanDbModel> GetAllLoans()
        {
            return new List<LoanDbModel>
            {
                new LoanDbModel
                {
                    LoanId = 1,
                    CopyId=1,
                    MemberId=1,
                    IssueDate = new DateOnly(2021,12,12),
                    ReturnDate = null,
                    HasReturned=false,
                },
                new LoanDbModel
                {
                    LoanId = 2,
                    CopyId=2,
                    MemberId=2,
                    IssueDate = new DateOnly(2021,12,15),
                    ReturnDate = new DateOnly(2021,12,25),
                    HasReturned=true,
                },
                new LoanDbModel
                {
                    LoanId = 3,
                    CopyId=6,
                    MemberId=2,
                    IssueDate = new DateOnly(2021,12,25),
                    ReturnDate = null,
                    HasReturned=false,
                },
                new LoanDbModel
                {
                    LoanId = 4,
                    CopyId=4,
                    MemberId=1,
                    IssueDate = new DateOnly(2021,12,15),
                    ReturnDate = new DateOnly(2021,12,16),
                    HasReturned=true,
                },
                new LoanDbModel
                {
                    LoanId = 5,
                    CopyId=5,
                    MemberId=2,
                    IssueDate = new DateOnly(2021,12,15),
                    ReturnDate = null,
                    HasReturned=false,
                },
                new LoanDbModel
                {
                    LoanId = 6,
                    CopyId=7,
                    MemberId=2,
                    IssueDate = new DateOnly(2021,12,15),
                    ReturnDate = null,
                    HasReturned=false,
                },
                new LoanDbModel
                {
                    LoanId = 7,
                    CopyId=8,
                    MemberId=1,
                    IssueDate = new DateOnly(2021,12,15),
                    ReturnDate = new DateOnly(2022,01,05),
                    HasReturned=true,
                },

            };
        }
    }
}
