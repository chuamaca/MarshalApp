using MarshalApp.Net.Rest.Infrastructure.Data.Contexts;
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;
using MarshalApp.Net.Rest.Infrastructure.Data.Helpers;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly LibraryContext _context;
        private IStudentPropertyMappingService _studentPropertyMappingService;
        public StudentRepository(
            LibraryContext context,
            IStudentPropertyMappingService propertyMappingService
        )
        {
            _context = context;
            _studentPropertyMappingService = propertyMappingService;
        }
        public PagedList<Student> GetStudents(StudentsResourceParameters studentsResourceParameters)
        {

            var collectionBeforePaging = _context.Students.ApplySort(studentsResourceParameters.OrderBy, _studentPropertyMappingService.GetPropertyMapping());

            if (!string.IsNullOrEmpty(studentsResourceParameters.Genre))
            {

                var genreForWhereClause = studentsResourceParameters.Genre.Trim().ToLower();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.Collegecareer.ToLower() == genreForWhereClause);
            }

            if (!string.IsNullOrEmpty(studentsResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = studentsResourceParameters.SearchQuery.Trim().ToLower();

                collectionBeforePaging = collectionBeforePaging
                    .Where(a => a.Gender.ToLower().Contains(searchQueryForWhereClause)
                    || a.FirstName.ToLower().Contains(searchQueryForWhereClause)
                    || a.LastName.ToLower().Contains(searchQueryForWhereClause)
                    || a.Collegecareer.ToLower().Contains(searchQueryForWhereClause));
            }

            return PagedList<Student>.Create(collectionBeforePaging,
                studentsResourceParameters.PageNumber,
                studentsResourceParameters.PageSize);
        }
        public IEnumerable<Student> GetStudents(IEnumerable<Guid> studentIds)
        {
            return _context.Students.Where(a => studentIds.Contains(a.StudentId))
                .OrderBy(a => a.LastName)
                .OrderBy(a => a.Collegecareer)
                .ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
        }
        public void UpdateStudent(Student student)
        {
            var studentUpdate = GetStudent(student.StudentId);
            if (studentUpdate != null)
            {
                studentUpdate.FirstName = student.FirstName;
                studentUpdate.LastName = student.LastName;
                studentUpdate.Phone = student.Phone;
                studentUpdate.Birthdate = student.Birthdate;
                studentUpdate.Gender = student.Gender;
                studentUpdate.Collegecareer = student.Collegecareer;
            }
        }

        public Student GetStudent(Guid studentId)
        {
            return _context.Students.FirstOrDefault(a => a.StudentId == studentId);
        }

        public bool StudentExists(Guid studentId)
        {
            return _context.Students.Any(a => a.StudentId == studentId);
        }
    }
}
