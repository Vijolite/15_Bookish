using System.ComponentModel.DataAnnotations;
// using Bookish.Models.Database;
// using Microsoft.EntityFrameworkCore;

// namespace Bookish.Models.Request
// {
//     public class CreateBookRequest
//     {
//         [Required]
//         [StringLength(20)]
//         public string Isbn { get; set; }
        
//         [Required]
//         [StringLength(100)]
//         public string Title { get; set; }
        
//     }
// }

namespace Bookish.Models.Request
{
    public class CreateBookRequest
    {
        [Required]
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public string? CoverPhotoUrl { get; set; }
        public string? Blurb { get; set; }

        public List<string>? AuthorNames { get; set; }
    }
}