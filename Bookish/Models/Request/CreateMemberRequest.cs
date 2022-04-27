using System.ComponentModel.DataAnnotations;


namespace Bookish.Models.Request
{
    public class CreateMemberRequest
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Address { get; set; }


    }
}

    
        