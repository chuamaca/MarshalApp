using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.AuthorCollections
{
    public class GetAuthorCollectionResult
    {
        public IEnumerable<AuthorDto> AuthorCollection { get; set; }
        public bool AuthorsFound { get; set; }
    }
}
