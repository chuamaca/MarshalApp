using MarshalApp.Net.Rest.Infrastructure.Data.Entities;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Repositories
{
    public interface IBookRepository
    {
        void AddBookForAuthor(Guid authorId, Book book);
        void DeleteBook(Book book);
        Book GetBookForAuthor(Guid authorId, Guid bookId);
        IEnumerable<Book> GetBooksForAuthor(Guid authorId);
        void UpdateBookForAuthor(Book book);
    }
}