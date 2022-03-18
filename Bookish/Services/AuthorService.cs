using Bookish.Repositories;
using Bookish.Models;
using Bookish.Models.Request;
using Bookish.Models.Database;

namespace Bookish.Services
{
    public interface IAuthorService
    {
        public List<Author> GetAllAuthors();
    }

    public class AuthorService : IAuthorService
    {
        private IAuthorRepo _authors;

        public AuthorService(IAuthorRepo authors)
        {
            _authors = authors;
        }

        public List<Author> GetAllAuthors()
        {
            var allDbAuthors = _authors.GetAllAuthors();

            List<Author> result = new List<Author>();

            foreach (var dbAuthor in allDbAuthors)
            {
                result.Add(new Author(dbAuthor));
            }

            return result;
        }
    }
}