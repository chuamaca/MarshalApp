using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Repositories
{
    public interface IAuthorRepository
    {
        void AddAuthor(Author author);
        bool AuthorExists(Guid authorId);
        void DeleteAuthor(Author author);
        Author GetAuthor(Guid authorId);
        PagedList<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters);
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        void UpdateAuthor(Author author);
    }
}