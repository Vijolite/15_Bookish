using Bookish.Models.Database;

namespace Bookish.Repositories
{
    public class CopyRepo
    {
        public List<CopyDbModel> GetAllCopies()
        {
            return new List<CopyDbModel>
            {
                new CopyDbModel
                {
                  CopyId = 1,
                  Isbn="0060125632"
                },
                new CopyDbModel
                {
                  CopyId = 2,
                  Isbn="0060125632"
                },
                new CopyDbModel
                {
                  CopyId = 3,
                  Isbn="0060125632"
                },
                new CopyDbModel
                {
                  CopyId = 4,
                  Isbn="9780747532743"
                },
                new CopyDbModel
                {
                  CopyId = 5,
                  Isbn="9780747532743"
                },
                new CopyDbModel
                {
                  CopyId = 6,
                  Isbn="9781405233378"
                },
                new CopyDbModel
                {
                  CopyId = 7,
                  Isbn="9780440237686"
                },
                new CopyDbModel
                {
                  CopyId = 8,
                  Isbn="9780440237686"
                },

            };
        }
    }
}
