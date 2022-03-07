using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Database
{
    public class BookDbModel
    {
        [Key]
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public string? CoverPhotoUrl { get; set; }
        public string? Blurb { get; set; }
        public List<AuthorDbModel>? Authors { get; set; }
        public List<CopyDbModel>? Copies { get; set; }
    }
}
