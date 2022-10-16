using MarshalApp.Net.Rest.Infrastructure.Data.Contexts;
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(
            LibraryContext context
        )
        {
            _context = context;
        }
        public void AddBookForAuthor(Guid authorId, Book book)
        {
            book.AuthorId = authorId;
            _context.Books.Add(book);
        }
        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
        }
        public void UpdateBookForAuthor(Book book)
        {
            Book bookUpdate = GetBookForAuthor(book.AuthorId, book.BookId);
            if (bookUpdate != null)
            {
                bookUpdate.Title = book.Title;
                bookUpdate.Description = book.Description;
            }
        }
        public IEnumerable<Book> GetBooksForAuthor(Guid authorId)
        {
            return _context.Books.Where(b => b.AuthorId == authorId).OrderBy(b => b.Title).ToList();
        }
        public Book GetBookForAuthor(Guid authorId, Guid bookId)
        {
            return _context.Books.Where(b => b.AuthorId == authorId && b.BookId == bookId).FirstOrDefault();
        }
    }
}
