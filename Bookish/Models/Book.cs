using Bookish.Models.Database;
namespace Bookish.Models
{
    public class Book
    {
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public List<Author>? Authors { get; set; }
        public List<Copy>? Copies { get; set; }
        public string? CoverPhotoUrl { get; set; }
        public string? Blurb { get; set; }

        public Book() { }

        public Book(BookDbModel bookDbModel)
        {
            Isbn = bookDbModel.Isbn;
            Title = bookDbModel.Title;
            CoverPhotoUrl = bookDbModel.CoverPhotoUrl;
            Blurb = bookDbModel.Blurb;

            Authors = bookDbModel.Authors?.Select(a => new Author(a)).ToList();
        }
    }
}
