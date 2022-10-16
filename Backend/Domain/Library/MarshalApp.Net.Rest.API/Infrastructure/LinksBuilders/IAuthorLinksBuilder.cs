using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;
using System.Dynamic;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public interface IAuthorLinksBuilder
    {
        string CreateAuthorsResourceUri(AuthorsResourceParameters authorsResourceParameters, ResourceUriType type);
        List<LinkDto> CreateDocumentationLinksForAuthor(Guid id, string fields);
        IEnumerable<IDictionary<string, object>> CreateDocumentationLinksForAuthorShapeData(IEnumerable<ExpandoObject> shapedAuthors, AuthorsResourceParameters authorsResourceParameters);
        IEnumerable<LinkDto> CreatePagedLinksForAuthors(AuthorsResourceParameters authorsResourceParameters, bool hasNext, bool hasPrevious);
        PaginationMetadata GetPaginationMetadata(PagedList<Author> authors, AuthorsResourceParameters authorsResourceParameters);
    }
}