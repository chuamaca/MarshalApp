using MarshalApp.Net.Rest.API.Infrastructure.Results.AuthorCollections;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Authors;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Books;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Grades;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Root;
using MarshalApp.Net.Rest.API.Infrastructure.Results.StudentCollections;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Students;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarshalApp.Net.Rest.API.ApplicationServices
{
    public interface ILibraryApplicationService
    {
        bool AuthorExists(Guid authorId);
        CreateAuthorResult CreateAuthor(AuthorForCreationDto author);
        CreateAuthorCollectionResult CreateAuthorCollection(IEnumerable<AuthorForCreationDto> authorCollection);
        CreateAuthorWithDateOfDeathResult CreateAuthorWithDateOfDeath(AuthorForCreationWithDateOfDeathDto author);
        CreateBookForAuthorResult CreateBookForAuthor(Guid authorId, BookForCreationDto book);
        bool? DeleteAuthor(Guid authorId);
        UpdateAuthorResult UpdateAuthor(Guid authorId, AuthorForUpdateDto author);
        DeleteBookForAuthorResult DeleteBookForAuthor(Guid authorId, Guid bookId);
        GetAuthorResult GetAuthor(Guid authorId, string fields);
        GetAuthorCollectionResult GetAuthorCollection(IEnumerable<Guid> ids);
        GetAuthorsResult GetAuthors(AuthorsResourceParameters authorsResourceParameters);
        GetBookForAuthorResult GetBookForAuthor(Guid authorId, Guid bookId);
        GetBooksForAuthorResult GetBooksForAuthor(Guid authorId);
        GetRootResult GetRoot();
        PartiallyUpdateBookForAuthorResult PartiallyUpdateBookForAuthor(Guid authorId, Guid bookId, JsonPatchDocument<BookForUpdateDto> patchDoc, ControllerBase controller);
        UpdateBookForAuthorResult UpdateBookForAuthor(Guid authorId, Guid bookId, BookForUpdateDto book);

        bool StudentExists(Guid studentId);
        CreateStudentResult CreateStudent(StudentForCreationDto student);
        CreateStudentCollectionResult CreateStudentCollection(IEnumerable<StudentForCreationDto> studentCollection);
        CreateGradeForStudentResult CreateGradeForStudent(Guid studentId, GradeForCreationDto grade);
        bool? DeleteStudent(Guid studentId);
        UpdateStudentResult UpdateStudent(Guid studentId, StudentForUpdateDto student);
        DeleteGradeForStudentResult DeleteGradeForStudent(Guid studentId, Guid gradeId);
        GetStudentResult GetStudent(Guid studentId, string fields);
        GetStudentCollectionResult GetStudentCollection(IEnumerable<Guid> ids);
        GetStudentsResult GetStudents(StudentsResourceParameters studentsResourceParameters);
        GetGradeForStudentResult GetGradeForStudent(Guid studentId, Guid gradeId);
        GetGradesForStudentResult GetGradesForStudent(Guid studentId);
        PartiallyUpdateGradeForStudentResult PartiallyUpdateGradeForStudent(Guid studentId, Guid gradeId, JsonPatchDocument<GradeForUpdateDto> patchDoc, ControllerBase controller);
        UpdateGradeForStudentResult UpdateGradeForStudent(Guid studentId, Guid gradeId, GradeForUpdateDto grade);
    }
}