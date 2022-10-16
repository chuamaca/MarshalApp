using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.Books
{
    public class GetBooksForAuthorResult
    {
        public LinkedCollectionResourceWrapperDto<BookDto> LinkedCollectionResource { get; set; }
    }
}
