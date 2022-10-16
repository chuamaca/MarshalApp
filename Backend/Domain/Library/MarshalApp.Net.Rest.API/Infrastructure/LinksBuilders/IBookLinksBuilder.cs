using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public interface IBookLinksBuilder
    {
        BookDto CreateDocumentationLinksForBook(BookDto book);
        LinkedCollectionResourceWrapperDto<BookDto> CreateDocumentationLinksForBooks(LinkedCollectionResourceWrapperDto<BookDto> booksWrapper);
    }
}