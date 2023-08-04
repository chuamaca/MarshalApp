using MarshalApp.Net.Rest.Infrastructure.Data.Contexts;
using MarshalApp.Net.Rest.Infrastructure.Data.Repositories;

namespace MarshalApp.Net.Rest.Infrastructure.Data.UnitOfWork
{
    public class LibraryUnitOfWork : UnitOfWork
    {
        public IAuthorRepository Authors { get; }
        public IBookRepository Books { get; }
        public IStudentRepository Students { get; }
        public IGradeRepository Grades { get; }
        //
        public IInfohdrRepository Infohdrs { get; }
        public LibraryContext _context { get; }

        public LibraryUnitOfWork(
            LibraryContext context,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            IStudentRepository studentRepository,
            IGradeRepository gradeRepository,
            IInfohdrRepository infohdrRepository
        ) : base(context)
        {
            _context = context;
            Authors = authorRepository;
            Books = bookRepository;
            Students = studentRepository;
            Grades = gradeRepository;
            Infohdrs = infohdrRepository;
        }
    }
}
