namespace Bookish.Models.Database
{
    public class BookDbModel
    {
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public string? CoverPhotoUrl { get; set; }
        public string? Blurb { get; set; }
        public int? AuthorId { get; set; }
    }
}
