using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.Authors
{
    public class UpdateAuthorResult
    {
        public AuthorDto AuthorUpserted { get; set; }
        public bool Success { get; set; }
    }
}
