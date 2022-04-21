// namespace Bookish.Models
// {
//     public class Author
//     {
//         public string? Name { get; set; }
//         public string? AuthorPhotoUrl { get; set; }
//     }
// }


using Bookish.Models.Database;

namespace Bookish.Models
{
    public class Author
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? AuthorPhotoUrl { get; set; }

        public Author() { }

        public Author(AuthorDbModel authorDbModel)
        {
            Id = authorDbModel.Id;
            Name = authorDbModel.Name;
            AuthorPhotoUrl = authorDbModel.AuthorPhotoUrl;
        }
    }
}
