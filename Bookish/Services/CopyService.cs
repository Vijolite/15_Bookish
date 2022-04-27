using Bookish.Repositories;
using Bookish.Models;
using Bookish.Models.Request;
using Bookish.Models.Database;

namespace Bookish.Services
{
    public interface ICopyService
    {
        public List<Copy> GetAllCopies();
        public Copy CreateCopy(CreateCopyRequest createCopyRequest);
        public Copy CreateCopy(string isbn);
    }

    public class CopyService : ICopyService
    {
        private IBookRepo _books;
        private ICopyRepo _copies;

        public CopyService(IBookRepo books, ICopyRepo copies)
        {
            _books = books;
            _copies = copies;
        }

        public List<Copy> GetAllCopies()
        {
            var allDbCopies = _copies.GetAllCopies();

            List<Copy> result = new List<Copy>();

            foreach (var dbCopy in allDbCopies)
            {
                result.Add(new Copy(dbCopy));
            }

            return result;
        }

        public Copy CreateCopy(CreateCopyRequest createCopyRequest)
        {
            var insertedCopy = _copies.CreateCopy(createCopyRequest);
            return new Copy(insertedCopy);    
        }

        public Copy CreateCopy(string isbn)
        {

            var insertedCopy = _copies.CreateCopy(
                new CopyDbModel
                {
                    Book = _copies.GetBookByIsbn(isbn)
                }
                );

            return new Copy(insertedCopy);
            
        }
    }
}