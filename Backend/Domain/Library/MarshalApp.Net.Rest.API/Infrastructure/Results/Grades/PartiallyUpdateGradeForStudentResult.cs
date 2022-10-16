using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.Grades
{
    public class PartiallyUpdateGradeForStudentResult
    {
        public GradeDto GradeUpserted { get; set; }
        public bool Success { get; set; }
    }
}
