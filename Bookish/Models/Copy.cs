using Bookish.Models.Database;
namespace Bookish.Models
{
    public class Copy
    {
        public int? CopyId { get; set; }
        public Book? Book { get; set; }

        public Copy() { }

        public Copy(CopyDbModel copyDbModel)
        {
            CopyId = copyDbModel.CopyId;
            Book = new Book {Title = copyDbModel.Book.Title, CoverPhotoUrl=copyDbModel.Book.CoverPhotoUrl};
            
        }

    }
}
