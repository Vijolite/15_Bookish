using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories
{
    public interface IMemberRepo
    {
        public List<MemberDbModel> GetAllMembers();
        public MemberDbModel CreateMember(MemberDbModel newMember);
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
        public MemberDbModel CreateMember(MemberDbModel newMember)
        {
            // explicitly remove ID, as you're not allowed to specify it
            var memberNoId = new MemberDbModel
            {
                FirstName = newMember.FirstName,
                LastName = newMember.LastName,
                MobilePhone = newMember.MobilePhone,
                Address = newMember.Address,
            };

            var insertedMemberEntry = context.Members.Add(memberNoId);
            context.SaveChanges();

            return insertedMemberEntry.Entity;
        }
    }
}

