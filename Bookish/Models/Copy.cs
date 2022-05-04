using Bookish.Models.Database;
namespace Bookish.Models
{
    public class Copy
    {
        public int CopyId { get; set; }
        public Book? Book { get; set; }
        public List<Loan>? LoanList {get; set;}

        public Copy() { }

        public Copy(CopyDbModel copyDbModel)
        {
            CopyId = copyDbModel.CopyId;
            Book = new Book {
                Title = copyDbModel.Book?.Title, 
                Isbn = copyDbModel.Book?.Isbn,
                CoverPhotoUrl=copyDbModel.Book?.CoverPhotoUrl};

            LoanList = copyDbModel
                        .Loans?
                        
                        .Select( q => new Loan
                            {
                                IssueDate=q.IssueDate,
                                ReturnDate=q.ReturnDate,
                                HasReturned=q.HasReturned, 
                            })
                    .ToList();
            
        }

    }
}
