using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.Paged;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        bool StudentExists(Guid studentId);
        void DeleteStudent(Student student);
        Student GetStudent(Guid studentId);
        PagedList<Student> GetStudents(StudentsResourceParameters studentsResourceParameters);
        IEnumerable<Student> GetStudents(IEnumerable<Guid> studentsIds);
        void UpdateStudent(Student student);

    }
}
