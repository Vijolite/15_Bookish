using Bookish.Models.Database;

namespace Bookish.Repositories
{
    public class AuthorRepo
    {
        public List<AuthorDbModel> GetAllAuthors()
        {
            return new List<AuthorDbModel>
            {
                new AuthorDbModel
                {
                    Id = 1,
                    Name = "Ursula K. Le Guin",
                },
                new AuthorDbModel
                {
                    Id = 2,
                    Name="JK Rowling",
                },
                new AuthorDbModel
                {
                    Id = 3,
                    Name="James S.A. Corey",
                },
                new AuthorDbModel
                {
                    Id = 4,
                    Name="Michael Morpurgo",
                },
                new AuthorDbModel
                {
                    Id = 5,
                    Name = "Lois Lowry",
                }
            };
        }
    }
}
