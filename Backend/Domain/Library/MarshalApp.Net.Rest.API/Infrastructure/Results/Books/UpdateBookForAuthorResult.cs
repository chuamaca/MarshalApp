using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.Books
{
    public class UpdateBookForAuthorResult
    {
        public BookDto BookUpserted { get; set; }
        public bool Success { get; set; }
    }
}
