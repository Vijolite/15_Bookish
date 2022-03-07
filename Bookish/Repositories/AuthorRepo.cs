// using Bookish.Models.Database;
// using Microsoft.EntityFrameworkCore;

// namespace Bookish.Repositories
// {
//     public class AuthorRepo
//     {
//         private BookishContext context = new BookishContext();

//         public List<AuthorDbModel> GetAllAuthors()
//         {
//             return context
//                 .Authors
//                 .Include(a => a.Books)
//                 .ToList();
//         }
//     }
// }

using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories
{
    public interface IAuthorRepo
    {
        public List<AuthorDbModel> GetAllAuthors();
    }

    public class AuthorRepo : IAuthorRepo
    {
        private BookishContext context = new BookishContext();

        public List<AuthorDbModel> GetAllAuthors()
        {
            return context
                .Authors
                .Include(a => a.Books)
                .ToList();
        }
    }
}
// using Bookish.Models.Database;

// namespace Bookish.Repositories
// {
//     public class AuthorRepo
//     {
//         public List<AuthorDbModel> GetAllAuthors()
//         {
//             return new List<AuthorDbModel>
//             {
//                 new AuthorDbModel
//                 {
//                     Id = 1,
//                     Name = "Ursula K. Le Guin",
//                 },
//                 new AuthorDbModel
//                 {
//                     Id = 2,
//                     Name="JK Rowling",
//                 },
//                 new AuthorDbModel
//                 {
//                     Id = 3,
//                     Name="James S.A. Corey",
//                 },
//                 new AuthorDbModel
//                 {
//                     Id = 4,
//                     Name="Michael Morpurgo",
//                 },
//                 new AuthorDbModel
//                 {
//                     Id = 5,
//                     Name = "Lois Lowry",
//                 }
//             };
//         }
//     }
// }
