using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders
{
    public class BookLinksBuilder : IBookLinksBuilder
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;

        public BookLinksBuilder(
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor
        )
        {
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
        }
        public BookDto CreateDocumentationLinksForBook(BookDto book)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            book.Links.Add(new LinkDto(urlHelper.Link("GetBookForAuthor", new { authorId = book.AuthorId, id = book.BookId }), "self", "GET"));
            book.Links.Add(new LinkDto(urlHelper.Link("DeleteBookForAuthor", new { authorId = book.AuthorId, id = book.BookId }), "delete_book", "DELETE"));
            book.Links.Add(new LinkDto(urlHelper.Link("UpdateBookForAuthor", new { authorId = book.AuthorId, id = book.BookId }), "update_book", "PUT"));
            book.Links.Add(new LinkDto(urlHelper.Link("PartiallyUpdateBookForAuthor", new { authorId = book.AuthorId, id = book.BookId }), "partially_update_book", "PATCH"));

            return book;
        }

        public LinkedCollectionResourceWrapperDto<BookDto> CreateDocumentationLinksForBooks(LinkedCollectionResourceWrapperDto<BookDto> booksWrapper)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            booksWrapper.Links.Add(new LinkDto(urlHelper.Link("GetBooksForAuthor", new { }), "self", "GET"));

            return booksWrapper;
        }
    }
}
