using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.AuthorCollections
{
    public class CreateAuthorCollectionResult
    {
        public IEnumerable<AuthorDto> AuthorCollection { get; set; }
        public string IdsAsString { get; set; }
    }
}
