using MarshalApp.Net.Rest.Infrastructure.Data.Entities;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Repositories
{
    public interface IGradeRepository
    {

        void AddGradeForStudent(Guid gradeId, Grade grade);
        void DeleteGrade(Grade grade);
        void UpdateGradeForStudent(Grade grade);

        Grade GetGradeForStudent(Guid studentId, Guid gradeId);
        IEnumerable<Grade> GetGradesForStudent(Guid studentId);
    }
}
