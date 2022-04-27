using System.ComponentModel.DataAnnotations;


namespace Bookish.Models.Request
{
    public class CreateCopyRequest
    {
        [Required]
        public string? BookIsbn { get; set; }

        public int? NumberOfCopies { get; set; }

        public CreateCopyRequest() {

        }


    }
}