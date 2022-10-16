using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Dynamic;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public class AuthorLinksBuilder : IAuthorLinksBuilder
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;

        public AuthorLinksBuilder(
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor
        )
        {
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
        }

        public string CreateAuthorsResourceUri(AuthorsResourceParameters authorsResourceParameters, ResourceUriType type)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return urlHelper.Link("GetAuthors",
                      new
                      {
                          fields = authorsResourceParameters.Fields,
                          orderBy = authorsResourceParameters.OrderBy,
                          searchQuery = authorsResourceParameters.SearchQuery,
                          genre = authorsResourceParameters.Genre,
                          pageNumber = authorsResourceParameters.PageNumber - 1,
                          pageSize = authorsResourceParameters.PageSize
                      });
                case ResourceUriType.NextPage:
                    return urlHelper.Link("GetAuthors",
                      new
                      {
                          fields = authorsResourceParameters.Fields,
                          orderBy = authorsResourceParameters.OrderBy,
                          searchQuery = authorsResourceParameters.SearchQuery,
                          genre = authorsResourceParameters.Genre,
                          pageNumber = authorsResourceParameters.PageNumber + 1,
                          pageSize = authorsResourceParameters.PageSize
                      });
                case ResourceUriType.Current:
                default:
                    return urlHelper.Link("GetAuthors",
                    new
                    {
                        fields = authorsResourceParameters.Fields,
                        orderBy = authorsResourceParameters.OrderBy,
                        searchQuery = authorsResourceParameters.SearchQuery,
                        genre = authorsResourceParameters.Genre,
                        pageNumber = authorsResourceParameters.PageNumber,
                        pageSize = authorsResourceParameters.PageSize
                    });
            }
        }

        public IEnumerable<LinkDto> CreatePagedLinksForAuthors(AuthorsResourceParameters authorsResourceParameters, bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>();

            // self 
            links.Add(new LinkDto(CreateAuthorsResourceUri(authorsResourceParameters, ResourceUriType.Current), "self", "GET"));

            if (hasNext)
            {
                links.Add(new LinkDto(CreateAuthorsResourceUri(authorsResourceParameters, ResourceUriType.NextPage), "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(new LinkDto(CreateAuthorsResourceUri(authorsResourceParameters, ResourceUriType.PreviousPage), "previousPage", "GET"));
            }

            return links;
        }

        public List<LinkDto> CreateDocumentationLinksForAuthor(Guid id, string fields)
        {
            var links = new List<LinkDto>();
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(new LinkDto(urlHelper.Link("GetAuthor", new { id }), "self", "GET"));
            }
            else
            {
                links.Add(new LinkDto(urlHelper.Link("GetAuthor", new { id, fields }), "self", "GET"));
            }

            links.Add(new LinkDto(urlHelper.Link("DeleteAuthor", new { id }), "delete_author", "DELETE"));
            links.Add(new LinkDto(urlHelper.Link("CreateBookForAuthor", new { authorId = id }), "create_book_for_author", "POST"));
            links.Add(new LinkDto(urlHelper.Link("GetBooksForAuthor", new { authorId = id }), "books", "GET"));

            return links;
        }

        public PaginationMetadata GetPaginationMetadata(PagedList<Author> authors, AuthorsResourceParameters authorsResourceParameters)
        {
            PaginationMetadata paginationMetadata = new PaginationMetadata
            {
                PreviousPageLink = authors.HasPrevious ? CreateAuthorsResourceUri(authorsResourceParameters, ResourceUriType.PreviousPage) : null,
                NextPageLink = authors.HasNext ? CreateAuthorsResourceUri(authorsResourceParameters, ResourceUriType.NextPage) : null,
                TotalCount = authors.TotalCount,
                PageSize = authors.PageSize,
                CurrentPage = authors.CurrentPage,
                TotalPages = authors.TotalPages,
            };

            return paginationMetadata;
        }

        public IEnumerable<IDictionary<string, object>> CreateDocumentationLinksForAuthorShapeData(IEnumerable<ExpandoObject> shapedAuthors, AuthorsResourceParameters authorsResourceParameters)
        {
            var shapedAuthorsWithLinks = shapedAuthors.Select(author =>
            {
                var authorAsDictionary = author as IDictionary<string, object>;
                var authorLinks = CreateDocumentationLinksForAuthor((Guid)authorAsDictionary["AuthorId"], authorsResourceParameters.Fields);
                authorAsDictionary.Add("links", authorLinks);

                return authorAsDictionary;
            });

            return shapedAuthorsWithLinks;
        }
    }
}
