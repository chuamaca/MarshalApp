using AutoMapper;
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders;
using MarshalApp.Net.Rest.API.Infrastructure.Results.AuthorCollections;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Authors;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Books;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Grades;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Root;
using MarshalApp.Net.Rest.API.Infrastructure.Results.StudentCollections;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Students;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers;
using MarshalApp.Net.Rest.Infrastructure.Data.UnitOfWork;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.LinksBuilder;
using MarshalApp.Net.Rest.API.Infrastructure.Results.Technicalreports;

namespace MarshalApp.Net.Rest.API.ApplicationServices
{
    public class LibraryApplicationService : ILibraryApplicationService
    {
        private readonly LibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthorLinksBuilder _authorLinksBuilder;
        private readonly IBookLinksBuilder _bookLinksBuilder;
        private readonly IRootLinksBuilder _rootLinksBuilder;
        private readonly IStudentLinksBuilder _studentLinksBuilder;
        private readonly IGradeLinksBuilder _gradeLinksBuilder;
        private readonly ITechnicalreportsLinksBuilder _technicalreportsLinksBuilder;

        public LibraryApplicationService(
            LibraryUnitOfWork unitOfWork,
            IMapper mapper,
            IAuthorLinksBuilder authorLinksBuilder,
            IBookLinksBuilder bookLinksBuilder,
            IStudentLinksBuilder studentLinksBuilder,
            IGradeLinksBuilder gradeLinksBuilder,
            ITechnicalreportsLinksBuilder technicalreportsLinksBuilder,
            IRootLinksBuilder rootLinksBuilder
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authorLinksBuilder = authorLinksBuilder;
            _bookLinksBuilder = bookLinksBuilder;
            _studentLinksBuilder = studentLinksBuilder;
            _gradeLinksBuilder = gradeLinksBuilder;
            _technicalreportsLinksBuilder = technicalreportsLinksBuilder;
            _rootLinksBuilder = rootLinksBuilder;
        }
        public GetAuthorsResult GetAuthors(AuthorsResourceParameters authorsResourceParameters)
        {
            GetAuthorsResult result = new GetAuthorsResult();
            var authorsFromRepo = _unitOfWork.Authors.GetAuthors(authorsResourceParameters);
            var authors = _mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);
            result.ShapedAuthors = authors.ShapeData(authorsResourceParameters.Fields);

            result.PaginationMetadata = _authorLinksBuilder.GetPaginationMetadata(authorsFromRepo, authorsResourceParameters);

            var links = _authorLinksBuilder.CreatePagedLinksForAuthors(authorsResourceParameters, authorsFromRepo.HasNext, authorsFromRepo.HasPrevious);
            var shapedAuthorsWithLinks = _authorLinksBuilder.CreateDocumentationLinksForAuthorShapeData(result.ShapedAuthors, authorsResourceParameters);

            result.LinkedCollectionResource = new LinkedCollectionResource
            {
                Value = shapedAuthorsWithLinks,
                Links = links
            };


            return result;
        }

        public GetAuthorResult GetAuthor(Guid authorId, string fields)
        {
            GetAuthorResult result = new GetAuthorResult();
            var authorFromRepo = _unitOfWork.Authors.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return null;
            }

            var author = _mapper.Map<AuthorDto>(authorFromRepo);
            var links = _authorLinksBuilder.CreateDocumentationLinksForAuthor(authorId, fields);

            result.LinkedResource = author.ShapeData(fields);

            result.LinkedResource.Add("links", links);

            return result;
        }

        public CreateAuthorResult CreateAuthor(AuthorForCreationDto author)
        {
            CreateAuthorResult result = new CreateAuthorResult();
            var authorEntity = _mapper.Map<Author>(author);

            _unitOfWork.Authors.AddAuthor(authorEntity);

            if (!_unitOfWork.Save())
            {
                throw new Exception("Creating an author failed on save.");
                // return StatusCode(500, "A problem happened with handling your request.");
            }

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

            var links = _authorLinksBuilder.CreateDocumentationLinksForAuthor(authorToReturn.AuthorId, null);

            result.LinkedResource = authorToReturn.ShapeData(null);

            result.LinkedResource.Add("links", links);

            return result;
        }

        public CreateAuthorWithDateOfDeathResult CreateAuthorWithDateOfDeath(AuthorForCreationWithDateOfDeathDto author)
        {
            CreateAuthorWithDateOfDeathResult result = new CreateAuthorWithDateOfDeathResult();
            var authorEntity = _mapper.Map<Author>(author);

            if (!_unitOfWork.Save())
            {
                throw new Exception("Creating an author failed on save");
                //return StatusCode(500, "A problem happened with handling your request");
            }

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

            var links = _authorLinksBuilder.CreateDocumentationLinksForAuthor(authorToReturn.AuthorId, null);

            result.LinkedResource = authorToReturn.ShapeData(null) as IDictionary<string, object>;

            result.LinkedResource.Add("links", links);

            return result;
        }

        public bool? DeleteAuthor(Guid authorId)
        {
            var authorFronRepo = _unitOfWork.Authors.GetAuthor(authorId);
            if (authorFronRepo == null)
            {
                return null;
            }

            _unitOfWork.Authors.DeleteAuthor(authorFronRepo);

            if (!_unitOfWork.Save())
            {
                throw new Exception($"Deleting author {authorId} failed on save.");
            }

            return true;
        }

        public UpdateAuthorResult UpdateAuthor(Guid authorId, AuthorForUpdateDto author)
        {
            UpdateAuthorResult result = new UpdateAuthorResult();
            var authorFromRepo = _unitOfWork.Authors.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                var authorToAdd = _mapper.Map<Author>(author);
                authorToAdd.AuthorId = authorId;

                _unitOfWork.Authors.AddAuthor(authorToAdd);

                if (!_unitOfWork.Save())
                {
                    throw new Exception($"Upserting author {authorId} failed on save.");
                }

                result.AuthorUpserted = _mapper.Map<AuthorDto>(authorToAdd);
                result.Success = true;

                return result;
            }

            _mapper.Map(author, authorFromRepo);
            _unitOfWork.Authors.UpdateAuthor(authorFromRepo);
            if (!_unitOfWork.Save())
            {
                throw new Exception($"Updating author {authorId} failed on save.");
            }

            result.Success = true;
            return result;
        }

        public bool AuthorExists(Guid authorId)
        {
            return _unitOfWork.Authors.AuthorExists(authorId);
        }

        public GetBooksForAuthorResult GetBooksForAuthor(Guid authorId)
        {
            GetBooksForAuthorResult result = new GetBooksForAuthorResult();
            var booksForAuthorFromRepo = _unitOfWork.Books.GetBooksForAuthor(authorId);
            var booksForAuthor = _mapper.Map<IEnumerable<BookDto>>(booksForAuthorFromRepo);

            booksForAuthor = booksForAuthor.Select(book =>
            {
                book = _bookLinksBuilder.CreateDocumentationLinksForBook(book);
                return book;
            });

            var wrapper = new LinkedCollectionResourceWrapperDto<BookDto>(booksForAuthor);
            result.LinkedCollectionResource = _bookLinksBuilder.CreateDocumentationLinksForBooks(wrapper);
            return result;
        }

        public GetBookForAuthorResult GetBookForAuthor(Guid authorId, Guid bookId)
        {
            GetBookForAuthorResult result = new GetBookForAuthorResult();
            var bookForAuthorFromRepo = _unitOfWork.Books.GetBookForAuthor(authorId, bookId);
            if (bookForAuthorFromRepo == null)
            {
                return null;
            }

            var bookForAuthor = _mapper.Map<BookDto>(bookForAuthorFromRepo);
            result.LinkedResource = _bookLinksBuilder.CreateDocumentationLinksForBook(bookForAuthor);

            return result;
        }

        public CreateBookForAuthorResult CreateBookForAuthor(Guid authorId, BookForCreationDto book)
        {
            CreateBookForAuthorResult result = new CreateBookForAuthorResult();
            var bookEntity = _mapper.Map<Book>(book);

            _unitOfWork.Books.AddBookForAuthor(authorId, bookEntity);

            if (!_unitOfWork.Save())
            {
                throw new Exception($"Creating a book for author {authorId} failed on save.");
            }

            var bookToReturn = _mapper.Map<BookDto>(bookEntity);

            result.LinkedResource = _bookLinksBuilder.CreateDocumentationLinksForBook(bookToReturn);

            return result;
        }

        public DeleteBookForAuthorResult DeleteBookForAuthor(Guid authorId, Guid bookId)
        {
            DeleteBookForAuthorResult result = new DeleteBookForAuthorResult();
            var bookForAuthorFromRepo = _unitOfWork.Books.GetBookForAuthor(authorId, bookId);
            if (bookForAuthorFromRepo == null)
            {
                return null;
            }

            _unitOfWork.Books.DeleteBook(bookForAuthorFromRepo);

            if (!_unitOfWork.Save())
            {
                throw new Exception($"Deleting book {bookId} for author {authorId} failed on save.");
            }

            result.Success = true;
            return result;
        }

        public UpdateBookForAuthorResult UpdateBookForAuthor(Guid authorId, Guid bookId, BookForUpdateDto book)
        {
            UpdateBookForAuthorResult result = new UpdateBookForAuthorResult();
            var bookForAuthorFromRepo = _unitOfWork.Books.GetBookForAuthor(authorId, bookId);

            if (bookForAuthorFromRepo == null)
            {
                var bookToAdd = _mapper.Map<Book>(book);
                bookToAdd.BookId = bookId;

                _unitOfWork.Books.AddBookForAuthor(authorId, bookToAdd);

                if (!_unitOfWork.Save())
                {
                    throw new Exception($"Upserting book {bookId} for author {authorId} failed on save.");
                }

                result.BookUpserted = _mapper.Map<BookDto>(bookToAdd);
                result.Success = true;

                return result;
            }

            _mapper.Map(book, bookForAuthorFromRepo);
            _unitOfWork.Books.UpdateBookForAuthor(bookForAuthorFromRepo);
            if (!_unitOfWork.Save())
            {
                throw new Exception($"Updating book {bookId} for author {authorId} failed on save.");
            }

            result.Success = true;
            return result;
        }

        public PartiallyUpdateBookForAuthorResult PartiallyUpdateBookForAuthor(Guid authorId, Guid bookId, JsonPatchDocument<BookForUpdateDto> patchDoc, ControllerBase controller)
        {
            PartiallyUpdateBookForAuthorResult result = new PartiallyUpdateBookForAuthorResult();
            var bookForAuthorFromRepo = _unitOfWork.Books.GetBookForAuthor(authorId, bookId);

            if (bookForAuthorFromRepo == null)
            {
                var bookDto = new BookForUpdateDto();
                patchDoc.ApplyTo(bookDto, controller.ModelState);

                if (bookDto.Description == bookDto.Title)
                {
                    controller.ModelState.AddModelError(nameof(BookForUpdateDto), "The provided description should be different from the title.");
                }

                controller.TryValidateModel(bookDto);

                if (!controller.ModelState.IsValid)
                {
                    result.Success = false;
                    return result;
                }

                var bookToAdd = _mapper.Map<Book>(bookDto);
                bookToAdd.BookId = bookId;

                _unitOfWork.Books.AddBookForAuthor(authorId, bookToAdd);

                if (!_unitOfWork.Save())
                {
                    result.Success = false;
                    throw new Exception($"Upserting book {bookId} for author {authorId} failed on save.");
                }

                result.BookUpserted = _mapper.Map<BookDto>(bookToAdd);
                result.Success = true;

                return result;
            }

            var bookToPatch = _mapper.Map<BookForUpdateDto>(bookForAuthorFromRepo);

            patchDoc.ApplyTo(bookToPatch, controller.ModelState);

            // patchDoc.ApplyTo(bookToPatch);

            if (bookToPatch.Description == bookToPatch.Title)
            {
                controller.ModelState.AddModelError(nameof(BookForUpdateDto), "The provided description should be different from the title.");
            }

            controller.TryValidateModel(bookToPatch);

            if (!controller.ModelState.IsValid)
            {
                result.Success = false;
                return result;
            }

            _mapper.Map(bookToPatch, bookForAuthorFromRepo);

            _unitOfWork.Books.UpdateBookForAuthor(bookForAuthorFromRepo);

            if (!_unitOfWork.Save())
            {
                result.Success = false;
                throw new Exception($"Patching book {bookId} for author {authorId} failed on save.");
            }

            result.Success = true;

            return result;
        }

        public CreateAuthorCollectionResult CreateAuthorCollection(IEnumerable<AuthorForCreationDto> authorCollection)
        {
            CreateAuthorCollectionResult result = new CreateAuthorCollectionResult();
            var authorEntities = _mapper.Map<IEnumerable<Author>>(authorCollection);

            foreach (var author in authorEntities)
            {
                _unitOfWork.Authors.AddAuthor(author);
            }

            if (!_unitOfWork.Save())
            {
                throw new Exception("Creating an author collection failed on save.");
            }

            result.AuthorCollection = _mapper.Map<IEnumerable<AuthorDto>>(authorEntities);
            result.IdsAsString = string.Join(",", result.AuthorCollection.Select(a => a.AuthorId));

            return result;
        }

        public GetAuthorCollectionResult GetAuthorCollection(IEnumerable<Guid> ids)
        {
            GetAuthorCollectionResult result = new GetAuthorCollectionResult();
            var authorEntities = _unitOfWork.Authors.GetAuthors(ids);

            if (ids.Count() != authorEntities.Count())
            {
                return result;
            }

            result.AuthorsFound = true;
            result.AuthorCollection = _mapper.Map<IEnumerable<AuthorDto>>(authorEntities);

            return result;
        }



        /////////
        public GetStudentsResult GetStudents(StudentsResourceParameters studentsResourceParameters)
        {
            GetStudentsResult result = new GetStudentsResult();
            var studentFromRepo = _unitOfWork.Students.GetStudents(studentsResourceParameters);
            var students = _mapper.Map<IEnumerable<StudentDto>>(studentFromRepo);
            result.ShapedStudents = students.ShapeData(studentsResourceParameters.Fields);

            result.PaginationMetadata = _studentLinksBuilder.GetPaginationMetadata(studentFromRepo, studentsResourceParameters);

            var links = _studentLinksBuilder.CreatePagedLinksForStudents(studentsResourceParameters, studentFromRepo.HasNext, studentFromRepo.HasPrevious);
            var shapedStudentsWithLinks = _studentLinksBuilder.CreateDocumentationLinksForStudentShapeData(result.ShapedStudents, studentsResourceParameters);

            result.LinkedCollectionResource = new LinkedCollectionResource
            {
                Value = shapedStudentsWithLinks,
                Links = links
            };


            return result;
        }

        public GetStudentResult GetStudent(Guid studentId, string fields)
        {
            GetStudentResult result = new GetStudentResult();
            var studentFromRepo = _unitOfWork.Students.GetStudent(studentId);

            if (studentFromRepo == null)
            {
                return null;
            }

            var student = _mapper.Map<StudentDto>(studentFromRepo);
            var links = _studentLinksBuilder.CreateDocumentationLinksForStudent(studentId, fields);

            result.LinkedResource = student.ShapeData(fields);

            result.LinkedResource.Add("links", links);

            return result;
        }

        public CreateStudentResult CreateStudent(StudentForCreationDto student)
        {
            CreateStudentResult result = new CreateStudentResult();
            var studentEntity = _mapper.Map<Student>(student);

            _unitOfWork.Students.AddStudent(studentEntity);

            if (!_unitOfWork.Save())
            {
                throw new Exception("Creating an author failed on save.");
                // return StatusCode(500, "A problem happened with handling your request.");
            }

            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);

            var links = _studentLinksBuilder.CreateDocumentationLinksForStudent(studentToReturn.StudentId, null);

            result.LinkedResource = studentToReturn.ShapeData(null);

            result.LinkedResource.Add("links", links);

            return result;
        }

        //public CreateEstudianteWithDateOfDeathResult CreateAuthorWithDateOfDeath(AuthorForCreationWithDateOfDeathDto author)
        //{
        //    CreateAuthorWithDateOfDeathResult result = new CreateAuthorWithDateOfDeathResult();
        //    var authorEntity = _mapper.Map<Author>(author);

        //    if (!_unitOfWork.Save())
        //    {
        //        throw new Exception("Creating an author failed on save");
        //        //return StatusCode(500, "A problem happened with handling your request");
        //    }

        //    var authorToReturn = _mapper.Map<EstudianteDto>(authorEntity);

        //    var links = _authorLinksBuilder.CreateDocumentationLinksForAuthor(authorToReturn.AuthorId, null);

        //    result.LinkedResource = authorToReturn.ShapeData(null) as IDictionary<string, object>;

        //    result.LinkedResource.Add("links", links);

        //    return result;
        //}

        public bool? DeleteStudent(Guid studentId)
        {
            var studentFronRepo = _unitOfWork.Students.GetStudent(studentId);
            if (studentFronRepo == null)
            {
                return null;
            }

            _unitOfWork.Students.DeleteStudent(studentFronRepo);

            if (!_unitOfWork.Save())
            {
                throw new Exception($"No se pudo eliminar el Estudiante {studentId} al guardar.");
            }

            return true;
        }

        public UpdateStudentResult UpdateStudent(Guid studentId, StudentForUpdateDto student)
        {
            UpdateStudentResult result = new UpdateStudentResult();
            var studentFromRepo = _unitOfWork.Students.GetStudent(studentId);

            if (studentFromRepo == null)
            {
                var studentToAdd = _mapper.Map<Student>(student);
                studentToAdd.StudentId = studentId;

                _unitOfWork.Students.AddStudent(studentToAdd);

                if (!_unitOfWork.Save())
                {
                    throw new Exception($"La inserción del Estudiante {studentId} falló al guardar.");
                }

                result.StudentUpserted = _mapper.Map<StudentDto>(studentToAdd);
                result.Success = true;

                return result;
            }

            _mapper.Map(student, studentFromRepo);
            _unitOfWork.Students.UpdateStudent(studentFromRepo);
            if (!_unitOfWork.Save())
            {
                throw new Exception($"La actualización del Estudiante {studentId} falló al guardar.");
            }

            result.Success = true;
            return result;
        }

        public bool StudentExists(Guid studentId)
        {
            return _unitOfWork.Students.StudentExists(studentId);
        }

        public GetGradesForStudentResult GetGradesForStudent(Guid studentId)
        {
            GetGradesForStudentResult result = new GetGradesForStudentResult();
            var gradesForStudentFromRepo = _unitOfWork.Grades.GetGradesForStudent(studentId);
            var gradesForStudent = _mapper.Map<IEnumerable<GradeDto>>(gradesForStudentFromRepo);

            gradesForStudent = gradesForStudent.Select(grade =>
            {
                grade = _gradeLinksBuilder.CreateDocumentationLinksForGrade(grade);
                return grade;
            }); ;

            var wrapper = new LinkedCollectionResourceWrapperDto<GradeDto>(gradesForStudent);
            result.LinkedCollectionResource = _gradeLinksBuilder.CreateDocumentationLinksForGrades(wrapper);
            return result;
        }

        public GetGradeForStudentResult GetGradeForStudent(Guid studentId, Guid gradeId)
        {
            GetGradeForStudentResult result = new GetGradeForStudentResult();
            var gradeForStudentFromRepo = _unitOfWork.Grades.GetGradeForStudent(studentId, gradeId);
            if (gradeForStudentFromRepo == null)
            {
                return null;
            }

            var gradeForStudent = _mapper.Map<GradeDto>(gradeForStudentFromRepo);
            result.LinkedResource = _gradeLinksBuilder.CreateDocumentationLinksForGrade(gradeForStudent);

            return result;
        }

        public CreateGradeForStudentResult CreateGradeForStudent(Guid studentId, GradeForCreationDto grade)
        {
            CreateGradeForStudentResult result = new CreateGradeForStudentResult();
            var gradeEntity = _mapper.Map<Grade>(grade);

            _unitOfWork.Grades.AddGradeForStudent(studentId, gradeEntity);

            if (!_unitOfWork.Save())
            {
                throw new Exception($"Creacion a Curso por Estudiante {studentId} Fallo Al Guardarse.");
            }

            var gradeToReturn = _mapper.Map<GradeDto>(gradeEntity);

            result.LinkedResource = _gradeLinksBuilder.CreateDocumentationLinksForGrade(gradeToReturn);

            return result;
        }

        public DeleteGradeForStudentResult DeleteGradeForStudent(Guid studentId, Guid gradeId)
        {
            DeleteGradeForStudentResult result = new DeleteGradeForStudentResult();
            var gradeForStudentFromRepo = _unitOfWork.Grades.GetGradeForStudent(studentId, gradeId);
            if (gradeForStudentFromRepo == null)
            {
                return null;
            }

            _unitOfWork.Grades.DeleteGrade(gradeForStudentFromRepo);

            if (!_unitOfWork.Save())
            {
                throw new Exception($"Eliminar Curso {gradeId} por estudiante {studentId} falla al guardar.");
            }

            result.Success = true;

            return result;
        }

        public UpdateGradeForStudentResult UpdateGradeForStudent(Guid studentId, Guid gradeId, GradeForUpdateDto grade)
        {
            UpdateGradeForStudentResult result = new UpdateGradeForStudentResult();
            var gradeForStudentFromRepo = _unitOfWork.Grades.GetGradeForStudent(studentId, gradeId);

            if (gradeForStudentFromRepo == null)
            {
                var gradeToAdd = _mapper.Map<Grade>(grade);
                gradeToAdd.GradeId = gradeId;

                _unitOfWork.Grades.AddGradeForStudent(studentId, gradeToAdd);

                if (!_unitOfWork.Save())
                {
                    throw new Exception($"Upserting Curso {gradeId} for Estudiante {studentId} failed on save.");
                }

                result.GradeUpserted = _mapper.Map<GradeDto>(gradeToAdd);
                result.Success = true;

                return result;
            }

            _mapper.Map(grade, gradeForStudentFromRepo);
            _unitOfWork.Grades.UpdateGradeForStudent(gradeForStudentFromRepo);
            if (!_unitOfWork.Save())
            {
                throw new Exception($"Updating Curso {gradeId} for Estudiante {studentId} failed on save.");
            }

            result.Success = true;
            return result;
        }

        public PartiallyUpdateGradeForStudentResult PartiallyUpdateGradeForStudent(Guid studentId, Guid gradeId, JsonPatchDocument<GradeForUpdateDto> patchDoc, ControllerBase controller)
        {
            PartiallyUpdateGradeForStudentResult result = new PartiallyUpdateGradeForStudentResult();
            var gradeForStudentFromRepo = _unitOfWork.Grades.GetGradeForStudent(studentId, gradeId);

            if (gradeForStudentFromRepo == null)
            {
                var gradeDto = new GradeForUpdateDto();
                patchDoc.ApplyTo(gradeDto, controller.ModelState);

                if (gradeDto.Subject == gradeDto.Description)
                {
                    controller.ModelState.AddModelError(nameof(GradeForUpdateDto), "The provided description should be different from the title.");
                }

                controller.TryValidateModel(gradeDto);

                if (!controller.ModelState.IsValid)
                {
                    result.Success = false;
                    return result;
                }

                var gradeToAdd = _mapper.Map<Grade>(gradeDto);
                gradeToAdd.GradeId = gradeId;

                _unitOfWork.Grades.AddGradeForStudent(studentId, gradeToAdd);

                if (!_unitOfWork.Save())
                {
                    result.Success = false;
                    throw new Exception($"Upserting curso {gradeId} for estudiante {studentId} failed on save.");
                }

                result.GradeUpserted = _mapper.Map<GradeDto>(gradeToAdd);
                result.Success = true;

                return result;
            }

            var gradeToPatch = _mapper.Map<GradeForUpdateDto>(gradeForStudentFromRepo);

            patchDoc.ApplyTo(gradeToPatch, controller.ModelState);

            // patchDoc.ApplyTo(bookToPatch);

            if (gradeToPatch.Subject == gradeToPatch.Description)
            {
                controller.ModelState.AddModelError(nameof(GradeForUpdateDto), "The provided description should be different from the title.");
            }

            controller.TryValidateModel(gradeToPatch);

            if (!controller.ModelState.IsValid)
            {
                result.Success = false;
                return result;
            }

            _mapper.Map(gradeToPatch, gradeForStudentFromRepo);

            _unitOfWork.Grades.UpdateGradeForStudent(gradeForStudentFromRepo);

            if (!_unitOfWork.Save())
            {
                result.Success = false;
                throw new Exception($"Patching Curso {gradeId} for Estudiante {studentId} failed on save.");
            }

            result.Success = true;

            return result;
        }

        public CreateStudentCollectionResult CreateStudentCollection(IEnumerable<StudentForCreationDto> studentCollection)
        {
            CreateStudentCollectionResult result = new CreateStudentCollectionResult();
            var studentEntities = _mapper.Map<IEnumerable<Student>>(studentCollection);

            foreach (var estudiante in studentEntities)
            {
                _unitOfWork.Students.AddStudent(estudiante);
            }

            if (!_unitOfWork.Save())
            {
                throw new Exception("La creación de una colección de autor falló al guardar..");
            }

            result.StudentCollection = _mapper.Map<IEnumerable<StudentDto>>(studentEntities);
            result.IdsAsString = string.Join(",", result.StudentCollection.Select(a => a.StudentId));

            return result;
        }

        public GetStudentCollectionResult GetStudentCollection(IEnumerable<Guid> ids)
        {
            GetStudentCollectionResult result = new GetStudentCollectionResult();
            var studentEntities = _unitOfWork.Students.GetStudents(ids);

            if (ids.Count() != studentEntities.Count())
            {
                return result;
            }

            result.StudentsFound = true;
            result.StudentCollection = _mapper.Map<IEnumerable<StudentDto>>(studentEntities);

            return result;
        }

        public GetRootResult GetRoot()
        {
            GetRootResult result = new GetRootResult();
            result.LinkedResources = _rootLinksBuilder.CreateDocumentationLinksForRoot();

            return result;
        }

        public CreateTechnicalreportsResult CreateTechnicalreports(InfohdrForCreationDto infohdr)
        {
            CreateTechnicalreportsResult result = new CreateTechnicalreportsResult();

            var infohdrEntity = _mapper.Map<InfoHdr>(infohdr);

            _unitOfWork.Infohdrs.AddInfohdr(infohdrEntity);

            if (!_unitOfWork.Save())
            {
                throw new Exception("Creating an author failed on save.");
                // return StatusCode(500, "A problem happened with handling your request.");
            }

            var infohdrToReturn = _mapper.Map<InfohdrDto>(infohdrEntity);

            var links = _technicalreportsLinksBuilder.CreateDocumentationLinksForTechnicalreports(infohdrToReturn.Idinfohdr, null);

            result.LinkedResource = infohdrToReturn.ShapeData(null);

            result.LinkedResource.Add("links", links);

            return result;
        }
    }
}
