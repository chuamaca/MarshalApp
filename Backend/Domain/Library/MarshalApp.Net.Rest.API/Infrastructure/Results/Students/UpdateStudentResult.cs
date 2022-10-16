using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Dtos;

namespace MarshalApp.Net.Rest.API.Infrastructure.Results.Students
{
    public class UpdateStudentResult
    {
        public StudentDto StudentUpserted { get; set; }
        public bool Success { get; set; }
    }
}
