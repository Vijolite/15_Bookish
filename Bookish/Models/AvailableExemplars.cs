using Bookish.Models.Database;
namespace Bookish.Models
{
    public class AvailableExemplars
    {
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public string? CoverPhotoUrl { get; set; }


        public int Count { get; set; }


        public AvailableExemplars() { }

        public AvailableExemplars(AvailableExemplars av)
        {
            Isbn = av.Isbn;
            Title = av.Title;
            Count= av.Count;  
            CoverPhotoUrl = av.CoverPhotoUrl; 
        }

    }
}
