using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories
{
    public interface IMemberRepo
    {
        public List<MemberDbModel> GetAllMembers();
    }
    public class MemberRepo : IMemberRepo
    {
        private BookishContext context = new BookishContext();

        public List<MemberDbModel> GetAllMembers()
        {
            return context
                .Members
                .Include(b => b.Loans)
                .ThenInclude (l=>l.Copy)
                .ThenInclude (b=>b.Book)
                .ToList();
        }
    }
}

// using Bookish.Models.Database;

// namespace Bookish.Repositories
// {
//     public class MemberRepo
//     {
//         public List<MemberDbModel> GetAllMembers()
//         {
//             return new List<MemberDbModel>
//             {
//                 new MemberDbModel
//                 {
//                   Id = 1,
//                   FirstName = "Anna",
//                   LastName = "Smith",
//                   MobilePhone = "000777555",
//                   Address = "NE35TH London street 5",
//                 },
//                 new MemberDbModel
//                 {
//                   Id = 2,
//                   FirstName = "Jacob",
//                   LastName = "Peterson",
//                   MobilePhone = "111222333",
//                   Address = "NB34RT Lilly's alley 45",
//                 },
//             };
//         }
//     }
// }
