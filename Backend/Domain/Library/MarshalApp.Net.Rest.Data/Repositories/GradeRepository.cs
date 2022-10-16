using MarshalApp.Net.Rest.Infrastructure.Data.Contexts;
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly LibraryContext _context;
        public GradeRepository(

            LibraryContext context
        )
        {
            _context = context;
        }
        public void AddGradeForStudent(Guid gradeId, Grade grade)
        {
            grade.GradeId = gradeId;
            _context.Grades.Add(grade);
        }
        public void DeleteGrade(Grade grade)
        {
            _context.Grades.Remove(grade);
        }
        public void UpdateGradeForStudent(Grade grade)
        {
            Grade gradeUpdate = GetGradeForStudent(grade.StudentId, grade.GradeId);
            if (gradeUpdate != null)
            {
                gradeUpdate.Subject = grade.Subject;
                gradeUpdate.Qualification = grade.Qualification;
                gradeUpdate.Description = grade.Description;
                gradeUpdate.StartDate = grade.StartDate;
                gradeUpdate.Status = grade.Status;
            }
        }
        public IEnumerable<Grade> GetGradesForStudent(Guid studentId)
        {
            return _context.Grades.Where(b => b.StudentId == studentId).OrderBy(b => b.Subject).ToList();
        }
        public Grade GetGradeForStudent(Guid studentId, Guid gradeId)
        {
            return _context.Grades.Where(b => b.StudentId == studentId && b.GradeId == gradeId).FirstOrDefault();
        }
    }
}
