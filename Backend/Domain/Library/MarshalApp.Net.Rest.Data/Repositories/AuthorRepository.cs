using MarshalApp.Net.Rest.Infrastructure.Data.Contexts;
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;
using MarshalApp.Net.Rest.Infrastructure.Data.Helpers;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;
        private IAuthorPropertyMappingService _authorPropertyMappingService;
        public AuthorRepository(
            LibraryContext context,
            IAuthorPropertyMappingService propertyMappingService
        )
        {
            _context = context;
            _authorPropertyMappingService = propertyMappingService;
        }
        public PagedList<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters)
        {
            var collectionBeforePaging = _context.Authors.ApplySort(authorsResourceParameters.OrderBy, _authorPropertyMappingService.GetPropertyMapping());

            if (!string.IsNullOrEmpty(authorsResourceParameters.Genre))
            {

                var genreForWhereClause = authorsResourceParameters.Genre.Trim().ToLower();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.Genre.ToLower() == genreForWhereClause);
            }

            if (!string.IsNullOrEmpty(authorsResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = authorsResourceParameters.SearchQuery.Trim().ToLower();

                collectionBeforePaging = collectionBeforePaging
                    .Where(a => a.Genre.ToLower().Contains(searchQueryForWhereClause)
                    || a.FirstName.ToLower().Contains(searchQueryForWhereClause)
                    || a.LastName.ToLower().Contains(searchQueryForWhereClause));
            }

            return PagedList<Author>.Create(collectionBeforePaging,
                authorsResourceParameters.PageNumber,
                authorsResourceParameters.PageSize);
        }

        public IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds)
        {
            return _context.Authors.Where(a => authorIds.Contains(a.AuthorId))
                .OrderBy(a => a.FirstName)
                .OrderBy(a => a.LastName)
                .ToList();
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }
        public void UpdateAuthor(Author author)
        {
            var authorUpdate = GetAuthor(author.AuthorId);
            if (authorUpdate != null)
            {
                authorUpdate.FirstName = author.FirstName;
                authorUpdate.LastName = author.LastName;
                authorUpdate.Genre = author.Genre;
                authorUpdate.DateOfBirth = author.DateOfBirth;
                authorUpdate.DateOfDeath = author.DateOfDeath;
            }
        }
        public Author GetAuthor(Guid authorId)
        {
            return _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
        }

        public bool AuthorExists(Guid authorId)
        {
            return _context.Authors.Any(a => a.AuthorId == authorId);
        }
    }
}
