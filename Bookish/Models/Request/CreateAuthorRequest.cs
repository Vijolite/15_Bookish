using System.ComponentModel.DataAnnotations;


namespace Bookish.Models.Request
{
    public class CreateAuthorRequest
    {
        [Required]
        public string? Name { get; set; }
        public string? AuthorPhotoUrl { get; set; }

    }
}