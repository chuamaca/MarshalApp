using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.Books
{
    public class GetBookForAuthorResult
    {
        public BookDto LinkedResource { get; set; }
    }
}
